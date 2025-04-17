using dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
	public partial class Detalles : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if ((Request.QueryString["id"] != null))
            {
                NegocioArticulos negocio = new NegocioArticulos();
                Articulos aux = (Articulos)negocio.listarConId(Request.QueryString["id"]);

                txtId.Text = aux.Id.ToString();
                txtCodigo.Text = aux.Codigo;
                txtNombre.Text = aux.Nombre;
                txtImagenUrl.Text = aux.ImagenUrl;
                txtDescripcion.Text = aux.Descripcion;
                txtPrecio.Text = aux.Precio.ToString();
                txtImagenUrl_TextChanged(sender, e);

                ddlMarcas.Text = (aux.Marca.Descripcion).ToString();
                ddlCategorias.Text = (aux.Categoria.Descripcion).ToString();

                txtId.Enabled = false;
                txtCodigo.Enabled = false;
                txtNombre.Enabled = false;
                txtImagenUrl.Enabled = false;
                txtDescripcion.Enabled = false;
                txtPrecio.Enabled = false;
                ddlCategorias.Enabled = false;
                ddlMarcas.Enabled = false;

            }
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImagenUrl.Text;
        }
    }
}