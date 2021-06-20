<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="DetalhesUser.aspx.cs" Inherits="siteProdutos.DetalhesUser" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary" style="margin-top: 15px">
        <h2 style="font-weight: 600">Cadastro de Usuário </h2>
    </div>
    <div class="row" style="margin-top: 15px;">
        <div class="col-md-6">
            <label>Nome:</label>
            
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control" Enabled="false">
            </asp:TextBox>
        </div>
        <div class="col-md-6">
            <label>Sobrenome:</label>
            <asp:TextBox ID="txtSobre" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-8">
            <label>Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Nivel:</label>
            <asp:TextBox ID="txtNivel" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top: 15px;">
        <div class="col-md-4">
            <label>telefone:</label>
            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Cpf:</label>
            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Sexo:</label>
           <asp:TextBox ID="txtSexo" runat="server" CssClass="form-control" Enabled="false" ></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div style="text-align: center;">
            <a href="ListarUser.aspx" class="btn btn-success" style="margin-top: 15px; margin-left: 10px;">Voltar</a>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div style="text-align: center;">
            <asp:Label ID="lblMsg" runat="server" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>
