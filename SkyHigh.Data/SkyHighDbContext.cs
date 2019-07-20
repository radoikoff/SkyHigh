using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkyHigh.Domain;

namespace SkyHigh.Data
{
    public class SkyHighDbContext : IdentityDbContext<SkyHighUser, IdentityRole, string>
    {
        public DbSet<Aircraft> Aircrafts { get; set; }

        public DbSet<Airport> Airports { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Flight> Flights { get; set; }

        public DbSet<FlightReservation> FlightReservations { get; set; }

        public DbSet<Reservation> Reservations { get; set; }


        public SkyHighDbContext(DbContextOptions<SkyHighDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FlightReservation>()
                   .HasKey(k => new { k.FlightId, k.ReservationId });

            builder.Entity<Airport>()
                   .HasMany(x => x.Arrivals)
                   .WithOne(x => x.DestinationAirport)
                   .HasForeignKey(x => x.DestinationAirportId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Airport>()
                   .HasMany(x => x.Departures)
                   .WithOne(x => x.SourceAirport)
                   .HasForeignKey(x => x.SourceAirportId)
                   .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
