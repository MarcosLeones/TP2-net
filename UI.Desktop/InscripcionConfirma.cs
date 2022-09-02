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
    public partial class InscripcionConfirma : Form
    {
        public Persona Sesion { get; set; }
        public Comision ComisionActual { get; set; }
        public Materia MateriaActual { get; set; }
        public Curso CursoActual { get; set; }

        public List<ParDocenteCurso> Docentes { get; set; }

        public InscripcionConfirma()
        {
            InitializeComponent();
        }

        public InscripcionConfirma(Persona sesion, int IDComision, int IDMateria)
        {
            InitializeComponent();
            Sesion = sesion;
            ComisionLogic comisionLogic = new ComisionLogic();
            ComisionActual = comisionLogic.GetOne(IDComision);
            MateriaLogic materiaLogic = new MateriaLogic();
            MateriaActual = materiaLogic.GetOne(IDMateria);
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            CursoActual = inscripcionLogic.GetCursoByComisionMateriaAnio(IDComision, IDMateria);
            Docentes = inscripcionLogic.GetDocentesByCurso(CursoActual);
        }

        private void InscripcionConfirma_Load(object sender, EventArgs e)
        {

        }
    }
}
