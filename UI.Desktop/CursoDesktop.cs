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
            this.txtAnioCalendario.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.cupo.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion.ToString();

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

                this.CursoActual.AnioCalendario = int.Parse(this.txtAnioCalendario.Text);
                this.CursoActual.cupo = int.Parse(this.txtCupo.Text);
                this.CursoActual.IDComision = (int)this.cbComisiones.SelectedValue;
                this.CursoActual.IDMateria = (int)this.cbMaterias.SelectedValue;
                this.CursoActual.Descripcion = (string)this.txtDescripcion.Text;
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

            if (this.txtCupo.Text.Length == 0 || this.txtAnioCalendario.Text.Length == 0 || this.txtDescripcion.Text.Length == 0)
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            var regEx = new Regex("^[0-9]+$");

            if (!regEx.IsMatch(this.txtCupo.Text) ||  !regEx.IsMatch(this.txtAnioCalendario.Text))
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

        private void CursoDesktop_Load(object sender, EventArgs e)
        {
            ComisionLogic cl = new ComisionLogic();
            this.cbComisiones.DataSource = cl.GetAll();
            this.cbComisiones.DisplayMember = "Descripcion";
            this.cbComisiones.ValueMember = "ID";
            if (this.Modo != ModoForm.Alta)
            {
                this.cbComisiones.SelectedValue = this.CursoActual.IDComision;
            }

            MateriaLogic ml = new MateriaLogic();
            this.cbMaterias.DataSource = ml.GetAll();
            this.cbMaterias.DisplayMember = "Descripcion";
            this.cbMaterias.ValueMember = "ID";
            if (this.Modo != ModoForm.Alta)
            {
                this.cbMaterias.SelectedValue = this.CursoActual.IDMateria;
            }
        }
    }
}
