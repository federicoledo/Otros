using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOJU_VISUAL
{
    public class Cliente
    {
        public string a, b, c;
        public int ID;

        public Cliente(string x, string y, string z, int xx)
        {
            this.a = x;
            this.b = y;
            this.c = z;
            this.ID = xx;
        }

        public string showCliente()
        {
            return "CLIENTE: " + this.a + " - DIRECCION: " + this.b + " - TELEFONO: " + this.c;
        }
    }
}
