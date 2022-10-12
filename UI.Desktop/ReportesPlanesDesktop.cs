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
    public partial class ReportesPlanesDesktop : Form
    {
        private PlanLogic planes = new PlanLogic();
        private List<Plan> listaPlanes = new List<Plan>();

        public ReportesPlanesDesktop()
        {
            InitializeComponent();
        }

        private void ReportesPlanesDesktop_Load(object sender, EventArgs e)
        {
            ListarCb();
            

        }

        public void Listardgv()
        {
            
            MateriaLogic materia = new MateriaLogic();
            var listaMateriasSinFiltro = materia.GetAll();
            foreach (var plan in listaPlanes)
            {
                if (cbReportesPlanes.SelectedItem.ToString() == plan.Descripcion )
                {
                    this.dgvReportePlanes.DataSource = listaMateriasSinFiltro.Where(lm => lm.IDPlan == plan.ID).ToList();
                }
                
            }
                       
        }


        public void ListarCb()
        {
            listaPlanes = planes.GetAll();
            foreach (var plan in listaPlanes)//este foreach solamente esta implementado porque no se solucionó todavia la falta de nomralizacion de la tabla Planes en la DB
            {
                var itemToAdd = plan.Descripcion;
                if (!this.cbReportesPlanes.Items.Contains(itemToAdd))
                {
                    this.cbReportesPlanes.Items.Add(itemToAdd); 
                }
                
            }
            
        }

        private void cbReportesPlanes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listardgv();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
