using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using EntidadesExcepciones;

namespace EntidadesArchivos
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
            catch (Exception error)
            {
                throw new EntidadesExcepciones.ArchivosException(error);
            }

            return retorno;
        }

        public bool Leer(string archivo, out T datos)
        {
            bool retorno = false;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StreamReader(archivo))
                {
                    datos = (T)serializer.Deserialize(reader);
                    retorno = true;
                }
            }
            catch (Exception error)
            {
                throw new EntidadesExcepciones.ArchivosException(error);
            }

            return retorno;
        }
    }
}
