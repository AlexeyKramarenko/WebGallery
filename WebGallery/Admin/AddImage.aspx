<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/NestedAdminMasterPage.Master" AutoEventWireup="true" CodeBehind="AddImage.aspx.cs" Inherits="WebGallery.Admin.AddImage" %>



<asp:Content ContentPlaceHolderID="NestedContentPlaceHolder" runat="server">
    <style>
     

    </style>

    <link href="../../Content/addimage.css" rel="stylesheet" />

    <div id="addImageForm">

        <div class="alert" style="display: none">
            <span class="closebtn">&times;</span>
            <span class="msg"></span>
            <div>
                Уменьшить вес фотографии можно с помощью Paint'a:
            <ol type="">
                <li>Запустите "Paint"</li>
                <li>Нажмите кнопку "Окрыть" и выберите изображение</li>
                <li>Перейдити на вкладку "Главная" и нажмите на "Изменить размер"</li>
                <li>Введите в поле "По горизонтали" значение,
                     которое будет меньшим 100 (например 50 - изображение будет в 2 раза легче).</li>
                <li>Нажмите "Сохранить как" и дайте новое имя этому изображению</li>
                <li>Теперь попробуйте заново загрузить уже уменьшенное в размере изображение.</li>
            </ol>
            </div>
        </div>

        <div class="alert  success" style="display: none">
            <span class="closebtn">&times;</span>
            <span class="msg"></span>
        </div>


        <h4>Добавление изображений</h4>


        <asp:FormView
            RenderOuterTable="false"
            runat="server"
            ClientIDMode="Static"
            ID="createPictureFormView"
            DefaultMode="Edit"
            ItemType="WebGallery.ViewModel.CreatePictureViewModel"
            SelectMethod="InitPictureForm"
            UpdateMethod="InsertImage">

            <EditItemTemplate>
                <table id="formViewTable">
                    <tr>
                        <td><strong>Тип галлереи:</strong></td>
                        <td>                          
                            <asp:DropDownList
                                ID="DropDownList1"
                                runat="server"
                                DataTextField="GalleryName"
                                DataValueField="GalleryID"
                                DataSource='<%# Item.GalleryTypes %>'
                                SelectedValue='<%# BindItem.GalleryID %>'>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Выберите изображение:</strong></td>
                        <td>
                            <asp:FileUpload
                                ID="fileUpload"
                                runat="server" />
                        </td>
                    </tr>

                    <tr>
                        <td><strong>Название:</strong></td>
                        <td>
                            <asp:TextBox
                                ID="Name"
                                Text='<%# BindItem.Name %>'
                                runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td><strong>Описание:</strong></td>
                        <td>
                            <asp:TextBox
                                ID="Description"
                                runat="server"
                                Text='<%# BindItem.Description %>'
                                TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Button
                                ID="btnSave"
                                runat="server"
                                Text="Сохранить"
                                CommandName="Update" /></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label
                                ID="lblResult"
                                ForeColor="Olive"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>

            </EditItemTemplate>
        </asp:FormView>

    </div>


    <script src="../../Scripts/images.js"></script>
</asp:Content>




