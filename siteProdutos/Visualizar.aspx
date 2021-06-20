<%@ Page Title="Ver Produto" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Visualizar.aspx.cs" Inherits="siteProdutos.Deletar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary" style="margin-top: 15px">
        <h2 style="font-weight: 600">Ver Produto </h2>
    </div>
    <div class="row" style="margin-top: 30px; justify-content: center">
        <div class="col-md-6">
            <label>Imagem:</label>
            <asp:Image ID="imgProduto" runat="server" Width="100%" Style="border-radius:6px;" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Id do Produto:</label>
            <asp:TextBox ID="txtId" runat="server" MaxLength="100" CssClass="form-control" Enabled="false">
            </asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Nome do Produto:</label>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control">
            </asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Descrição do Produto:</label>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="multiline" Rows="3"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Preço:</label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" PlaceHolder="Informe o valor do produto "></asp:TextBox>
            <asp:Button ID="btnDeletar" runat="server" Text="Excluir" CssClass="btn btn-danger" Style="margin-top: 15px;" OnClick="btnDeletar_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center;">
        <div class="col-md-6">
            <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </div>
</asp:Content>
