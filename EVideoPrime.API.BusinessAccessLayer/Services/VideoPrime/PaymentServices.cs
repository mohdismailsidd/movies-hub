using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.BusinessAccessLayer.Interface.VideoPrime;
using EVideoPrime.API.Entities.Identity;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;

namespace EVideoPrime.API.BusinessAccessLayer.Services.VideoPrime
{
    public class PaymentServices : IPaymentServices
    {
        private readonly IUnitOfWorkVideoPrime _unitOfWorkVideoPrime;
        private readonly ISubscriptionServices _subscriptionServices;

        public PaymentServices(IUnitOfWorkVideoPrime unitOfWorkVideoPrime,
            ISubscriptionServices subscriptionServices)
        {
            _unitOfWorkVideoPrime = unitOfWorkVideoPrime;
            _subscriptionServices = subscriptionServices;
        }

        public async Task<PaymentModel> CreatePaymentAsync(PaymentModel model)
        {
            var subscription = await _subscriptionServices.AddSubscriptionAsync(model.SubscriptionDetail);
            var result = await _unitOfWorkVideoPrime.PaymentRepository.AddAsync(new PaymentDetail
            {
                CreatedDate = model.CreatedDate,
                Currency = model.Currency,
                Email = model.Email,
                Price = model.Price,
                Status = model.Status,
                Subscription = new Subscription
                {
                    Id = model.SubscriptionDetail.Id,
                    ExpiryOn = model.SubscriptionDetail.ExpiryOn,
                    Plan = new Plan
                    {
                        Id = model.SubscriptionDetail.Plan.Id,
                        Currency = model.SubscriptionDetail.Plan.Currency,
                        Name = model.SubscriptionDetail.Plan.Name,
                        Price = model.SubscriptionDetail.Plan.Price
                    },
                    PlanId = model.SubscriptionDetail.Plan.Id,
                    SubscribedOn = model.SubscriptionDetail.SubscribedOn,
                    User = new User
                    {
                        CreatedDate = model.SubscriptionDetail.User.CreatedDate,
                        Name = model.SubscriptionDetail.User.Name,
                        Email = model.SubscriptionDetail.User.Email,
                        Id = model.SubscriptionDetail.User.Id,
                        Roles = model.SubscriptionDetail.User.Roles.Select(x => new Role
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList(),
                        Username = model.SubscriptionDetail.User.Username
                    }
                },
                SubscriptionId = model.SubscriptionDetail.Id,
                Tax = model.Tax,
                Total = model.Total
            });

            return new PaymentModel
            {
                CreatedDate = result!.CreatedDate,
                Currency = result!.Currency,
                Email = result!.Email,
                Price = result!.Price,
                Status = result!.Status,
                SubscriptionDetail = new SubscriptionModel
                {
                    Id = result!.Subscription.Id,
                    ExpiryOn = result!.Subscription.ExpiryOn,
                    Plan = new PlanModel
                    {
                        Id = result!.Subscription.Plan.Id,
                        Currency = result!.Subscription.Plan.Currency,
                        Name = result!.Subscription.Plan.Name,
                        Price = result!.Subscription.Plan.Price
                    },
                    SubscribedOn = result!.Subscription.SubscribedOn,
                    User = new UserModel
                    {
                        CreatedDate = result!.Subscription.User.CreatedDate,
                        Name = result!.Subscription.User.Name,
                        Email = result!.Subscription.User.Email,
                        Id = result!.Subscription.User.Id,
                        Roles = result!.Subscription.User.Roles.Select(x => new RoleModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList(),
                        Username = result!.Subscription.User.Username
                    }
                },
                Tax = result!.Tax,
                Total = result!.Total
            };
        }

        public async Task<PaymentModel> GetPaymentAsync(int id)
        {
            var result = await _unitOfWorkVideoPrime.PaymentRepository.GetAsync(id);

            return new PaymentModel
            {
                CreatedDate = result!.CreatedDate,
                Currency = result!.Currency,
                Email = result!.Email,
                Price = result!.Price,
                Status = result!.Status,
                SubscriptionDetail = new SubscriptionModel
                {
                    Id = result!.Subscription.Id,
                    ExpiryOn = result!.Subscription.ExpiryOn,
                    Plan = new PlanModel
                    {
                        Id = result!.Subscription.Plan.Id,
                        Currency = result!.Subscription.Plan.Currency,
                        Name = result!.Subscription.Plan.Name,
                        Price = result!.Subscription.Plan.Price
                    },
                    SubscribedOn = result!.Subscription.SubscribedOn,
                    User = new UserModel
                    {
                        CreatedDate = result!.Subscription.User.CreatedDate,
                        Name = result!.Subscription.User.Name,
                        Email = result!.Subscription.User.Email,
                        Id = result!.Subscription.User.Id,
                        Roles = result!.Subscription.User.Roles.Select(x => new RoleModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList(),
                        Username = result!.Subscription.User.Username
                    }
                },
                Tax = result!.Tax,
                Total = result!.Total
            };
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentAsync()
        {
            var result = await _unitOfWorkVideoPrime.PaymentRepository.GetAllAsync();

            return result!.Select(m => new PaymentModel
            {
                CreatedDate = m.CreatedDate,
                Currency = m.Currency,
                Email = m.Email,
                Price = m.Price,
                Status = m.Status,
                SubscriptionDetail = new SubscriptionModel
                {
                    Id = m.Subscription.Id,
                    ExpiryOn = m.Subscription.ExpiryOn,
                    Plan = new PlanModel
                    {
                        Id = m.Subscription.Plan.Id,
                        Currency = m.Subscription.Plan.Currency,
                        Name = m.Subscription.Plan.Name,
                        Price = m.Subscription.Plan.Price
                    },
                    SubscribedOn = m.Subscription.SubscribedOn,
                    User = new UserModel
                    {
                        CreatedDate = m.Subscription.User.CreatedDate,
                        Name = m.Subscription.User.Name,
                        Email = m.Subscription.User.Email,
                        Id = m.Subscription.User.Id,
                        Roles = m.Subscription.User.Roles.Select(x => new RoleModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        }).ToList(),
                        Username = m.Subscription.User.Username
                    }
                },
                Tax = m.Tax,
                Total = m.Total
            });
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsByPlanAsync(string plan)
        {
            return await _unitOfWorkVideoPrime.PaymentRepository.GetAllPaymentsByPlanAsync(plan);
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsByUserAsync(string username)
        {
            return await _unitOfWorkVideoPrime.PaymentRepository.GetAllPaymentsByUserAsync(username);
        }
    }
}
