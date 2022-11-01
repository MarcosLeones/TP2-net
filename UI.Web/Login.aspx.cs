using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Web.Security;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ingresarButton_Click(object sender, EventArgs e)
        {
            if (Validaciones()) { 

                string usuario = this.usuarioTextBox.Text;
                string password = this.passwordTextBox.Text;

                LoginLogic login = new LoginLogic();
                Persona p = login.validarIngreso(usuario, password);

                if (p != null)
                {

                    if (p.TipoPersona == Persona.TiposPersonas.Docente)
                    {
                        FormsAuthentication.RedirectFromLoginPage(usuarioTextBox.Text, true);
                        Response.Redirect("~/Default.aspx");
                    }
                    else
                    {
                        mensajeLabel.Text = "El ingreso por web actualmente sólo se encuentra disponible para docentes.";
                    } 
                }
                else
                {
                    mensajeLabel.Text = "Usuario y/o contraseña incorrectos.";
                }
            }
        }

        public bool Validaciones()
        {
            usuarioValidator.Validate();
            passwordValidator.Validate();

            if (!this.usuarioValidator.IsValid) return false;
            if (!this.passwordValidator.IsValid) return false;
            return true;
        }
    }
}