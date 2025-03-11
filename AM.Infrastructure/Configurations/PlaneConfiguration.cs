using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AM.Infrastructure.Configurations
{
    public class PlaneConfiguration : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            //Définir PlaneId comme clé primaire
            builder.HasKey(p => p.PlaneId);

            //  Renommer la table 
            builder.ToTable("MyPlanes");

            // Renommer la colonne 
            builder.Property(p => p.Capacity)
                   .HasColumnName("PlaneCapacity");


        }
    }
}
