using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTravelBooking.Shared.Domain
{
    public class Payment : BaseDomainModel
    {
        public string Name { get; set; }
        public string CardNumber { get; set; }
        public string SecurityNumber { get; set; }
        public string DateOfIssue { get; set; }
        public string ExpiryDate { get; set; }
    }
}
