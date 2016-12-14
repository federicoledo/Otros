using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;

namespace EntidadesInstanciables
{
    public class Instructor:PersonaGimnasio
    {
        private Queue<Gimnasio.EClases> _clasesDelDia;
        private static Random _random;


        static Instructor()
        {
            _random = new Random();
        }

        public Instructor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(id,nombre,apellido,dni,nacionalidad)
        {
            this._clasesDelDia = new Queue<Gimnasio.EClases>();
            this._randomClases();
        }

        private void _randomClases()
        {
            int aux = 0;
            aux = _random.Next(1, 4);
            this._clasesDelDia.Enqueue((Gimnasio.EClases)_random.Next(1, 4));
            this._clasesDelDia.Enqueue((Gimnasio.EClases)aux);
        }

        protected string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.Append(this.ParticiparEnClase());
            return sb.ToString();

        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DIA: ");
            foreach (Gimnasio.EClases item in this._clasesDelDia)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }

        public string ToString()
        {
            return this.MostrarDatos();
        }

        public static bool operator ==(Instructor ins, Gimnasio.EClases clase)
        {
            bool flag = false;
            foreach (Gimnasio.EClases item in ins._clasesDelDia)
            {
                if (item == clase)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }

        public static bool operator !=(Instructor ins, Gimnasio.EClases clase)
        {
            bool flag = false;
            foreach (Gimnasio.EClases item in ins._clasesDelDia)
            {
                if (item != clase)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
    }
}
