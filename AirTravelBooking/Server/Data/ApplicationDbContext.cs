using AirTravelBooking.Server.Configurations.Entities;
using AirTravelBooking.Server.Models;
using AirTravelBooking.Shared.Domain;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Baggage> Baggages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Seat> Seats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new FeatureSeedConfiguration());
            builder.ApplyConfiguration(new DestinationSeedConfiguration());
            builder.ApplyConfiguration(new BaggageSeedConfiguration());
            builder.ApplyConfiguration(new SeatSeedConfiguration());

        }

    }
}
