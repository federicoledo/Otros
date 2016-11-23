using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Avion : Vehiculo,IAFIP
    {
        public override float CalcularCosto()
        {
            return 1500f;
        }

        public Avion(string patente) :
            base(patente)
        {

        }

        public float RetornarImpuestos()
        {
            return 120f;
        }

        public override string mostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Avion ");
            sb.AppendLine(this.Patente);
            return sb.ToString();
        }
    }
}
