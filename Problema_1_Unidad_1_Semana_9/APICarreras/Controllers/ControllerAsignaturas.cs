using Aplicacion.Dominio;
using Aplicacion.Servicios;
using Aplicacion.Servicios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;

namespace APICarreras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControllerAsignaturas : ControllerBase
    {
        private IServicio servicio;

        public ControllerAsignaturas()
        {
            servicio = new ImpFabricaServicio().CrearServicio();
        }
        
        [HttpGet]
        public List<Asignatura> Get()
        {
            return servicio.ConsultarAsignaturas();
        }

        [HttpGet("/getTabla")]
        public IActionResult GetAsignaturasTabla()
        {
            return Ok(JsonConvert.SerializeObject(servicio.ConsultarAsignaturasTabla()));
        }
    }
}
