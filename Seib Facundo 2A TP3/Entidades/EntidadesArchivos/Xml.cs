using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    public class Xml<T> : IArchivo<T>
    {
        public bool Guardar(string archivo, T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextWriter writer = new StreamWriter(archivo))
                {
                    serializer.Serialize(writer, datos);
                    retorno = true;
                }
            }
            catch(Exception error)
            {
                throw new Excepciones.ArchivosException(error);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using(TextReader reader = new StreamReader(archivo))
                {
                    datos = (T)serializer.Deserialize(reader);
                    retorno = true;
                }
            }
            catch(Exception error)
            {
                throw new Excepciones.ArchivosException(error);
            }

            return retorno;
        }
    }
}
