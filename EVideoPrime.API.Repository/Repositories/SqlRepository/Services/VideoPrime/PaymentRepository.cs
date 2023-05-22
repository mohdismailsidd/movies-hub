using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Interfaces;
using EVideoPrime.API.Repository.Services;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.EntityFrameworkCore;
using Movies.API.DAL;
using System.Linq;

namespace EVideoPrime.API.Repository.SqlRepository.Services.VideoPrime
{
    public class PaymentRepository : Repository<PaymentDetail>, IPaymentRepository
    {
        SqlDbContext DbContext
        {
            get
            {
                return _dBContext as SqlDbContext;
            }
        }

        public PaymentRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsByPlanAsync(string plan)
        {
            var data = await this.
                FindAsync(m => m.Subscription.Plan.Name.Equals(plan, StringComparison.InvariantCultureIgnoreCase));

            return data!.Select(m => new PaymentModel
            {
                CreatedDate = m.CreatedDate,
                Currency = m.Currency,
                Email = m.Email,
                Id = m.Id,
                Price = m.Price,
                Status = m.Status,
                SubscriptionDetail = new SubscriptionModel
                {
                    Id = m.SubscriptionId,
                    ExpiryOn = m.Subscription.ExpiryOn,
                    Plan = new PlanModel
                    {
                        Id = m.Subscription.Plan.Id,
                        Currency = m.Subscription.Plan.Currency,
                        Name = m.Subscription.Plan.Name,
                        Price = m.Subscription.Plan.Price
                    },
                    SubscribedOn = m.Subscription.SubscribedOn,
                },
                Tax = m.Tax,
                Total = m.Total
            });
        }

        public async Task<IEnumerable<PaymentModel>> GetAllPaymentsByUserAsync(string username)
        {
            var data = await this.
                FindAsync(m => m.Subscription.User.Username.Equals(username, StringComparison.InvariantCultureIgnoreCase));

            return data!.Select(m => new PaymentModel
            {
                CreatedDate = m.CreatedDate,
                Currency = m.Currency,
                Email = m.Email,
                Id = m.Id,
                Price = m.Price,
                Status = m.Status,
                SubscriptionDetail = new SubscriptionModel
                {
                    Id = m.SubscriptionId,
                    ExpiryOn = m.Subscription.ExpiryOn,
                    Plan = new PlanModel
                    {
                        Id = m.Subscription.Plan.Id,
                        Currency = m.Subscription.Plan.Currency,
                        Name = m.Subscription.Plan.Name,
                        Price = m.Subscription.Plan.Price
                    },
                    SubscribedOn = m.Subscription.SubscribedOn
                },
                Tax = m.Tax,
                Total = m.Total
            });
        }
    }
}
