using Microsoft.EntityFrameworkCore;
using Pixelbadger.CustomerDetailsService.Core.Model;

namespace CustomerDetailsService.Model
{
    /// <summary>
    /// EF Core DbContext for models relating to the CustomerDetails entity
    /// </summary>
    internal class CustomerDetailsContext : DbContext
    {
        public DbSet<CustomerDetails> CustomerDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }

        /*public CustomerDetailsContext()
        {
        }*/

        public CustomerDetailsContext(DbContextOptions<CustomerDetailsContext> options) : base(options) 
        {
        }
    }
}
