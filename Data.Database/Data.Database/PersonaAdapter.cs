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
    public class PersonaAdapter : Adapter
    {

        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];
                    
                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {


                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];

                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Persona persona)
        {

            if (persona.State == BusinessEntity.States.Deleted)
            {
                this.Delete(persona.ID);
            }
            else if (persona.State == BusinessEntity.States.New)
            {
                this.Insert(persona);
            }
            else if (persona.State == BusinessEntity.States.Modified)
            {
                this.Update(persona);
            }
            persona.State = BusinessEntity.States.Unmodified;
        }




        protected void Update(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE personas set nombre=@nombre, apellido=@apellido, direccion=@direccion, email=@email, telefono=@telefono, fecha_nac=@fecha_nac, legajo=@legajo, tipo_persona=@tipo_persona, id_plan=@id_plan, nombre_usuario=@nombre_usuario, clave=@clave, habilitado=@habilitado WHERE id_persona=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;

                if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 0;
                else
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Persona persona)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO personas (nombre, apellido, email, direccion, telefono, fecha_nac, legajo, tipo_persona, id_plan, nombre_usuario, clave, habilitado) VALUES (@nombre, @apellido, @email, @direccion, @telefono, @fecha_nac,@legajo, @tipo_persona, @id_plan, @nombre_usuario, @clave, @habilitado) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = persona.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = persona.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = persona.Apellido;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = persona.Email;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = persona.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = persona.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = persona.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = persona.Legajo;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = persona.IDPlan;
                cmdSave.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = persona.NombreUsuario;
                cmdSave.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = persona.Clave;
                cmdSave.Parameters.Add("@habilitado", SqlDbType.Bit).Value = persona.Habilitado;

                if (persona.TipoPersona == Persona.TiposPersonas.Alumno)
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 0;
                else
                    cmdSave.Parameters.Add("@tipo_persona", SqlDbType.Int).Value = 1;

                persona.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        public List<Persona> GetAllAlumnos()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona=0", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];

                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }

        public List<Persona> GetAllDocentes()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where tipo_persona=1", sqlConn);

                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona per = new Persona();

                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];

                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                    personas.Add(per);
                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return personas;
        }


        public Persona GetByNombreUsuario(string NombreUsuario)
        {
            Persona per = new Persona();

            try
            {
                this.OpenConnection();

                SqlCommand cmdPersonas = new SqlCommand("select * from personas where nombre_usuario=@nombre_usuario", sqlConn);
                cmdPersonas.Parameters.Add("@nombre_usuario", SqlDbType.VarChar,50).Value = NombreUsuario;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {


                    per.ID = (int)drPersonas["id_persona"];
                    per.Nombre = (string)drPersonas["nombre"];
                    per.Apellido = (string)drPersonas["apellido"];
                    per.Direccion = (string)drPersonas["direccion"];
                    per.Email = (string)drPersonas["email"];
                    per.Telefono = (string)drPersonas["telefono"];
                    per.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    per.Legajo = (int)drPersonas["legajo"];
                    per.IDPlan = (int)drPersonas["id_plan"];
                    per.NombreUsuario = (string)drPersonas["nombre_usuario"];
                    per.Clave = (string)drPersonas["clave"];
                    per.Habilitado = (bool)drPersonas["habilitado"];

                    if ((int)drPersonas["tipo_persona"] == 0)
                        per.TipoPersona = Persona.TiposPersonas.Alumno;
                    else
                        per.TipoPersona = Persona.TiposPersonas.Docente;

                }

                drPersonas.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar persona", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return per;
        }
    }
}
