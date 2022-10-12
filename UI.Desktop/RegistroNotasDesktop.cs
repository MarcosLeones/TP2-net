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
using Util;

namespace UI.Desktop
{
    public partial class RegistroNotasDesktop : Form
    {
        public RegistroNotasLogic rnl { get; set; }
        public Persona Sesion { get; set; }
        public RegistroNotasDesktop()
        {
            InitializeComponent();
        }

        public RegistroNotasDesktop(Persona sesion)
        {
            InitializeComponent();
            Sesion = sesion;
            rnl = new RegistroNotasLogic();
        }

        private void RegistroNotasDesktop_Load(object sender, EventArgs e)
        {
            this.cbCursos.DataSource = rnl.MostrarCursosDeDocente(Sesion);
            this.cbCursos.DisplayMember = "Descripcion";
            this.cbCursos.ValueMember = "ID";
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Curso curso = new Curso();
            curso.ID = (int)this.cbCursos.SelectedValue;
            
            this.dgvAlumnosNotas.DataSource = rnl.MostrarAlumnosPorCurso(curso);
            this.dgvAlumnosNotas.Enabled = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            List<AlumnoNota> lista = new List<AlumnoNota>();

            for (int i=0; i < dgvAlumnosNotas.RowCount; i++){
                AlumnoNota an = new AlumnoNota();
                an.IDAlumno = (int)dgvAlumnosNotas.Rows[i].Cells[0].Value;
                an.Legajo = (int)dgvAlumnosNotas.Rows[i].Cells[1].Value;
                an.Apellido = (string)dgvAlumnosNotas.Rows[i].Cells[2].Value;
                an.Nombre = (string)dgvAlumnosNotas.Rows[i].Cells[3].Value;
                an.Email = (string)dgvAlumnosNotas.Rows[i].Cells[4].Value;
                an.IDPlan = (int)dgvAlumnosNotas.Rows[i].Cells[5].Value;
                an.IDCurso = (int)dgvAlumnosNotas.Rows[i].Cells[6].Value;
                an.Nota = (int)dgvAlumnosNotas.Rows[i].Cells[7].Value;
                an.Condicion = (string)dgvAlumnosNotas.Rows[i].Cells[8].Value;
                an.IDInscripcion = (int)dgvAlumnosNotas.Rows[i].Cells[9].Value;
                lista.Add(an);
            }
                

            try
            {
                rnl.GuardarNota(lista);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
             
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
