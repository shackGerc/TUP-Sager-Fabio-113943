using Aplicacion.AccesoDatos.Implementaciones;
using Aplicacion.AccesoDatos.Interfaces;
using Aplicacion.Dominio;
using Aplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios.Implementaciones
{
    public class ServicioCarrera : IServicio
    {
        private ICarreraDAO DAO;
        public ServicioCarrera()
        {
            DAO = new CarreraDAO();
        }

        public List<Asignatura> ConsultarAsignaturas()
        {
            return DAO.ConsultarAsignaturas();
        }

        public DataTable ConsultarAsignaturasTabla()
        {
            return DAO.ConsultarAsignaturasTabla();
        }

        public List<Carrera> ConsultarCarreras()
        {
            return DAO.ConsultarCarreras();
        }

        public DataTable ConsultarMateriasXCarrera()
        {
            return DAO.ConsultarMateriasXCarrera();
        }

        public bool DeshabilitarCarrera(Carrera carrera)
        {
            return DAO.DeshabilitarCarrera(carrera);
        }

        public bool InsertarCarrera(Carrera carrera)
        {
            return DAO.InsertarCarrera(carrera);
        }

        public bool Login(string nombre, string contrasenia)
        {
            return DAO.Login(nombre, contrasenia);
        }

        public bool ModificarCarrera(Carrera carrera)
        {
            return DAO.ModificarCarrera(carrera);
        }
    }
}
