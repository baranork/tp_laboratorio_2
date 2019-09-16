using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public static class Calculadora
    {
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            double resultado = 0;
            operador = ValidarOperador(operador);

            if(operador == "+")
            {
               resultado = num1 + num2;
            }
            else if(operador == "/")
            {
                resultado = num1 / num2;
            }
            else if(operador == "-")
            {
                resultado = num1 - num2;
            }
            else if(operador == "*")
            {
                resultado = num1 * num2;
            }
            return resultado;
        }

        private static string ValidarOperador(string operador)
        {
            string retorno = "+";
            if (operador == "*")
            {
                retorno = "*";
            }
            else if (operador == "-")
            {
                retorno = "-";
            }
            else if (operador == "/")
            {
                retorno = "/";
            }
            else
            {
                retorno = "+";
            }
            return retorno;
        }


    }

}
