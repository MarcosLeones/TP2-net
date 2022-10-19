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
    public partial class MenuAlumno : ApplicationForm
    {


        private Persona sesion;
        public MenuAlumno()
        {
            InitializeComponent();
        }

        public MenuAlumno(Persona p)
        {
            InitializeComponent();
            this.sesion = p;
        }

        private void MenuAlumno_Load(object sender, EventArgs e)
        {
            this.labelTitulo.Text = "¡Hola " + sesion.Nombre + "!";
        }

        private void btnInscribirse_Click(object sender, EventArgs e)
        {
            InscripcionDesktop id = new InscripcionDesktop(sesion);
            this.HideAndShow(id);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            ListadoNotasDesktop lnd = new ListadoNotasDesktop(sesion);
            this.HideAndShow(lnd);
        }
    }
}
