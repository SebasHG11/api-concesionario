using apiconcesionario.Models;
using Microsoft.EntityFrameworkCore;

namespace apiconcesionario.Services
{
    public class AutoService : IAutoService
    {
        private readonly ApiContext context;

        public AutoService(ApiContext _context)
        {
            context = _context;
        }

        public IEnumerable<Auto> Get()
        {
            return context.Autos.Include(p => p.Marca);
        }

        public Auto GetById(int id)
        {
            return context.Autos.Include(p => p.Marca).FirstOrDefault(auto => auto.Id == id);
        }

        public async Task Save(Auto auto)
        {
            context.Add(auto);
            await context.SaveChangesAsync();
        }

        public async Task Update(int id, Auto auto)
        {
            var autoActual = context.Autos.Find(id);

            if(autoActual != null)
            {

                autoActual.MarcaId = auto.MarcaId;
                autoActual.Modelo = auto.Modelo;
                autoActual.Color = auto.Color;
                autoActual.Descripcion = auto.Descripcion;
                autoActual.Image = auto.Image;

                await context.SaveChangesAsync();

            }
        }

        public async Task Delete(int id)
        {
            var autoActual = context.Autos.Find(id);

            if(autoActual != null)
            {
                context.Remove(autoActual);
                
                await context.SaveChangesAsync();
            }
        }
    }

    public interface IAutoService
    {
        IEnumerable<Auto> Get();
        Auto GetById(int id);
        Task Save(Auto auto);
        Task Update(int id, Auto auto);
        Task Delete(int id);
    }
}