using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Destination : BaseDomainModel
    {
        public string BoardingName { get; set; }
        public string ArrivalName { get; set; }
        public int Distance { get; set; }
    }
}
