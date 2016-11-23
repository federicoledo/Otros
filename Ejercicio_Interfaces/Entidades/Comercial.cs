using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comercial:Avion, IARBA
    {
        public Comercial(double precio, double velMax) :
            base(precio, velMax)
        {

        }

        double IARBA.CalcularImpuesto()
        {
            return (this._precio * 0.25);
        }
    }
}
