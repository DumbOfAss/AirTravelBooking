using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Seat : BaseDomainModel
    {
        public string Availability { get; set; }
        public string Location { get; set; }
    }
}
