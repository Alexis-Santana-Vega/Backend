﻿using CE.Chepeat.Domain.Aggregates.Comments;
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
                new SqlParameter("IdUser", commentAggregate.IdUser),
                new SqlParameter("IdSeller", commentAggregate.IdSeller),
                new SqlParameter("IdTransaction", commentAggregate.IdTransaction),
                new SqlParameter("Message", commentAggregate.Message),
                new SqlParameter("Rating", commentAggregate.Rating),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_Comments_Add @IdUser, @IdSeller, @IdTransaction, @Message, @Rating, @NumError OUTPUT, @Result OUTPUT";
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
                new SqlParameter("CommentId", updateMessage.CommentId),
                new SqlParameter("IdUser", updateMessage.IdUser),
                new SqlParameter("NewMessage", updateMessage.NewMessage),
                new SqlParameter("NewRating", updateMessage.NewRating),
                NumError,
                Result
            };

                string sqlQuery = "EXEC dbo.SP_Comments_Edit @CommentId, @IdUser, @NewMessage, @NewRating, @NumError OUTPUT, @Result OUTPUT";
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