<%@ Page Title="" Language="C#" MasterPageFile="~/Mimaster.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Catalogo.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Favoritos</h1>
       <div class="row row-cols-1 row-cols-md-5 g-4 container">

      <asp:Repeater ID="repeater1" OnItemCommand="repeater1_ItemCommand" runat="server">
         <ItemTemplate>
                <div class="col">
                <div class="card h-100">
                        <img src=<%# Eval("ImagenUrl") %> class="card-img-top " style="height: 200px; object-fit: contain;" alt="...">
                        <div class="card-body d-flex flex-column">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <div>
                               <p class="card-text"><%#Eval("Descripcion") %></p>
                               <p class="card-text"><%#Eval("Precio") %></p>
                            </div>
                            <div class="row row-cols-1 row-cols-md-2 g-4  mt-auto ">
                                 <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-danger"  CommandName="Remover" CommandArgument=<%# Eval("ID") %> >Remover</asp:LinkButton>                                       
                                  <asp:LinkButton ID="LinkButton2" runat="server" CssClass="btn btn-primary" CommandName="Detalle" CommandArgument=<%# Eval("ID") %> >Detalles</asp:LinkButton>
                            </div>
                            
                        </div>
                </div>
                </div>
         </ItemTemplate>
      </asp:Repeater>

    </div>
</asp:Content>
