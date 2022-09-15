using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1y2_Unidad_2
{
    internal interface IColeccion
    {
        bool EstaVacia();
        Object Extraer();
        Object Primero();
        bool Aniadir(Object item);
    }
}
