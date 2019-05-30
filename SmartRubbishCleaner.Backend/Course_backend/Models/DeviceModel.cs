using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Models
{
    public class DeviceModel
    {
        public int DeviceId { get; set; }
        public double ActionRange { get; set; }
        public double MaxVolume { get; set; }
        public double MaxWeight { get; set; }
        public UserModel Owner { get; set; }
    }
}
