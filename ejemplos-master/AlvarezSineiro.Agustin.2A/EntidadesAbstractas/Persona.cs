using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        public enum ENacionalidad
        {
            Argentino, Extranjero
        }
        
        #region constructores
        public Persona()
        { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad):this(nombre,apellido,nacionalidad)
        {
            this.StringToDNI = dni;
            
        }
    #endregion

        #region propiedades
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);                
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = this.ValidarDni(this.Nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        public string StringToDNI
        {
            set
            {
                this.DNI = this.ValidarDni(this._nacionalidad, value);                
            }
        }
        #endregion


        #region metodos
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine("POR NOMBRE COMPLETO: " + this.Apellido + "," + this.Nombre);
            sb.AppendLine("Nacionalidad: " + this.Nacionalidad);
            //sb.AppendLine("DNI: " + this._dni);

            return sb.ToString();
        }

        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato < 1 || dato > 89999999)
                    {
                        throw new NacionalidadInvalidaException(dato.ToString());
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato < 89999999 || dato > 99999999)
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
            }
            return dato;
        }

        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            dato = dato.Replace(".", "");

            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException(dato.ToString());
            }
            int dni;
           
            try
            {
                dni = Int32.Parse(dato);
            }
            catch (Exception e)
            {
                throw new DniInvalidoException(dato.ToString(), e);
            }

            return this.ValidarDni(nacionalidad, dni);
        }

        private string ValidarNombreApellido(string dato)
        {
            bool flag = true;
            int i;
            for (i=0;i<dato.Length;i++)
            {
                if ((int)dato[i]<=65 || (int)dato[i]>=123)
                {
                    flag = false;
                    break;
                }
            }
            
            if (flag==true)
            { 
                return dato;
            }
                
            return null;
        }
        #endregion
    }
}
