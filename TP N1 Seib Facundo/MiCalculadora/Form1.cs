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




namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        private bool botonABinarioFueApretado = false;
        public FormCalculadora()
        {
            InitializeComponent();
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
       
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            string binario;
            string numero = lblResultado.Text.ToString();
            double numerito;

            if (!botonABinarioFueApretado)
            {
                if (double.TryParse(numero, out numerito))
                {
                    binario = Numero.DecimalBinario(numerito);

                    lblResultado.Text = binario.ToString();

                    botonABinarioFueApretado = true;
                }
            }         



        }

        private void ConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero;
            string binario = lblResultado.Text.ToString();

            numero = Numero.BinarioDecimal(binario);

            lblResultado.Text = numero;
            botonABinarioFueApretado = false;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            string numero1 = this.txtNumero1.Text;
            string numero2 = this.txtNumero2.Text;
            string operador = this.cmbOperador.Text;
            double resultado = Operar(numero1, numero2, operador);

            lblResultado.Text = resultado.ToString();
            botonABinarioFueApretado = false;
        }

        private void Limpiar()
        {
            txtNumero1.Clear();
            txtNumero2.Clear();
            lblResultado.Text = "";
            cmbOperador.SelectedIndex = -1;
        }

        public static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;

            Numero numeroUno = new Numero(numero1);
            Numero numeroDos = new Numero(numero2);

            resultado = Calculadora.Operar(numeroUno, numeroDos, operador);
            return resultado;
        }

    }
}
