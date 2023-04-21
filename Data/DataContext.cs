using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Data
{

    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext>options):base(options){ }
        public DbSet<User> Users{ get; set; }
        public DbSet<Leccion> Lessons{ get; set; }
        public DbSet<Gimnasio> Gyms{ get; set; }
        public DbSet<GimnasioLesson> GymLesson{ get; set; }
    }

}