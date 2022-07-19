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
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes", sqlConn);

                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                while (drPlanes.Read())
                {
                    Plan pl = new Plan();

                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IDEspecialidad = (int)drPlanes["id_especialidad"];

                    planes.Add(pl);
                }

                drPlanes.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return planes;
        }



        public Plan GetOne(int ID)
        {
            Plan pl = new Plan();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPlanes = new SqlCommand("select * from planes where id_plan=@id", sqlConn);
                cmdPlanes.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlanes = cmdPlanes.ExecuteReader();

                if (drPlanes.Read())
                {
                    pl.ID = (int)drPlanes["id_plan"];
                    pl.Descripcion = (string)drPlanes["desc_plan"];
                    pl.IDEspecialidad = (int)drPlanes["id_especialidad"];
                }

                drPlanes.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar plan", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return pl;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void DeleteByEspecialidad(int IDEspecialidad)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete planes where id_especialidad=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = IDEspecialidad;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar planes por especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }


        protected void Update(Plan pl)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE planes set desc_plan=@desc, id_especialidad=@id_esp WHERE id_plan=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = pl.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = pl.Descripcion;
                cmdSave.Parameters.Add("id_esp", SqlDbType.Int).Value = pl.IDEspecialidad;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


        protected void Insert(Plan pl)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO planes (desc_plan, id_especialidad) VALUES (@desc, @id_esp) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = pl.Descripcion;
                cmdSave.Parameters.Add("id_esp", SqlDbType.Int).Value = pl.IDEspecialidad;

                pl.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


        public void Save(Plan pl)
        {

            if (pl.State == BusinessEntity.States.Deleted)
            {
                this.Delete(pl.ID);
            }
            else if (pl.State == BusinessEntity.States.New)
            {
                this.Insert(pl);
            }
            else if (pl.State == BusinessEntity.States.Modified)
            {
                this.Update(pl);
            }
            pl.State = BusinessEntity.States.Unmodified;
        }


    }
}
