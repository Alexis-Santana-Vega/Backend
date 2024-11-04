using CE.Chepeat.Domain.Aggregates.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Interfaces.Infraestructure
{
    public interface ICommentInfraestructure
    {
        Task<RespuestaDB> AddComment(CommentAggregate commentAggregate);
        Task<RespuestaDB> UpdateCommentMessage(UpdateCommentMessageAggregate updateMessage);
        Task<RespuestaDB> UpdateCommentRating(UpdateCommentRatingAggregate updateRating);
    }
}
