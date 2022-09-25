using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Util
{
    public class ParDocenteCurso
    {

        private Persona _Docente;
        public DocenteCurso _Dictado;

        public Persona Docente { get { return _Docente; } set { _Docente = value; } }

        public DocenteCurso Dictado { get { return _Dictado; } set { _Dictado = value; } }
    }
}
