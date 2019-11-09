using System;
using System.Text;

namespace Entidades
{
    public abstract class Persona
    {

        #region ATRIBUTOS

        private string apellido;
        private string nombre;
        private int dni;
        private ENacionalidad nacionalidad;

        #endregion


        #region PROPIEDADES

        public string Apellido
        {
            get
            {  return this.apellido;  }
            set
            {  this.apellido = ValidarNombreApellido(value);  }
        }

        public int DNI
        {
            get
            { return this.dni; }
            set
            {
                this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public string Nombre
        {
            get
            { return this.nombre; }
            set
            { this.nombre = ValidarNombreApellido(value); }
        }

        public ENacionalidad Nacionalidad
        {
            get
            { return this.nacionalidad; }
            set
            { this.nacionalidad = value; }
        }

        public string StringToDNI
        {
            set
            {
                int dni = ValidarDni(this.nacionalidad, value);
                this.dni = dni;
            }
        }
        #endregion 


        #region CONSTRUCTORES

        public Persona()
        {
            this.Apellido = "";
            this.Nacionalidad = ENacionalidad.Argentino;
            this.Nombre = "";
            this.DNI = 1;
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        :this()
        {
            this.Apellido = apellido;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        :this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        :this(nombre, apellido, nacionalidad)
        {
            StringToDNI = dni;
        }

        #endregion


        #region METODOS
        /// <summary>
        /// Crea una string con los datos de la persona
        /// </summary>
        /// <returns>Retorna la string</returns>
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("NOMBRE COMPLETO: " + Apellido + ", " + Nombre);
            stringBuilder.AppendLine("NACIONALIDAD: " + Nacionalidad);

            return stringBuilder.ToString();
        }
        /// <summary>
        /// Valida que el DNI sea correspondiente a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI en entero</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            dni = ValidarDni(nacionalidad, dato.ToString());
            return dni;
        }
        /// <summary>
        /// Valida que el DNI sea correspondiente a la nacionalidad y lo parsea a entero si puede
        /// </summary>
        /// <param name="nacionalidad">Nacionalidad</param>
        /// <param name="dato">DNI en string</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            bool pudo = false;
            try
            {
                pudo = int.TryParse(dato, out dni);

                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if(dni < 1 || dni > 89999999)
                        {
                            throw new NacionalidadInvalidaException("argentina");
                        }
                        break;
                    case ENacionalidad.Extranjero:
                        if(dni < 90000000 || dni > 99999999)
                        {
                            throw new NacionalidadInvalidaException("extranjera");
                        }
                        break;
                }

            }
            catch
            {
                if(pudo != true)
                {
                    throw new DniInvalidoException("");
                }
                dni = 0;
            }
            
            return dni;
        }
        /// <summary>
        /// Valida que ni el nombre ni el apellido pasado tenga numeros o sea inválido
        /// </summary>
        /// <param name="dato">Apellido o Nombre</param>
        /// <returns>retorna la string del nombre o una string vacia si es invalida</returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = dato;
            foreach(char c in dato)
            {
                int nada;
                if (int.TryParse(c.ToString(), out nada))
                {
                    retorno = "";
                }
                    
            }
            return retorno;
        }
        #endregion

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
    }
}
