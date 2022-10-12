using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Data.Database;
using Util;

namespace Business.Logic
{
    public class RegistroNotasLogic : BusinessLogic
    {
        
        public List<Curso> MostrarCursosDeDocente(Persona docente)
        {
            InscripcionAdapter adapter = new InscripcionAdapter();
            return adapter.GetCursosByDocente(docente);
        }

        public List<AlumnoNota> MostrarAlumnosPorCurso(Curso curso)
        {
            InscripcionAdapter adapter = new InscripcionAdapter();
            return adapter.GetAlumnosByCurso(curso);
        }

        public void GuardarNota(List<AlumnoNota> alumnosNotas)
        {

            foreach(AlumnoNota alumnoNota in alumnosNotas) { 
                AlumnoInscripcion alumnoInscripcion = new AlumnoInscripcion();
                alumnoInscripcion.IDAlumno = alumnoNota.IDAlumno;
                alumnoInscripcion.IDCurso = alumnoNota.IDCurso;
                alumnoInscripcion.Condicion = alumnoNota.Condicion;
                alumnoInscripcion.Nota = alumnoNota.Nota;
                alumnoInscripcion.ID = alumnoNota.IDInscripcion;

                if (alumnoInscripcion.Nota >= 0 || alumnoInscripcion.Nota <= 10)
                {
                    InscripcionAdapter adapter = new InscripcionAdapter();
                    adapter.Update(alumnoInscripcion);
                }
                else
                {
                    Exception ExcepcionManejada =
                   new Exception("La nota debe estar entre 0 y 10");
                    throw ExcepcionManejada;
                }
            }
        }
        
    }
}
