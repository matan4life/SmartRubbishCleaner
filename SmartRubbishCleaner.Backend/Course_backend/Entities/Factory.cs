using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class Factory
    {
        public int FactoryId { get; set; }
        public double Longtitude { get; set; }
        public double Latitude { get; set; }

        public List<Cleaning> DeviceFactories { get; set; }

        public Factory()
        {
            DeviceFactories = new List<Cleaning>();
        }
    }
}
