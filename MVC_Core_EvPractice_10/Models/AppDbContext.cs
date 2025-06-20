using Microsoft.EntityFrameworkCore;

namespace MVC_Core_EvPractice_10.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DeliveryAddress> DeliveryAddresses { get; set; }
    }
}
