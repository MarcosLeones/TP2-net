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
    public partial class DictadoConfirma : Form
    {
        public Persona Sesion { get; set; }
        public Curso CursoActual { get; set; }
        public Plan PlanActual { get; set; }
        public Comision ComisionActual { get; set; }
        public Materia MateriaActual { get; set; } 
        public List<ParDocenteCurso> DocentesActuales { get; set; }


        public DictadoConfirma()
        {
            InitializeComponent();
        }

        public DictadoConfirma(Persona sesion, int idPlan, int idComision, int idMateria)
        {
            InitializeComponent();

            Sesion = sesion;

            InscripcionLogic il = new InscripcionLogic();
            CursoActual = il.GetCursoByComisionMateriaAnio(idPlan, idComision);
            PlanLogic pl = new PlanLogic();
            PlanActual = pl.GetOne(idPlan);
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(idComision);
            MateriaLogic ml = new MateriaLogic();
            MateriaActual = ml.GetOne(idMateria);
            DocentesActuales = il.GetDocentesByCurso(CursoActual);
            
        }

        private void DictadoConfirma_Load(object sender, EventArgs e)
        {
            //Llena los valores del ComboBox de cargos
            this.cbCargo.DataSource = Enum.GetValues(typeof(DocenteCurso.TiposCargos));


            //Carga los datos en los textbox
            this.txtPlan.Text = PlanActual.Descripcion;
            this.txtComision.Text = ComisionActual.Descripcion;
            this.txtMateria.Text = MateriaActual.Descripcion;
            this.txtCurso.Text = CursoActual.Descripcion;


            //Arma una lista de docentes con los cargos para cargar en la grilla
            List<DocenteCargo> cargos = new List<DocenteCargo>();
            foreach (ParDocenteCurso pdc in DocentesActuales)
            {
                DocenteCargo cargo = new DocenteCargo();
                cargo.Nombre = pdc.Docente.Nombre;
                cargo.Apellido = pdc.Docente.Apellido;
                cargo.Cargo = pdc.Dictado.Cargo.ToString();
                cargos.Add(cargo);
            }
            this.dgvDocentes.DataSource = cargos;

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            DocenteCurso dictado = new DocenteCurso();
            dictado.IDCurso = CursoActual.ID;
            dictado.IDDocente = Sesion.ID;
            dictado.Cargo = (DocenteCurso.TiposCargos)this.cbCargo.SelectedValue;
            dictado.State = BusinessEntity.States.New;

            InscripcionLogic il = new InscripcionLogic();
            try
            {
                il.InscribirDocente(dictado);
                MessageBox.Show("Se registró con éxito como docente del curso.","Docente registrado",MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Close();
            }
            
        }
    }
}
