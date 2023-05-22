using EVideoPrime.API.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Entities.VideoPrime
{
    public partial class PaymentDetail
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public int SubscriptionId { get; set; }
        public virtual Subscription Subscription { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
