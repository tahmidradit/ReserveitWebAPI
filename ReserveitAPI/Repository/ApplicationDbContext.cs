using Microsoft.EntityFrameworkCore;
using ReserveitAPI.Model;

namespace ReserveitAPI.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}
