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
    public partial class Docentes : Form
    {
        public Docentes()
        {
            InitializeComponent();
        }

        private void Docentes_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAllDocentes();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteDesktop formDocente = new DocenteDesktop(ApplicationForm.ModoForm.Alta);
            formDocente.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formDocente.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                DocenteDesktop formDocente = new DocenteDesktop(ID, ApplicationForm.ModoForm.Baja);
                formDocente.ShowDialog();
                this.Listar();
            }
        }
    }
}
