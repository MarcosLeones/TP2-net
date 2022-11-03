using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;

namespace Util
{
    public class ContenedorCurso
    {
        private Curso _curso;
        private Materia _materia;
        private Comision _comision;

        public Curso Curso { get { return _curso; } set { _curso = value; } }
        public Materia Materia { get { return _materia; } set { _materia = value; } } 
        public Comision Comision { get { return _comision; } set { _comision = value; } }
    }
}
