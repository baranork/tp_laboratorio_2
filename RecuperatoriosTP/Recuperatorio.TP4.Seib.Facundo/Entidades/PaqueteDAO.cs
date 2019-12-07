using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Data;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Entidades
{
    public static class PaqueteDAO
    {
        static SqlCommand sqlCommand;
        static SqlConnection sql;
        /// <summary>
        /// Constructor de PaqueteDAO. Inicializa las conexiones y comandos del sql
        /// </summary>
        static PaqueteDAO()
        {
            sql = new SqlConnection(Properties.Settings.Default.conexion);
            sqlCommand = new SqlCommand();
        }
        /// <summary>
        /// Trata de insertar el paquete recibido en la base de datos. Si no lo logra muestra un mensaje con el error
        /// </summary>
        /// <param name="p">Paquete a insertar</param>
        /// <returns>Devuelve si se pudo o no cargar el paquete</returns>
        public static bool Insertar(Paquete p)
        {
            bool retorno = false;
            string alumno = "Facundo Seib";

            try
            {
                sql = new SqlConnection(Properties.Settings.Default.conexion);
                sqlCommand = new SqlCommand();
                sql.Open();
                sqlCommand.Connection = sql;
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = "INSERT INTO paquetes(direccionEntrega, trackingID, alumno) values (@direccionEntrega, @trackingID, @alumno)";
                sqlCommand.Parameters.AddWithValue("@direccionEntrega", p.DireccionEntrega);
                sqlCommand.Parameters.AddWithValue("@trackingID", p.TrackingID);
                sqlCommand.Parameters.AddWithValue("@alumno", alumno);
                sqlCommand.ExecuteNonQuery();
                sql.Close();

                retorno = true;
            }
            catch
            {
                MessageBox.Show("Error al cargar datos a la base de datos");
            }
            return retorno;                
        }
    }
}
