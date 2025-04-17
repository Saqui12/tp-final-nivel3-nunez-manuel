using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
	public partial class CambiarPass : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Usuario user = (Usuario)Session["user"];
            NegocioUsuario negocio = new NegocioUsuario();
            negocio.actualizarPass(user,txtpass2.Text);
            Response.Redirect("MiPerfil.aspx", false);
        }
    }
}