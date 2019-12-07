<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Entidades
{
    public static class GuardaString
    {   
        /// <summary>
        /// Guarda el string enviado en un archivo en el escritorio con el nombre de archivo
        /// </summary>
        /// <param name="texto">Texto a guardar en el archivo</param>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <returns>Retorna true si fue posible</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    sw.WriteLine(texto);
                    retorno = true;
                }
            }
            catch
            {
                throw new Exception("No se pudo guardar el archivo");
            }

            return retorno;
        }
    }
}
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Entidades
{
    public static class GuardaString
    {   
        /// <summary>
        /// Guarda el string enviado en un archivo en el escritorio con el nombre de archivo
        /// </summary>
        /// <param name="texto">Texto a guardar en el archivo</param>
        /// <param name="archivo">Nombre del archivo a guardar</param>
        /// <returns>Retorna true si fue posible</returns>
        public static bool Guardar(this string texto, string archivo)
        {
            bool retorno = false;

            try
            {
                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + archivo, true))
                {
                    sw.WriteLine(texto);
                    retorno = true;
                }
            }
            catch
            {
                throw new Exception("No se pudo guardar el archivo");
            }

            return retorno;
        }
    }
}
>>>>>>> ee9bbf0cb6f34fe2b849ef010570f783045a7e22
