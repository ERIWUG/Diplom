namespace AppTest.Models.Entities
{
    public class ReportEntity
    {
        public int Id { get; set; }

        public virtual PostEntity? Post { get; set; }
        public virtual TestEntity? Test { get; set; }
        public virtual CommentEntity? Comment {  get; set; } 
    }
}
