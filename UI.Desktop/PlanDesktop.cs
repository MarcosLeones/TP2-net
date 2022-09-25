using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PlanDesktop : ApplicationForm
    {

        public Plan PlanActual { get; set; }

        public PlanDesktop()
        {
            InitializeComponent();
        }

        public PlanDesktop(ModoForm modo) : this() { Modo = modo; }

        public PlanDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;      

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
                this.PlanActual = new Plan();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.PlanActual.Descripcion = this.txtDescripcion.Text;
                this.PlanActual.IDEspecialidad = (int)this.cbEspecialidades.SelectedValue;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    PlanActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    PlanActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    PlanActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    PlanActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            PlanLogic pl = new PlanLogic();
            pl.Save(PlanActual);
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0)
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PlanDesktop_Load(object sender, EventArgs e)
        {
            EspecialidadLogic el = new EspecialidadLogic();
            this.cbEspecialidades.DataSource = el.GetAll();
            this.cbEspecialidades.DisplayMember = "Descripcion";
            this.cbEspecialidades.ValueMember = "ID";
            if (this.Modo != ModoForm.Alta)
            {
                this.cbEspecialidades.SelectedValue = this.PlanActual.IDEspecialidad;
            }
        }
    }
}
