using EVideoPrime.API.Abstractions.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EVideoPrime.API.Abstractions.Models.VideoPrime
{
    public partial class PaymentModel
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public SubscriptionModel SubscriptionDetail { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
