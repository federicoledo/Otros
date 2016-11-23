using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Auto:Vehiculo
    {
        public int cantidadDePuertas;

        public Auto(string patente):
            base(patente)
        {
           
        }

        public override string mostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Auto ");
            sb.AppendLine(this.Patente);
            return sb.ToString();
        }
    }
}
