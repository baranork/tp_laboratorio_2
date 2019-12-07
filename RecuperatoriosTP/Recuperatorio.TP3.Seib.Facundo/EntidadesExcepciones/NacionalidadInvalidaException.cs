using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException()
        {
            Console.WriteLine("La nacionalidad no se coincide con el número de DNI");

        }
        public NacionalidadInvalidaException(string message)
        {
            Console.WriteLine("El numero de DNI y la Nacionalidad " + message + " son incompatibles");

        }
    }
}
