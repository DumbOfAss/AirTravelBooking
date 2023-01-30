using AirTravelBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Configurations.Entities
{
    public class DestinationSeedConfiguration : IEntityTypeConfiguration<Destination>
    {
        public void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.HasData(
                new Destination
                {
                    Id = 1,
                    BoardingName = "Boarding Airport",
                    ArrivallName = "Arrival Airport"
                });
        }
    }
}
