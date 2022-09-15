using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_1_Unidad_1.Dominio
{
    internal class Carrera:ICloneable
    {
        private List<DetalleCarrera> detalles = new List<DetalleCarrera>();

        public string NombreTitulo
        {
            get;
            set;
        }

        public int Cod_carrera
        {
            get;
            set;
        }

        public List<DetalleCarrera> DetallesCarrera
        {
            get { return detalles; }
            set { detalles = value; }
        }

        public bool Deshabilitada
        {
            get;
            set;
        }

        public object Clone()
        {
            Carrera clonCarrera = new Carrera();
            clonCarrera.NombreTitulo = NombreTitulo;
            clonCarrera.Cod_carrera = Cod_carrera;
            clonCarrera.Deshabilitada = Deshabilitada;
            
            for(int i = 0; i < detalles.Count; i++)
            {
                clonCarrera.AgregarDetalle(detalles[i]);
            }
            

            return clonCarrera;
        }

        public override string ToString()
        {
            return "Nombre de carrera: " + NombreTitulo;
        }

        public void AgregarDetalle(DetalleCarrera detalle)
        {
            DetallesCarrera.Add(detalle);
        }

        public void EliminarDetalle(int indice)
        {
            DetallesCarrera.RemoveAt(indice);
        }
    }
}
