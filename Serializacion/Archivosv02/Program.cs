using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivosv02
{
    class Program
    {
        static void Main(string[] args)
        {
           // Persona p = new Persona();
           // p.nombre = "Jose";
           // Serializar.SerializarPersona(p);

           // Persona p2 = new Persona("Pepe");
           // Serializar.SerializarPersona(p2);
            
           // List<Persona> listaPersonas = new List<Persona>(2);
           // listaPersonas.Add(new Persona("Luis"));
           // listaPersonas.Add(new Persona("Armando"));
           // listaPersonas.Add(new Alumno());
           // Serializar.SerializarListadoPersona(listaPersonas);


            List<Persona> listaPersonas = new List<Persona>(2);
            listaPersonas.Add(new Alumno("Pedro", 123));
            listaPersonas.Add(new Alumno("Jose", 961));
            Aula aula1 = new Aula(3, "Kinder", listaPersonas);
            aula1.profesor = new Persona("Martin");
            
           
            Serializar.SerializarAula(aula1);

        }
    }
}
