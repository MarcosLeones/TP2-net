using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {


        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones", sqlConn);

                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                while (drComisiones.Read())
                {
                    Comision comi = new Comision();

                    comi.ID = (int)drComisiones["id_usuario"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                    

                    comisiones.Add(comi);
                }

                drComisiones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision comi = new Comision();

            try
            {
                this.OpenConnection();

                SqlCommand cmdComisiones = new SqlCommand("select * from comisiones where id_comision=@id", sqlConn);
                cmdComisiones.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drComisiones = cmdComisiones.ExecuteReader();

                if (drComisiones.Read())
                {
                    comi.ID = (int)drComisiones["id_usuario"];
                    comi.Descripcion = (string)drComisiones["desc_comision"];
                    comi.AnioEspecialidad = (int)drComisiones["anio_especialidad"];
                    comi.IDPlan = (int)drComisiones["id_plan"];
                }

                drComisiones.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar comision", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return comi;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete comisiones where id_comision=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Comision comi)
        {

            if (comi.State == BusinessEntity.States.Deleted)
            {
                this.Delete(comi.ID);
            }
            else if (comi.State == BusinessEntity.States.New)
            {
                this.Insert(comi);
            }
            else if (comi.State == BusinessEntity.States.Modified)
            {
                this.Update(comi);
            }
            comi.State = BusinessEntity.States.Unmodified;
        }




        protected void Update(Comision comi)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE comisiones set desc_comision=@desc, anio_especialidad=@anio, id_plan=@plan WHERE id_comision=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = comi.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comi.Descripcion;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@plan", SqlDbType.Int).Value = comi.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Comision comi)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO comisones (desc_comision, anio_especialidad, id_plan) VALUES (@desc, @anio, @plan) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comi.Descripcion;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = comi.AnioEspecialidad;
                cmdSave.Parameters.Add("@plan", SqlDbType.Int).Value = comi.IDPlan;

                comi.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }


    }
}
