using Aplicacion.Servicios.Implementaciones;
using Aplicacion.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarreras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerUsuarios : ControllerBase
    {
        private IServicio servicio = new ServicioCarrera(); 

        [HttpGet("/usuario")]
        public IActionResult GetUsuario(string nombre, string contrasenia)
        {
            try
            {
                if (nombre == null || contrasenia == null)
                    return BadRequest("No se ingresaron algunos parametros");
                return Ok(servicio.Login(nombre, contrasenia));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }
    }
}
