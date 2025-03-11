using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            // Many-to-Many entre Flight et Passenger
            builder
                .HasMany(f => f.passengers)
                .WithMany(p => p.flights)
                .UsingEntity(t => t.ToTable("Reservations")); 

            //  One-to-Many entre Flight et Plane
            builder
                .HasOne(f => f.plane)
                .WithMany(p => p.flights)
                .HasForeignKey(f => f.planeFK)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
