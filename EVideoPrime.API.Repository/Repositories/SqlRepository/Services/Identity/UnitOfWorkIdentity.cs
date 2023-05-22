using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Repository.Interfaces;
using EVideoPrime.API.Repository.Services;
using EVideoPrime.API.Repository.SqlRepository.Interface.Identity;
using Movies.API.DAL;

namespace EVideoPrime.API.Repository.SqlRepository.Services.Identity
{
    public class UnitOfWorkIdentity : IUnitOfWorkIdentity
    {
        private readonly SqlDbContext _sqlDbContext;

        public IUserRepository UserRepository { get; init; }

        public IRepository<Role> RoleRepository { get; init; }

        public UnitOfWorkIdentity(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
            UserRepository = new UserRepository(sqlDbContext);
            RoleRepository = new Repository<Role>(sqlDbContext);
        }

        public async Task<int> CompleteChanges()
        {
            return await _sqlDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            if (_sqlDbContext != null)
                _sqlDbContext.Dispose();
        }
    }
}
