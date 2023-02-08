using AirTravelBooking.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirTravelBooking.Server.Configurations.Entities
{
    public class FeatureSeedConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData
            (
                new Feature
                {
                    Id = 1,
                    Name = "Blank"
                },
                new Feature
                {
                    Id = 2,
                    Name = "Wider Seats"
                }
            );
        }
    }
}
