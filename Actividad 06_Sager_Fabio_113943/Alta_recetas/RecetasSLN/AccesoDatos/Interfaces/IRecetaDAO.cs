using RecetasSLN.dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.AccesoDatos.Interfaces
{
    internal interface IRecetaDAO
    {
        bool CargarReceta(Receta r);
        int ObtenerIDProxReceta();
        DataTable ObtenerIngredientes();
        DataTable ObtenerTiposRecetas();
        List<Receta> ObtenerRecetasConFiltros(int tipo, string nombre);
    }
}
