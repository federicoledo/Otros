using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Familiar:Auto
    {
        public override float CalcularCosto()
        {
            return 100f;
        }

        public Familiar(string patente) :
            base(patente)
        {

        }
    }
}
