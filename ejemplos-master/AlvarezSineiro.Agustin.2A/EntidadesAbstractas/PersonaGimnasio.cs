using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class PersonaGimnasio:Persona
    {
        private int _identificador;

        #region metodos
        public override bool Equals(object obj)
        {
            if (this.GetType() == obj.GetType())
            {
                return true;
            }
            return false;
        }

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("CARNET NUMERO: " + this._identificador);
            return sb.ToString();
        }

        protected virtual string ParticiparEnClase()
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region contructores
        public PersonaGimnasio()
        { }

        public PersonaGimnasio(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad):base(nombre,apellido,dni,nacionalidad)
        {
            this._identificador = id;
        }
        #endregion

        #region sobrecarga
        public static bool operator ==(PersonaGimnasio pg1,PersonaGimnasio pg2)
        {
            if ((pg1.DNI == pg2.DNI || pg1._identificador == pg2._identificador) && pg1.Equals(pg2))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(PersonaGimnasio pg1, PersonaGimnasio pg2)
        {
            if ((pg1.DNI != pg2.DNI || pg1._identificador != pg2._identificador) && pg1.Equals(pg2))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
