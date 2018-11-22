﻿using System.Configuration;
using AutoReservation.Dal.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace AutoReservation.Dal
{
    public class AutoReservationContext
        : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Reservation> Reservationen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>()
                .ToTable("Auto", schema: "dbo");
            modelBuilder.Entity<Kunde>()
                .ToTable("Kunde", schema: "dbo");
            modelBuilder.Entity<Reservation>()
                .ToTable("Reservation", schema: "dbo");
        }

        public static readonly LoggerFactory LoggerFactory = new LoggerFactory(
            new[] { new ConsoleLoggerProvider((_, logLevel) => logLevel >= LogLevel.Information, true) }
        );

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseLoggerFactory(LoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
                    .UseSqlServer(ConfigurationManager.ConnectionStrings[nameof(AutoReservationContext)].ConnectionString);
            }
        }

        //public void Add(Auto auto)
        //{
        //    Autos.Add(auto);
        //}
        //public void Add(Kunde kunde)
        //{
        //    Kunden.Add(kunde);
        //}
        //public void Add(Reservation reservation)
        //{
        //    Reservationen.Add(reservation);
        //}
    }
}