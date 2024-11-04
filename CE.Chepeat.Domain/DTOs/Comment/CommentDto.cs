using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CE.Chepeat.Domain.DTOs.Comment
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public Guid IdUser { get; set; }
        public Guid IdSeller { get; set; }
        public Guid IdTransaction { get; set; }
        public string Message { get; set; }
        public decimal Rating { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
