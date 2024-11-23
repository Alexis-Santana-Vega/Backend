using CE.Chepeat.Domain.Aggregates.Comments;
using CE.Chepeat.Domain.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Infraestructure.Repositories
{
    public class CommentInfraestructure : ICommentInfraestructure
    {
        private readonly ChepeatContext _context;

        public CommentInfraestructure(ChepeatContext context)
        {
            _context = context;
        }

        public async Task<CommentDto> GetCommentById(Guid id)
        {
            try
            {
                var comment = await _context.commentDto.Where(c => c.Id == id).ToListAsync();
                return comment.FirstOrDefault();
            } catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> AddComment(CommentAggregate commentAggregate)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("IdTransaction", commentAggregate.IdTransaction),
                new SqlParameter("Message", commentAggregate.Message),
                new SqlParameter("Rating", commentAggregate.Rating),
                new SqlParameter("CreatedAt", DateTime.UtcNow),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_Comments_Add @IdTransaction, @Message, @Rating, @CreatedAt, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> UpdateCommentMessage(UpdateCommentMessageAggregate updateMessage)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("Id", updateMessage.Id),
                new SqlParameter("NewMessage", updateMessage.NewMessage),
                new SqlParameter("NewRating", updateMessage.NewRating),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_Comments_Edit @Id, @NewMessage, @NewRating, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }

        public async Task<RespuestaDB> UpdateCommentRating(UpdateCommentRatingAggregate updateRating)
        {
            try
            {
                var NumError = new SqlParameter
                {
                    ParameterName = "NumError",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                var Result = new SqlParameter
                {
                    ParameterName = "Result",
                    SqlDbType = SqlDbType.VarChar,
                    Size = 100,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                new SqlParameter("CommentId", updateRating.CommentId),
                new SqlParameter("IdUser", updateRating.IdUser),
                new SqlParameter("NewRating", updateRating.NewRating),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_Comments_UpdateRating @CommentId, @IdUser, @NewRating, @NumError OUTPUT, @Result OUTPUT";
                var dataSP = await _context.respuestaDB.FromSqlRaw(sqlQuery, parameters).ToListAsync();
                return dataSP.FirstOrDefault();
            }
            catch (SqlException ex)
            {
                throw;
            }
        }
    }
}