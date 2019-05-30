using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }
        public double ActionRange { get; set; }
        public double MaxVolume { get; set; }
        public double MaxWeight { get; set; }
        public string UserId { get; set; }
        public User Owner { get; set; }

        public List<TrashCan> TrashCans { get; set; }
        public List<Cleaning> Cleanings { get; set; }

        public Device()
        {
            TrashCans = new List<TrashCan>();
            Cleanings = new List<Cleaning>();
        }
    }
}
