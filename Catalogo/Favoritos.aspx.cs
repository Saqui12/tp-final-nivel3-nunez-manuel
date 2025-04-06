using dominio;
using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] != null)
            {
                NegocioArticulos negocio = new NegocioArticulos();
                Usuario user = (Usuario)Session["user"];
                repeater1.DataSource = negocio.listarFavoritos(user.Id.ToString());
                repeater1.DataBind();
            }

        }


        protected void repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "Remover")
            {
                
                NegocioFavoritos favoritos = new NegocioFavoritos();
                Usuario user = (Usuario)Session["User"];
                List<string> listaFav = (List<string>)Session["favoritos"];
                int idArt = Convert.ToInt32(e.CommandArgument);

                favoritos.eliminar(idArt,user.Id );
                listaFav.Remove(idArt.ToString());
                
                Response.Redirect("Favoritos.aspx", false);

            }
            if (e.CommandName == "Detalle")
            {
                string id = e.CommandArgument.ToString();
                Response.Redirect("Detalles.aspx?id=" + id);
            }
        }
    }
}