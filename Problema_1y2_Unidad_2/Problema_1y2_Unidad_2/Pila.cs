using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1y2_Unidad_2
{
    internal class Pila : IColeccion
    {
        private Object[] pila;
        int ultimo = 0;

        public Pila(int tamanio)
        {
            pila = new Object[tamanio];
        }

        public bool EstaVacia()
        {
            bool estaVacia = true;
            
            if(pila.Length != 0)
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
                objetoExtraido = pila[ultimo-1];
                pila[ultimo-1] = null;
                ultimo--;
            }
            return objetoExtraido;
        }

        public Object Primero()
        {
            Object objetoExtraido = null;
            if (!EstaVacia())
            {
                objetoExtraido = pila[ultimo-1];
            }
            return objetoExtraido;
        }
        
        public bool Aniadir(Object item)
        {
            bool seAgrego = true;
            try
            {
                pila[ultimo] = item;
                ultimo++;
            }
            catch (Exception)
            {
                seAgrego = false;
            }

            return seAgrego;
        }
    }
}
