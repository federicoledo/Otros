using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Archivosv02
{
    public class Aula
    {
        public int numero;
        private List<Persona> listaAlumnos;
        public Persona profesor;
        private string _nombreAula;

        public Aula()
        {

        }

        public Aula(int num, string nombre, List<Persona> lista)
        {
            this._nombreAula = nombre;
            this.numero = num;
            this.listaAlumnos = lista;
        }

        public string NombreAula
        {
            set
            {
                this._nombreAula = value;
            }
            get
            {
                return this._nombreAula;
            }
        }

        public List<Persona> listaDePersonas
        {
            get
            {
                return this.listaAlumnos;
            }
        }



    }
}
