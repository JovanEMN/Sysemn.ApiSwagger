using Microsoft.EntityFrameworkCore;

namespace Sysemn.ApiSwagger.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {                
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ApiSwagger;Trusted_Connection=True;ConnectRetryCount=0");
            }
        }

        public DbSet<UserModel> UserModels { get; set; }
    }
}
