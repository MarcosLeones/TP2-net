using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Data.Database
{
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias", sqlConn);

                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mt = new Materia();

                    mt.ID = (int)drMaterias["id_materia"];
                    mt.Descripcion = (string)drMaterias["desc_materia"];
                    mt.HSSemanales = (int)drMaterias["hs_semanales"];
                    mt.HSTotales = (int)drMaterias["hs_totales"];
                    mt.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mt);
                }

                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return materias;
        }


        public Materia GetOne(int ID)
        {
            Materia mt = new Materia();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMaterias.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                if (drMaterias.Read())
                {
                    mt.ID = (int)drMaterias["id_materia"];
                    mt.Descripcion = (string)drMaterias["desc_materia"];
                    mt.HSSemanales = (int)drMaterias["hs_semanales"];
                    mt.HSTotales = (int)drMaterias["hs_totales"];
                    mt.IDPlan = (int)drMaterias["id_plan"];
                }

                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar materia", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return mt;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void DeleteByPlan(int IDPlan)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete materias where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDPlan;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materias por plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Materia mt)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE materias set desc_materia=@desc, hs_semanales=@hss, hs_totales=@hst, id_plan=@idPlan WHERE id_materia=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = mt.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.Int).Value = mt.Descripcion;
                cmdSave.Parameters.Add("@hss", SqlDbType.Int).Value = mt.HSSemanales;
                cmdSave.Parameters.Add("@hst", SqlDbType.Int).Value = mt.HSTotales;
                cmdSave.Parameters.Add("@idPlan", SqlDbType.Int).Value = mt.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void Insert(Materia mt)
        { 
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO materias (desc_materia, hs_semanales, hs_totales, id_plan) VALUES (@desc, @hss, @hst, @id_plan) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = mt.Descripcion;
                cmdSave.Parameters.Add("@hss", SqlDbType.Int).Value = mt.HSSemanales;
                cmdSave.Parameters.Add("@hst", SqlDbType.Int).Value = mt.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = mt.IDPlan;

                mt.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        public void Save(Materia mt)
        {

            if (mt.State == BusinessEntity.States.Deleted)
            {
                this.Delete(mt.ID);
            }
            else if (mt.State == BusinessEntity.States.New)
            {
                this.Insert(mt);
            }
            else if (mt.State == BusinessEntity.States.Modified)
            {
                this.Update(mt);
            }
            mt.State = BusinessEntity.States.Unmodified;
        }


        public List<Materia> GetByPlanFiltraPorAlumno(int IDPlan, int IDAlumno)
        {
            //Devuelve las materias del plan que el alumno aun no tenga aprobadas

            List<Materia> materias = new List<Materia>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdMaterias = new SqlCommand("select m.id_materia as id_materia, m.desc_materia as desc_materia, m.hs_semanales as hs_semanales, m.hs_totales as hs_totales, m.id_plan as id_plan"
                    + "from materias m inner join cursos c on c.id_materia=m.id_materia"
                    + "left join alumnos_inscripciones ai  on ai.id_curso=c.id_curso"
                    + "where ai.id_alumno=@id_alumno and m.id_plan=@id_plan and ai.condicion <> 'aprobado'"
                    , sqlConn);
                cmdMaterias.Parameters.Add("@id_plan", SqlDbType.Int).Value = IDPlan;
                cmdMaterias.Parameters.Add("@id_alumno", SqlDbType.Int).Value = IDAlumno;
                SqlDataReader drMaterias = cmdMaterias.ExecuteReader();

                while (drMaterias.Read())
                {
                    Materia mt = new Materia();

                    mt.ID = (int)drMaterias["id_materia"];
                    mt.Descripcion = (string)drMaterias["desc_materia"];
                    mt.HSSemanales = (int)drMaterias["hs_semanales"];
                    mt.HSTotales = (int)drMaterias["hs_totales"];
                    mt.IDPlan = (int)drMaterias["id_plan"];

                    materias.Add(mt);
                }

                drMaterias.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return materias;
        }
    }
}
