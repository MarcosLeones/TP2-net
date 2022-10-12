using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;
using Util;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter
    {

        public int GetCantidadInscripciones(Curso curso)
        {
            int inscripciones = 0;

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select count(*) as cantidad from alumnos_inscripciones where id_curso=@id_curso", sqlConn);
                cmdInscripciones.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso.ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    inscripciones = (int)drInscripciones["cantidad"];

                }

                drInscripciones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar inscripciones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return inscripciones;
        }


        public AlumnoInscripcion GetInscripcionDePersona(int curso, int alumno)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();
            inscripcion.ID = 0;

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select id_inscripcion, id_curso, id_alumno, condicion, ISNULL(nota,0) as nota from alumnos_inscripciones where id_curso=@id_curso and id_alumno=@id_alumno", sqlConn);
                cmdInscripciones.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso;
                cmdInscripciones.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alumno;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                if (drInscripciones.Read())
                {
                    inscripcion.ID = (int)drInscripciones["id_inscripcion"];
                    inscripcion.IDCurso = (int)drInscripciones["id_curso"];
                    inscripcion.IDAlumno = (int)drInscripciones["id_alumno"];
                    inscripcion.Condicion = (string)drInscripciones["condicion"];
                    inscripcion.Nota = (int)drInscripciones["nota"];
                }

                drInscripciones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar inscripción", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return inscripcion;
        }


        public void Insert(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso, condicion) VALUES (@id_alumno, @id_curso, 'cursando') select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;

                inscripcion.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripción", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE alumnos_inscripciones set id_alumno=@id_alumno, id_curso=@id_curso, condicion=@condicion, nota=@nota WHERE id_inscripcion=@id_inscripcion", sqlConn);

                cmdSave.Parameters.Add("@id_inscripcion", SqlDbType.Int).Value = inscripcion.ID;
                cmdSave.Parameters.Add("@condicion", SqlDbType.VarChar, 50).Value = inscripcion.Condicion;
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = inscripcion.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = inscripcion.IDCurso;
                cmdSave.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de inscripción", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete alumnos_inscripciones where id_inscripcion=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar inscripción", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion ai)
        {
            if (ai.State == BusinessEntity.States.Deleted)
            {
                this.Delete(ai.ID);
            }
            else if (ai.State == BusinessEntity.States.New)
            {
                this.Insert(ai);
            }
            else if (ai.State == BusinessEntity.States.Modified)
            {
                this.Update(ai);
            }
            ai.State = BusinessEntity.States.Unmodified;
        }


        public List<AlumnoNota> GetAlumnosByCurso(Curso curso)
        {
            List<AlumnoNota> alumnos = new List<AlumnoNota>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdAlumnos = new SqlCommand("select id_inscripcion, nombre, apellido, email, id_alumno, id_plan, condicion, legajo, isnull(nota,0) as nota, id_curso from alumnos_inscripciones ai "
                    + " inner join personas p on ai.id_alumno = p.id_persona "
                    + " where id_curso = @id_curso  and habilitado = 1", sqlConn);
                cmdAlumnos.Parameters.Add("@id_curso", SqlDbType.Int).Value = curso.ID;
                SqlDataReader drAlumnos = cmdAlumnos.ExecuteReader();

                while (drAlumnos.Read())
                {

                    AlumnoNota an = new AlumnoNota();
                    an.IDInscripcion = (int)drAlumnos["id_inscripcion"];
                    an.Nombre = (string)drAlumnos["nombre"];
                    an.Apellido = (string)drAlumnos["apellido"];
                    an.Email = (string)drAlumnos["email"];
                    an.IDAlumno = (int)drAlumnos["id_alumno"];
                    an.IDPlan = (int)drAlumnos["id_plan"];
                    an.Condicion = (string)drAlumnos["condicion"];
                    an.Legajo = (int)drAlumnos["legajo"];
                    an.Nota = (int)drAlumnos["nota"];
                    an.IDCurso = (int)drAlumnos["id_curso"];

                    alumnos.Add(an);
                }

                drAlumnos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar alumnos inscriptos al curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return alumnos;
        }


        public List<Curso> GetCursosByDocente(Persona docente)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdInscripciones = new SqlCommand("select c.id_curso as id_curso, id_materia, id_comision, anio_calendario, cupo, descripcion"
                                + " from cursos c "
                                + " inner join docentes_cursos dc on c.id_curso = dc.id_curso "
                                + " where id_docente = @id_docente ", sqlConn);
                cmdInscripciones.Parameters.Add("@id_docente", SqlDbType.Int).Value = docente.ID;
                SqlDataReader drInscripciones = cmdInscripciones.ExecuteReader();

                while (drInscripciones.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drInscripciones["id_curso"];
                    curso.IDMateria = (int)drInscripciones["id_materia"];
                    curso.IDComision = (int)drInscripciones["id_comision"];
                    curso.AnioCalendario = (int)drInscripciones["anio_calendario"];
                    curso.cupo = (int)drInscripciones["cupo"];
                    curso.Descripcion = (string)drInscripciones["descripcion"];
                    cursos.Add(curso);
                }

                drInscripciones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

    }

}
