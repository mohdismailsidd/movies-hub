using EVideoPrime.API.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Entities.VideoPrime
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
        public int PlanId { get; set; }
        public virtual Plan Plan { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
