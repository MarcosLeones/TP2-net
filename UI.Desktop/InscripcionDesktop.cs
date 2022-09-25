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
    public partial class InscripcionDesktop : Form
    {
        public Persona Sesion { get; set; }

        public Plan PlanActual { get; set; }

        public int IDComision { get; set; }

        public int IDMateria { get; set; }

        public InscripcionDesktop()
        {
            InitializeComponent();
        }

        public InscripcionDesktop(Persona sesion)
        {
            InitializeComponent();
            Sesion = sesion;
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(Sesion.IDPlan);
               
        }

        private void InscripcionDesktop_Load(object sender, EventArgs e)
        {
            this.txtPlan.Text = PlanActual.Descripcion;

            InscripcionLogic il = new InscripcionLogic();
            this.cbComision.DataSource = il.GetComisionesByPlan(Sesion.IDPlan);
            this.cbComision.DisplayMember = "Descripcion";
            this.cbComision.ValueMember = "ID";

            //Esto es temporal porque no funciona el DataSource del ComboBox
                MateriaLogic ml = new MateriaLogic();
                this.cbMateria.DataSource = ml.GetAll();
                this.cbMateria.DisplayMember = "Descripcion";
                this.cbMateria.ValueMember = "ID";
                this.cbMateria.Refresh();
            //Fin temporal
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            this.IDComision = (int)cbComision.SelectedValue;

            InscripcionLogic il = new InscripcionLogic();
            //this.cbMateria.DataSource = il.GetMateriasByPlanFiltraPorAlumno(Sesion.IDPlan, Sesion.ID);
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.ValueMember = "ID";
            this.cbMateria.Refresh();
            
            cbComision.Enabled = false;
            btnComision.Enabled = false;
            cbMateria.Enabled = true;
            btnSiguiente.Enabled = true;

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.IDMateria = (int)cbMateria.SelectedValue;

            InscripcionConfirma inscripcionConfirma = new InscripcionConfirma(this.Sesion, this.PlanActual, this.IDComision, this.IDMateria);
            inscripcionConfirma.ShowDialog();

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
