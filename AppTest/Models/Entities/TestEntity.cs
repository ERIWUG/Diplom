namespace AppTest.Models.Entities
{
    public class TestEntity
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Name { get; set; } = String.Empty;
        public decimal Rating { get; set; } = decimal.Zero;
        public bool IsAuthorized { get; set; } = false;
        public bool isClosed { get; set; } = false;
        public int? MaxAge { get; set; } = null;
        public int? MinAge { get; set; } = null;
        public string? CountryRequirement { get; set; } = null;
        public string? TownRequirement { get; set; } = null;
        public DateTime CreatingDate { get; set; } = DateTime.Now;
        public bool isRequiredAuthorization {  get; set; } = false;
        public virtual List<TicketEntity> TestContents { get; set; } = [];
        public virtual List<TestResultEntity> TestResults { get; set; } = [];
        public virtual required UserEntity Author { get; set; }
        public virtual List<CommentEntity> Comments { get; set; } = [];
        public virtual List<ReportEntity> Reports { get; set; } = [];

    }
}
