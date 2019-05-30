using Course_backend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Course_backend.Controllers
{
    public static class TimeOptimization
    {
        public static double GetCleaningSpeed(List<Cleaning> c1, List<Cleaning> c2)
        {
            var difference = c2.OrderBy(x => x.Date).LastOrDefault().Date - c1.OrderBy(x => x.Date).FirstOrDefault().Date;
            return c2.Select(x => x.Amount).Sum() / (difference.TotalSeconds + 0.0);
        }

        public static double GetAverageSpeed(List<List<Cleaning>> cleanings)
        {
            double result = 0.0;
            for (int i=1; i<cleanings.Count; i++)
            {
                result += GetCleaningSpeed(cleanings[i - 1], cleanings[i]);
            }
            return result / (cleanings.Count - 1);
        }

        public static double GetAverageAmount(List<List<Cleaning>> cleanings)
        {
            double result = 0.0;
            cleanings.ForEach(x => result += (x.Select(y => y.Amount).Sum() / x.Count));
            return result / cleanings.Count;
        }

        public static double GetNeededTime(List<List<Cleaning>> cleanings)
        {
            return GetAverageAmount(cleanings) / GetAverageSpeed(cleanings);
        }
    }
}
