using CE.Chepeat.Domain.Aggregates.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Application.Presenters
{
    public class CommentPresenter : ICommentPresenter
    {
        private readonly IUnitRepository _unitRepository;
        private readonly IMapper _mapper;

        public CommentPresenter(IUnitRepository unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Agrega un nuevo comentario
        /// </summary>
        public async Task<RespuestaDB> AddComment(CommentAggregate commentAggregate)
        {
            return await _unitRepository.commentInfraestructure.AddComment(commentAggregate);
        }

        /// <summary>
        /// Actualiza el mensaje de un comentario existente
        /// </summary>
        public async Task<RespuestaDB> UpdateCommentMessage(UpdateCommentMessageAggregate updateMessage)
        {
            return await _unitRepository.commentInfraestructure.UpdateCommentMessage(updateMessage);
        }

        /// <summary>
        /// Actualiza el rating de un comentario existente
        /// </summary>
        public async Task<RespuestaDB> UpdateCommentRating(UpdateCommentRatingAggregate updateRating)
        {
            return await _unitRepository.commentInfraestructure.UpdateCommentRating(updateRating);
        }
    }
}
