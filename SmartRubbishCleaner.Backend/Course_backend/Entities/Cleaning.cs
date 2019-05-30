using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Entities
{
    public class Cleaning
    {
        public int CleaningId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string RubbishType { get; set; }

        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public int FactoryId { get; set; }
        public Factory Factory { get; set; }
    }
}
