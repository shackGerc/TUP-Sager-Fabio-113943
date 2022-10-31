using Aplicacion.Servicios.Implementaciones;
using Aplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public class ImpFabricaServicio : FabricaAbstractaServicio
    {
        public override IServicio CrearServicio()
        {
            return new ServicioCarrera();
        }
    }
}
