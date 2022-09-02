using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{

    public class DocenteCargo
    {
        //Esta clase se usa com DataSource para las grillas de docentes de un curso

        private string _nombre;
        private string _apellido;
        private string _cargo;

        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Cargo { get { return _cargo; } set { _cargo = value;} }
    }
}
