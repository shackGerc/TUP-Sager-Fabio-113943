using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1y2_Unidad_2
{
    internal class Cola : IColeccion
    {
        private List<Object> cola = new List<object>();

        public bool EstaVacia()
        {
            bool estaVacia = true;

            if (cola.Count != 0)
            {
                estaVacia = false;
            }

            return estaVacia;
        }

        public Object Extraer()
        {
            Object objetoExtraido = null;
            if (!EstaVacia())
            {
                objetoExtraido = cola.First();
                cola.Remove(objetoExtraido);
            }
            return objetoExtraido;
        }

        public Object Primero()
        {
            Object objetoExtraido = null;
            if (!EstaVacia())
            {
                objetoExtraido = cola.First();
            }
            return objetoExtraido;
        }

        public bool Aniadir(Object item)
        {
            bool seAgrego = true;
            try
            {
                cola.Add(item);
            }
            catch (Exception)
            {
                seAgrego = false;
            }

            return seAgrego;
        }
    }
}
