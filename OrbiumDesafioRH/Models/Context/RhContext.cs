using Microsoft.EntityFrameworkCore;

namespace OrbiumDesafioRH.Models.Context
{
    public class RhContext : DbContext
    {

        public DbSet<Employee> Employees { get; set; }

        public RhContext(DbContextOptions<RhContext> options):base(options)
        {
        }
    }
}
