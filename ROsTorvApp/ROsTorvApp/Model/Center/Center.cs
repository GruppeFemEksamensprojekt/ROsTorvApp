using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROsTorvApp.Model.Center
{
    class Center
    {
        public string CenterName { get; set; }
        public string OpeningHoursStart { get; set; }
        public string OpeningHoursEnd { get; set; }

        public Center(string centerName, string openingHoursStart, string openingHoursEnd)
        {
            CenterName = centerName;
            OpeningHoursStart = openingHoursStart;
            OpeningHoursEnd = openingHoursEnd;
        }

        public override string ToString()
        {
            return $"{CenterName} Har åbent fra {OpeningHoursStart} til {OpeningHoursEnd}.";
        }
    }
}
