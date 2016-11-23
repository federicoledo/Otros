using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Deportivo : Auto,IAFIP
    {
        public override float CalcularCosto()
        {
            //throw new NotImplementedException();
            return 150f;
        }

        public Deportivo(string patente) :
            base(patente)
        {

        }

        public float RetornarImpuestos()
        {
            return 12f;
        }
    }
}
