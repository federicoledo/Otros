using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Carreta : Vehiculo
    {
        public override float CalcularCosto()
        {
            return 5f;
        }

        public Carreta(string patente) :
            base(patente)
        {

        }

        public override string mostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Carreta ");
            sb.AppendLine(this.Patente);
            return sb.ToString();
        }
    }
}
