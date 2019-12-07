using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesExcepciones
{
    public class DniInvalidoException : Exception
    {
        static string mensajeBase = "ERROR: ";

        public DniInvalidoException()
       : base()
        {
            mensajeBase += "El DNI no esta en un formato correcto";
            Console.WriteLine(mensajeBase);

        }

        public DniInvalidoException(Exception e)
    : this(e.Message)
        {
        }

        public DniInvalidoException(string message)
            : base(message)
        {
        }


        public DniInvalidoException(string message, Exception innerException)
    : base(message, innerException)
        {

        }


        //Meter el if en un try, tirar excepcion para que me lleve al catch y mostrar mensaje
    }
}
