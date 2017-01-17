using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebGallery.HttpHandlers
{
    public class Cakes : IHttpHandler
    {
        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(@"
<!DOCTYPE HTML>

<html lang='en'>
<head>

<meta charset='utf-8'>
<title>Галлерея Людмилы Хлёсткиной</title>

<meta name='viewport' content='width=device-width, initial-scale=1.0'>
<link rel='stylesheet' href='Content/BluempGallery/css/blueimp-gallery.css'>
<link rel='stylesheet' href='Content/BluempGallery/css/blueimp-gallery-indicator.css'>
<link rel='stylesheet' href='Content/BluempGallery/css/blueimp-gallery-video.css'>
<link rel='stylesheet' href='Content/BluempGallery/css/demo.css'>

    <script src='Scripts/bootstrap.js' type='text/javascript'></script>
    <link href='Content/bootstrap.css' rel='stylesheet' />

<style>
    img{
       border:2.2px solid black;
       height:124px;
    }
</style>  

</head>
<body>
    <br/>
    <div class='navbar'>
    <div class='navbar-inner'>
        <a class='brand'><i>Сайт Л.Хлёсткиной</i></a>
        <ul class='nav' style='margin-left: 150px; font-size: 16px'>
                <li><a href='/галлерея/1'>Картины</a></li>
                <li><a href='/галлерея/2'>Пряники</a></li>
                <li><a href='/тортики'>Тортики</a></li>
                <li><a href='/книги'>Книги</a></li>
                <li><a href='/проза'>Проза</a></li>
                <li><a href='/контакты'>Контакты</a></li>                     
        </ul>
    </div>
    </div>
<br/>
<div style='margin-left:auto; margin-right:auto;  width:1350px; '>
   <!-- Content/BluempGallery -->
<div id='links' class='links' >");

            for (int i = 1; i < 227; i++)
            {
                context.Response.Write(string.Format(@"<a href='Images/cakes/{0}.jpg'><img src='Images/cakes/icons/{0}.jpg'/></a>", i));
            }
            context.Response.Write(
           @"</div>
</div>
<div id='blueimp-gallery' class='blueimp-gallery'>
    <div class='slides'>     
    </div>
    <h3 class='title'></h3>
    <a class='prev'>‹</a>
    <a class='next'>›</a>
    <a class='close'>×</a>
    <a class='play-pause'></a>
    <ol class='indicator'></ol>
</div>


<script src='Content/BluempGallery/js/blueimp-helper.js'></script>
<script src='Content/BluempGallery/js/blueimp-gallery.js'></script>
<script src='Content/BluempGallery/js/blueimp-gallery-fullscreen.js'></script>
<script src='Content/BluempGallery/js/blueimp-gallery-indicator.js'></script>
<script src='Scripts/jquery-1.8.3.min.js'></script>

<script>
    document.getElementById('links').onclick = function (event) {
        event = event || window.event;
        var target = event.target || event.srcElement,
            link = target.src ? target.parentNode : target,
            options = { index: link, event: event },
            links = this.getElementsByTagName('a');
        blueimp.Gallery(links, options);
    };
</script>
    <script>
        blueimp.Gallery(
            document.getElementById('links').getElementsByTagName('a'),
            {
                container: '#blueimp-gallery-carousel',
                carousel: true
            }
        );
</script>
<script src='Content/BluempGallery/js/jquery.blueimp-gallery.js'></script>

</body> 
</html>"
                        );
        }
    }
}
