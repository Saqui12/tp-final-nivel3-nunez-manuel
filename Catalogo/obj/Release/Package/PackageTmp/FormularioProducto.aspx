<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="FormularioProducto.aspx.cs" Inherits="Catalogo.FormularioProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <script>
                function validarEntradas() {

                    const txtnombre = document.getElementById("txtNombre");
                    const txtprecio = document.getElementById("txtPrecio");
                    const precioRegex = /[0-9]+/

                    if (txtnombre.value == "") {
                        txtnombre.classList.add("is-invalid");
                        return false;
                    } else {
                        txtnombre.classList.add("is-valid");
                    }
                    if (txtprecio.value == "" || !(precioRegex.test(txtprecio.value))) {
                        txtprecio.classList.add("is-invalid");
                        console.log("entramoli")
                        return false;
                    } else {
                        txtprecio.classList.add("is-valid");
                    }

                    return true
                }
            </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" CssClass="container" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row m-3">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre: </label>
                <asp:TextBox ClientIdMode="Static" runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo </label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="ddlMarca" class="form-label">Marca </label>
                <asp:DropDownList ID="ddlMarca" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="ddlCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio </label>
                <asp:TextBox runat="server" type="number" ClientIDMode="Static" ID="txtPrecio" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" CssClass="btn btn-primary " OnClientClick="return validarEntradas()" OnClick="btnAceptar_Click" runat="server" />
                <%if (Negocio.Seguridad.esAdmin(Session["user"]))
                    {  %>
                         <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click1" CssClass="btn btn-danger m-3 ms-5" runat="server" />

                  <%} %>
                <a href="Administrar.aspx" class="m-5" >Cancelar</a>
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                                           
                        <%if (ConfirmaEliminacion)
                            { %>
                        <div class="mb-3">
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click1" CssClass="btn btn-outline-danger" runat="server" />
                        </div>
                        <%} %>
                    </ContentTemplate>
                </asp:UpdatePanel>                                     
            </div>

        </div>


        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripción: </label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />
            </div>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImagenUrl" class="form-label">Url Imagen</label>
                        <asp:TextBox runat="server" ID="txtImagenUrl" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtImagenUrl_TextChanged" />
                    </div>
                    <asp:Image ImageUrl="https://grupoact.com.ar/wp-content/uploads/2020/04/placeholder.png"
                        runat="server" ID="imgProducto" Width="60%" />
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>

</asp:Content>
