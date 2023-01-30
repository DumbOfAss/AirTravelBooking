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
        public int SeatId { get; set; }
        public virtual Seat Seat { get; set; }
        public int ClassId { get; set; }
        public virtual Class Class { get; set; }
        public int BaggageId { get; set; }
        public virtual Baggage Baggage { get; set; }
    }
}
