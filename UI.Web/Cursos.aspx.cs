using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }


        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.cupoLabel.Text = this.Entity.cupo.ToString();
            this.anioLabel.Text = this.Entity.AnioCalendario.ToString();
            this.materiaValidator.Text = this.Entity.IDMateria.ToString();
            this.ComisionLabel.Text = this.Entity.IDComision.ToString();
        }



        private void LoadEntity(Curso curso)
        {
            curso.cupo = int.Parse(this.cupoTextBox.Text);
            curso.AnioCalendario = int.Parse(this.anioTextBox.Text);
            curso.IDMateria = int.Parse(this.materiaTextBox.Text);
            curso.IDComision = int.Parse(this.comisionTextBox.Text);
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
            this.materiaTextBox.Text = String.Empty;
            this.comisionTextBox.Text = String.Empty;


        }


        protected override void EnableForm(bool enable)
        {
            this.cupoTextBox.Enabled = enable;
            this.anioTextBox.Enabled = enable;
            this.materiaTextBox.Enabled = enable;
            this.comisionTextBox.Enabled = enable;

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
            cupoValidator.Validate();
            anioValidator.Validate();
            materiaValidator.Validate();
            comisionValidator.Validate();


            if (!this.cupoValidator.IsValid) return false;
            if (!this.anioValidator.IsValid) return false;
            if (!this.materiaValidator.IsValid) return false;
            if (!this.materiaValidator.IsValid) return false;

            return true;
        }

    }
}