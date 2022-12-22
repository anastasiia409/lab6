using lab6.Data;
using Microsoft.EntityFrameworkCore;

namespace lab6.Database
{
    public class DbConnection: DbContext
    {
        public DbConnection(DbContextOptions<DbConnection> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;
        public DbSet<EmployeeProject> EmployeeProjects { get; set; } = null!;
    }
}
