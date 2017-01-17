using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebGallery.HttpHandlers
{
    public class Intro : IHttpHandler
    {

        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write(@"
<!DOCTYPE html>
<html xmlns='http://www.w3.org/1999/xhtml'>
<head>
    <title></title>

    <style>
        body {
            margin: 0;
            padding: 0;
            z-index: -2;
            background: white;
        }

        .congratulation {
            font-size: 50px;
            font-style: italic;
            text-align: center;
            padding: 10px;
            margin-top: 300px;
            display: none;
            z-index: -1;
        }

        #background {
            margin: 0;
            padding: 0;
            position: absolute;
            z-index: 0;
            display: none;
            top: 0;
            left: 0;
            width: 100%;
            height: 100%;
            background: rgba(211, 213, 218, 1);
        }

        .photo {
            text-align: center;
            margin-top: 100px;
            display: none;
            border-radius: 8px;
            scrollbar-shadow-color: white;
            scrollbar-3dlight-color: white;
            scrollbar-arrow-color: white;
            scrollbar-base-color: white;
            scrollbar-face-color: white;
        }
    </style>
</head>

<body>
    <div class='congratulation'>
        Добро пожаловать на мой сайт!        
    </div>

    <div id='p1' class='photo'>
        <img src='Images/intro_1.jpg' style='border-radius: 12px' />
    </div>

    <div id='p2' class='photo'>
        <img src='Images/intro_2.jpg' width='900' style='border-radius: 12px' />
    </div>

    <div id='background' />

    <script src='Scripts/jquery-1.8.3.min.js'></script>
    <script type='text/javascript'>
        $(window).ready(function () {
            $('.congratulation').fadeIn(2000).fadeOut(2000);
            $('#p1').delay(4010).fadeIn(2000).fadeOut(2000);
            $('#p2').delay(8020).fadeIn(2000).fadeOut(2000);
            $('#background').delay(12040).fadeIn(2500);
            window.setTimeout(function () {
                window.location = 'галлерея/1';
            }, 14000);
        });
    </script>

</body>
</html>

");

        }
    }
}
