using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archivos;

namespace EntidadesInstanciables
{
    public class Jornada
    {
        private List<Alumno> _alumnos;
        private Gimnasio.EClases _clase;
        private Instructor _instructor;
       
        public enum EClases
        {
            CrossFit, Pilates, Natacion
        }

        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada(Gimnasio.EClases clase, Instructor instructor)
            : this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto text = new Texto();
            return text.guardar("Jornada.txt", jornada.ToString());
        }

        public string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("JORNADA");
            sb.AppendLine("Clase de : " + this._clase.ToString() + " por " + this._instructor.ToString());
            sb.AppendLine("Alumnos:");

            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("<------------------------------->");

            return sb.ToString();
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            if (a == j._clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            if (a != j._clase)
            {
                return true;
            }
            return false;
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (j == a)
            {
                j._alumnos.Add(a);
            }
            return j;
        }

        
    }
}
