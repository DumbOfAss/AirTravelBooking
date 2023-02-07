using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Booking : BaseDomainModel
    {
        public DateTime Boarding { get; set; }
        public DateTime Arrival { get; set; }
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public int DestinationId { get; set; }
        public virtual Destination Destination { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public int PriorityId { get; set; }
        public virtual Priority Priority { get; set; }
        public int BaggageId { get; set; }
        public virtual Baggage Baggage { get; set; }
    }
}
