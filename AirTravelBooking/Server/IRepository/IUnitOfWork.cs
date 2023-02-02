using AirTravelBooking.Shared.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Airplane> Airplanes { get; }
        IGenericRepository<Baggage> Baggages { get; }
        IGenericRepository<Destination> Destinations { get; }
        IGenericRepository<Seat> Seats { get; }
        IGenericRepository<Feature> Features { get; }
        IGenericRepository<Priority> Priorities { get; }
        IGenericRepository<Booking> Bookings { get; }
        IGenericRepository<Customer> Customers { get; }
    }
}