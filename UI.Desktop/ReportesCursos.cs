using Business.Entities;
using Business.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Desktop
{
    public partial class ReportesCursos : Form
    {
        private MateriaLogic materia = new MateriaLogic();
        private List<Materia> listaMaterias = new List<Materia>();
        private ComisionLogic comision = new ComisionLogic();
        private List<Comision> listaComision = new List<Comision>();

        public ReportesCursos()
        {
            InitializeComponent();
        }

        private void ReportesCursos_Load(object sender, EventArgs e)
        {
            ListarCb();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ListarCb()
        {
            listaMaterias = materia.GetAll();
            foreach (var mat in listaMaterias)
            {
                var itemToAdd = mat.Descripcion;
                if (!this.cbAsignatura.Items.Contains(itemToAdd))
                {
                    this.cbAsignatura.Items.Add(itemToAdd);
                }

            }

            listaComision = comision.GetAll();
            foreach (var com in listaComision)
            {
                var itemToAdd = com.Descripcion;
                if (!this.cbComision.Items.Contains(itemToAdd))
                {
                    this.cbComision.Items.Add(itemToAdd);
                }

            }


        }

        public void Listardgv()
        {
            if (cbComision.SelectedItem != null && cbAsignatura.SelectedItem != null)
            {

                if (cbComision.SelectedItem.ToString() != string.Empty && cbAsignatura.SelectedIndex.ToString() != string.Empty)
                {

                    var comision = listaComision.Where(lc => lc.Descripcion.ToLower() == cbComision.SelectedItem.ToString().ToLower()).FirstOrDefault();
                    var materia = listaMaterias.Where(lm => lm.Descripcion.ToLower() == cbAsignatura.SelectedItem.ToString().ToLower()).FirstOrDefault();
                    var reporteCurso = new ReporteCursoLogic();
                    List<Persona> listaPersonas = new List<Persona>();
                    reporteCurso.GetReporteCurso(comision.ID, materia.ID).ForEach(reporte => listaPersonas.Add(reporte.persona));


                    this.dgvReportesCursos.DataSource = listaPersonas;
                }
            }

        }

        private void cbAsignatura_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listardgv();
        }

        private void cbComision_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Listardgv();
        }
    }
}
