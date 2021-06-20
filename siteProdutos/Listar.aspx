<%@ Page Title="Listar Produtos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Listar.aspx.cs" Inherits="siteProdutos.Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #card {
           margin-top:10px;
           display:flex;
           flex-flow: wrap;
           width: 1200px;
           justify-content:center;
        }
         #card > div{
            margin-top: 20px;
         }
        #card > div{
                margin-left: 30px;
           }
        
       #img{
           width:100%;
           height: 220px;
        }

         #card > div > div > p{
             height: 120px;
         }
         #card > div > div {
             background-color: white;
             
         }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary" style="margin-top: 15px">
        <h2 style="font-weight: 600">Listagem de Produtos </h2>
    </div>
    <div id="card">
        <asp:Repeater ID="rptProducts" runat="server">
            <ItemTemplate>

                <div class="card" style="width: 18rem;">
                    <div id="img">
                    <img src="img/imgProducts/<%# DataBinder.Eval(Container.DataItem, "pd_image") %>" class="card-img-top" alt="<%# DataBinder.Eval(Container.DataItem, "pd_nome") %>">
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><%# DataBinder.Eval(Container.DataItem, "pd_nome") %></h5>
                        <p class="card-text"><%# DataBinder.Eval(Container.DataItem, "pd_desc") %></p>
                        <h5 class="card-title">Preço: <%# DataBinder.Eval(Container.DataItem, "pd_price") %></h5>
                        <a href="<%# Eval("pd_id", "Editar.aspx?id={0}") %>" class="btn btn-primary"> Selecionar </a>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div class="row" style="margin-top: 15px; text-align: center;">
        <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>

</asp:Content>
