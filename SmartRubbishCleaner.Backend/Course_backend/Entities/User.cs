using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class User : IdentityUser
    {
        public string Role { get; set; }

        public int? SubscriptionId { get; set; }
        public Subscription Subscription { get; set; }

        public List<Device> Devices { get; set; }

        public User()
        {
            this.Devices = new List<Device>();
        }
    }
}
