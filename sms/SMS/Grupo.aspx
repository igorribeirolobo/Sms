<%@ Page Title="" Language="C#" MasterPageFile="~/Padrao.Master" AutoEventWireup="true" CodeBehind="Grupo.aspx.cs" Inherits="SMS.Grupo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1>Cadastro de Grupo</h1>
        <p>Nome do grupo:</p>
        <p><asp:TextBox ID="tx_nome" runat="server" CssClass="form-control" placeholder="Nome do grupo"></asp:TextBox></p>        
        <p><asp:Button CssClass="btn btn-primary btn-lg" ID="Button1" runat="server" Text="Salvar" OnClick="Button1_Click" /></p>
        <p>Grupos cadastrados:</p>
        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="idGrupo" ForeColor="#333333" GridLines="None" OnRowCommand="edita">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="idGrupo" HeaderText="idGrupo" Visible="False" />
                <asp:BoundField DataField="Nome" HeaderText="Nome do grupo" />
                <asp:ButtonField Text="Alterar" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
      </div>
</asp:Content>

