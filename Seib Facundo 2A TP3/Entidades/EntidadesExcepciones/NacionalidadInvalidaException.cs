using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
            Console.WriteLine("La nacionalidad no se coincide con el número de DNI");
            
        }
        public NacionalidadInvalidaException(string message)
        {
            Console.WriteLine("El numero de DNI y la Nacionalidad " + message +  " son incompatibles");
            
        }
    }
}
