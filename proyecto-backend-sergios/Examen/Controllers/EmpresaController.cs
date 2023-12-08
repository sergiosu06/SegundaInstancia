using Examen.Context;
using Examen.Models;
using Microsoft.AspNetCore.Mvc;

namespace Examen.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmpresaController : Controller
    {
        public readonly AplicacionContext _aplicacionContext;
        public EmpresaController(AplicacionContext context)
        {
            _aplicacionContext = context;
        }
        [HttpPost]
        [Route("AgregarEmpresa")]
        public async Task<IActionResult> Post([FromBody] Empresa empresa)
        {
            _aplicacionContext.Empresa.Add(empresa);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Agregado correctamente");
        }
        [HttpGet]
        [Route("MostrarEmpresa")]
        public async Task<IActionResult> Get()
        {
            List<Empresa> listaEmpresa = _aplicacionContext.Empresa.OrderByDescending(e => e.idEmpresa).ToList();
            return StatusCode(StatusCodes.Status200OK, listaEmpresa);
        }
        [HttpPut]
        [Route("EditarEmpresa/")]
        public async Task<IActionResult> Put([FromBody] Empresa empresa)
        {
            _aplicacionContext.Empresa.Update(empresa);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Editado correctamente ");
        }
        [HttpDelete]
        [Route("EliminarEmpresa/")]
        public async Task<IActionResult> Delete(int? id)
        {
            Empresa empresa = _aplicacionContext.Empresa.Find(id);
            _aplicacionContext.Empresa.Remove(empresa);
            await _aplicacionContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status200OK, "Eliminado correctamente  ");
        }
    }
}
