using Aplicacion.AccesoDatos.Interfaces;
using Aplicacion.AccesoDatos;
using Aplicacion.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.AccesoDatos.Implementaciones
{
    public class CarreraDAO : ICarreraDAO
    {
        public List<Asignatura> ConsultarAsignaturas()
        {
            DataTable tabla = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_recuperar_asignaturas");
            List<Asignatura> asignaturas = new List<Asignatura>();
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                Asignatura a = new Asignatura();
                if (!tabla.Rows[i].IsNull("Código"))
                    a.Codigo = Convert.ToInt32(tabla.Rows[i]["Código"]);
                if (!tabla.Rows[i].IsNull("Nombre"))
                    a.Nombre = tabla.Rows[i]["Nombre"].ToString();

                asignaturas.Add(a);
            }
            return asignaturas;
        }

        public List<Carrera> ConsultarCarreras()
        {
            List<Carrera> carreras = new List<Carrera>();
            DataTable tablaCarreras = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_consultar_carreras");
            DataTable tablaDetalles = DBHelper.ObtenerInstancia().HacerConsultaConSP("pa_consultar_detalleCarrera");
            int ultimaPosicion = 0;

            for (int i = 0; i < tablaCarreras.Rows.Count; i++)
            {
                Carrera carrera = new Carrera();
                if (!tablaCarreras.Rows[i].IsNull("nombre"))
                {
                    carrera.NombreTitulo = tablaCarreras.Rows[i]["nombre"].ToString();
                }

                if (!tablaCarreras.Rows[i].IsNull("cod_carrera"))
                {
                    carrera.Cod_carrera = Convert.ToInt32(tablaCarreras.Rows[i]["cod_carrera"]);
                }

                if (tablaCarreras.Rows[i].IsNull("bajada_logicamente"))
                {
                    carrera.Deshabilitada = false;
                }
                else
                {
                    carrera.Deshabilitada = (bool)tablaCarreras.Rows[i]["bajada_logicamente"];
                }

                for (int j = ultimaPosicion; j < tablaDetalles.Rows.Count; j++)
                {

                    if (carrera.Cod_carrera ==
                        Convert.ToInt32(tablaDetalles.Rows[j]["cod_carrera"]))
                    {
                        int anioCursado = Convert.ToInt32(tablaDetalles.Rows[j]["anio_cursado"]);
                        int cuatrimestre = Convert.ToInt32(tablaDetalles.Rows[j]["cuatrimestre"]);

                        Asignatura materia = new Asignatura();
                        materia.Codigo = Convert.ToInt32(tablaDetalles.Rows[j]["cod_asignatura"]);
                        materia.Nombre = tablaDetalles.Rows[j]["nombre asignatura"].ToString();

                        DetalleCarrera detalleCarrera = new DetalleCarrera(anioCursado, cuatrimestre,
                            materia);

                        carrera.AgregarDetalle(detalleCarrera);
                    }
                    else
                    {
                        break;
                    }

                    ultimaPosicion = j+1;
                }
                carreras.Add(carrera);
            }
            return carreras;
        }

        public bool DeshabilitarCarrera(Carrera carrera)
        {
            return DBHelper.ObtenerInstancia().actualizarCarreraConSP("pa_actualizar_carrera", carrera);
        }

        public bool InsertarCarrera(Carrera carrera)
        {
            return DBHelper.ObtenerInstancia().InsertarCarreraConSP("pa_insertar_carrera", carrera);
        }

        public bool ModificarCarrera(Carrera carreraModificada)
        {
            DBHelper.ObtenerInstancia().actualizarCarreraConSP("pa_actualizar_carrera", carreraModificada);

            if (DBHelper.ObtenerInstancia().borrarMateriasConSP("pa_borrar_detalles_carrera", carreraModificada.Cod_carrera))
            {
                DBHelper.ObtenerInstancia().InsertarDetallesCarreraConSP("pa_insertar_detalleCarrera", carreraModificada);
                return true;
            }
                
            return false;
        }
    }
}
