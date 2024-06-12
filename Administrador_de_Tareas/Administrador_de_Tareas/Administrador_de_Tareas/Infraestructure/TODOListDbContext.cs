using Administrador_de_Tareas.Models;
using Microsoft.EntityFrameworkCore;

namespace Administrador_de_Tareas.Infraestructure
{
    public class TODOListDbContext : DbContext
    {
        public DbSet<Todo> TodoSet { get; set; }

        public TODOListDbContext(DbContextOptions<TODOListDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
    }
}
