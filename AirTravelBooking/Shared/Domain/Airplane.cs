using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Airplane : BaseDomainModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Operator { get; set; }
    }
}
