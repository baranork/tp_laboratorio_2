using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Texto : IArchivo<string>
    {
        public bool Guardar(string archivo, string datos)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(datos);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new Excepciones.ArchivosException(error);
            }

            return retorno;
        }

        public bool Leer(string archivo, out string datos)
        {
            bool retorno = false;
            datos = null;

            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadToEnd();
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new Excepciones.ArchivosException(error);
            }

            return retorno;
        }
    }
}
