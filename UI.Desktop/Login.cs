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
    public partial class Login : Form
    {
        private LoginLogic login;
        public Login()
        {
            InitializeComponent();
            login = new LoginLogic();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = this.txtUsuario.Text;
            string clave = this.txtClave.Text;

            Persona p = login.validarIngreso(usuario, clave);
            if (p != null)
            {
                if (p.TipoPersona == Persona.TiposPersonas.Alumno)
                {
                    MenuAlumno ma = new MenuAlumno(p);
                    ma.ShowDialog();
                }
                else
                {
                    MenuDocente md = new MenuDocente(p);
                    md.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Usuario y clave incorrectos.","Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
