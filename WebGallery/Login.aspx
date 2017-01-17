<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebGallery.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/login.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:FormView
        ID="FormView1"
        RenderOuterTable="false"
        DefaultMode="Insert"
        ItemType="WebGallery.ViewModel.LoginViewModel"
        InsertMethod="LoginUser"
        runat="server">
        <InsertItemTemplate>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Label">Имя:</asp:Label></td>
                    <td>
                        <asp:TextBox ID="TextBox1" Text="<%# BindItem.UserName %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label">Пароль:</asp:Label></td>
                    <td>
                        <asp:TextBox TextMode="Password" ID="TextBox2" Text="<%# BindItem.Password %>" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button CommandName="Insert" ID="Button1" runat="server" Text="Войти" /></td>
                </tr>
            </table>
            
        </InsertItemTemplate>
    </asp:FormView>

    <asp:ValidationSummary
        ID="valSummary"
        runat="server"
        ClientIDMode="Static"
        HeaderText="Исправьте следующие ошибки:"
        ShowModelStateErrors="true"
        DisplayMode="BulletList"
        EnableClientScript="true"
        ForeColor="Red" />

    <asp:Label ID="lblMessage" ClientIDMode="Static" runat="server"></asp:Label>
</asp:Content>
