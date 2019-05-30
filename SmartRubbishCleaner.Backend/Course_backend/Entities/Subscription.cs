using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class Subscription
    {
        public int SubscriptionId { get; set; }
        public string IdentificationName { get; set; }
        public double Price { get; set; }

        public List<User> Subscribers { get; set; }

        public Subscription()
        {
            this.Subscribers = new List<User>();
        }
    }
}
