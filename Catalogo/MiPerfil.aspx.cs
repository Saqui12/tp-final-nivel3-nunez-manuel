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
	public partial class MiPerfil : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Seguridad.sessionActiva(Session["user"]))
                    {
                        Usuario user = (Usuario)Session["user"];
                        txtEmail.Text = user.Email;
                        txtEmail.ReadOnly = true;
                        txtNombre.Text = user.Nombre;
                        txtApellido.Text = user.Apellido;
                        if (!string.IsNullOrEmpty(user.ImagenPerfil))
                            imgNuevoPerfil.ImageUrl = "~/Images/" + user.ImagenPerfil;
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
            NegocioUsuario negocio = new NegocioUsuario();
            Usuario user = (Usuario)Session["user"];
            
            if (txtImagen.PostedFile.FileName != "")
            {
                string ruta = Server.MapPath("./Images/");
                txtImagen.PostedFile.SaveAs(ruta + "perfil-" + user.Id + ".jpg");
                user.ImagenPerfil = "perfil-" + user.Id + ".jpg";
            }

            user.Nombre = txtNombre.Text;
            user.Email = txtEmail.Text;
            user.Apellido = txtApellido.Text;
            Image img = (Image)Master.FindControl("imgAvatar");
            img.ImageUrl = "~/Images/" + user.ImagenPerfil;

            negocio.actualizar(user);
            Session.Add("user", user);

            Response.Redirect("/Default.aspx", false);
        }
    }
	
}