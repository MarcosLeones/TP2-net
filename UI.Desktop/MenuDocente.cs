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

namespace UI.Desktop
{
    public partial class MenuDocente : Form
    {
        public Persona Sesion { get; set; }
        public MenuDocente()
        {
            InitializeComponent();
        }
        public MenuDocente(Persona sesion)
        {
            InitializeComponent();
            Sesion = sesion;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDocentes_Click(object sender, EventArgs e)
        {
           //Usuarios usuarios = new Usuarios();
           //usuarios.ShowDialog();
           Personas personas = new Personas(Sesion, true);
           personas.ShowDialog();

           //Docentes docentes = new Docentes();
           //docentes.ShowDialog();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            //Usuarios usuarios = new Usuarios();
            //usuarios.ShowDialog();
            Personas personas = new Personas(Sesion, false);
            personas.ShowDialog();
            //Alumnos alumnos = new Alumnos();
            //alumnos.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            especialidades.ShowDialog();
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            planes.ShowDialog();
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            materias.ShowDialog();
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            comisiones.ShowDialog();
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            cursos.ShowDialog();
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            DictadoDesktop dictadoDesktop = new DictadoDesktop(Sesion);
            dictadoDesktop.ShowDialog();
        }
    }
}
