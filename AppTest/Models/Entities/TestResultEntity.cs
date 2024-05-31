namespace AppTest.Models.Entities
{
    public class TestResultEntity
    {
        public int Id { get; set; }
        public virtual TestEntity? Test { get; set; }
        public virtual UserEntity? User { get; set; }

        public virtual List<AnswerEntity>? Answers { get; set; } = [];

        public int ResultInt { get; set; } = 0;
        public string ResultString { get; set; } = string.Empty;
    }
}