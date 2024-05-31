using System.Runtime.CompilerServices;

namespace AppTest.Models.Entities
{
    public class RoleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public virtual List<UserEntity> Users { get; set; } = [];
    }
}
