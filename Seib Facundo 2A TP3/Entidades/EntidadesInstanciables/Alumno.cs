using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public sealed class Alumno : Universitario
    {
        #region ATRIBUTOS

        Universidad.EClases claseQueToma;
        EEstadoCuenta estadoCuenta;

        #endregion

        #region CONSTRUCTORES

        public Alumno() : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
        :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
        :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
            this.estadoCuenta = estadoCuenta;
        }

        #endregion

        #region METODOS
        /// <summary>
        /// Verifica si el alumno toma la clase a la que se iguala
        /// Y si lo hace y no tiene un estado de cuenta de Deudor retorna un bool positivo
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna el booleano correspondiente</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                retorno = true;
            }

            return retorno;
        }
        /// <summary>
        /// Verifica que el alumno NO tome la clase a la que se iguala
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>Retorna un booleano correspondiente</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool retorno = false;

            if (a.claseQueToma != clase)
            {
                retorno = true;
            }

            return retorno;
        }

        #endregion

        #region OVERRIDES
        /// <summary>
        /// Vuelca todos los datos del alumno en una cadena de texto
        /// </summary>
        /// <returns>Retorna la string con los datos</returns>
        protected override string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("ESTADO DE CUENTA: " + this.estadoCuenta);
            stringBuilder.AppendLine("TOMA CLASES DE " + this.claseQueToma);
            stringBuilder.AppendLine();

            return base.MostrarDatos() + stringBuilder.ToString();
        }
        /// <summary>
        /// Crea una string con las clases tomadas por el alumno
        /// </summary>
        /// <returns>Retorna la string</returns>
        protected override string ParticiparEnClase()
        {
            return "TOMA CLASE DE " + this.claseQueToma + "\n\n";
        }
        /// <summary>
        /// Hace publico los datos del MostrarDatos()
        /// </summary>
        /// <returns>Retorna la string de MostrarDatos()</returns>
        public override string ToString()
        {
            return MostrarDatos();
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

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }
    }
}
