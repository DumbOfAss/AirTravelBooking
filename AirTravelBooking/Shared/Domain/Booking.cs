using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
    }
}
