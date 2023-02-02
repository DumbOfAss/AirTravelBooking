using AirTravelBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Configurations.Entities
{
    public class BaggageSeedConfiguration : IEntityTypeConfiguration<Baggage>
    {
        public void Configure(EntityTypeBuilder<Baggage> builder)
        {
            builder.HasData(
                new Baggage
                {
                    Id = 1,
                    Name = "Example",
                    Weight = 2.5,
                    Size = "Medium"
                }
                );
        }
    }
}
