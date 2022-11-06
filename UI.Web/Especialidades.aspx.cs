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
    public partial class WebForm1 : UIWeb
    {
        private EspecialidadLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new EspecialidadLogic();
                }
                return (EspecialidadLogic)_logic;
            }
        }


        private Especialidad Entity { get; set; }



        protected override void LoadGrid()
        {
            if (Session["user"] == null)
                Response.Redirect("login.aspx", true);

            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }


        protected override void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.descripcionTextBox.Text = this.Entity.Descripcion;

        }



        private void LoadEntity(Especialidad esp)
        {
            esp.Descripcion = this.descripcionTextBox.Text;
        }

        private void SaveEntity(Especialidad esp)
        {
            this.Logic.Save(esp);
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected override void ClearForm()
        {
            this.descripcionTextBox.Text = String.Empty;
        }


        protected override void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
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
                    if (Validaciones()) { 
                        this.Entity = new Especialidad();
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
                        this.Entity = new Especialidad();
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

            if (!this.descripcionValidator.IsValid) return false;
            return true;
        }


    }
}