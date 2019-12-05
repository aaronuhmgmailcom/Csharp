//function correctPNG()
//{
//	
//   for(var i=0; i<document.images.length; i++)
//   {
//   var img = document.images[i]
//   var imgName = img.src.toUpperCase()
//   if (imgName.substring(imgName.length-3, imgName.length) == "PNG")
//   {
//   var imgID = (img.id) ? "id='" + img.id + "' " : ""
//   var imgClass = (img.className) ? "class='" + img.className + "' " : ""
//   var imgTitle = (img.title) ? "title='" + img.title + "' " : "title='" + img.alt + "' "
//   var imgStyle = "display:inline-block;" + img.style.cssText
//   if (img.align == "left") imgStyle = "float:left;" + imgStyle
//   if (img.align == "right") imgStyle = "float:right;" + imgStyle
//   if (img.parentElement.href) imgStyle = "cursor:hand;" + imgStyle
//   var strNewHTML = "<span " + imgID + imgClass + imgTitle
//   + " style=\"" + "width:" + img.width + "px; height:" + img.height + "px;" + imgStyle
//   + "filter:progid:DXImageTransform.Microsoft.AlphaImageLoader"
//   + "(src=\'" + img.src + "\', sizingMethod='scale');\"></span>"
//   img.outerHTML = strNewHTML
//   i = i-1
//   };
//   };
//};
//
//if(navigator.userAgent.indexOf("MSIE")>-1)
//{
//window.attachEvent("onload", correctPNG);
//};
// -----------------------------------------------------------------------------------
function floatWindow(demo_table) {

    var screenwidth, screenheight, mytop, getPosLeft, getPosTop
    screenwidth = $(window).width();
    screenheight = $(document).height();
    //获取滚动条距顶部的偏移
    mytop = $(document).scrollTop();
    //计算弹出层的left
    getPosLeft = screenwidth / 2 - 285;
    //计算弹出层的top
    if (screenwidth < 1000) { getPosLeft = screenwidth / 2 - 285; }
    //getPosTop = screenheight / 2 - 400;
    getPosTop = 240;
    //getPosTop = screenheight/2;
    //css定位弹出层
    $("#" + demo_table).css({ "left": getPosLeft, "top": getPosTop });
    //当浏览器窗口大小改变时
    $(window).resize(function () {
        //alert($(document).height());
        screenwidth = $(window).width();
        screenheight = $(document).height();
        mytop = $(document).scrollTop();
        getPosLeft = screenwidth / 2 - 285;
        if (screenwidth < 1000) { getPosLeft = screenwidth / 2 - 285; }
        //getPosTop = screenheight / 2 - 400;
        getPosTop = 100;
        //$("#"+demo_table).css({ "left": getPosLeft, "top": getPosTop });
    });

    $("#" + demo_table).fadeIn("slow"); //toggle("slow"); 
    //$("#company_name").focus();
    //获取页面文档的高度
    var docheight = $(document).height();
    //追加一个层，使背景变灰
    $("body").append("<div id='greybackground'></div>");
    $("#greybackground").css({ "opacity": "0.5", "height": docheight });

    $("#totalProgressBarDiv").css("display", "none");
}
// -----------------------------------------------------------------------------------