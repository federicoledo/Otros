using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
namespace Ejercicio_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Carreta carreta1 = new Carreta(19.8);
            Comercial avionComercial1 = new Comercial(1986.3, 177.6);
            Privado avionPrivado1 = new Privado(2887.9, 266.3);
            Deportivo autoDeportivo1 = new Deportivo(631, "DDD 111", 46);
            Familiar autoFamiliar1 = new Familiar(263, "FFF 111", 4);

            autoDeportivo1.MostrarPatente();           
            autoFamiliar1.MostrarPatente();

            List<Vehiculo> listaVehiculos = new List<Vehiculo>();
            listaVehiculos.Add(avionComercial1);
            listaVehiculos.Add(avionPrivado1);
            listaVehiculos.Add(autoDeportivo1);
            listaVehiculos.Add(autoFamiliar1);

            
            foreach (Vehiculo item in listaVehiculos)
            {
                if (item is Comercial)
                {
                    Console.WriteLine("COMERCIAL");
                    item.MostrarPrecio();
                }
                if (item is Privado)
                {
                    Console.WriteLine("Privado");
                    item.MostrarPrecio();
                }
                if (item is Deportivo)
                {
                    Console.WriteLine("Deportivo");
                    item.MostrarPrecio();
                }
                if (item is Familiar)
                {
                    Console.WriteLine("Familiar");
                    item.MostrarPrecio();
                }
            }

            Avion av = new Avion(100, 899);

            Console.WriteLine("IMPUESTO NACIONAL: "+Gestion.MostarImpuestoNacional((IAFIP)av));

            Console.WriteLine("IMPUESTO PROVINCIAL: "+Gestion.MostarImpuestoProvincial((IARBA)av));


            Console.ReadKey();
        }
    }
}

/*

SIMILITUDES

 * Se pueden sobrecargar los elementos
 * Pueden tenes atributos
 * Pueden tener constructores estaticos
 * Pueden tener propiedades

DIFERENCIAS 

 * DINAMICAS :
 * Se pueden instanciar
 * 
 * ESTATICAS
   No se pueden instanciar



*/