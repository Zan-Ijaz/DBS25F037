using Microsoft.EntityFrameworkCore;

namespace skillhub.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
