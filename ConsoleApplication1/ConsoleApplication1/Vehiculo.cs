using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public abstract class Vehiculo
    {
        public string Patente;

        public Vehiculo(string pat)
        {
            this.Patente = pat;
        }


        public override string ToString()
        {
            return this.Patente;
        }

        public virtual string mostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Vehiculo ");
            sb.AppendLine(this.Patente);
            return sb.ToString();
        }

        public abstract float CalcularCosto();

    }
}
