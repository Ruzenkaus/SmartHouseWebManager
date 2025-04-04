using letsmakesmth.Models;
using Microsoft.EntityFrameworkCore;

namespace letsmakesmth.Contexts
{
    public class DeviceContext:DbContext
    {
        public DeviceContext(DbContextOptions<DeviceContext> options) : base(options) { }

        public DbSet<DeviceModel> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("connection string");
            }
        }
    }
}
