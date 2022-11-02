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
using Util;

namespace UI.Desktop
{
    public partial class Cursos : ApplicationForm
    {
        public Cursos()
        {
            InitializeComponent();
        }

        public void Listar()
        {

            DataTable table = new DataTable("cursosDT");

            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("Descripción", typeof(string));
            table.Columns.Add("Año Calendario", typeof(int));
            table.Columns.Add("Cupo", typeof(int));
            table.Columns.Add("Materia", typeof(string));
            table.Columns.Add("comisión", typeof(string));


            CursoLogic cl = new CursoLogic();
            List<ContenedorCurso> cursos = cl.GetCursosCompletos();

            foreach (ContenedorCurso c in cursos)
            {
                DataRow row = table.NewRow();
                row["ID"] = c.Curso.ID;
                row["Descripción"] = c.Curso.Descripcion;
                row["Año Calendario"] = c.Curso.AnioCalendario;
                row["Cupo"] = c.Curso.cupo;
                row["Materia"] = c.Materia.Descripcion;
                row["Comisión"] = c.Comision.Descripcion;
                table.Rows.Add(row);
            }

            this.dgvCursos.DataSource = table;
        }

        private void Curso_Load(object sender, EventArgs e)
        {
            Listar();
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
            CursoDesktop formCurso = new CursoDesktop(ApplicationForm.ModoForm.Alta);
            formCurso.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            //int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            int ID = (int)this.dgvCursos.CurrentRow.Cells["ID"].Value;

            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            //int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;
            int ID = (int)this.dgvCursos.CurrentRow.Cells["ID"].Value;

            if (this.dgvCursos.SelectedRows.Count > 0)
            {
                CursoDesktop formCurso = new CursoDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                formCurso.ShowDialog();
                this.Listar();
            }
        }
    }
}
