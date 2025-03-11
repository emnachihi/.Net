using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        //DBSET image au niveau be BD
        public DbSet<Flight> flights { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        // OnConfiguring nommer la base de donnés + chemin d'acces
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog=AirportManagementDB;
                                        Integrated Security=true;
                                        MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
        //onModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1ere methode
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());

            ////2eme methode (sans classe de configuration)

            //modelBuilder.Entity<Plane>()
            //    .HasKey(p => p.PlaneId);


            //modelBuilder.Entity<Plane>()
            //    .ToTable("MyPlanes");


            //modelBuilder.Entity<Plane>()
            //    .Property(p => p.Capacity)
            //    .HasColumnName("PlaneCapacity");

            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.Entity<Passenger> ().OwnsOne(f=>f.FullName);
            
            base.OnModelCreating(modelBuilder);
            
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            //type date dans la base de données
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("datetime");
        }

    }
}
