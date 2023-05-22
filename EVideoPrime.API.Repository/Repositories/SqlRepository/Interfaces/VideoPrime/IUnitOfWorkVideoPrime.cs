using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime
{
    public interface IUnitOfWorkVideoPrime : IDisposable
    {
        public IMovieRepository MovieRepository { get; }
        public ISubscriptionRepository SubsRepository { get; }
        public IPaymentRepository PaymentRepository { get; }
        public IRepository<Category> CategoryRepository { get; }
        public IRepository<Plan> PlanRepository { get; }
        public IRepository<Language> LanguageRepository { get; }

        Task<int> CompleteChanges();
    }
}
