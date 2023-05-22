using System.ComponentModel.DataAnnotations;

namespace EVideoPrime.API.Entities.Identity
{
    public partial class User
    {
        public User()
        {
            Roles = new HashSet<Role>();
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
