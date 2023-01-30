using AirTravelBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Configurations.Entities
{
    public class SeatSeedConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder.HasData(
                new Seat
                {
                    Id = 1,
                    Availability = "Choose a seat",
                    Location = "Not Chosen",
                });
        }
    }
}
