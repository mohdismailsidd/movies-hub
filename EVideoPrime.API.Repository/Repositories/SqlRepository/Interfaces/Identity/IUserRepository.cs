using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.Identity
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserModel> CreateUser(UserModel user, IEnumerable<int> roleIds);
        Task<UserModel> ValidateUser(string username, string password);
    }
}
