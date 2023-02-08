using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Destination : BaseDomainModel
    {
        public string Name { get; set; }
        public int Distance { get; set; }
        public DateTime TravelTime { get; set; }
    }
}
