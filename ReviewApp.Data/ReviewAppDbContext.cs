using Microsoft.EntityFrameworkCore;
using ReviewApp.Model;

namespace ReviewApp.Data
{
    public class ReviewAppDbContext : DbContext
    {
        public ReviewAppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ReviewTask> ReviewTasks { get; set; }
        public DbSet<Quarter>  Quarters {  get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
