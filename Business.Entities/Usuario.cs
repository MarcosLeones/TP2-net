using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Usuario : Persona
    {
        private string _NombreUsuario;
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }


        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private bool _Habilitado;
        public bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }

    }
}
