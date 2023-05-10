using Microsoft.EntityFrameworkCore;
using Prueba.Models;

namespace Prueba.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Leccion> Lessons { get; set; }
        public DbSet<Gimnasio> Gyms { get; set; }
        public DbSet<GimnasioLesson> GymLesson { get; set; }
        public DbSet<UserLesson> UsuarioLesson { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User{Name = "admin", Username = "admin", Password = "admin", Role = true, Admin = true, SignUpDate = DateTime.Now, Id=1},
                new User{Name = "teacher", Username = "teacher", Password = "1111", Role = true, Admin = false, SignUpDate = DateTime.Now, Id=2}
            );
             modelBuilder.Entity<Leccion>().HasData(
                new Leccion { Id = 1, Name = "Karate principiantes", Description="Clase de karate para gente sin experiencia", TeacherId=2, Hour=20, Minute=30, Capacity=35},
                new Leccion { Id = 2, Name = "Karate avanzado", Description="Clase de karate para gente que lleva un tiempo practicando karate",TeacherId=2, Hour=21, Minute=30, Capacity=35},
                new Leccion { Id = 3, Name = "Muay Thai", Description="Arte marcial tailandesa que se especializa en codos y rodillas",TeacherId=2, Hour=17, Minute=30, Capacity=20},
                new Leccion { Id = 4, Name = "Zumba", Description="Clase de zumba para todos los niveles",TeacherId=2, Hour=20, Minute=00, Capacity=50}
            );

            modelBuilder.Entity<Gimnasio>().HasData(
                new Gimnasio { Id = 1, Name = "Sankukai", Address="Calle Julian Sanz Ibañez", MonthPrice=40, SignUpDate = DateTime.Now, Description="Gimnasio especializado en karate"},
                new Gimnasio { Id = 2, Name = "Strong Fist", Address="Paseo Calanda", MonthPrice=30, SignUpDate = DateTime.Now, Description="Gimnasio especializado en artes marciales mixtas"},
                new Gimnasio { Id = 3, Name = "Gimnasio Delicias", Address="Avenida Navarra", MonthPrice=50, SignUpDate = DateTime.Now, Description="Gimnasio con multiples clases y salas de pesas"}
            );

             modelBuilder.Entity<GimnasioLesson>().HasData(
                new GimnasioLesson { Id = 1, GimnasioId = 1, LeccionId = 1 },
                new GimnasioLesson { Id = 2, GimnasioId = 1, LeccionId = 2 },
                new GimnasioLesson { Id = 3, GimnasioId = 2, LeccionId = 3 },
                new GimnasioLesson { Id = 4, GimnasioId = 3, LeccionId = 4 }
            );

            modelBuilder.Entity<UserLesson>().HasData(
                new UserLesson { Id = 1, UsuarioId = 2, LeccionId = 1 },
                new UserLesson { Id = 2, UsuarioId = 2, LeccionId = 2 },
                new UserLesson { Id = 3, UsuarioId = 2, LeccionId = 3 }
            );

        }
    }
}