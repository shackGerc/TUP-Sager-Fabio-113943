using Aplicacion.Dominio;
using Aplicacion.Servicios;
using Aplicacion.Servicios.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

        // GET: api/<ControllerCarreras>
        [HttpGet]
        public List<Carrera> Get()
        {
            return servicio.ConsultarCarreras();
        }

        // POST api/<ControllerCarreras>
        [HttpPost]
        public IActionResult Post(Carrera carrera)
        {
            if (carrera != null)
            {
                bool result = servicio.InsertarCarrera(carrera);
                return (Ok(result));
            }

            return BadRequest("Debe ingresar una carrera como parametro");
        }

        // PUT api/<ControllerCarreras>/5
        [HttpPut("/carrera")]
        public IActionResult Put(Carrera carreraModificada)
        {
            if (carreraModificada != null)
            {
                bool result = servicio.ModificarCarrera(carreraModificada);
                return Ok(result);
            }
            return BadRequest("Debe ingresar una carrera como parametro");
        }

        // DELETE api/<ControllerCarreras>/5
        [HttpDelete]
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
