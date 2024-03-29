﻿using Business.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;

namespace Data.Database
{
    public class CursoAdapter : Adapter
    {


        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos", sqlConn);

                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                while (drCursos.Read())
                {
                    Curso curso = new Curso();

                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.cupo = (int)drCursos["cupo"];
                    curso.Descripcion = (string)drCursos["descripcion"];

                    cursos.Add(curso);
                }

                drCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso curso = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCursos.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.cupo = (int)drCursos["cupo"];
                    curso.Descripcion = (string)drCursos["descripcion"];
                }

                drCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return curso;
        }


        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
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

        public void Save(Curso curso)
        {

            if (curso.State == BusinessEntity.States.Deleted)
            {
                this.Delete(curso.ID);
            }
            else if (curso.State == BusinessEntity.States.New)
            {
                this.Insert(curso);
            }
            else if (curso.State == BusinessEntity.States.Modified)
            {
                this.Update(curso);
            }
            curso.State = BusinessEntity.States.Unmodified;
        }




        protected void Update(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("UPDATE cursos set anio_calendario=@anio, id_materia=@mat, id_comision=@com, cupo=@cupo, descripcion=@descripcion WHERE id_curso=@id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@mat", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@com", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.cupo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del curso", ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Curso curso)
        {
            try
            {
                this.OpenConnection();

                SqlCommand cmdSave = new SqlCommand("INSERT INTO cursos (anio_calendario, id_materia, id_comision, cupo, descripcion) VALUES (@anio, @mat, @com, @cupo, @descripcion) select @@identity", sqlConn);

                cmdSave.Parameters.Add("@anio", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@mat", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@com", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.cupo;
                cmdSave.Parameters.Add("@descripcion", SqlDbType.VarChar, 50).Value = curso.Descripcion;

                curso.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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


        public Curso GetByComisionMateriaAnio(int comision, int materia, int anio)
        {
            Curso curso = new Curso();

            try
            {
                this.OpenConnection();

                SqlCommand cmdCursos = new SqlCommand("select * from cursos where id_comision=@comision and id_materia=@materia and anio_calendario=@anio", sqlConn);
                cmdCursos.Parameters.Add("@comision", SqlDbType.Int).Value = comision;
                cmdCursos.Parameters.Add("@materia", SqlDbType.Int).Value = materia;
                cmdCursos.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                SqlDataReader drCursos = cmdCursos.ExecuteReader();

                if (drCursos.Read())
                {
                    curso.ID = (int)drCursos["id_curso"];
                    curso.IDMateria = (int)drCursos["id_materia"];
                    curso.IDComision = (int)drCursos["id_comision"];
                    curso.AnioCalendario = (int)drCursos["anio_calendario"];
                    curso.cupo = (int)drCursos["cupo"];
                    curso.Descripcion = (string)drCursos["descripcion"];
                }

                drCursos.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada =
               new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }

            return curso;
        }


        public List<ContenedorCurso> GetCursosCompletos()
        {
            List<ContenedorCurso> lista = new List<ContenedorCurso>();

            List<Curso> cursos = this.GetAll();
            MateriaAdapter materiaAdapter = new MateriaAdapter();
            ComisionAdapter comisionAdapter = new ComisionAdapter();

            foreach(Curso cur in cursos)
            {  
                Materia mat = materiaAdapter.GetOne(cur.IDMateria);
                Comision comi = comisionAdapter.GetOne(cur.IDComision);

                ContenedorCurso cw = new ContenedorCurso();
                cw.Curso = cur;
                cw.Materia = mat;
                cw.Comision = comi;
                lista.Add(cw);
            }

            return lista;
        }

    }
}