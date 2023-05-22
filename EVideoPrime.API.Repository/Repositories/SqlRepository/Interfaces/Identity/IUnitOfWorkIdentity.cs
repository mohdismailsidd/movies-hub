using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.Interfaces;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.Identity
{
    public interface IUnitOfWorkIdentity : IDisposable
    {
        public IUserRepository UserRepository { get; }
        public IRepository<Role> RoleRepository { get; }

        Task<int> CompleteChanges();
    }
}
