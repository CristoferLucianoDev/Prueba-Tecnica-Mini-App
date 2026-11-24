using Microsoft.EntityFrameworkCore;
using Prueba_Técnica___Mini_App.Entities;

namespace Prueba_Técnica___Mini_App.Datos
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Books> Books => Set<Books>();
    }
}
