using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivosv02
{
    public static class Serializar
    {
        public static bool SerializarPersona(Persona p)
        {
            //XmlTextWriter writer = 
            //XmlSerializer serializador 
            bool aux = false;
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter("Persona.xml", Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Persona));
                    serializador.Serialize(escritor, p);
                    aux = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return aux;
        }

        public static Persona DeserializarPersona()
        {
            Persona miPersona = null;
            try
            {
                using (XmlTextReader escritor = new XmlTextReader("Persona.xml"))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Persona));
                    miPersona = (Persona)serializador.Deserialize(escritor);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return miPersona;
        }

        public static void SerializarListadoPersona(List<Persona> p)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter("ListadoPersona.xml", Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(List<Persona>));
                    serializador.Serialize(escritor, p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void SerializarAula(Aula p)
        {
            try
            {
                using (XmlTextWriter escritor = new XmlTextWriter("Aula.xml", Encoding.UTF8))
                {
                    XmlSerializer serializador = new XmlSerializer(typeof(Aula));
                    serializador.Serialize(escritor, p);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static bool SerializarGenerico(ISerializable2016 iSer)
        {
            return iSer.serializar();
        }
    }
}
