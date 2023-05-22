using EVideoPrime.API.Abstractions.Models.Identity;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.Identity
{
    public interface IUserServices
    {
        Task<UserModel> CreateUser(UserModel user, IEnumerable<int> roleIds);
        Task<IEnumerable<UserModel>> SearchUserAsync(UserModel model);
        Task<bool> ValidateUser(string username, string password);
    }
}