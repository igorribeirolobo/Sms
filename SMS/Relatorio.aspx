﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Padrao.Master" AutoEventWireup="true" CodeBehind="Relatorio.aspx.cs" Inherits="SMS.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnSetor" runat="server" CssClass="btn btn-primary  btn-lg" OnClick="btnSetor_Click" Text="Setor" />
    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary btn-lg" OnClick="Button1_Click1" Text="Data" />
    <asp:DropDownList ID="ddSetor" runat="server" Visible="False">
    </asp:DropDownList>
    <asp:Button ID="btnGerar" runat="server" OnClick="btnGerar_Click" Text="Gerar" Width="56px" CssClass="btn btn-success btn-block" Visible="False" />
    <br />
    <asp:Label ID="lbldataini" runat="server" Text="Data Inicial.:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lbldatafim" runat="server" Text="Data Final.:" Visible="False"></asp:Label>
    <asp:Calendar ID="cdini" runat="server" CssClass="list-inline" Visible="False"></asp:Calendar><asp:Calendar ID="cdfim" runat="server" CssClass="list-inline" Style="float:left; margin-top:-161px; margin-left:250px;" Visible="False"></asp:Calendar>
    <asp:Label ID="lblsql" runat="server" Text="Label"></asp:Label>
    <asp:Button ID="btnGerar1" runat="server" CssClass="btn btn-success btn-lg" OnClick="btnGerar1_Click" Text="Gerar" Visible="False" />
    <br />
    <asp:Table ID="tblrelatorio" runat="server" CssClass="table table-striped" Height="32px" Width="157px" Visible="False">
    </asp:Table>
    <asp:Table ID="tblrelatorio1" runat="server" Height="33px" Visible="False" Width="157px">
    </asp:Table>
</div>

</asp:Content>