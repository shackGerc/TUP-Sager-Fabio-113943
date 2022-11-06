using Aplicacion.Dominio;
using Aplicacion.Servicios;
using Aplicacion.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APICarreras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerCarreras : ControllerBase
    {
        private IServicio servicio;

        public ControllerCarreras()
        {
            servicio = new ImpFabricaServicio().CrearServicio();
        }

        [HttpGet("/GetMateriasXCarrera")]
        public IActionResult GetMateriasXCarrera()
        {
            return Ok(JsonConvert.SerializeObject(servicio.ConsultarMateriasXCarrera()));
        }

        [HttpGet("/CarreraGet")]
        public List<Carrera> Get()
        {
            return servicio.ConsultarCarreras();
        }

        [HttpPost("/carreraPost")]
        public IActionResult Post(Carrera carrera)
        {
            try
            {
                if (carrera == null)
                {
                    return BadRequest("Datos de carrera incorrectos");
                }
                return Ok(servicio.InsertarCarrera(carrera));
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
        }

        [HttpPut("/carreraPut")]
        public IActionResult Put(Carrera carreraModificada)
        {
            try
            {
                if (carreraModificada == null)
                {
                    return BadRequest("Debe ingresar una carrera como parametro");
                }
                return Ok(servicio.ModificarCarrera(carreraModificada));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno! Intente luego");
            }
            
        }

        [HttpDelete("/CarreraDel")]
        public IActionResult Delete(Carrera carrera)
        {
            if(carrera != null)
            {
                bool result = servicio.DeshabilitarCarrera(carrera);
                return Ok(result);
            }

            return BadRequest("Debe ingresar una carrera como parametro");
        }
    }
}
