using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
    public partial class Comisiones : UIWeb
    {

        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return (ComisionLogic)_logic;
            }
        }

        private Comision Entity { get; set; }


        public void Selection_Change(Object sender, EventArgs e)
        {

        }

        protected override void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.anioTextBox.Text = this.Entity.AnioEspecialidad.ToString();
            this.descripcionTextBox.Text = this.Entity.Descripcion;
            
            PlanLogic pl = new PlanLogic();
            this.planList.DataSource = pl.GetAll();
            this.planList.DataBind();

        }


        /*
        private void LoadEntity(Plan pl)
        {
            pl.Descripcion = this.descripcionTextBox.Text;
            pl.IDEspecialidad = Int32.Parse(this.idEspecialidadTextBox.Text);
        }


        private void SaveEntity(Plan pl)
        {
            this.Logic.Save(pl);
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected override void ClearForm()
        {
            this.descripcionTextBox.Text = String.Empty;
            this.idEspecialidadTextBox.Text = String.Empty;
        }


        protected override void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.idEspecialidadTextBox.Enabled = enable;
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
                        this.Entity = new Plan();
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
                        this.Entity = new Plan();
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
            idEspecialidadValidator.Validate();
            idEspecialidadIntValidator.Validate();

            if (!this.descripcionValidator.IsValid) return false;
            if (!this.idEspecialidadValidator.IsValid) return false;
            if (!this.idEspecialidadIntValidator.IsValid) return false;
            return true;
        }
        */
    }
}