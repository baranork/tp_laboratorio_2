using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class AlumnoRepetidoException : Exception
    {
       public AlumnoRepetidoException()
            :base("Alumno Repetido")
        {
            
            
        }

        //public AlumnoRepetidoException(Exception e)
        //{
        //    Console.WriteLine(e.Message);
        //    Console.ReadKey();
        //}
    }
}
