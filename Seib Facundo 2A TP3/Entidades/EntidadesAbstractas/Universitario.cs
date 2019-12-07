using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
     abstract public class Universitario : Persona
    {
        #region ATRIBUTOS

        private int legajo;

        #endregion


        #region CONSTRUCTORES
        public Universitario()
        :base()
        {
            this.legajo = 0;
        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        :base(nombre, apellido, dni , nacionalidad)
        {
            this.legajo = legajo;
        }

        #endregion


        #region METODOS
        /// <summary>
        /// Crea una string con los datos del Universitario y los concatena con los de la persona
        /// </summary>
        /// <returns>Retorna la string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("LEGAJO NÚMERO: " + legajo);

            return base.ToString() + stringBuilder.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(null, obj))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        /// <summary>
        /// Verifica que el universitario 1 y el 2 sean del mismo tipo y que sean
        /// iguales por DNI o legajo
        /// </summary>
        /// <param name="pg1">Universitario 1</param>
        /// <param name="pg2">Universitario 2</param>
        /// <returns>Retorna un bool true si son iguales, false en caso contrario</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false; 

            if(pg1 is Profesor && pg2 is Profesor)
            {
                if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    retorno = true;
                }
            }
            else if(pg1 is Alumno && pg2 is Alumno)
            {
                if(pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
                {
                    retorno = true;
                }
            }

            return retorno;
        }

        #endregion
    }
}
