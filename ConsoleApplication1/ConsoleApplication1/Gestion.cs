using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{

    //1-Implementar mostrarIMP
    //2-Verificar si la implementacion se hereda o no.
    //Crear clase PRIVADA Y COMERCIAL hereda de avion
    //Crear propiedades
    //a-abstractas
    //b-virtuales
    //c-en la interface

    public class Gestion
    {
        public Gestion()
        {

        }

        public static float mostrarImpuestos(IAFIP algo)
        {
            return algo.RetornarImpuestos();
        }
    }
}
