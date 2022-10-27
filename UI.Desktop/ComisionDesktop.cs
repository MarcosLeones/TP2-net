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
    public partial class ComisionDesktop : ApplicationForm
    {

        public Comision ComisionActual { get; set; }

        public ComisionDesktop()
        {
            InitializeComponent();
        }

        public ComisionDesktop(ModoForm modo) : this() { Modo = modo; }

        public ComisionDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            ComisionLogic cl = new ComisionLogic();
            ComisionActual = cl.GetOne(ID);
            MapearDeDatos();           
            
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.ComisionActual.ID.ToString();
            this.txtAnioEsp.Text = this.ComisionActual.AnioEspecialidad.ToString();
            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            


            switch (this.Modo)
            {
                case ModoForm.Baja:
                    this.btnAceptar.Text = "Eliminar";
                    break;
                case ModoForm.Consulta:
                    this.btnAceptar.Text = "Aceptar";
                    break;
                default:
                    this.btnAceptar.Text = "Guardar";
                    break;
            }
        }

        public override void MapearADatos()
        {
            if (this.Modo == ModoForm.Alta)
            {
                this.ComisionActual = new Comision();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.ComisionActual.AnioEspecialidad = Int32.Parse(this.txtAnioEsp.Text);
                this.ComisionActual.Descripcion = this.txtDescripcion.Text;
                this.ComisionActual.IDPlan = (int)this.cbPlanes.SelectedValue;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    ComisionActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    ComisionActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    ComisionActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    ComisionActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }

        public override void GuardarCambios()
        {
            MapearADatos();
            ComisionLogic cl = new ComisionLogic();
            cl.Save(ComisionActual);
        }

        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0 || this.txtAnioEsp.Text.Length == 0 )
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                try
                {
                    GuardarCambios();
                }
                catch (Exception ex)
                {
                    Notificar("ERROR", ex.Message + "\nNo se ha podido completar la acción.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    Close();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComisionDesktop_Load(object sender, EventArgs e)
        {
            PlanLogic pl = new PlanLogic();
            this.cbPlanes.DataSource = pl.GetAll();
            this.cbPlanes.DisplayMember = "Descripcion";
            this.cbPlanes.ValueMember = "ID";
            if(this.Modo != ModoForm.Alta)
            {
                this.cbPlanes.SelectedValue = this.ComisionActual.IDPlan;
            }
            
        }
    }
}
