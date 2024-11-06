using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.Aggregates.Comments
{
    public class CommentAggregate
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdSeller { get; set; }
        public Guid IdTransaction { get; set; }
        public string Message { get; set; }
        public decimal Rating { get; set; }
    }

    public class UpdateCommentMessageAggregate
    {
        public Guid CommentId { get; set; }
        public Guid IdUser { get; set; }
        public string NewMessage { get; set; }
        public decimal NewRating { get; set; }
    }

    public class UpdateCommentRatingAggregate
    {
        public Guid CommentId { get; set; }
        public Guid IdUser { get; set; }
        public decimal NewRating { get; set; }
    }
}