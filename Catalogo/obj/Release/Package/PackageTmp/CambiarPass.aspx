<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="CambiarPass.aspx.cs" Inherits="Catalogo.CambiarPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function validarPass() {

            let txt1 = document.getElementById("txtpass1");
            let txt2 = document.getElementById("txtpass2");

            if (!(txt1.value == txt2.value)) {
                txt1.classList.add("is-invalid");
                txt2.classList.add("is-invalid");
                return false
            } else
            {
                txt1.classList.remove("is-invalid");
                txt2.classList.remove("is-invalid");
                txt1.classList.add("is-valid");
                txt2.classList.add("is-valid");

            }
            if (txt1.value == "" || txt2.value == "")
            {
                txt1.classList.add("is-invalid");
                txt2.classList.add("is-invalid");
                return false;
            }

            return true
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="row">
     <div class="col-md-4">
         <div class="mb-3">
             <label class="form-label">Ingrese su nueva clave</label>
             <asp:TextBox runat="server" ClientIdMode="Static" CssClass="form-control" ID="txtpass1" TextMode="Password"/>
             <label class="form-label">Repita su clave</label>
             <asp:TextBox runat="server" ClientIdMode="Static" aria-describedby="validationServer" CssClass="form-control" ID="txtpass2" TextMode="Password"/>
             <div id="validationServer" class="invalid-feedback">
                    Ambas Claves deben coincidir. No pueden ser nulas.
             </div>
         </div>
       </div>
     </div>
        <div class="row">
        <div class="col-md-4">
            <asp:Button Text="Guardar" CssClass="btn btn-primary" OnClientClick="return validarPass()" OnClick="btnGuardar_Click" ID="btnGuardar" runat="server" />
            <a href="/MiPerfil.aspx">Regresar</a>
        </div>
    </div>
</asp:Content>
