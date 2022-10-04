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
                try
                {
                    if (p.TipoPersona == Persona.TiposPersonas.Alumno)
                    {
                        MenuAlumno ma = new MenuAlumno(p);
                        this.Hide();
                        ma.ShowDialog();

                    }
                    else
                    {
                        MenuDocente md = new MenuDocente(p);
                        this.Hide();
                        md.ShowDialog();
                    }
                }
                finally 
                {
                    this.Close();
                }

            }
            else
            {
                MessageBox.Show("Usuario y clave incorrectos.","Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
