using Microsoft.EntityFrameworkCore;
using Pixelbadger.CustomerDetailsService.Core.Model;

namespace CustomerDetailsService.Model
{
    /// <summary>
    /// EF Core DbContext for models relating to the CustomerDetails entity
    /// </summary>
    internal class CustomerDetailsContext : DbContext
    {
        private readonly string _connectionString;

        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public CustomerDetailsContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        // for brevity we assume a SQL Server connection string here, but injected ctor
        // configuration could be extended to allow support for multiple data sources.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(_connectionString);
    }
}
