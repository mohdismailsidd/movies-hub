using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.BusinessAccessLayer.Interface.Identity;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.SqlRepository.Interface.Identity;

namespace EVideoPrime.API.BusinessAccessLayer.Services.Identity
{
    public class UserServices : IUserServices
    {
        private readonly IUnitOfWorkIdentity _unitOfWorkIdentity;

        public UserServices(IUnitOfWorkIdentity unitOfWorkIdentity)
        {
            _unitOfWorkIdentity = unitOfWorkIdentity;
        }

        public async Task<IEnumerable<UserModel>> SearchUserAsync(UserModel model)
        {
            List<User> user = new List<User>();
            if (!string.IsNullOrWhiteSpace(model.Username))
                user = (await _unitOfWorkIdentity.UserRepository.FindAsync(u => u.Username.Equals(model.Username, StringComparison.InvariantCultureIgnoreCase)))!.ToList();

            else if (!string.IsNullOrWhiteSpace(model.Name) && !string.IsNullOrWhiteSpace(model.Email))
                user = (await _unitOfWorkIdentity.UserRepository.FindAsync(u => u.Name.Equals(model.Name ?? "", StringComparison.InvariantCultureIgnoreCase)
                            && u.Email.Equals(model.Email ?? "", StringComparison.InvariantCultureIgnoreCase)))!.ToList();

            else if (!string.IsNullOrWhiteSpace(model.Name) || !string.IsNullOrWhiteSpace(model.Email))
                user = (await _unitOfWorkIdentity.UserRepository.FindAsync(u => u.Name.Equals(model.Name ?? "", StringComparison.InvariantCultureIgnoreCase)
                || u.Email.Equals(model.Email ?? "", StringComparison.InvariantCultureIgnoreCase)))!.ToList();

            return user.Select(u => new UserModel
            {
                Name = u.Name,
                Username = u.Username,
                Email = u.Email,
                Roles = u.Roles.Select(l => new RoleModel
                {
                    Id = l.Id,
                    Name = l.Name
                }).ToList(),
                Id = u.Id
            });
        }

        public async Task<UserModel> CreateUser(UserModel user, IEnumerable<int> roleIds)
        => await _unitOfWorkIdentity.UserRepository.CreateUser(user, roleIds);

        public async Task<bool> ValidateUser(string username, string password)
        => await _unitOfWorkIdentity.UserRepository.ValidateUser(username, password) != null ? true : false;
    }
}
