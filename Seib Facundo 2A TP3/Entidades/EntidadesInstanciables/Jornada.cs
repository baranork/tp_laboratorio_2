using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Entidades
{
    public class Jornada
    {
        #region ATRIBUTOS

        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #endregion


        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }

            set
            {
                this.alumnos = new List<Alumno>(value);
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }

            set
            {
                this.clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }

            set
            {
                this.instructor = value;
            }
        }

        #endregion


        #region CONSTRUCTORES

        private Jornada()
        {
            this.Alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
        {
            this.Clase = clase;
            this.Instructor = instructor;
            this.Alumnos = new List<Alumno>();
        }
        #endregion


        #region METODOS
        /// <summary>
        /// Verifica si el alumno está ya ingresado en la jornada
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Si esta o no</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno element in j.Alumnos)
            {
                if(element == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Verifica si el alumno está ya ingresado en la jornada
        /// </summary>
        /// <param name="j"></param>
        /// <param name="a"></param>
        /// <returns>Si esta o no</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Agrega un alumno a la jornada si no lo está y si no es nulo
        /// </summary>
        /// <param name="j">Jornada receptora</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>La jornada</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                if(a != null)
                {
                    j.Alumnos.Add(a);
                }
               
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }
        /// <summary>
        /// Lee los datos de una jornada desde un archivo de texto
        /// </summary>
        /// <returns>Los datos del archivo</returns>
        public string Leer()
        {
            string jornada = null;
            Texto datos = new Texto();
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo directorioPadre = directoryInfo.Parent;

            datos.Leer(directorioPadre + @"Jornada.txt", out jornada);

            return jornada;
        }
        /// <summary>
        /// Guarda los datos de la jornada en un archivo de texto
        /// </summary>
        /// <param name="jornada">La jornada a guardar</param>
        /// <returns>Si se pudo o no guardar</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool retorno = false;
            Texto datos = new Texto();
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo directorioPadre = directoryInfo.Parent;
            

            if(datos.Guardar(directorioPadre + @"\Jornada.txt", jornada.ToString()))
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion


        #region OVERRIDES

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        /// <summary>
        /// Crea un override de To String Para mostrar todos los datos de la jornada
        /// </summary>
        /// <returns>Todos los datos en un string</returns>
        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append("CLASE DE " + this.Clase + " ");
            retorno.AppendLine("POR " + this.Instructor + "\n");
            retorno.AppendLine("ALUMNOS: ");

            foreach (Alumno element in this.Alumnos)
            {
                retorno.Append(element);
            }

            retorno.AppendLine("<------------------------------->");

            return retorno.ToString();
        }

        #endregion
    }
}
