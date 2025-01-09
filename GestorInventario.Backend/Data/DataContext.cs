using GestorInventario.Shared.Entitis;
using Microsoft.EntityFrameworkCore;

namespace GestorInventario.Backend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Rol> roles { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Producto> Productos { get; set; }

        public DbSet<Categoria> categorias { get; set; }
        public DbSet<Proveedor> proveedores { get; set; }
        public DbSet<Proveedor> entrada_stock { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Rol>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();
            DisableCascadingDlete(modelBuilder);
            modelBuilder.Entity<Producto>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Categoria>().HasIndex(x => x.Name).IsUnique();
            modelBuilder.Entity<Proveedor>().HasIndex(x => x.nombre).IsUnique();
            modelBuilder.Entity<Entrada_Inventario>().HasIndex(x => x.Cantidad).IsUnique();
        }

        private void DisableCascadingDlete(ModelBuilder modelBuilder)
        {
            var relations = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());
            foreach (var relation in relations)
            {
                relation.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}