using EVideoPrime.API.Abstractions.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Abstractions.Models.VideoPrime
{
    public partial class SubscriptionModel
    {
        public int Id { get; set; }
        public DateTime SubscribedOn { get; set; }
        public DateTime ExpiryOn { get; set; }
        public PlanModel Plan { get; set; }
        public UserModel User { get; set; }
    }
}
