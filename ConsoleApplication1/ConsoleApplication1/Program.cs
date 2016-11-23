using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Vehiculo vehiculoUno = new Vehiculo("h2o");
            //Auto autoUno = new Auto("HRI 655");
            //autoUno.cantidadDePuertas = 3; //No lo muestra, arreglar codigo;
            //Console.WriteLine(vehiculoUno.mostrarDatos());
            //Console.WriteLine(autoUno.mostrarDatos());
            Familiar familiarUno = new Familiar("AAA 111");
            Deportivo deportivoUno = new Deportivo("BBB 222");
            Carreta carretaUno = new Carreta("CCC 333");
            Avion avionUno = new Avion("DDD 444");
            Comercial comercialUno = new Comercial("EEE 555");
            Privada privadaUno = new Privada("FFF 666");

            //Creo la lista de los vehiculos
            List<Vehiculo> listaVehiculoUno = new List<Vehiculo>();
            listaVehiculoUno.Add(familiarUno);
            listaVehiculoUno.Add(deportivoUno);
            listaVehiculoUno.Add(carretaUno);
            listaVehiculoUno.Add(avionUno);

            //Muesto el costo y la patente
            foreach (Vehiculo item in listaVehiculoUno)
            {
                Console.WriteLine("El costo es de "+item.CalcularCosto());
                Console.WriteLine(item.mostrarDatos());
            }

            //Creo lista afip
            List<IAFIP> listaAFIP = new List<IAFIP>();


            //Agrego los elementos a la lista
            listaAFIP.Add(deportivoUno);
            listaAFIP.Add(avionUno);

            //Muestro los impuestos
            foreach (IAFIP item in listaAFIP)
            {

                Console.WriteLine("El impuesto a pagar es de $ "+Gestion.mostrarImpuestos(item));
                //Console.WriteLine(item.RetornarImpuestos()); ES LO MISMO QUE EL DE ARRIBA, SIN UTILIZAR LA CLASE GESTION
            }
            Console.WriteLine();
            Console.WriteLine("Privada "+privadaUno.mostrarDatos());
            Console.WriteLine("Comercial " + comercialUno.mostrarDatos());

            //Luego de hacer el punto 2(agregar clases privada y comercial heredadas de avion) me fijo si los puede agregar a 
            //la lista IAFIP, en caso de que se pueda la implementacion SE HEREDA, sino NO.
            listaAFIP.Add(privadaUno);
            listaAFIP.Add(comercialUno);

            foreach (IAFIP item in listaAFIP)
            {
                Console.WriteLine(item.RetornarImpuestos());
            }
            //Como puede agregar los elementos a la lista, la implementacion se HEREDA.


            //polimorfismo capacidad de clases de implementar en tiempo de ejecucion ?????????????????

            Console.ReadKey();
        }
    }
}
