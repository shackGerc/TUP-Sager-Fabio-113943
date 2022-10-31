using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio
{
    public class DetalleCarrera
    {
        public int Cuatrimestre
        {
            get;
            set;
        }

        public int AnioCursado
        {
            get;
            set;
        }

        public Asignatura Materia
        {
            set;
            get;
        }

        public DetalleCarrera()
        {
            AnioCursado = 0;
            Cuatrimestre = 0;
            Materia = null;
        }

        public DetalleCarrera(int anioCursado, int cuatrimestre,
            Asignatura asignatura)
        {
            AnioCursado = anioCursado;
            Cuatrimestre = cuatrimestre;
            Materia = asignatura;
        }

        public override string ToString()
        {
            return "Año cursado: " + AnioCursado + " | Cuatrimestre: " + Cuatrimestre +
                " | " + Materia.ToString();
        }
    }
}
