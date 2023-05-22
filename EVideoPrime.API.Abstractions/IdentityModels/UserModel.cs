using EVideoPrime.API.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Abstractions.Models.Identity
{
    public partial class UserModel
    {
        public UserModel()
        {
            Roles = new List<RoleModel>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public virtual IEnumerable<RoleModel> Roles { get; set; }
    }
}
