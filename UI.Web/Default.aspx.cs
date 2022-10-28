using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void usuariosLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Usuarios.aspx");
        }

        protected void especialidadesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Especialidades.aspx");
        }

        protected void planesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Planes.aspx");
        }

        protected void comisionesLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Comisiones.aspx");
        }

        protected void materiasLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Materias.aspx");
        }

        protected void cursosLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos.aspx");
        }
    }
}