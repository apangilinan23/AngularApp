using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;

namespace AngularApp.Server.Data
{
    public class WeatherDbContext : DbContext
    {
        public WeatherDbContext(DbContextOptions<WeatherDbContext> options)
            : base(options)
        { }

        public DbSet<Forecast> Forecast { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Ensure primary key
            modelBuilder.Entity<Forecast>()
                        .HasNoKey();

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