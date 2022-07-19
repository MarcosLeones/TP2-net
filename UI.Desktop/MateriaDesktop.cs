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
    public partial class MateriaDesktop : ApplicationForm
    {

        public Materia MateriaActual { get; set; }

        public MateriaDesktop()
        {
            InitializeComponent();
        }

        public MateriaDesktop(ModoForm modo) : this() { Modo = modo; }

        public MateriaDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHSSemanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHSTotales.Text = this.MateriaActual.HSTotales.ToString();
            this.txtIDPlan.Text = this.MateriaActual.IDPlan.ToString();

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
                this.MateriaActual = new Materia();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.MateriaActual.Descripcion = this.txtDescripcion.Text;
                this.MateriaActual.HSSemanales = Int32.Parse(this.txtHSSemanales.Text);
                this.MateriaActual.HSTotales = Int32.Parse(this.txtHSTotales.Text);
                this.MateriaActual.IDPlan = Int32.Parse(this.txtIDPlan.Text);
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    MateriaActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    MateriaActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    MateriaActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    MateriaActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            MateriaLogic ml = new MateriaLogic();
            ml.Save(MateriaActual);
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0 || this.txtIDPlan.Text.Length == 0
                || this.txtHSSemanales.Text.Length == 0 || this.txtHSTotales.Text.Length == 0)
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
    }
}
