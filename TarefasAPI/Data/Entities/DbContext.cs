using Microsoft.EntityFrameworkCore;
using tareaAPI.Data.Entities;

namespace TarefasAPI.Data.Entities
{
    public class databaseContext : DbContext
    {
        public databaseContext(DbContextOptions<databaseContext> options) : base(options)
        {
        }

        public DbSet<Tarefas> Tarefas { get; set; }
    }
}