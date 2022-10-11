using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class AlumnoNota
    {
        private int _IDInscripcion;
        private string _Apellido;
        private string _Email;
        private int _IDPlan;
        private int _Legajo;
        private string _Nombre;
        private string _Condicion;
        private int _IDAlumno;
        private int _IDCurso;
        private int _Nota;

        public int IDInscripcion { get { return _IDInscripcion; } set { _IDInscripcion = value; } }
        public string Condicion { get { return _Condicion; } set { _Condicion = value; } }
        public int IDAlumno { get { return _IDAlumno; } set { _IDAlumno = value; } }
        public int IDCurso { get { return _IDCurso; } set { _IDCurso = value; } }
        public int Nota { get { return _Nota; } set { _Nota = value; } }

        public string Apellido { get { return _Apellido; } set { _Apellido = value; } }
        public string Email { get { return _Email; } set { _Email = value; } }
        public int IDPlan { get { return _IDPlan; } set { _IDPlan = value; } }
        public int Legajo { get { return _Legajo; } set { _Legajo = value; } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value; } }



    }
}
