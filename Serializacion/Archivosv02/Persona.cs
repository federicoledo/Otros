using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Archivosv02
{
    [XmlInclude(typeof(Alumno))]
    public class Persona:ISerializable2016
    {
        public string nombre;

        public Persona()
        {

        }

        public Persona(string nombre)
        {
            this.nombre = nombre;
        }


        public bool serializar()
        {
            return Serializar.SerializarPersona(this);
        }
    }
}
