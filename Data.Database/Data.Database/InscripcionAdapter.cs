using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Data;

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

                SqlCommand cmdInscripciones = new SqlCommand("select * from alumnos_inscripciones where id_curso=@id_curso and id_alumno=@id_alumno", sqlConn);
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

                SqlCommand cmdSave = new SqlCommand("INSERT INTO alumnos_inscripciones (id_alumno, id_curso) VALUES (@id_alumno, @id_curso) select @@identity", sqlConn);

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
    }
}
