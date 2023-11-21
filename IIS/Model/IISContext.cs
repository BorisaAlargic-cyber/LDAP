using System;
using IIS.Configuration;
using IIS.Model.Request;
using Microsoft.EntityFrameworkCore;

namespace IIS.Model
{
    public class IISContext : DbContext
    {
        public static ProjectConfiguration Configuration;

        public IISContext(DbContextOptions<IISContext> context, ProjectConfiguration configuration) : base(context)
        {
            if (configuration != null)
            {
                IISContext.Configuration = configuration;
            }
        }

        public IISContext() : base() { }

        public DbSet<Airplane> Airplanes { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<FlightAdditionals> FlightAdditionals { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Purcheser> Purchesers { get; set; }
        public DbSet<PurchesersAdditionals> PurchesersAdditionals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlServer(IISContext.Configuration.DatabaseConfiguration.ConnectionString);
        }
    }
}
