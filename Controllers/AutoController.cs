using apiconcesionario.Models;
using apiconcesionario.Services;
using Microsoft.AspNetCore.Mvc;

namespace apiconcesionario.Controllers
{
    [ApiController]
    [Route("v1/{controller}")]
    public class AutoController : Controller
    {
        private readonly IAutoService autoService;

        public AutoController(IAutoService _autoService)
        {
            autoService = _autoService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(autoService.Get());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(autoService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AutoCreate autoCreate)
        {
            var auto = new Auto
            {
                Id = autoCreate.Id,
                MarcaId = autoCreate.MarcaId,
                Modelo = autoCreate.Modelo,
                Color = autoCreate.Color,
                Descripcion = autoCreate.Descripcion,
                Image = autoCreate.Image
            };
            
            await autoService.Save(auto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AutoCreate autoCreate)
        {
            var auto = new Auto
            {
                Id = autoCreate.Id,
                MarcaId = autoCreate.MarcaId,
                Modelo = autoCreate.Modelo,
                Color = autoCreate.Color,
                Descripcion = autoCreate.Descripcion,
                Image = autoCreate.Image
            };

            await autoService.Update(id, auto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await autoService.Delete(id);
            return Ok();
        }
    }
}