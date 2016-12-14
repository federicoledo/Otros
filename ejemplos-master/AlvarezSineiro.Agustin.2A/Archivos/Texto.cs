using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using System.IO;

namespace Archivos
{
    public class Texto:IArchivo<string>
    {
        public bool guardar(string archivo, string datos)
        {
            bool flag = false;
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo, false))
                {
                    writer.Write(datos);
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }
        

        public bool leer(string archivo, out string datos)
        {
            bool flag = false;
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = reader.ReadToEnd();
                    flag = true;
                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
            return flag;
        }
    }
}
