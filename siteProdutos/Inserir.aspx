<%@ Page Title="Adicionar Produtos" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Inserir.aspx.cs" Inherits="siteProdutos.Inserir" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary" style="margin-top: 15px">
        <h2 style="font-weight: 600">Cadastro de Produtos </h2>
    </div>
    <div class="row" style="margin-top: 30px; justify-content: center">
        <div class="col-md-6">
            <label>Imagem:</label>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="uplImg" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:FileUpload ID="uplImg" runat="server" MaxLength="100" CssClass="form-control" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Nome do Produto:</label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control">
            </asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Descrição do Produto:</label>
            <asp:RequiredFieldValidator ID="rfvDescription" ControlToValidate="txtDescription" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="multiline" Rows="3"></asp:TextBox>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div class="col-md-6">
            <label>Preço:</label>
            <asp:RequiredFieldValidator ID="rfvPrice" ControlToValidate="txtPrice" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" PlaceHolder="Informe o valor do produto "></asp:TextBox>
            <asp:Button ID="btnImg" runat="server" Text="Enviar" CssClass="btn btn-primary" Style="margin-top: 15px;" OnClick="btnImg_Click" />
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center;">
        <div class="col-md-6">
            <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
        </div>
    </div>
    
</asp:Content>
