using System.ComponentModel.DataAnnotations;

namespace AppTest.Models.Entities
{
    public class UserPageEntity
    {
        public virtual required UserEntity User { get; set; }
        public int UserId {  get; set; }
        public int Id { get; set; } 

        public bool isAuthorized { get; set; } = false;

        public virtual List<PostEntity> Posts { get; set; } = [];
    }
}
