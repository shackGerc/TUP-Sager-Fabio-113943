using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1_Unidad_1.Dominio
{
    internal class Asignatura:ICloneable
    {
        public int Codigo 
        {
            get;
            set;
        }

        public string Nombre 
        {
            get;
            set; 
        }

        public object Clone()
        {
            Asignatura clonAsignatura = new Asignatura();
            clonAsignatura.Codigo = Codigo;
            clonAsignatura.Nombre = Nombre;

            return clonAsignatura;
        }

        public override string ToString()
        {
            return "Asignatura: " + Nombre;
        }
    }
}
