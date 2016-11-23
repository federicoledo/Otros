using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Vehiculo
    {
        protected double _precio;

        public void MostrarPrecio()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("PRECIO: " + this._precio);
            Console.WriteLine(sb);
        }

        public Vehiculo(double precio)
        {
            this._precio = precio;
        }
    }
}
