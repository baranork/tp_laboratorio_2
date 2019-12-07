using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstracta;

namespace EntidadesInstanciables
{
    public sealed class Profesor : Universitario
    {
        #region ATRIBUTOS

        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion


        #region CONSTRUCTORES

        static Profesor()
        {
            random = new Random();
        }

        public Profesor()
        : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.darClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.darClases();
        }

        #endregion


        #region METODOS
        /// <summary>
        /// Retorna las clases del profesor en un string
        /// </summary>
        /// <returns>Las clases devueltas</returns>
        private string ListarClases()
        {
            string retorno = "";

            foreach (Universidad.EClases element in this.clasesDelDia)
            {
                retorno += "\n";
                retorno += element;
            }

            return retorno;
        }
        /// <summary>
        /// Le asigna 2 clases aleatorias al profesor
        /// </summary>
        private void darClases()
        {
            int i;
            for (i = 0; i < 2; i++)
            {
                this.clasesDelDia.Enqueue((Universidad.EClases)random.Next(4));
            }
        }
        /// <summary>
        /// Verifica si el profesor da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>True o False</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach (Universidad.EClases element in i.clasesDelDia)
            {
                if (element == clase)
                {
                    retorno = true;
                }
            }

            return retorno;
        }
        /// <summary>
        /// Verifica si el profesor da esa clase
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">Clase a verificar</param>
        /// <returns>Si pudo o no</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion


        #region OVERRIDES
        /// <summary>
        /// Retorna un string con las clases que da el profesor
        /// </summary>
        /// <returns>String</returns>
        protected override string ParticiparEnClase()
        {
            string retorno = "CLASES DEL DIA: ";

            retorno += ListarClases();

            return retorno;
        }
        /// <summary>
        /// Concatena los datos del profesor y las clases que da y los devuelve en una string
        /// </summary>
        /// <returns>String devuelta</returns>
        protected override string MostrarDatos()
        {
            return base.MostrarDatos() + ListarClases();
        }
        /// <summary>
        /// Hace publicos los datos del MostrarDatos()
        /// </summary>
        /// <returns>Retorna los datos del MostrarDatos()</returns>
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
    }
}
