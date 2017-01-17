<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Gallery.aspx.cs" Inherits="WebGallery.Gallery" %>

<asp:Content ContentPlaceHolderID="head" runat="server">


    <link href="../Content/Galereya-latest/css/jquery.galereya.css" rel="stylesheet" />
    <link href="../Content/Galereya-latest/css/jquery.galereya.ie.css" rel="stylesheet" />
    <link href='http://fonts.googleapis.com/css?family=Scada:400,400italic,700,700italic&subset=latin,cyrillic' rel='stylesheet' type='text/css' />
    <link href="../Content/gallery.css" rel="stylesheet" />
</asp:Content>



<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div id="gal1">

        <asp:Repeater
            ID="rptGallery"
            SelectMethod="GetPictures"
            ItemType="WebGallery.ViewModel.GalleryPictureViewModel"
            runat="server">
            <ItemTemplate>

                <img
                    src='<%# Item.ThumbnailImagePath.Replace("~","")   %>'
                    alt='<%# Item.Name %>'
                    title='<%# Item.Name %>'
                    data-desc='<%# Item.Description %>'
                    data-fullsrc='<%#  Item.ImagePath.Replace("~","")  %>' />

            </ItemTemplate>
        </asp:Repeater>

    </div>

</asp:Content>




<asp:Content ContentPlaceHolderID="script" runat="server">

    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js" type="text/javascript"></script>
   
    <script src="../Content/Galereya-latest/js/jquery.galereya.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jQuery(function () {
            jQuery('#gal1').galereya();
        })
    </script>

    <script type="text/javascript">
        var _gaq = [['_setAccount', 'UA-40540506-1'], ['_trackPageview']];
        (function (d, t) {
            var g = d.createElement(t), s = d.getElementsByTagName(t)[0];
            g.src = '//www.google-analytics.com/ga.js';
            s.parentNode.insertBefore(g, s)
        }(document, 'script'));
    </script>

</asp:Content>
