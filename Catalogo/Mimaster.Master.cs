using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Catalogo
{
	public partial class Mimaster : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			

			if( (Page is Favoritos) || (Page is MiPerfil) || (Page is Administrar))
			{
				if (!Seguridad.sessionActiva(Session["user"]))
				{
					Response.Redirect("Login.aspx", false);
				}
			}
			if (Seguridad.sessionActiva(Session["user"]) && ((Usuario)Session["user"]).ImagenPerfil != null)
			{
                  imgAvatar.ImageUrl = "~/Images/" + ((Usuario)Session["user"]).ImagenPerfil;
								
			}
			else
			{
                imgAvatar.ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/8/89/Portrait_Placeholder.png";
            }
		}

        protected void btnlogout_Click(object sender, EventArgs e)
        {

            

            Session.Clear();
			Response.Redirect("Default.aspx", false);
        }
    }
}