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
    public partial class CursoDesktop : ApplicationForm
    {
        public CursoDesktop()
        {
            InitializeComponent();
        }

        public Curso CursoActual { get; set; }

        public CursoDesktop(ModoForm modo) : this() { Modo = modo; }

        public CursoDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            CursoLogic cl = new CursoLogic();
            CursoActual = cl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos() {

            this.txtIDcurso.Text = this.CursoActual.ID.ToString();
            this.txtComision.Text = this.CursoActual.IDComision.ToString();
            this.txtMateria.Text = this.CursoActual.IDMateria.ToString();
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.cupo.ToString();

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
        public override void MapearADatos() {

            if (this.Modo == ModoForm.Alta)
            {
                this.CursoActual = new Curso();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.CursoActual.IDComision = int.Parse(this.txtComision.Text);
                this.CursoActual.IDMateria = int.Parse(this.txtMateria.Text);
                this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                this.CursoActual.cupo = int.Parse(this.txtCupo.Text);
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    CursoActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    CursoActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    CursoActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    CursoActual.State = BusinessEntity.States.Unmodified;
                    break;
            }
        }
        public override void GuardarCambios() {

            MapearADatos();
            CursoLogic cl = new CursoLogic();
            cl.Save(CursoActual);

        }
        public override bool Validar() {

            if (this.txtCupo.Text.Length == 0 || this.txtAnioCalendario.Text.Length == 0 || this.txtComision.Text.Length == 0 || this.txtMateria.Text.Length == 0 )
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var regEx = new Regex("^[0-9]+$");

            if (!regEx.IsMatch(this.txtCupo.Text) || !regEx.IsMatch(this.txtMateria.Text) || !regEx.IsMatch(this.txtAnioCalendario.Text) || !regEx.IsMatch(this.txtComision.Text))
            {
                Notificar("Error", "El o los elementos deben ser un numero", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
