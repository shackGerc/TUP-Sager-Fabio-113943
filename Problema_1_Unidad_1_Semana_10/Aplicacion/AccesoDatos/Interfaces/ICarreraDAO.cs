using Aplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AccesoDatos.Interfaces
{
    public interface ICarreraDAO
    {
        public List<Carrera> ConsultarCarreras();
        public List<Asignatura> ConsultarAsignaturas();
        public bool ModificarCarrera(Carrera carrera);
        public bool InsertarCarrera(Carrera carrera);
        public bool DeshabilitarCarrera(Carrera carrera);
    }
}
