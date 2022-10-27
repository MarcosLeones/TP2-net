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
    public partial class DictadoDesktop : ApplicationForm
    {
        public Persona Sesion { get; set; }

        public DictadoDesktop()
        {
            InitializeComponent();
        }

        public DictadoDesktop(Persona sesion)
        {
            InitializeComponent();
            Sesion = sesion;
        }

        private void DictadoDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            this.cbPlanes.DataSource = pl.GetAll();
            this.cbPlanes.DisplayMember = "Descripcion";
            this.cbPlanes.ValueMember = "ID";

            ComisionLogic cl = new ComisionLogic();
            this.cbComisiones.DataSource = cl.GetAll();
            this.cbComisiones.DisplayMember = "Descripcion";
            this.cbComisiones.ValueMember = "ID";

            MateriaLogic ml = new MateriaLogic();
            this.cbMaterias.DataSource = ml.GetAll();
            this.cbMaterias.DisplayMember = "Descripcion";
            this.cbMaterias.ValueMember = "ID";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            int idPlan = (int)cbPlanes.SelectedValue;
            int idComision = (int)cbComisiones.SelectedValue;
            int idMateria = (int)cbMaterias.SelectedValue;
            try { 
                DictadoConfirma dc = new DictadoConfirma(Sesion, idPlan, idComision, idMateria);
                this.HideAndShow(dc);
            } catch (Exception ex) {
                Notificar("ERROR", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
