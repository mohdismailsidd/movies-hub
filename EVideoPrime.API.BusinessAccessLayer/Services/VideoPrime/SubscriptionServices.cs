using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class SubscriptionServices : ISubscriptionServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;

        public SubscriptionServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
        }

        public async Task<SubscriptionModel> AddSubscriptionAsync(SubscriptionModel model)
        {
            var result = await _unitOfWorkVideoPrime.SubsRepository.AddAsync(new Subscription
            {
                Id = model.Id,
                ExpiryOn = model.ExpiryOn,
                Plan = new Plan
                {
                    Id = model.Plan.Id,
                    Currency = model.Plan.Currency,
                    Name = model.Plan.Name,
                    Price = model.Plan.Price
                },
                PlanId = model.Plan.Id,
                SubscribedOn = model.SubscribedOn,
                User = new User
                {
                    CreatedDate = model.User.CreatedDate,
                    Name = model.User.Name,
                    Email = model.User.Email,
                    Id = model.User.Id,
                    Roles = model.User.Roles.Select(x=> new Role
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList(),
                    Username = model.User.Username
                }
            });

            return new SubscriptionModel
            {
                Id = result!.Id,
                ExpiryOn = result!.ExpiryOn,
                Plan = new PlanModel
                {
                    Id = result!.Plan.Id,
                    Currency = result!.Plan.Currency,
                    Name = result!.Plan.Name,
                    Price = result!.Plan.Price
                },
                SubscribedOn = result!.SubscribedOn,
                User = new UserModel
                {
                    CreatedDate = result!.User.CreatedDate,
                    Name = result!.User.Name,
                    Email = result!.User.Email,
                    Id = result!.User.Id,
                    Roles = model.User.Roles.Select(x => new RoleModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList(),
                    Username = result!.User.Username
                }
            };
        }

        public async Task<SubscriptionModel> GetSubscriptionAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.SubsRepository.GetAsync(id);

            return new SubscriptionModel
            {
                Id = result!.Id,
                ExpiryOn = result!.ExpiryOn,
                Plan = new PlanModel
                {
                    Id = result!.Plan.Id,
                    Currency = result!.Plan.Currency,
                    Name = result!.Plan.Name,
                    Price = result!.Plan.Price
                },
                SubscribedOn = result!.SubscribedOn,
                User = new UserModel
                {
                    CreatedDate = result!.User.CreatedDate,
                    Name = result!.User.Name,
                    Email = result!.User.Email,
                    Id = result!.User.Id,
                    Roles = result!.User.Roles.Select(x => new RoleModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList(),
                    Username = result!.User.Username
                }
            };
        }

        public async Task<IEnumerable<SubscriptionModel>> GetAllSubscriptionsAsync()
        {
            var result = await _unitOfWorkVideoPrime.SubsRepository.GetAllAsync();

            return result!.Select(m => new SubscriptionModel
            {
                Id = m.Id,
                ExpiryOn = m.ExpiryOn,
                Plan = new PlanModel
                {
                    Id = m.Plan.Id,
                    Currency = m.Plan.Currency,
                    Name = m.Plan.Name,
                    Price = m.Plan.Price
                },
                SubscribedOn = m.SubscribedOn,
                User = new UserModel
                {
                    CreatedDate = m.User.CreatedDate,
                    Name = m.User.Name,
                    Email = m.User.Email,
                    Id = m.User.Id,
                    Roles = m.User.Roles.Select(x => new RoleModel
                    {
                        Id = x.Id,
                        Name = x.Name
                    }).ToList(),
                    Username = m.User.Username
                }
            });
        }

        public async Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByPlanAsync(string plan)
        {
            return await _unitOfWorkVideoPrime.SubsRepository.GetSubscriptionsByPlanAsync(plan);
        }
    }
}
