using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoDesktop : ApplicationForm
    {
        public AlumnoDesktop()
        {
            InitializeComponent();
        }

        public Persona PersonaActual { get; set; }

        public AlumnoDesktop(ModoForm modo) : this() { Modo = modo; }

        public AlumnoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PersonaLogic pl = new PersonaLogic();
            PersonaActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtNombreUsuario.Text = this.PersonaActual.NombreUsuario;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.chkHabilitado.Checked = this.PersonaActual.Habilitado;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.dtpFechaNacimiento.Value = this.PersonaActual.FechaNacimiento;


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
                this.PersonaActual = new Persona();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {

                this.PersonaActual.Nombre = this.txtNombre.Text;
                this.PersonaActual.Apellido = this.txtApellido.Text;
                this.PersonaActual.NombreUsuario = this.txtNombreUsuario.Text;
                this.PersonaActual.Email = this.txtEmail.Text;
                this.PersonaActual.Clave = this.txtClave.Text;
                this.PersonaActual.TipoPersona = Persona.TiposPersonas.Alumno;
                this.PersonaActual.Habilitado = this.chkHabilitado.Checked;
                this.PersonaActual.Direccion = this.txtDireccion.Text;
                this.PersonaActual.Telefono = this.txtTelefono.Text;
                this.PersonaActual.FechaNacimiento = this.dtpFechaNacimiento.Value;
                this.PersonaActual.IDPlan = (int)this.cbPlanes.SelectedValue;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PersonaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PersonaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PersonaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PersonaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PersonaLogic pl = new PersonaLogic();
            pl.Save(PersonaActual);
        }


        public override bool Validar()
        {
            if (this.txtNombre.Text.Length == 0 || this.txtApellido.Text.Length == 0 ||
                this.txtEmail.Text.Length == 0 || this.txtNombreUsuario.Text.Length == 0 ||
                this.txtClave.Text.Length == 0 || this.txtRepetirClave.Text.Length == 0)
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text.Length < 8 && this.txtClave.Text.Length > 0)
            {
                Notificar("Error", "La clave debe tener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtClave.Text != this.txtRepetirClave.Text)
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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                GuardarCambios();
                Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PersonaDesktop_Load(object sender, EventArgs e)
        {

            PlanLogic pl = new PlanLogic();
            this.cbPlanes.DataSource = pl.GetAll();
            this.cbPlanes.DisplayMember = "Descripcion";
            this.cbPlanes.ValueMember = "ID";
            if (this.Modo != ModoForm.Alta)
            {
                this.cbPlanes.SelectedValue = this.PersonaActual.IDPlan;
            }

        }
    }
}
