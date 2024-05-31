namespace AppTest.Models.Entities
{
    public class CommentEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = String.Empty;
        public DateTime Time { get; set; }
        public virtual required UserEntity User { get; set; }
        public int UserID { get; set; }
        public virtual PostEntity? Post { get; set; }
        public virtual TestEntity? Test { get; set; }
        public virtual List<ImageEntity> Images { get; set; } = [];
        public virtual List<ReportEntity> Reports { get; set; } = [];

    }
}
