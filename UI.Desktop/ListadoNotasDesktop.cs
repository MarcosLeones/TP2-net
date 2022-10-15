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
    public partial class ListadoNotasDesktop : Form
    {
        public Persona Sesion { get; set; }

        public ListadoNotasDesktop()
        {
            InitializeComponent();
        }

        public ListadoNotasDesktop(Persona sesion)
        {
            Sesion = sesion;
            InitializeComponent();
        }

        private void ListadoNotasDesktop_Load(object sender, EventArgs e)
        {
            InscripcionLogic il = new InscripcionLogic();
            this.dgvNotas.DataSource = il.GetNotas(Sesion);
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
