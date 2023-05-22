using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface ISubscriptionServices
    {
        Task<SubscriptionModel> AddSubscriptionAsync(SubscriptionModel subscriptionModel);
        Task<IEnumerable<SubscriptionModel>> GetAllSubscriptionsAsync();
        Task<SubscriptionModel> GetSubscriptionAsync(int id);
        Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByPlanAsync(string plan);
    }
}