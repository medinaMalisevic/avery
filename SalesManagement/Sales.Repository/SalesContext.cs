using Microsoft.EntityFrameworkCore;
using System;

namespace Sales.Repository
{
    /// <summary>
    /// Represents a session with Sales.DB
    /// </summary>
    public class SalesContext : DbContext
    {
        readonly string connectionString;

        public SalesContext(string connectionString)
        {
            if (connectionString == null)
                throw new ArgumentNullException(nameof(connectionString));

            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentException("Value should not be empty.", nameof(connectionString));

            this.connectionString = connectionString;
        }

        public DbSet<SaleData> SalesData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
