using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Models
{
    public class CleaningModel
    {
        public int CleaningId { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public string RubbishType { get; set; }

        public int DeviceId { get; set; }

        public FactoryModel Factory { get; set; }
    }
}
