using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    public class Ingrediente
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int Unidad { get; set; }

        public Ingrediente()
        {
            ID = 0;
            Nombre = string.Empty;
        }

        public Ingrediente(int iD, string nombre, int unidad)
        {
            ID=iD;
            Nombre=nombre;
            Unidad=unidad;
        }
    }
}
