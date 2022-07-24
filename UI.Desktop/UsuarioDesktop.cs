using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;
using System.Text.RegularExpressions;

namespace UI.Desktop
{
    public partial class UsuarioDesktop : ApplicationForm
    {

        public Usuario UsuarioActual { get; set; }

        public UsuarioDesktop(ModoForm modo) : this() { Modo = modo; }

        public UsuarioDesktop(int ID, ModoForm modo) : this() 
        {
            Modo = modo;
            UsuarioLogic ul = new UsuarioLogic();
            UsuarioActual = ul.GetOne(ID);
            MapearDeDatos();
        }

        public UsuarioDesktop()
        {
            InitializeComponent();
        }

        public override void MapearDeDatos() 
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;

            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }

            
        }
        public override void MapearADatos() 
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.UsuarioActual = new Usuario();
            }
            

            if (this.Modo == ModoForm.Alta || this.Modo== ModoForm.Modificacion)
            {
                this.UsuarioActual.Habilitado = this.chkHabilitado.Checked;
                this.UsuarioActual.Nombre = this.txtNombre.Text;
                this.UsuarioActual.Apellido = this.txtApellido.Text;  
                this.UsuarioActual.Email = this.txtEmail.Text;
                this.UsuarioActual.NombreUsuario = this.txtUsuario.Text;
                this.UsuarioActual.Clave = this.txtClave.Text;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    UsuarioActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    UsuarioActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    UsuarioActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    UsuarioActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
            
        }
        public override void GuardarCambios() 
        {
            MapearADatos();
            UsuarioLogic ul = new UsuarioLogic();
            ul.Save(UsuarioActual);
        }


        public override bool Validar()
        {
            if ( this.txtNombre.Text.Length == 0 || this.txtApellido.Text.Length == 0 ||
                this.txtEmail.Text.Length == 0 || this.txtUsuario.Text.Length == 0 ||
                this.txtClave.Text.Length == 0 || this.txtConfirmarClave.Text.Length == 0)
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text.Length < 8 && this.txtClave.Text.Length > 0)
            {
                Notificar("Error", "La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text != this.txtConfirmarClave.Text)
            {
                Notificar("Eror", "La clave y su confirmación no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            var regExEmail = new Regex("^\\S+@\\S+\\.\\S+$");

            if (!regExEmail.IsMatch(this.txtEmail.Text))
            {
                Notificar("Error", "Email Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
