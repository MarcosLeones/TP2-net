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
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar()
        {
            PersonaLogic pl = new PersonaLogic();
            this.dgvPersonas.DataSource = pl.GetAll();
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
            PersonaDesktop formPersona = new PersonaDesktop(ApplicationForm.ModoForm.Alta);
            formPersona.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formPersona.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

            if (this.dgvPersonas.SelectedRows.Count > 0)
            {
                PersonaDesktop formPersona = new PersonaDesktop(ID, ApplicationForm.ModoForm.Baja);
                formPersona.ShowDialog();
                this.Listar();
            }
        }
    }
}
