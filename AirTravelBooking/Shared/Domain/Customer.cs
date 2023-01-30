using System;

namespace AirTravelBooking.Shared.Domain
{
    public class Customer : BaseDomainModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Payment { get; set; }
    }
}