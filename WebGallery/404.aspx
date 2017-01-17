<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="WebGallery.Error" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <style>
        #lblMessage {
            width: 400px;
            margin: 50px auto auto auto;
            color: orangered;
        }
    </style>
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblMessage" ClientIDMode="Static" runat="server" Text="Label"></asp:Label>



</asp:Content>


<asp:Content ContentPlaceHolderID="script" runat="server">

    
</asp:Content>
