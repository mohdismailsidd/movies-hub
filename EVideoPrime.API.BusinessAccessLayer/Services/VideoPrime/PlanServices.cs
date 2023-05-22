using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class PlanServices : IPlanServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;

        public PlanServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
        }

        public async Task<PlanModel> AddPlanAsync(PlanModel model)
        {
            var result = await _unitOfWorkVideoPrime.PlanRepository.AddAsync(new Plan
            {
                Currency = model.Currency,
                Name = model.Name,
                Price = model.Price
            });
            model.Id = result!.Id;
            return model;
        }

        public async Task AddPlansAsync(IEnumerable<PlanModel> model)
        {
            await _unitOfWorkVideoPrime.PlanRepository.AddRangeAsync(model.Select(m => new Plan
            {
                Currency = m.Currency,
                Name = m.Name,
                Price = m.Price
            }));
        }

        public async Task<PlanModel> RemovePlanAsync(PlanModel model)
        {
            var result = await _unitOfWorkVideoPrime.PlanRepository.RemoveAsync(new Plan
            {
                Currency = model.Currency,
                Name = model.Name,
                Price = model.Price
            });

            return model;
        }

        public async Task RemovePlansAsync(IEnumerable<PlanModel> model)
        {
            await _unitOfWorkVideoPrime.PlanRepository.RemoveRangeAsync(model.Select(m => new Plan
            {
                Currency = m.Currency,
                Name = m.Name,
                Price = m.Price
            }));
        }

        public async Task<PlanModel> GetPlanAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.PlanRepository.GetAsync(id);

            return new PlanModel
            {
                Currency = result!.Currency,
                Name = result!.Name,
                Price = result!.Price,
                Id = result!.Id
            };
        }

        public async Task<IEnumerable<PlanModel>> GetAllPlansAsync()
        {
            var result = await _unitOfWorkVideoPrime.PlanRepository.GetAllAsync();

            return result!.Select(m => new PlanModel
            {
                Currency = m.Currency,
                Name = m.Name,
                Price = m.Price,
                Id = m.Id
            });
        }
    }
}
