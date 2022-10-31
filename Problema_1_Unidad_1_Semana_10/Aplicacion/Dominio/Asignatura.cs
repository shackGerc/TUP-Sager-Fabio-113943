﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion.Dominio
{
    public class Asignatura
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

        public override string ToString()
        {
            return "Asignatura: " + Nombre;
        }
    }
}
