using Microsoft.EntityFrameworkCore;
using MVCProject2.Models;

namespace MVCProject2.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
