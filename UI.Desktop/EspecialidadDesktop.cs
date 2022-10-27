using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;


namespace UI.Desktop
{
    public partial class EspecialidadDesktop : ApplicationForm
    {

        public Especialidad EspecialidadActual { get; set; }


        public EspecialidadDesktop()
        {
            InitializeComponent();
        }
        public EspecialidadDesktop(ModoForm modo) : this() { Modo = modo; }

        public EspecialidadDesktop(int ID, ModoForm modo) : this()
        {
            Modo = modo;
            EspecialidadLogic el = new EspecialidadLogic();
            EspecialidadActual = el.GetOne(ID);
            MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;

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
                this.EspecialidadActual = new Especialidad();
            }


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.EspecialidadActual.Descripcion = this.txtDescripcion.Text;
            }

            switch (this.Modo)
            {
                case ModoForm.Alta:
                    EspecialidadActual.State = BusinessEntity.States.New;
                    break;
                case ModoForm.Modificacion:
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                    break;
                case ModoForm.Baja:
                    EspecialidadActual.State = BusinessEntity.States.Deleted;
                    break;
                case ModoForm.Consulta:
                    EspecialidadActual.State = BusinessEntity.States.Unmodified;
                    break;
            }

        }


        public override void GuardarCambios()
        {
            MapearADatos();
            EspecialidadLogic el = new EspecialidadLogic();
            el.Save(EspecialidadActual);
        }


        public override bool Validar()
        {
            if (this.txtDescripcion.Text.Length == 0 )
            {
                Notificar("Error", "Hay campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }



        private void btnAceptar_Click_1(object sender, EventArgs e)
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
    }
}
