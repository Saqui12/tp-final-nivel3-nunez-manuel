using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Negocio;

namespace Catalogo
{
	public partial class FormularioProducto : System.Web.UI.Page
	{
        public bool ConfirmaEliminacion { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
            txtId.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    NegocioMarcas negocioM = new NegocioMarcas();
                    List<Marcas> listM = negocioM.listar();

                    NegocioCategoria negocioC = new NegocioCategoria();
                    List<Categorias> listC = negocioC.listar();

                    ddlMarca.DataSource = listM;
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataTextField = "Descripcion";
                    DataBind();

                    ddlCategoria.DataSource = listC;
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataTextField = "Descripcion";
                    DataBind();

                }
                //modificar
                if ((Request.QueryString["id"] != null)&& (!IsPostBack))
                {
                    NegocioArticulos negocio = new NegocioArticulos();
                    Articulos aux = (Articulos)negocio.listarConId(Request.QueryString["id"]);

                    txtId.Text = aux.Id.ToString();
                    txtCodigo.Text = aux.Codigo;
                    txtNombre.Text = aux.Nombre;
                    txtImagenUrl.Text = aux.ImagenUrl;
                    txtDescripcion.Text = aux.Descripcion;
                    txtPrecio.Text = aux.Precio.ToString();

                    ddlMarca.SelectedValue = (aux.Marca.Id).ToString();
                    ddlCategoria.SelectedValue = (aux.Categoria.Id).ToString();
                    txtImagenUrl_TextChanged(sender, e);

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
		}

        protected void btnInactivar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
                NegocioArticulos negocio = new NegocioArticulos();
                Articulos nuevo = new Articulos();

                nuevo.Nombre = txtNombre.Text;
                nuevo.Codigo = txtCodigo.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.ImagenUrl = txtImagenUrl.Text;
                nuevo.Precio = decimal.Parse(txtPrecio.Text);

                nuevo.Categoria = new Categorias();
                nuevo.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                nuevo.Marca = new Marcas();
                nuevo.Marca.Id = int.Parse(ddlMarca.SelectedValue);

            if ((Request.QueryString["id"] != null))
            {
                nuevo.Id = int.Parse(txtId.Text);
                negocio.modificarConSP(nuevo);
                Response.Redirect("Administrar.aspx", false);
            }
            else
            {
                negocio.agregar(nuevo);
                Response.Redirect("Productos.aspx", false);
            }
                
        }

        protected void txtImagenUrl_TextChanged(object sender, EventArgs e)
        {
            imgProducto.ImageUrl = txtImagenUrl.Text;
        }

        protected void btnConfirmaEliminar_Click1(object sender, EventArgs e)
        {
            try
            {
                if (chkConfirmaEliminacion.Checked)
                {
                    NegocioArticulos negocio = new NegocioArticulos();
                    negocio.eliminar(int.Parse(txtId.Text));
                    Response.Redirect("Administrar.aspx",false);
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnEliminar_Click1(object sender, EventArgs e)
        {
            ConfirmaEliminacion = true;

        }
    }
}