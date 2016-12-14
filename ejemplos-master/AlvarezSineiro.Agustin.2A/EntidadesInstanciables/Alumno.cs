using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntidadesAbstractas;


namespace EntidadesInstanciables
{
    public class Alumno:PersonaGimnasio
    {
        private Gimnasio.EClases _claseQueTurna;
        private EEstadoCuenta _estadoCuenta;

        public enum EEstadoCuenta
        {
            MesPrueba, AlDia, Deudor
        }
        #region contructores
        public Alumno()
        {}
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Gimnasio.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueTurna = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad,Gimnasio.EClases claseQueToma,EEstadoCuenta estadoCuenta):this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }
        #endregion

        #region metodos
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Estado de cuenta: " + this._estadoCuenta);
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return ("TOMA CLASE DE " + this._claseQueTurna.ToString());
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region sobrecarga
        public static bool operator ==(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueTurna == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Alumno a, Gimnasio.EClases clase)
        {
            if (a._claseQueTurna != clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
