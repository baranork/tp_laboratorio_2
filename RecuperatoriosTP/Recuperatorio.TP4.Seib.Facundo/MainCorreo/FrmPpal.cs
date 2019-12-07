using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private Correo correo;
        public FrmPpal()
        {
            InitializeComponent();
            this.correo = new Correo();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Paquete nuevoPaquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
                if(nuevoPaquete != null)
                {
                    nuevoPaquete.InformaEstado += new Paquete.DelegadoEstado(paq_InformaEstado);
                    this.correo += nuevoPaquete;
                    this.ActualizarEstados();
                   
                }

            }
            catch (TrackingIdRepetidoException error)
            {
                MessageBox.Show(error.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }

            this.txtDireccion.Clear();
            this.mtxtTrackingID.Clear();
        }



        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void ActualizarEstados()
        {
            lstEntregado.Items.Clear();
            lstEnViaje.Items.Clear();
            lstIngresado.Items.Clear();

            foreach (Paquete element in this.correo.Paquetes)
            {
                if (element.Estado == Paquete.EEstado.Entregado)
                {
                    
                    lstEntregado.Items.Add(element);
                }
                else if (element.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEnViaje.Items.Add(element);
                }
                else if (element.Estado == Paquete.EEstado.Ingresado)
                {

                    lstIngresado.Items.Add(element);
                }
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if(!(object.Equals(elemento, null)))
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                GuardaString.Guardar(elemento.MostrarDatos(elemento), "salida.txt");
            }
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEntregado.SelectedItem);
        }

        private void MtxtTrackingID_Click(object sender, EventArgs e)
        {
            mtxtTrackingID.SelectionStart = 0;
        }

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntrega();
        }

        private void CmsListas_Opening(object sender, CancelEventArgs e)
        {

        }
    }
}
