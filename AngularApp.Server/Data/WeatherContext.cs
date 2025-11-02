using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Xml;

namespace AngularApp.Server.Data
{
    public class WeatherContext : DbContext // Fix: Inherit from DbContext, not itself
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        { }

        public DbSet<Forecast> Forecast { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure primary key
            modelBuilder.Entity<Forecast>()
                        .HasKey(x => x.Id);

            // Ensure primary key
            modelBuilder.Entity<User>()
           .HasKey(e => e.Id); 

            // Map DateOnly to SQL date (uses ValueConverter)
            var dateConverter = new ValueConverter<DateOnly, DateTime>(
                d => d.ToDateTime(TimeOnly.MinValue),
                dt => DateOnly.FromDateTime(dt));

            modelBuilder.Entity<Forecast>()
                        .Property(w => w.Date)
                        .HasConversion(dateConverter)
                        .HasColumnType("date"); // SQL Server date type; change for other providers
        }
    }
}