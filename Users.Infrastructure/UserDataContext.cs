using Microsoft.EntityFrameworkCore;
using Users.Domain.Model;

namespace Users.Infrastructure
{
    public class UserDataContext : DbContext
    {
        public UserDataContext(DbContextOptions<UserDataContext> options)
               : base(options)
        { }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Users");
        
        }
    }

}