using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Util;
using System.Data;

namespace UI.Web
{
    public partial class Cursos : UIWeb
    {

        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return (CursoLogic)_logic;
            }
        }


        private Curso Entity { get; set; }



        protected override void LoadGrid()
        {
            DataTable table = new DataTable("cursosDT");

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Descripcion", typeof(string));
            table.Columns.Add("AnioCalendario", typeof(int));
            table.Columns.Add("Cupo", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("Comision", typeof(string));


            List<ContenedorCurso> cursos = this.Logic.GetCursosCompletos();

            foreach (ContenedorCurso c in cursos)
            {
                DataRow row = table.NewRow();
                row["ID"] = c.Curso.ID;
                row["Descripcion"] = c.Curso.Descripcion;
                row["AnioCalendario"] = c.Curso.AnioCalendario;
                row["Cupo"] = c.Curso.cupo;
                row["Materia"] = c.Materia.Descripcion;
                row["Comision"] = c.Comision.Descripcion;
                table.Rows.Add(row);
            }

            this.gridView.DataSource = table;
            this.gridView.DataBind();
        }


        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            this.cupoTextBox.Text = this.Entity.cupo.ToString();
            this.anioTextBox.Text = this.Entity.AnioCalendario.ToString();
            //this.materiaTextBox.Text = this.Entity.IDMateria.ToString();
            //this.comisionTextBox.Text = this.Entity.IDComision.ToString();
            this.materiaDropDown.SelectedValue = this.Entity.IDMateria.ToString();
            this.comisionDropDown.SelectedValue=this.Entity.IDComision.ToString();
        }



        private void LoadEntity(Curso curso)
        {
            curso.Descripcion = this.descripcionTextBox.Text;
            curso.cupo = int.Parse(this.cupoTextBox.Text);
            curso.AnioCalendario = int.Parse(this.anioTextBox.Text);
            //curso.IDMateria = int.Parse(this.materiaTextBox.Text);
            //curso.IDComision = int.Parse(this.comisionTextBox.Text);
            curso.IDMateria = int.Parse(this.materiaDropDown.SelectedValue);
            curso.IDComision = int.Parse(this.comisionDropDown.SelectedValue);
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected override void ClearForm()
        {
            this.cupoTextBox.Text = String.Empty;
            this.anioTextBox.Text = String.Empty;
            //this.materiaTextBox.Text = String.Empty;
            //this.comisionTextBox.Text = String.Empty;


        }


        protected override void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.cupoTextBox.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            //this.materiaTextBox.Enabled = enable;
            //this.comisionTextBox.Enabled = enable;
            this.materiaDropDown.Enabled = enable;
            this.comisionDropDown.Enabled = enable;

        }

        protected override void aceptarLinkButton_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;

                case FormModes.Modificacion:
                    if (Validaciones())
                    {
                        this.Entity = new Curso();
                        this.Entity.ID = this.SelectedID;
                        this.Entity.State = BusinessEntity.States.Modified;
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }

                    break;

                case FormModes.Alta:
                    if (Validaciones())
                    {
                        this.Entity = new Curso();
                        this.LoadEntity(this.Entity);
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                    }

                    break;
            }

        }

        public bool Validaciones()
        {
            descripcionValidator.Validate();
            cupoValidator.Validate();
            anioValidator.Validate();
            //materiaValidator.Validate();
            //comisionValidator.Validate();

            if (!this.descripcionValidator.IsValid) return false;
            if (!this.cupoValidator.IsValid) return false;
            if (!this.anioValidator.IsValid) return false;
            //if (!this.materiaValidator.IsValid) return false;
            //if (!this.comisionValidator.IsValid) return false;

            return true;
        }

    }
}