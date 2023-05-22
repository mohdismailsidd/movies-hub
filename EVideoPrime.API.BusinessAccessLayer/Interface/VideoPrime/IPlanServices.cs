using EVideoPrime.API.Abstractions.Models.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime
{
    public interface IPlanServices
    {
        Task<PlanModel> AddPlanAsync(PlanModel model);
        Task AddPlansAsync(IEnumerable<PlanModel> model);
        Task<IEnumerable<PlanModel>> GetAllPlansAsync();
        Task<PlanModel> GetPlanAsync(int id);
        Task<PlanModel> RemovePlanAsync(PlanModel model);
        Task RemovePlansAsync(IEnumerable<PlanModel> model);
    }
}