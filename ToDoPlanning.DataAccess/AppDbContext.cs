using Microsoft.EntityFrameworkCore;
using ToDoPlanning.Entities.Concrete;

namespace ToDoPlanning.DataAccess
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ToDoPlanningDB;integrated security=true;");
        }

        public virtual DbSet<WorkTask> WorkTasks { get; set; }
    }
}
