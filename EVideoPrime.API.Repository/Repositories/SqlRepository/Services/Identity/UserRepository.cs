using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.Services;
using Microsoft.EntityFrameworkCore;
using Movies.API.DAL;
using BC = BCrypt.Net.BCrypt;
namespace EVideoPrime.API.Repository.SqlRepository.Interface.Identity
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        SqlDbContext Context { get { return _dBContext as SqlDbContext; } }

        public UserRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<UserModel> CreateUser(UserModel user, IEnumerable<int> roleIds)
        {
            var hashPassword = BC.HashPassword(user.Password);
            var role = Context.Roles.Where(x => roleIds.Where(r => r == x.Id).Any()).ToList();
            user.Roles = role.Select(l => new RoleModel
            {
                Id = l.Id,
                Name = l.Name
            }).ToList();

            var result = await this.AddAsync(new User
            {
                Name = user.Name,
                Username = user.Username,
                Email = user.Email,
                Password = hashPassword,
                Roles = user.Roles.Select(l => new Role
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList()
            });
            user.Id = result.Id;
            return user;
        }

        public async Task<UserModel> ValidateUser(string username, string password)
        {
            var result = await Context.Users.Where(x => x.Username == username && BC.Verify(password, x.Password)).FirstOrDefaultAsync();
            return new UserModel
            {
                Name = result.Name,
                Username = result.Username,
                Email = result.Email,
                Password = password,
                Roles = result.Roles.Select(l => new RoleModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Id = result.Id
            };
        }
    }
}
