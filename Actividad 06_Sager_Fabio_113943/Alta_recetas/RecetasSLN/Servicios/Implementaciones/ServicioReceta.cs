using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecetasSLN.AccesoDatos.Implementaciones;
using RecetasSLN.AccesoDatos.Interfaces;
using RecetasSLN.dominio;
using RecetasSLN.Servicios.Interfaces;

namespace RecetasSLN.Servicios.Implementaciones
{
    internal class ServicioReceta : IServicio
    {
        public bool CargarReceta(Receta r)
        {
            return RecetaDAO.ObtenerInstancia().CargarReceta(r);
        }

        public DataTable ObtenerIngredientes()
        {
            return RecetaDAO.ObtenerInstancia().ObtenerIngredientes();
        }

        public int ObtenerIDproxReceta()
        {
            return RecetaDAO.ObtenerInstancia().ObtenerIDProxReceta();
        }

        public DataTable ObtenerTiposRecetas()
        {
            return RecetaDAO.ObtenerInstancia().ObtenerTiposRecetas();
        }

        public List<Receta> ObtenerRecetasConFiltros(int tipo, string nombre)
        {
            return RecetaDAO.ObtenerInstancia().ObtenerRecetasConFiltros(tipo, nombre);
        }
    }
}
