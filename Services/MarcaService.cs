using apiconcesionario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiconcesionario.Services
{
    public class MarcaService : IMarcaService
    {
        private readonly ApiContext context;

        public MarcaService(ApiContext _context)
        {
            context = _context;
        }
        public IEnumerable<Marca> Get()
        {
            return context.Marcas;
        }

        public Marca GetById(int id)
        {
            return context.Marcas.Find(id);
        }

        public async Task Save(Marca marca)
        {
            context.Add(marca);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Marca marca)
        {
            var marcaActual = context.Marcas.Find(id);

            if(marcaActual != null)
            {
                marcaActual.Nombre = marca.Nombre;
                marcaActual.Image = marca.Image;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var marcaActual = context.Marcas.Find(id);

            if(marcaActual != null)
            {
                context.Remove(marcaActual);

                await context.SaveChangesAsync();
            }
        }
    }

    public interface IMarcaService
    {
        IEnumerable<Marca> Get();
        Marca GetById(int id);
        Task Save(Marca marca);
        Task Update(int id, Marca marca);
        Task Delete(int id);
    }
}