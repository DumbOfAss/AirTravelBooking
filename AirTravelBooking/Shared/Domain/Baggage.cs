using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Baggage : BaseDomainModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Size { get; set; }
        //removed BaggageOwner - makes no fucking sense
    }
}
