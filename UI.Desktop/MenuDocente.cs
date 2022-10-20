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
    public partial class MenuDocente : ApplicationForm
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
           this.HideAndShow(personas);

           //Docentes docentes = new Docentes();
           //docentes.ShowDialog();
        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
            //Usuarios usuarios = new Usuarios();
            //usuarios.ShowDialog();
            Personas personas = new Personas(Sesion, false);
            this.HideAndShow(personas);
            //Alumnos alumnos = new Alumnos();
            //alumnos.ShowDialog();
        }

        private void btnEspecialidades_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            this.HideAndShow(especialidades);
        }

        private void btnPlanes_Click(object sender, EventArgs e)
        {
            Planes planes = new Planes();
            this.HideAndShow(planes);
        }

        private void btnMaterias_Click(object sender, EventArgs e)
        {
            Materias materias = new Materias();
            this.HideAndShow(materias);
        }

        private void btnComisiones_Click(object sender, EventArgs e)
        {
            Comisiones comisiones = new Comisiones();
            this.HideAndShow(comisiones);
        }

        private void btnCursos_Click(object sender, EventArgs e)
        {
            Cursos cursos = new Cursos();
            this.HideAndShow(cursos);
        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            DictadoDesktop dictadoDesktop = new DictadoDesktop(Sesion);
            this.HideAndShow(dictadoDesktop);
        }

        private void btnRepoPlanes_Click(object sender, EventArgs e)
        {
            ReportesPlanesDesktop repPlanes = new ReportesPlanesDesktop();
            this.HideAndShow(repPlanes);
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            RegistroNotasDesktop regNotas = new RegistroNotasDesktop(Sesion);
            this.HideAndShow(regNotas);
        }

        private void btnRepoCursos_Click(object sender, EventArgs e)
        {
            ReportesCursosDesktop repCursos = new ReportesCursosDesktop();
            this.HideAndShow(repCursos);
        }



    }
}
