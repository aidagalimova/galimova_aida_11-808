using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCProject2.Models;

namespace MVCProject2.Data
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
    }
}
