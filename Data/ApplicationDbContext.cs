using Microsoft.EntityFrameworkCore;
using Parcial3_Web.Models;

namespace Parcial3_Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Contacto> Contactos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.NombreUsuario)
                .IsUnique();

            // Usuarios iniciales
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    Id = 1,
                    NombreUsuario = "admin",
                    Password = "123456", 
                    NombreCompleto = "Administrador del Sistema",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                },
                new Usuario
                {
                    Id = 2,
                    NombreUsuario = "usuario",
                    Password = "password",
                    NombreCompleto = "Usuario Demo",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                },
                new Usuario
                {
                    Id = 3,
                    NombreUsuario = "demo",
                    Password = "demo123",
                    NombreCompleto = "Usuario de Demo",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                }
            );

            //Contactos iniciales
            modelBuilder.Entity<Contacto>().HasData(
                new Contacto
                {
                    Id = 1,
                    Nombre = "Juan Pérez",
                    Telefono = "555-0101",
                    Email = "juan@email.com",
                    Departamento = "Ventas",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                },
                new Contacto
                {
                    Id = 2,
                    Nombre = "María García",
                    Telefono = "555-0102",
                    Email = "maria@email.com",
                    Departamento = "Soporte",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                },
                new Contacto
                {
                    Id = 3,
                    Nombre = "Carlos López",
                    Telefono = "555-0103",
                    Email = "carlos@email.com",
                    Departamento = "IT",
                    FechaCreacion = DateTime.Now,
                    Activo = true
                }
            );
        }
    }
}