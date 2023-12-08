using Examen.Context;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbanilesController : Controller
    {
        public readonly AplicacionContext _aplicacionContext;
        public AlbanilesController(AplicacionContext context)
        {
            _aplicacionContext = context;
        }
        [HttpPost]
        [Route("AgregarAlbanil")]
        public async Task<IActionResult> Post([FromBody] Albanil albanil)
        {
            _aplicacionContext.Albanil.Add(albanil);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Agregado correctamente");
        }
        [HttpGet]
        [Route("MostrarAlbaniles")]
        public async Task<IActionResult> Get()
        {
            List<Albanil> listaAlbaniles = _aplicacionContext.Albanil.OrderByDescending(e => e.idAlbanil).ToList();
            return StatusCode(StatusCodes.Status200OK, listaAlbaniles);
        }
        [HttpPut]
        [Route("EditarAlbanil/")]
        public async Task<IActionResult> Put([FromBody] Albanil albanil)
        {
            _aplicacionContext.Albanil.Update(albanil);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Editado correctamente ");
        }
        [HttpDelete]
        [Route("EliminarAlbanil/")]
        public async Task<IActionResult> Delete(int? id)
        {
            Albanil albanil = _aplicacionContext.Albanil.Find(id);
            _aplicacionContext.Albanil.Remove(albanil);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Eliminado correctamente  ");
        }
    }
}
