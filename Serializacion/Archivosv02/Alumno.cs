using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivosv02
{
    public class Alumno:Persona
    {
        public int legajo;

        public Alumno() :
            base()
        {

        }

        public Alumno(string nombre, int legajo) :
            base(nombre)
        {
            this.legajo = legajo;
        }
    }
}
