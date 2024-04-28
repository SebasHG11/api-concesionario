using apiconcesionario.Models;
using apiconcesionario.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiconcesionario.Controllers
{
    [ApiController]
    [Route("v2/{controller}")]
    public class MarcaController : Controller
    {
        private readonly IMarcaService marcaService;

        public MarcaController(IMarcaService _marcaService)
        {
            marcaService = _marcaService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(marcaService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(marcaService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MarcaCreate marcaCreate)
        {
            var marca = new Marca
            {
                Id = marcaCreate.Id,
                Nombre = marcaCreate.Nombre,
                Image = marcaCreate.Image
            };

            await marcaService.Save(marca);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] MarcaCreate marcaCreate)
        {
            var marca = new Marca
            {
                Id = marcaCreate.Id,
                Nombre = marcaCreate.Nombre,
                Image = marcaCreate.Image
            };

            await marcaService.Update(id, marca);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await marcaService.Delete(id);
            return Ok();
        }
    }
}