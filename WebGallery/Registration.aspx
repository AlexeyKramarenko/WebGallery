<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebGallery.Registration" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="background-color:rgb(250, 235, 215); width: 250px; margin-left: auto; margin-right: auto; padding: 50px; border: 1px solid black">
        
        <h4 style="font-size: medium">Регистрация</h4>
        
        <p>
            <asp:Literal runat="server" ID="litStatusMessage" />
        </p>
        <asp:FormView
            RenderOuterTable="false"
            ID="createUserFormView"
            runat="server"
            DefaultMode="Insert"
            ItemType="WebGallery.ViewModel.CreateUserViewModel"
            InsertMethod="CreateUser">
            <InsertItemTemplate>
                <div style="margin-bottom: 10px">
                    <asp:Label runat="server" AssociatedControlID="txtbxUserName">Имя:</asp:Label>

                    <asp:TextBox runat="server" ID="txtbxUserName" Text="<%# BindItem.UserName %>" />
                </div>
                <div style="margin-bottom: 10px">
                    <asp:Label runat="server" AssociatedControlID="txtbxPassword">Пароль:</asp:Label>

                    <asp:TextBox runat="server" ID="txtbxPassword" TextMode="Password" Text="<%# BindItem.Password %>" />
                </div>
                <div style="margin-bottom: 10px">
                    <asp:Label runat="server" AssociatedControlID="txtbxConfirmPassword">Подтвердить пароль:</asp:Label>

                    <asp:TextBox runat="server" ID="txtbxConfirmPassword" TextMode="Password" Text="<%# BindItem.ConfirmPassword %>" />
                </div>
                <div>
                    <asp:Button ID="btnRegister" runat="server" CommandName="Insert" Text="Зарегистрироваться" />
                </div>
            </InsertItemTemplate>
        </asp:FormView>
        <%--</fieldset>--%>
    </div>
</asp:Content>


<asp:Content ContentPlaceHolderID="script" runat="server">
</asp:Content>
