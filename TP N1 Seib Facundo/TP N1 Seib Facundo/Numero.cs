using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Numero
    {
        #region ATRIBUTOS

        private double numero;

        #endregion

        #region CONSTRUCTORES

        public Numero()
        {
            numero = 0;
        }

        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        public Numero(double dNumero)
        {
            numero = dNumero;
        }

        #endregion 

        #region PROPIEDADES
        private string SetNumero
        {
            set
            {
                numero = ValidarNumero(value);
            }
        }
        #endregion

        #region METODOS


        double ValidarNumero(string strNumero)
        {
            double num;
            double retorno;

            if (double.TryParse(strNumero, out num))
            {
                retorno = num;
            }
            else
            {
                retorno = 0;
            }

            return retorno;
        }


        public static string BinarioDecimal(string binario)
        {
            int enteroBinario;
            int enteroDecimal;
            string stringDecimal;
            bool respuesta;

            

            if (respuesta = int.TryParse(binario, out enteroBinario))
            {
                try
                {enteroDecimal = Convert.ToInt32(binario, 2);
                stringDecimal = enteroDecimal.ToString();
                }
                catch
                {
                    stringDecimal = binario;
                }
            }
            else
            {
                stringDecimal = "Valor Invalido";
            }

            return stringDecimal;
        }

         public static string DecimalBinario(double numero)
        {
            int entero;
            string binario;

            entero = Convert.ToInt32(numero);
            
            binario = Convert.ToString(entero, 2);

            return binario;
        }

         public static string DecimalBinario(string numero)
        {
            bool respuesta;
            int entero;
            string binario;

            if(respuesta = Int32.TryParse(numero, out entero))
            {
                binario = Convert.ToString(entero, 2);
            }
            else
            {
                binario = "Valor Invalido";
            }

            return binario;
        }

        #region SOBRECARGA DE OPERADORES

        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;
            
            return resultado;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if(n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
              resultado = n1.numero / n2.numero;
            }

            return resultado;
        }
        #endregion
        #endregion
    }
}
