<%@ Page Title="Inserir Usuário" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="InserirUser.aspx.cs" Inherits="siteProdutos.InserirUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="text-center text-primary" style="margin-top: 15px">
        <h2 style="font-weight: 600">Cadastro de Usuário </h2>
    </div>
    <div class="row" style="margin-top: 15px;">
        <div class="col-md-6">
            <label>Nome:</label>
            <asp:RequiredFieldValidator ID="rfvNome" ControlToValidate="txtNome" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtNome" runat="server" MaxLength="100" CssClass="form-control">
            </asp:TextBox>
        </div>
        <div class="col-md-6">
            <label>Sobrenome:</label>
            <asp:RequiredFieldValidator ID="rfvSobre" ControlToValidate="txtSobre" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtSobre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
    </div>

    <div class="row" style="margin-top: 15px">
        <div class="col-md-6">
            <label>Email:</label>
            <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Senha:</label>
            <asp:RequiredFieldValidator ID="rfv" ControlToValidate="txtSenha" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtSenha" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="col-md-3">
            <label>Nivel:</label>
            <asp:RequiredFieldValidator ID="rfvNivel" ControlToValidate="ddlNivel" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlNivel" runat="server" CssClass="form-control">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Admin" Value="A"></asp:ListItem>
                <asp:ListItem Text="Operador" Value="O"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>

    <div class="row" style="margin-top: 15px;">
        <div class="col-md-4">
            <label>telefone:</label>
            <asp:RequiredFieldValidator ID="rfvTel" ControlToValidate="txtTel" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtTel" runat="server" CssClass="form-control" PlaceHolder="Informe o valor do produto "></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Cpf:</label>
            <asp:RequiredFieldValidator ID="rfvCpf" ControlToValidate="txtCpf" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:TextBox ID="txtCpf" runat="server" CssClass="form-control" PlaceHolder="Informe o valor do produto "></asp:TextBox>
        </div>
        <div class="col-md-4">
            <label>Sexo:</label>
            <asp:RequiredFieldValidator ID="rfvSexo" ControlToValidate="ddlSexo" ErrorMessage="*" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <asp:DropDownList ID="ddlSexo" runat="server" CssClass="form-control" PlaceHolder="Informe o sexo">
                <asp:ListItem Text="" Value=""></asp:ListItem>
                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                <asp:ListItem Text="Feminino" Value="F"></asp:ListItem>
            </asp:DropDownList>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center">
        <div style="text-align: center;">
            <asp:Button ID="btnSalvar" runat="server" Text="Enviar" CssClass="btn btn-primary" Style="margin-top: 15px;" OnClick="btnSalvar_Click" />
            <a href="ListarUser.aspx" class="btn btn-success" style="margin-top: 15px; margin-left: 10px;">Voltar</a>
        </div>
    </div>
    <div class="row" style="margin-top: 15px; justify-content: center;">
        <div class="col-md-6">
            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
