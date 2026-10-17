using LogisticsCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LogisticsCore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<TruckDepot> TruckDepots => Set<TruckDepot>();
        public DbSet<Driver> Drivers => Set<Driver>();
        public DbSet<DeliveryTruck> DeliveryTrucks => Set<DeliveryTruck>();
    }
}