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
        public Plan PlanActual { get; set; }
        public Comision ComisionActual { get; set; }
        public Materia MateriaActual { get; set; }
        public Curso CursoActual { get; set; }

        public List<ParDocenteCurso> Docentes { get; set; }

        public InscripcionConfirma()
        {
            InitializeComponent();
        }

        public InscripcionConfirma(Persona sesion, Plan planActual, int IDComision, int IDMateria)
        {
            InitializeComponent();
            //setea los valores necesarios para trabajar
            Sesion = sesion;
            PlanActual = planActual;
            ComisionLogic comisionLogic = new ComisionLogic();
            ComisionActual = comisionLogic.GetOne(IDComision);
            MateriaLogic materiaLogic = new MateriaLogic();
            MateriaActual = materiaLogic.GetOne(IDMateria);
            InscripcionLogic inscripcionLogic = new InscripcionLogic();
            try
            {
                CursoActual = inscripcionLogic.GetCursoByComisionMateriaAnio(IDComision, IDMateria);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            Docentes = inscripcionLogic.GetDocentesByCurso(CursoActual);

            

            //llena los campos con datos
            this.txtPlan.Text = PlanActual.Descripcion;
            this.txtComision.Text = ComisionActual.Descripcion;
            this.txtMateria.Text = MateriaActual.Descripcion;
            this.txtCurso.Text = CursoActual.Descripcion;

            //llena la grilla con los datos de los docentes
            DataTable dt = new DataTable();
            dt.Columns.Add("Apellido", typeof(string));
            dt.Columns.Add("Nombre", typeof (string));
            dt.Columns.Add("Cargo", typeof(string));

            foreach (ParDocenteCurso pdc in Docentes)
            {
                string nombreCargo;
                if (pdc.Dictado.Cargo == DocenteCurso.TiposCargos.Titular)
                    nombreCargo = "Titular";
                else
                    nombreCargo = "Ayudante";

                dt.Rows.Add(pdc.Docente.Apellido, pdc.Docente.Nombre, nombreCargo);
            }

            this.dgvDocentes.DataSource = dt;
        }

        private void InscripcionConfirma_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion ai = new AlumnoInscripcion();
            InscripcionLogic il = new InscripcionLogic();

            ai.IDAlumno = Sesion.ID;
            ai.IDCurso = CursoActual.ID;
            ai.State = BusinessEntity.States.New;

            try
            {
                il.InscribirAlumno(ai);
                MessageBox.Show("Se ha regitrado la inscripción", "Confirmación", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
