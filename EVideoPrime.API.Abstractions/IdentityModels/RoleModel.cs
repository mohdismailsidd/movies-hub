using System.ComponentModel.DataAnnotations;

namespace EVideoPrime.API.Abstractions.Models.Identity
{
    public class RoleModel
    {
        public RoleModel()
        {
            Users = new List<UserModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<UserModel> Users { get; set; }
    }
}
