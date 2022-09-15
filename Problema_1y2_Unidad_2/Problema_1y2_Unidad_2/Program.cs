using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1y2_Unidad_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cola cola = new Cola();
            Pila pila = new Pila(2);
            
            cola.Aniadir(1);
            cola.Aniadir("hola");

            Console.WriteLine(cola.Extraer());
            cola.Primero();
            Console.WriteLine(cola.EstaVacia());

            pila.Aniadir(1);
            pila.Aniadir("hola");
            Console.WriteLine(pila.Extraer());

        }
    }
}
