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
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
			

			try
			{
                NegocioUsuario negocioU = new NegocioUsuario();
                Usuario user = new Usuario();
				NegocioFavoritos negocioF = new NegocioFavoritos();

				user.Email = txtEmail.Text;
				user.Pass = txtPassword.Text;

				if (negocioU.Login(user))
				{
                    Session.Add("user", negocioU.listar(user));                  
					List<string> listFav = negocioF.listarfav((((Usuario)Session["user"]).Id).ToString());                   
                    Session.Add("favoritos", listFav);
                    Response.Redirect("MiPerfil.aspx", false);
				}
				else
				{
                    txtregistro.Visible = true;
                   // Session.Add("error", "User o Pass incorrectos");
					//Response.Redirect("Error.aspx", false);
				}

            }
			catch (Exception ex)
			{
				Session.Add("error", ex.ToString());
				Response.Redirect("Error.aspx", false);
			}
        }

        protected void txtEmail_TextChanged(object sender, EventArgs e)
        {
               if (txtregistro.Visible == true)
                    txtregistro.Visible = false;

        }
    }
}