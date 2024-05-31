namespace AppTest.Models.Entities
{
    public class AnswerEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = String.Empty;
        //is used to specify id of Answers
        public int Value { get; set; } = 0;

        public int AnswerType { get; set; } = 1;
        public bool isRequired { get; set; } = false;

        public bool isDigit { get; set; } = false;

        public string SelectOptions { get; set; } = String.Empty;

        public virtual ImageEntity? Image { get; set; }
        public virtual TicketEntity? Ticket { get; set; }

        public virtual List<TestResultEntity>? Results { get; set; }

    }
}
