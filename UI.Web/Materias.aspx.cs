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
    public partial class Materias : UIWeb
    {

        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return (MateriaLogic)_logic;
            }
        }

        private Materia Entity { get; set; }
        /*
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            this.planDropDown.DataTextField = "Descripcion";
            this.planDropDown.DataValueField = "ID";
            PlanLogic planLogic = new PlanLogic();
            this.planDropDown.DataSource = planLogic.GetAll();
            this.planDropDown.DataBind();
        }*/
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
            this.hsSemanalesTextBox.Text = this.Entity.HSSemanales.ToString();
            this.hsTotalesTextBox.Text = this.Entity.HSTotales.ToString();
            //this.idPlanTextBox.Text = this.Entity.IDPlan.ToString();
            this.planDropDown.SelectedValue = this.Entity.IDPlan.ToString();
        }

        private void LoadEntity(Materia mt)
        {
            mt.Descripcion = this.descripcionTextBox.Text;
            mt.HSSemanales = int.Parse(this.hsSemanalesTextBox.Text);
            mt.HSTotales = int.Parse(this.hsTotalesTextBox.Text);
           //mt.IDPlan = int.Parse(this.idPlanTextBox.Text);
            mt.IDPlan = int.Parse(planDropDown.SelectedValue);
        }

        private void SaveEntity(Materia mt)
        {
            this.Logic.Save(mt);
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected override void ClearForm()
        {
            this.descripcionTextBox.Text = String.Empty;
            this.hsSemanalesTextBox.Text = String.Empty;
            this.hsTotalesTextBox.Text = String.Empty;
            //this.idPlanTextBox.Text = String.Empty;
        }


        protected override void EnableForm(bool enable)
        {
            this.descripcionTextBox.Enabled = enable;
            this.hsSemanalesTextBox.Enabled = enable;
            this.hsTotalesTextBox.Enabled = enable;
            //this.idPlanTextBox.Enabled = enable;
            this.planDropDown.Enabled = enable;
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
                        this.Entity = new Materia();
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
                        this.Entity = new Materia();
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
            hsSemanalesIntValidator.Validate();
            hsSemanalesIntValidator.Validate();
            hsTotalesValidator.Validate();
            hsTotalesIntValidator.Validate();
            //idPlanValidator.Validate();
            //idPlanIntValidator.Validate();

            if (!this.descripcionValidator.IsValid) return false;
            if (!this.hsSemanalesValidator.IsValid) return false;
            if (!this.hsSemanalesIntValidator.IsValid) return false;
            if (!this.hsTotalesValidator.IsValid) return false;
            if (!this.hsTotalesIntValidator.IsValid) return false;
            //if (!this.idPlanValidator.IsValid) return false;
            //if (!this.idPlanIntValidator.IsValid) return false;
            return true;
        }

    }
}