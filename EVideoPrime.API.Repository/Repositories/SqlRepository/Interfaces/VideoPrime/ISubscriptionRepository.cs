using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;

namespace EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByPlanAsync(string plan);
    }
}
