<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Catalogo.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <script>
        function validarEntradas() {
            
            let txtemail = document.getElementById("txtEmail");
            let txtpass = document.getElementById("txtPassword");
            let emailRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/

            if (!emailRegex.test(txtemail.value) || txtemail.value === "")
            {
                txtemail.classList.add("is-invalid");
                return false
            } else
            {
                txtemail.classList.remove("is-invalid");
                txtemail.classList.add("is-valid");

            }

            if (txtpass.value == "")
            {
                txtpass.classList.add("is-invalid");
                return false;
            } else
            {
                txtpass.classList.remove("is-invalid");
                txtpass.classList.add("is valid");
            }
            return true
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col-4">
            <h2 class="mb-4" >Creá tu perfil </h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ClientIdMode="Static"  OnTextChanged="txtEmail_TextChanged" AutoPostBack="true" aria-describedby="validationFeedback" cssclass="form-control mb-2" ID="txtEmail"/>
                <div id="validationFeedback" cssclass="text-danger" class="invalid-feedback ">
                 El texto debe tener formato de email.
                </div>
                <asp:Label ID="txtregistro" visible="false" CssClass="text-danger" runat="server" >Este Email ya se encuentra registrado.</asp:Label>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ClientIdMode="Static"  cssclass="form-control" aria-describedby="validationFeedback1" ID="txtPassword" TextMode="Password"/>
                <div id="validationFeedback1" cssclass="text-danger" class="invalid-feedback ">
                 La clave no puede ser una cadena vacia.
                </div>
            </div>
            <asp:Button Text="Registrarse" cssclass="btn btn-primary" ID="btnRegistrarse" OnClientClick="return validarEntradas()" OnClick="btnRegistrarse_Click" runat="server" />
            <a href="/">Cancelar</a>

        </div>
    </div>
</asp:Content>
