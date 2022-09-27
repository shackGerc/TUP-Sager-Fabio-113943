using RecetasSLN.dominio;
using System.Collections.Generic;
using System.Data;

namespace RecetasSLN.Servicios.Interfaces
{
    internal interface IServicio
    {
        bool CargarReceta(Receta r);
        int ObtenerIDproxReceta();
        DataTable ObtenerIngredientes();
        DataTable ObtenerTiposRecetas();
        List<Receta> ObtenerRecetasConFiltros(int tipo, string nombre);
    }
}
