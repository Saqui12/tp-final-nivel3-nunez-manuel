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
	public partial class Productos : System.Web.UI.Page
	{
        
        public bool FiltroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
		{
			NegocioArticulos negocio = new NegocioArticulos();
			Session.Add("listaProductos", negocio.listarConSP());
			dgvProductos.DataSource = Session["listaProductos"];
			dgvProductos.DataBind();
		
		}

        protected void filtro_TextChanged(object sender, EventArgs e)
        {
            List<Articulos> lista = (List<Articulos>)Session["listaProductos"];
            List<Articulos> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));
            dgvProductos.DataSource = listaFiltrada;
            dgvProductos.DataBind();
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Precio")
            {
                ddlCriterio.Items.Add("Igual a");
                ddlCriterio.Items.Add("Mayor a");
                ddlCriterio.Items.Add("Menor a");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene");
                ddlCriterio.Items.Add("Comienza con");
                ddlCriterio.Items.Add("Termina con");
            }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulos negocio = new NegocioArticulos();
                dgvProductos.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text);
         
                dgvProductos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                throw;
            }

        }

        protected void chkAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            FiltroAvanzado = chkAvanzado.Checked;
            txtFiltro.Enabled = !FiltroAvanzado;
        }
    }
}