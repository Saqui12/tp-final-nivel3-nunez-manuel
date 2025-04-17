<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Catalogo.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
            function validarEntradas() {
            
            let txtemail = document.getElementById("txtEmail");
            let txtpass = document.getElementById("txtPassword");
            let emailRegex = /^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$/

            console.log("Elemento email:", txtemail);
            console.log("Valor email:", txtemail.value);

            if (!emailRegex.test(txtemail.value) || txtemail.value === "")
            {
                txtemail.classList.add("is-invalid");
                console.log("Valor email:", txtemail.value);
                return false
            } else
            {
                txtemail.classList.remove("is-invalid");
                txtemail.classList.add("is-valid");

            }

            if (txtpass.value == "")
            {
                txtpass.classList.add("is-invalid");
                console.log("Valor pass:", txtpass.value);
                return false;
            } else
            {
                txtpass.classList.remove("is-invalid");
                txtpass.classList.add("is valid");
            }
            console.log("paso a true");
            return true
        }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
       <ContentTemplate>
     <div class="row">
        <div class="col-4">
            <div class="mb-3">
              <asp:Label ID="txtregistro" visible="false"  CssClass=" d-block text-danger alert alert-danger text-danger" runat="server" >Email o clave Incorrecta.</asp:Label>
             </div>
            <h2 class="mb-4" >Login</h2>
            <div class="mb-3">
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" ClientIdMode="Static" AutoPostBack="true" OnTextChanged="txtEmail_TextChanged" cssclass="form-control"  ID="txtEmail"/>
                 <div id="validationFeedback" class="invalid-feedback">
                 El texto debe tener formato de email.
                </div>
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" ClientIdMode="Static"  cssclass="form-control" ID="txtPassword" TextMode="Password"/>
                 <div id="validationFeedback1" class="invalid-feedback">
                 La clave no puede ser una cadena vacia.
                </div>
            </div>
            <asp:Button Text="Ingresar" cssclass="btn btn-primary" ID="btnLogin" OnClientClick="return validarEntradas()" OnClick="btnLogin_Click" runat="server" />
            <a href="/">Cancelar</a>
             

        </div>
    </div>
   </ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>
