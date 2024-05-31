using Microsoft.EntityFrameworkCore;
namespace AppTest.Models.Entities
{
    [Index(nameof(Login), IsUnique = true)]
    public class UserEntity
    {
        public string Login {  get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; } = string.Empty;
        public int Id {  get; set; }
        public string Password {  get; set; } = string.Empty;
        public int? Age { get; set; } = 0;
        public string? Town { get; set; } = string.Empty;
        public string? Country { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Surname { get; set; } = string.Empty;
        public bool IsVerified { get; set; } = false;
        public virtual List<RoleEntity> Roles { get; set; } = [];
        public virtual List<TestEntity> Tests { get; set; } = [];
        public virtual List<TestResultEntity> Results { get; set; } = [];
        public virtual UserPageEntity Page { get; set; }
        public virtual List<CommentEntity> Comments { get; set; } = [];
        public virtual List<UserEntity>? Friends { get;set ; } = [];
    }
}
