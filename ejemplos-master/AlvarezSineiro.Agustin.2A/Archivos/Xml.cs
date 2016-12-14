using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T>:IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextWriter writer = new XmlTextWriter(archivo, Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    serializador.Serialize(writer, datos);
                    writer.Close();
                    flag =true;
                }
            }
            catch (Exception e)
            {   
                throw new ArchivosException(e);
            }
            return flag;
        }

        public bool leer(string archivo, out T datos)
        {
            bool flag = false;
            try
            {
                using (XmlTextReader reader = new XmlTextReader(archivo))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(T));
                    datos = (T)serializador.Deserialize(reader);
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
