using letsmakesmth.Models;
using Microsoft.EntityFrameworkCore;

namespace letsmakesmth.Contexts
{
    public class UserContext: DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=smartHouse;Host=localhost;Port=5432;Database=UsersDatabase;Username=postgres;Password=kdfnidiv104931");
            }
        }

    }
}
