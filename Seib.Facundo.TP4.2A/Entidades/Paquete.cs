using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado   
        }

        public delegate void DelegadoEstado(object emisor, EventArgs eventArgs);
        public event DelegadoEstado InformaEstado;  

        #region PROPIEDADES

        public string DireccionEntrega
        {
            get
            {
                return this.direccionEntrega;
            }

            set
            {
                this.direccionEntrega = value;
            }
        }

        public EEstado Estado
        {
            get
            {
                return this.estado;
            }

            set
            {
                this.estado = value;
            }
        }

        public string TrackingID
        {
            get
            {
                return this.trackingID;
            }

            set
            {
                this.trackingID = value;
            }
        }

        #endregion

        /// <summary>
        /// Constructor parametrizado de Paquete. Ademas de instanciar parametros siempre instancia el estado como "Ingresado"
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.Estado = EEstado.Ingresado;
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
        }

        /// <summary>
        /// Crea un ciclo de vida del paquete. Cambiando su estado, informandolo mediante evento e insertandolo en la tabla 
        /// de la base de datos. Siempre llamando a los metodos correspondientes
        /// </summary>
        public void MockCicloDeVida()
        {
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);
                this.Estado += 1;
                this.InformaEstado(this, new EventArgs());
            }

            
            PaqueteDAO.Insertar(this);
        }

        /// <summary>
        /// Devuelve true si los Tracking ID's de p1 y p2 son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool r = false;

            if(!(p1 is null || p2 is null))
            {
                if (p1.TrackingID == p2.TrackingID)
                {
                    r = true;
                }
            }
            return r;
        }
        /// <summary>
        /// Devuelve false si los Tracking ID's de p1 y p2 son iguales
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Muestra los datos del elemento generico si y solo si es de tipo "paquete"
        /// </summary>
        /// <param name="elemento">Elemento generico de Interfaz</param>
        /// <returns>Retorna un string con los datos del paquete en cuestion</returns>
        string IMostrar<Paquete>.MostrarDatos(IMostrar<Paquete> elemento)
        {
            StringBuilder sb = new StringBuilder();

            if(!object.Equals(elemento, null) && elemento is Paquete)
            {
                Paquete algo = (Paquete)elemento;
                sb.AppendLine(algo.TrackingID + " para " + algo.DireccionEntrega);
            }

             return sb.ToString();

        }


        /// <summary>
        /// Override de Paquete cual muestra todos los datos de este
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.TrackingID + " para " + this.DireccionEntrega + " (" + this.estado + ")";
        }


        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
