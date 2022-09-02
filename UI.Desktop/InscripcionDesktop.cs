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

        public AlumnoInscripcion Inscripcion { get; set; }

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
            Inscripcion = new AlumnoInscripcion();
            Inscripcion.IDAlumno = sesion.ID;
        }

        private void InscripcionDesktop_Load(object sender, EventArgs e)
        {
            this.txtPlan.Text = Sesion.IDPlan.ToString();

            InscripcionLogic il = new InscripcionLogic();
            this.cbComision.DataSource = il.GetComisionesByPlan(Sesion.IDPlan);
            this.cbComision.DisplayMember = "Descripcion";
            this.cbComision.ValueMember = "ID";

           
        }

        private void btnComision_Click(object sender, EventArgs e)
        {
            this.IDComision = (int)cbComision.SelectedValue;

            InscripcionLogic il = new InscripcionLogic();
            this.cbMateria.DataSource = il.GetMateriasByPlanFiltraPorAlumno(Sesion.IDPlan, Sesion.ID);
            this.cbMateria.DisplayMember = "Descripcion";
            this.cbMateria.ValueMember = "ID";

            cbComision.Enabled = false;
            btnComision.Enabled = false;
            cbMateria.Enabled = true;



        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.IDMateria = (int)cbMateria.SelectedValue;

            InscripcionConfirma inscripcionConfirma = new InscripcionConfirma(this.Sesion, this.IDComision, this.IDMateria);
            inscripcionConfirma.ShowDialog();

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
