﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class SinProfesorException : Exception
    {
        public SinProfesorException()
    : base("No hay Profesor para la clase.")
        {

        }
    }
}
