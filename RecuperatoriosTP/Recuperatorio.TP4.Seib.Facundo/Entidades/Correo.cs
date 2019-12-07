using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }

            set
            {
                this.paquetes = value;
            }
        }

        /// <summary>
        /// Constructor de instancia para las listas de Correo
        /// </summary>
        public Correo()
        {
            this.paquetes = new List<Paquete>();
            this.mockPaquetes = new List<Thread>();
        }
        /// <summary>
        /// Aborta todos los hilos creados en Correo.mockPaquetes
        /// </summary>
        public void FinEntrega()
        {
            foreach(Thread element in this.mockPaquetes)
            {
                element.Abort();
            }
        }
        /// <summary>
        /// Agrega un paquete a la lista de paquetes de correo si y solo si el Tracking ID de p no se encuentra en la lista de c
        /// Ademas crea un hilo y lo agrega a la lista de hilos de c
        /// </summary>
        /// <param name="c">Parametro tipo Correo</param>
        /// <param name="p">Parametro tipo Paquete</param>
        /// <returns>Retorna el correo "c"</returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            if(c.paquetes.Count > 0)
            {
                foreach (Paquete element in c.paquetes)
                {
                    if (element == p)
                    {
                        throw new TrackingIdRepetidoException("El paquete ya se encuentra ingresado");
                    }
                }
            }
                Thread hilo = new Thread(p.MockCicloDeVida);
                c.paquetes.Add(p);
                c.mockPaquetes.Add(hilo);
                hilo.Start();
            
            return c;
        }
        /// <summary>
        /// Muestra los datos de todos los paquetes en la lista de "Elemento" si y solo si es de tipo "correo"
        /// </summary>
        /// <param name="elemento">Elemento Generico de la interfaz</param>
        /// <returns>Retorna una string con todos los datos</returns>
        string IMostrar<List<Paquete>>.MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            

            StringBuilder sb = new StringBuilder();

            if(!(object.Equals(elemento, null)) && elemento is Correo)
            {
                List<Paquete> lista = ((Correo)elemento).Paquetes;
                foreach(Paquete element in lista)
                {
                    sb.AppendLine(element.TrackingID + " para " + element.DireccionEntrega + " (" + element.Estado + ")"); 
                }
            }


            return sb.ToString();
        }
    }
}
