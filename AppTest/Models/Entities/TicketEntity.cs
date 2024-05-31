namespace AppTest.Models.Entities
{
    public class TicketEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public int CorrectAnswer { get; set; }
        public virtual List<AnswerEntity> Answers { get; set; } = [];
        public virtual ImageEntity? Image { get; set; }
        public virtual TestEntity? Test { get; set; }
        
    }
}
