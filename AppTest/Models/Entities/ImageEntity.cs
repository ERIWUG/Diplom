using System.Net;

namespace AppTest.Models.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string src { get; set; } = string.Empty;
        
        public int? AnswerId { get; set; }
        public int? TicketId { get; set; }
        public virtual AnswerEntity? Answer { get; set; }
        public virtual TicketEntity? Ticket { get; set; }

        public virtual List<CommentEntity> Comments { get; set; } = [];
        public virtual List<PostEntity> Posts { get; set; } = [];
    }
}
