using EVideoPrime.API.Abstractions.Models.Identity;
using EVideoPrime.API.Abstractions.Models.VideoPrime;
using EVideoPrime.API.Entities.VideoPrime;
using EVideoPrime.API.Repository.Services;
using EVideoPrime.API.Repository.SqlRepository.Interface.VideoPrime;
using Microsoft.EntityFrameworkCore;
using Movies.API.DAL;

namespace EVideoPrime.API.Repository.SqlRepository.Services.VideoPrime
{
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        SqlDbContext DbContext
        {
            get
            {
                return _dBContext as SqlDbContext;
            }
        }

        public SubscriptionRepository(DbContext dBContext) : base(dBContext)
        {
        }

        public async Task<IEnumerable<SubscriptionModel>> GetSubscriptionsByPlanAsync(string plan)
        {
            var data = await this.FindAsync(s => s.Plan.Name.Equals(plan, StringComparison.InvariantCultureIgnoreCase));

            return data!.Select(m => new SubscriptionModel
            {
                ExpiryOn = m.ExpiryOn,
                Id = m.Id,
                Plan = new PlanModel
                {
                    Id = m.PlanId,
                    Currency = m.Plan.Currency,
                    Name = m.Plan.Name,
                    Price = m.Plan.Price
                },
                SubscribedOn = m.SubscribedOn,
                User = new UserModel
                {
                    CreatedDate = m.User.CreatedDate,
                    Email = m.User.Email,
                    Id = m.UserId,
                    Name = m.User.Name,
                    Roles = m.User.Roles.Select(l => new RoleModel
                    {
                        Id = l.Id,
                        Name = l.Name
                    }).ToList(),
                    Username = m.User.Username
                }
            });
        }
    }
}
