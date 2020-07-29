using System;
using GodelTech.ReadMe.Example.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace GodelTech.ReadMe.Example.Data
{
    public class WeatherForecastDbContext : DbContext
    {
        public DbSet<PrecipitationType> PrecipitationTypes { get; set; }

        public DbSet<Precipitation> Precipitations { get; set; }

        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> contextOptions)
            : base(contextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Precipitation).Assembly);

            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PrecipitationType>().HasData(new PrecipitationType {Id = 1, Name = "Rain"});
            modelBuilder.Entity<PrecipitationType>().HasData(new PrecipitationType {Id = 2, Name = "Snow"});
            modelBuilder.Entity<PrecipitationType>().HasData(new PrecipitationType {Id = 3, Name = "Hail"});

            modelBuilder.Entity<Precipitation>().HasData(new Precipitation
            {
                Id = 1, Town = "Grodno", PrecipitationTypeId = 1, DateTime = new DateTime(2020, 01, 02), Summary = "Hot",
                Temperature = 32
            });
            modelBuilder.Entity<Precipitation>().HasData(new Precipitation
            {
                Id = 2, Town = "London", PrecipitationTypeId = 1, DateTime = new DateTime(2019, 11, 12), Summary = "Ok",
                Temperature = 26
            });

            modelBuilder.Entity<Precipitation>().HasData(new Precipitation
            {
                Id = 3, Town = "Venezia", PrecipitationTypeId = 2, DateTime = new DateTime(2020, 08, 29),
                Summary = "Where is summer?", Temperature = 20
            });
            modelBuilder.Entity<Precipitation>().HasData(new Precipitation
            {
                Id = 4, Town = "Barselona", PrecipitationTypeId = 2, DateTime = new DateTime(2019, 07, 28), Summary = "Cold",
                Temperature = 15
            });

            modelBuilder.Entity<Precipitation>().HasData(new Precipitation
            {
                Id = 5, Town = "Minsk", PrecipitationTypeId = 3, DateTime = new DateTime(2018, 05, 02), Summary = "Not bad",
                Temperature = 26
            });
        }
    }
}