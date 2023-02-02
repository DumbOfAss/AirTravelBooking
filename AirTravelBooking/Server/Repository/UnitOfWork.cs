using AirTravelBooking.Server.Data;
using AirTravelBooking.Server.IRepository;
using AirTravelBooking.Server.Models;
using AirTravelBooking.Shared.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IGenericRepository<Airplane> _airplanes;
        private IGenericRepository<Baggage> _baggages;
        private IGenericRepository<Seat> _seats;
        private IGenericRepository<Booking> _bookings;
        private IGenericRepository<Customer> _customers;
        private IGenericRepository<Destination> _destinations;
        private IGenericRepository<Feature> _features;
        private IGenericRepository<Priority> _priorities;

        private UserManager<ApplicationUser> _userManager;

        public UnitOfWork(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IGenericRepository<Booking> Bookings
            => _bookings ??= new GenericRepository<Booking>(_context);
        public IGenericRepository<Customer> Customers
            => _customers ??= new GenericRepository<Customer>(_context);

        public IGenericRepository<Airplane> Airplanes => _airplanes ??= new GenericRepository<Airplane>(_context);

        public IGenericRepository<Baggage> Baggages => _baggages ??= new GenericRepository<Baggage>(_context);

        public IGenericRepository<Destination> Destinations => _destinations ??= new GenericRepository<Destination>(_context);

        public IGenericRepository<Seat> Seats => _seats ??= new GenericRepository<Seat>(_context);

        public IGenericRepository<Feature> Features => _features ??= new GenericRepository<Feature>(_context);

        public IGenericRepository<Priority> Priorities => _priorities ??= new GenericRepository<Priority>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }


        
        public async Task Save(HttpContext httpContext)
        {
            //To be implemented
            /*
            string user = "System";

            var entries = _context.ChangeTracker.Entries()
                .Where(q => q.State == EntityState.Modified ||
                    q.State == EntityState.Added);
            
            foreach (var entry in entries)
            {
                ((BaseDomainModel)entry.Entity).DateUpdated = DateTime.Now;
                ((BaseDomainModel)entry.Entity).UpdatedBy = user;
                if (entry.State == EntityState.Added)
                {
                    ((BaseDomainModel)entry.Entity).DateCreated = DateTime.Now;
                    ((BaseDomainModel)entry.Entity).CreatedBy = user;
                }
            }
            */
            await _context.SaveChangesAsync();
        }
        
    }
}