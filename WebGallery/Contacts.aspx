<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contacts.aspx.cs" Inherits="WebGallery.Contacts" %>

<asp:Content ContentPlaceHolderID="head" runat="server">
    <link href="Content/contacts.css" rel="stylesheet" />
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2" style="text-align: center">
                <h4>Людмила Геннадиевна Хлесткина</h4>
                <h4>тел. (098)127-95-60</h4>
                <br />
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                <b>Имя</b><b>:</b>
            </td>
            <td>
                <asp:TextBox
                    ID="txtName"
                    Width="200px"
                    runat="server">
                </asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator
                    ForeColor="Red"
                    ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Имя обязательно"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <b>E-mail:</b>
            </td>
            <td>
                <asp:TextBox
                    ID="txtEmail"
                    Width="200px"
                    runat="server">
                </asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator
                    Display="Dynamic"
                    ForeColor="Red"
                    ID="RequiredFieldValidator2"
                    runat="server"
                    ControlToValidate="txtEmail"
                    ErrorMessage="E-mail обязателен"
                    Text="*">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator
                    Display="Dynamic"
                    ForeColor="Red"
                    ID="RegularExpressionValidator1"
                    runat="server"
                    ErrorMessage="Неверный E-mail"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ControlToValidate="txtEmail"
                    Text="*">
                </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <b>Тема:</b>
            </td>
            <td>
                <asp:TextBox
                    ID="txtSubject"
                    Width="200px"
                    runat="server">
                </asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator
                    ForeColor="Red"
                    ID="RequiredFieldValidator3"
                    runat="server"
                    ControlToValidate="txtSubject"
                    ErrorMessage="Тема обязательна"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="vertical-align: top">
                <b>Сообщение:</b>
            </td>
            <td style="vertical-align: top">
                <asp:TextBox
                    ID="txtComments"
                    Width="200px"
                    TextMode="MultiLine"
                    Rows="5"
                    runat="server">
                </asp:TextBox>
            </td>
            <td style="vertical-align: top">
                <asp:RequiredFieldValidator
                    ForeColor="Red"
                    ID="RequiredFieldValidator4"
                    runat="server"
                    ControlToValidate="txtComments"
                    ErrorMessage="Комментарий обязателен"
                    Text="*">
                </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary
                    HeaderText="Пожалуйста устраните указанные проблемы:"
                    ForeColor="Red"
                    ID="ValidationSummary1"
                    runat="server" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <span style="margin-left: 180px">
                    <asp:Button
                        ID="Button1"
                        runat="server"
                        Text="Отправить"
                        OnClick="Button1_Click"
                        Height="29px"
                        Width="104px" /></span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
    </table>

</asp:Content>



<asp:Content ContentPlaceHolderID="script" runat="server">
</asp:Content>
