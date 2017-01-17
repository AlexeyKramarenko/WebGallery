var images = (function () {
    function initBootstrapAlert() {

        var close = document.getElementsByClassName("closebtn");
        var i;

        for (i = 0; i < close.length; i++) {
            close[i].onclick = function () {
                var div = this.parentElement;
                div.style.opacity = "0";
                setTimeout(function () { div.style.display = "none"; }, 600);
            }
        }
    }

    function showNotificationAboutSuccessfullUpload(photosAmount) {

        initBootstrapAlert();
        var text = "Файл сохранен. Вы можете загрузить на этот хостинг еще около "
            + photosAmount + " изображений.";

        document.getElementsByClassName("msg")[1].innerText = text;
        document.getElementsByClassName("alert")[1].removeAttribute('style');
    }
    return {
        showNotificationAboutSuccessfullUpload: showNotificationAboutSuccessfullUpload
    }
})();