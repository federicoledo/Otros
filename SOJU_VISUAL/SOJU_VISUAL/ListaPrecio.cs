using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOJU_VISUAL
{
    public class ListaPrecio
    {
        public Queue<Producto> lista;

        public ListaPrecio()
        {
            this.lista = new Queue<Producto>();
            this.lista.Enqueue(new Producto("ACELGA", 70));
            this.lista.Enqueue(new Producto("FRUTILLA", 210));
            this.lista.Enqueue(new Producto("AJO", 35));
            this.lista.Enqueue(new Producto("ALBAHACA", 35));
            this.lista.Enqueue(new Producto("ANCO", 60));
            this.lista.Enqueue(new Producto("LIMON", 55));
            this.lista.Enqueue(new Producto("APIO", 120));
            this.lista.Enqueue(new Producto("MANDARINA", 55));
            this.lista.Enqueue(new Producto("BANANA", 90));
            this.lista.Enqueue(new Producto("BATATA", 35));
            this.lista.Enqueue(new Producto("BERENJENA", 100));
            this.lista.Enqueue(new Producto("CABUTO", 60));
            this.lista.Enqueue(new Producto("MANZANA", 75));
            this.lista.Enqueue(new Producto("CEBOLLA", 40));
            this.lista.Enqueue(new Producto("CHERRY", 100));
            this.lista.Enqueue(new Producto("ESPINACA", 50));
            this.lista.Enqueue(new Producto("LECHUGA", 100));
            this.lista.Enqueue(new Producto("MORRON ROJO", 150));
            this.lista.Enqueue(new Producto("NARANJA", 55));
            this.lista.Enqueue(new Producto("PAPA NEGRA", 30));
            this.lista.Enqueue(new Producto("PERA", 65));
            this.lista.Enqueue(new Producto("PEREJIL", 120));
            this.lista.Enqueue(new Producto("POMELO", 55));
            this.lista.Enqueue(new Producto("PUERRO", 120));
            this.lista.Enqueue(new Producto("REMOLACHA", 85));
            this.lista.Enqueue(new Producto("RUCULA", 15));
            this.lista.Enqueue(new Producto("TOMATE", 125));
            this.lista.Enqueue(new Producto("ZANAHORIA", 100));
            this.lista.Enqueue(new Producto("VERDEO", 120));
            this.lista.Enqueue(new Producto("ZAPALLITO", 85));
            this.lista.Enqueue(new Producto("CHOCLO", 20));
            this.lista.Enqueue(new Producto("PALTA", 70));
            this.lista.Enqueue(new Producto("KIWI", 200));
            this.lista.Enqueue(new Producto("UVA", 200));
            this.lista.Enqueue(new Producto("BROCOLI", 90));
            this.lista.Enqueue(new Producto("COLIFLOR", 100));
        }

        public double price(string producto, double cantidad)
        {
            double xReturn = 0;
            foreach(Producto p in this.lista)
            {
                if (p.name.ToUpper() == producto.ToUpper())
                {
                    xReturn = p.price * cantidad;
                }
            }
            return xReturn;
        }
    }
}
