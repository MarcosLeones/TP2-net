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
    public partial class Usuarios : UIWeb
    {

        private UsuarioLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new UsuarioLogic();
                }
                return (UsuarioLogic)_logic;
            }
        }

        
        private Usuario Entity { get; set; }



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
            this.nombreTextBox.Text = this.Entity.Nombre;
            this.apellidoTextBox.Text = this.Entity.Apellido;
            this.emailTextBox.Text = this.Entity.Email;
            this.habilitadoCheckBox.Checked = this.Entity.Habilitado;
            this.nombreUsuarioTextBox.Text = this.Entity.NombreUsuario;
        }



        private void LoadEntity(Usuario usuario)
        {
            usuario.Nombre = this.nombreTextBox.Text;
            usuario.Apellido = this.apellidoTextBox.Text;
            usuario.Email = this.emailTextBox.Text;
            usuario.NombreUsuario = this.nombreUsuarioTextBox.Text;
            usuario.Clave = this.claveTextBox.Text;
            usuario.Habilitado = this.habilitadoCheckBox.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected override void ClearForm()
        {
            this.nombreTextBox.Text = String.Empty;
            this.apellidoTextBox.Text = String.Empty;
            this.emailTextBox.Text = String.Empty;
            this.habilitadoCheckBox.Checked = false;
            this.nombreUsuarioTextBox.Text = String.Empty;
        }


        protected override void EnableForm(bool enable)
        {
            this.nombreTextBox.Enabled = enable;
            this.apellidoTextBox.Enabled = enable;
            this.emailTextBox.Enabled = enable;
            this.nombreUsuarioTextBox.Enabled = enable;
            this.claveTextBox.Enabled = enable;
            this.claveLabel.Enabled = enable;
            this.repetirClaveTextBox.Enabled = enable;
            this.repetirClaveLabel.Enabled = enable;
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
                        this.Entity = new Usuario();
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
                        this.Entity = new Usuario();
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
            nombreValidator.Validate();
            apellidoValidator.Validate();
            nombreUsuarioValidator.Validate();
            emailValidator.Validate();
            claveValidator.Validate();
            repetirClaveValidator.Validate();

            if (!this.nombreValidator.IsValid) return false;
            if (!this.apellidoValidator.IsValid) return false;
            if (!this.nombreUsuarioValidator.IsValid) return false;
            if (!this.emailValidator.IsValid) return false;
            if (!this.claveValidator.IsValid) return false;
            if (!this.repetirClaveValidator.IsValid) return false;
            return true;
        }

    }
}