using Aplicacion.Servicios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Servicios
{
    public abstract class FabricaAbstractaServicio
    {
        public abstract IServicio CrearServicio();
    }
}
