using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;
using EVideoPrime.API.Repository.Services;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Movies.API.DAL;

namespace EVideoPrime.API.Repository.SqlRepository.Services.VideoPrime
{
    public class UnitOfWorkVideoPrime : IUnitOfWorkVideoPrime
    {
        private readonly SqlDbContext _sqlDbContext;

        public IMovieRepository MovieRepository { get; init; }
        public ISubscriptionRepository SubsRepository { get; init; }
        public IPaymentRepository PaymentRepository { get; init; }
        public IRepository<Category> CategoryRepository { get; init; }
        public IRepository<Plan> PlanRepository { get; init; }
        public IRepository<Language> LanguageRepository { get; init; }

        public UnitOfWorkVideoPrime(SqlDbContext sqlDbContext)
        {
            _sqlDbContext = sqlDbContext;
            MovieRepository = new MovieRepository(sqlDbContext);
            SubsRepository = new SubscriptionRepository(sqlDbContext);
            PaymentRepository = new PaymentRepository(sqlDbContext);
            CategoryRepository = new Repository<Category>(sqlDbContext);
            PlanRepository = new Repository<Plan>(sqlDbContext);
            LanguageRepository = new Repository<Language>(sqlDbContext);
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
