using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Entidades
{
    public class Universidad
    {
        #region ATRIBUTOS

        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        #endregion

        #region PROPIEDADES

        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }

            set { this.alumnos = new List<Alumno>(value); }
        }

        public List<Profesor> Profesores
        {
            get { return this.profesores; }

            set { this.profesores = new List<Profesor>(value); }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }

            set { this.jornada = new List<Jornada>(value); }
        }

        public Jornada this[int i]
        {
            get { return this.jornada[i]; }

            set { this.jornada[i] = value; }
        }



        #endregion


        #region METODOS

        public Universidad()
        {
            Alumnos = new List<Alumno>();
            Jornadas = new List<Jornada>();
            Profesores = new List<Profesor>();
        }
        /// <summary>
        /// Guarda los datos de una universidad en un archivo XML
        /// </summary>
        /// <param name="uni">Universidad elefida</param>
        /// <returns>Si se pudo o no guardar</returns>
        public static bool Guardar(Universidad uni)
        {
            bool retorno = false;
            Xml<Universidad> archivoGuardado = new Xml<Universidad>();
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo directorioPadre = directoryInfo.Parent;

            if (archivoGuardado.Guardar(directorioPadre + @"\Universidad.xml", uni))
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Lee los datos de una universidad desde un archivo XML
        /// </summary>
        /// <returns>La universidad</returns>
        public Universidad Leer()
        {
            Universidad universidadCargada = null;
            Xml<Universidad> archivoCargado = new Xml<Universidad>();
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DirectoryInfo directorioPadre = directoryInfo.Parent;

            archivoCargado.Leer(directorioPadre + @"\Universidad.xml", out universidadCargada);

            return universidadCargada;
        }
        /// <summary>
        /// Vuelca todos los datos de la universidad en una cadena de texto
        /// </summary>
        /// <param name="uni">Universidad pasada</param>
        /// <returns>Cadena de texto cargada</returns>
        private string MostrarDatos(Universidad uni)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("JORNADA: ");
            foreach(Jornada element in uni.Jornadas)
            {
                stringBuilder.AppendLine(element.ToString());
            }
            return stringBuilder.ToString();
        }
        /// <summary>
        ///  Indica si el alumno está cargado en la lista de alumnos de la universidad o no
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Booleano de respuesta</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Indica si el alumno está cargado en la lista de alumnos de la universidad o no
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno a verificar</param>
        /// <returns>Booleano de respuesta</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool retorno = false;

            foreach(Alumno element in g.Alumnos)
            {
                if(element == a)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Indica si el profesor se encuentra cargado en la lista de la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor a verificar</param>
        /// <returns>Booleano de respuesta</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Indica si el profesor se encuentra cargado en la lista de la universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor a verificar</param>
        /// <returns>Booleano de respuesta</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool retorno = false;

            foreach(Profesor element in g.Profesores)
            {
                if(element == i)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Busca un profesor en la universidad que no pueda dar la clase y lo retorna
        /// </summary>
        /// <param name="u">Universidad </param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Retorna el primer profesor que no pueda dar la clase</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            bool flag = false;
            Profesor retorno = null;

            foreach(Profesor element in u.profesores)
            {
                if(element != clase && flag == false)
                {
                    retorno = element;
                    flag = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Busca y retorna el primer profesor en la universidad que pueda dar la clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns></returns>
        public static Profesor operator ==(Universidad g, EClases clase)
        {
            bool flag = false;
            Profesor retorno = null;

            foreach(Profesor element in g.profesores)
            {
                if(element == clase && flag == false)
                {
                    retorno = element;
                    flag = true;
                }
            }

            if(flag == false || retorno == null)
            {
                throw new Excepciones.SinProfesorException();
            }
            else
            {
                return retorno;
            }
            
        }
        /// <summary>
        /// Crea una jornada, agrega la clase a la jornada, busca un profesor disponible en la universidad para dar
        /// la clase y agrega todos los alumnos que vayan a tomar la clase
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna la universidad con la jornada creada y cargada</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Profesor profesorDeJornada = g == clase;

            Jornada jornada = new Jornada(clase, profesorDeJornada);
            foreach(Alumno element in g.Alumnos)
            {
                if(element == clase)
                {
                    jornada += element;
                }
            }

            g.Jornadas.Add(jornada);
            return g;
        }
        /// <summary>
        /// Agrega un alumno a la universidad verificando que no este anteriormente
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Retorna la universidad con el alumno cargado o da una excepcion</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            bool flag = false;

            foreach (Alumno element in u.alumnos)
            {
                if (element == a)
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return u;
        }
        /// <summary>
        /// Agrega un profesor a la universidad verificando que no este anteriormente
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Retorna la universidad con el alumno cargado o da una excepcion</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            bool flag = false;

            foreach (Profesor element in u.profesores)
            {
                if(element == i)
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                u.profesores.Add(i);
            }
            return u;
        }



        #endregion

        #region OVERRIDES
        /// <summary>
        /// Hace publicos los datos del MostrarDatos()
        /// </summary>
        /// <returns>retorna un string con los datos de MostrarDatos()</returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }
    }
}
