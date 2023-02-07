using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Client.Static
{
    public static class EndPoints
    {
        private static readonly string Prefix = "api";

        public static readonly string SeatsEndPoint = $"{Prefix}/Seats";
        public static readonly string FeaturesEndPoint = $"{Prefix}/Features";
        public static readonly string BaggagesEndPoint = $"{Prefix}/Baggages";
        public static readonly string PrioritiesEndPoint = $"{Prefix}/Priorities";
        public static readonly string AirplanesEndPoint = $"{Prefix}/Airplanes";
        public static readonly string CustomersEndPoint = $"{Prefix}/Customers";
        public static readonly string BookingsEndPoint = $"{Prefix}/Bookings";
        public static readonly string DestinationsEndPoint = $"{Prefix}/Destinations";
    }
}
