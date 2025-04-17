<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Catalogo.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row row-cols-1 row-cols-md-5 g-4 container">

        <asp:Repeater ID="repeater1" OnItemCommand="repeater1_ItemCommand" runat="server">
            <ItemTemplate>

                <div class="col">
                    <div class="card" style="height: 100%">
                        
                        <img src='<%# Eval("ImagenUrl") %>' class="card-img-top " style="height: 200px; object-fit: contain;" alt="...">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <div>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                            </div>
                            <div>
                                <p class="card-text"><%#Eval("Precio") %></p>
                            </div>
          <!--                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate> -->
                                   <div class="row row-cols-1 row-cols-md-2 g-4  mt-auto ">                        
                                        <asp:LinkButton ID="Button1" runat="server" CssClass="btn btn-danger" OnClick="Button1_Click" CommandName="Favorito" CommandArgument='<%# Eval("ID") %>'>
                                     <i class="bi bi-heart"></i></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary" CommandName="Detalle" CommandArgument='<%# Eval("ID") %>'>Detalles</asp:LinkButton>

                                    </div>
         <!--                       </ContentTemplate>
                            </asp:UpdatePanel> -->
                        </div>
                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>

    </div>
</asp:Content>
