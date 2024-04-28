using apiconcesionario.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace apiconcesionario
{
    public class ApiContext : DbContext
    {
        public DbSet<Auto> Autos {get; set;}
        public DbSet<Marca> Marcas {get; set;}
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        //Fluent API

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Marca> MarcasInit = new List<Marca>();
            MarcasInit.Add(new Marca() {Id=1, Nombre="Chevrolet", Image="https://upload.wikimedia.org/wikipedia/commons/1/1e/Chevrolet-logo.png"});
            MarcasInit.Add(new Marca() {Id=2, Nombre="Mazda", Image="https://static.vecteezy.com/system/resources/previews/020/502/740/original/mazda-logo-symbol-brand-car-with-name-black-design-japan-automobile-illustration-free-vector.jpg"});
            MarcasInit.Add(new Marca() {Id=3, Nombre="Bugatti", Image="https://upload.wikimedia.org/wikipedia/commons/thumb/6/60/Bugatti_logo.svg/2560px-Bugatti_logo.svg.png"});
            MarcasInit.Add(new Marca() {Id=4, Nombre="Audi", Image="https://w7.pngwing.com/pngs/492/427/png-transparent-audi-logo-audi-r8-car-logo-audi-text-trademark-desktop-wallpaper.png"});
            
            modelBuilder.Entity<Auto>(auto=>{
                
                auto.ToTable("Auto");

                auto.HasKey(p => p.Id);
                auto.HasOne(p => p.Marca).WithMany(p => p.Autos).HasForeignKey(p => p.MarcaId);
                
                auto.Property(p => p.Modelo).IsRequired(true);
                auto.Property(p => p.Color).IsRequired(true);
                auto.Property(p => p.Descripcion).IsRequired(false);
                auto.Property(p => p.Image).IsRequired(true);                
            });

            modelBuilder.Entity<Marca>(marca =>
            {
                marca.ToTable("Marca");

                marca.HasKey(p => p.Id);

                marca.Property(p => p.Nombre).IsRequired(true);
                marca.Property(p => p.Image).IsRequired(true);

                marca.HasData(MarcasInit);
            });

        }
    }
}