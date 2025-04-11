using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Person> Person { get; set; } = default!;
        public DbSet<Employee> Employee { get; set; } = default!;

        public DbSet<DaiLy> DaiLys { get; set; } = default!;
        public DbSet<HeThongPhanPhoi> HeThongPhanPhois { get; set; } = default!;
    }
}
