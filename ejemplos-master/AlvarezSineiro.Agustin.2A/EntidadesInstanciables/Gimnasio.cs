using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excepciones;
using Archivos;

namespace EntidadesInstanciables
{
    public class Gimnasio
    {
        private List<Alumno> _alumnos;
        private List<Instructor> _instructores;
        private List<Jornada> _jornada;

        public enum EClases
        {
            CrossFit, Pilates, Natacion,Yoga
        }

        #region constructor
        public Gimnasio()
        {
            this._alumnos = new List<Alumno>();
            this._instructores = new List<Instructor>();
            this._jornada = new List<Jornada>();
        }
        #endregion

        #region metodos
        public static bool Guardar(Gimnasio gim)
        {
            Archivos.Xml<Gimnasio> xml = new Archivos.Xml<Gimnasio>();
            xml.guardar("Gimnasio.xml", gim);
            return true;
        }

        private static string MostrarDatos(Gimnasio gim)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Jornada:");
            foreach (Jornada item in gim._jornada)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }

        public override string ToString()
        {
            return Gimnasio.MostrarDatos(this);
        }
        #endregion


        #region sobrecarga
        public static Gimnasio operator +(Gimnasio gim, Alumno alum)
        {
            bool flag = true;
            foreach (Alumno item in gim._alumnos)
            {
                if (item == alum)
                {
                    flag = false;
                    break;
                }
            }
            if (flag==true)
            {
                gim._alumnos.Add(alum);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
            return gim;
        }
        public static Gimnasio operator +(Gimnasio gim, Instructor ins)
        {
            bool flag = true;
            foreach (Instructor item in gim._instructores)
            {
                if (item == ins)
                {
                    flag = false;
                    break;
                }
            }
            if (flag==true)
            {
                gim._instructores.Add(ins);
            }
            return gim;
        }
        public static bool operator ==(Gimnasio gim, Alumno alum)
        {
            bool flag = false;
            foreach (Alumno item in gim._alumnos)
            {
                if (item.DNI == alum.DNI)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static bool operator !=(Gimnasio gim, Alumno alum)
        {
            bool flag = false;
            foreach (Alumno item in gim._alumnos)
            {
                if (item.DNI != alum.DNI)
                {
                    flag = true;
                    break;
                }
            }
            return flag;
        }
        public static Gimnasio operator +(Gimnasio gim, Gimnasio.EClases clase)
        {
            Jornada nuevaJornada = new Jornada(clase, (gim == clase));
            foreach (Alumno item in gim._alumnos)
            {
                if (item == clase)
                {
                    nuevaJornada = nuevaJornada + item;
                }
            }
            gim._jornada.Add(nuevaJornada);
            return gim;

        }
        public static Instructor operator ==(Gimnasio gim, Gimnasio.EClases clase)
        {
            int i;
            bool flag = false;
            for (i=0; i<gim._instructores.Count; i++)
            {
                if (gim._instructores[i] == clase)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                return gim._instructores[i];
            }
            throw new SinInstructorException();
        }
        public static Instructor operator !=(Gimnasio gim, Gimnasio.EClases clase)
        {
            int i;
            bool flag = false;
            for (i=0; i<gim._instructores.Count; i++)
            {
                if (gim._instructores[i] != clase)
                {
                    flag = true;
                    break;
                }
            }
            if (flag == true)
            {
                return gim._instructores[i];
            }
            throw new SinInstructorException();
        }

        public static bool operator ==(Gimnasio gim, Instructor ins)
        {
            bool flag = false;
            foreach (Instructor item in gim._instructores)
            {
                if (item==ins)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static bool operator !=(Gimnasio gim, Instructor ins)
        {
            bool flag = false;
            foreach (Instructor item in gim._instructores)
            {
                if (!item.Equals(ins))
                {
                    flag = true;
                }
            }
            return flag;
        }
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this._jornada.Count)
                {
                    return this._jornada[i];
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion
    }
}
