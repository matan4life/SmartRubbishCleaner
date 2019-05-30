using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class TrashCan
    {
        public int TrashCanId { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
