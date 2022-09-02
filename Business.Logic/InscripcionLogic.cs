using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using Business.Entities;
using Util;

namespace Business.Logic
{
    public class InscripcionLogic : BusinessLogic
    {

        private InscripcionAdapter _InscripcionData;

        public InscripcionAdapter InscripcionData
        {
            get { return _InscripcionData; }
            set { _InscripcionData = value; }
        }

        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }

        public string InscribirAlumno(AlumnoInscripcion inscripcion)
        {
            //Registra la inscripcion del alumno verificando que no este inscripto de antes y que haya cupo

            AlumnoInscripcion existeInscripcion = InscripcionData.GetInscripcionDePersona(inscripcion.IDCurso, inscripcion.IDAlumno);

            if (existeInscripcion.ID == 0)
            {
                Exception ExcepcionManejada =
                  new Exception("El alumno ya se encuentra inscripto en el curso.");
                throw ExcepcionManejada;
            }
            else
            {
                CursoAdapter cursoData = new CursoAdapter();
                Curso curso = cursoData.GetOne(inscripcion.IDCurso);
                int cupo = curso.cupo;

                int inscripcionesActuales = InscripcionData.GetCantidadInscripciones(curso);

                if (inscripcionesActuales < cupo)
                {
                    InscripcionData.Save(inscripcion);
                    return "El alumno se inscribió correctamente al curso.";
                }
                else
                {
                    Exception ExcepcionManejada =
                  new Exception("No hay cupo disponible para el curso seleccionado.");
                    throw ExcepcionManejada;
                }
            }

        }
        public Curso GetCursoByComisionMateriaAnio(int comision,int materia)
        {
            //Devuelve un curso para una materia de una comision de el año actual

            CursoAdapter cursoData = new CursoAdapter();
            DateTime myDateTime = DateTime.Now;
            int year = myDateTime.Year;
            Curso curso = cursoData.GetByComisionMateriaAnio(comision, materia, year);
            if (curso != null)
            {
                return curso;
            }
            else
            {
                Exception ExcepcionManejada =
                  new Exception("No hay curso disponible para la materia en la comisión seleccionada.");
                throw ExcepcionManejada;
            }
                
        }

        public List<Comision> GetComisionesByPlan(int IDPlan)
        {
            //Devuelve todas las comisiones de un plan en particular

            ComisionAdapter comisionData = new ComisionAdapter();
            return comisionData.GetByPlan(IDPlan);
            
        }

        public List<Materia> GetMateriasByPlanFiltraPorAlumno(int IDPlan, int IDAlumno)
        {
            //Devuelve las materias del plan que el alumno aun no tenga aprobadas

            MateriaAdapter materiaData = new MateriaAdapter();
            List<Materia> materias = materiaData.GetByPlanFiltraPorAlumno(IDPlan, IDAlumno);
            return materias;

        }

        public List<ParDocenteCurso> GetDocentesByCurso(Curso curso)
        {
            //Devuelve todos los profesores que esten anotados como docentes en un curso
            PersonaAdapter personaData = new PersonaAdapter();
            return personaData.GetDocentesByCurso(curso);
        }
    }
}
