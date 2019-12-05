//document.write("<scri" + "pt type='text/javascript' src='js/jquery-1.5.2.min.js'></scr" + "ipt>");
// JavaScript Document
/*
*date: 20110415
*author: Jian Wu
*/
//hover事件调度 鼠标经过时 改变背景色,弹出本行的菜单
/*param(id:事件的对象id，
hoverClass:CSS类名，鼠标移上去的样式)
icon 菜单图标的id
speed 缓动速度
*/
function showShortMenuDown(id, hoverClass, icon, speed) {
    $("#" + id).find("dd").each(function () {
        $(this).hover(function () {
            $(this).addClass(hoverClass);
            $(this).find("#" + icon).each(function () {
                $(this).show();
                $(this).click(function () {
                    // alert("11");
                    $(this).parents("dd").find("ul").slideDown(speed);
                })
            })

        }, function () {
            $(this).find("ul").slideUp(speed);
            $(this).removeClass(hoverClass);
            $(this).find("#" + icon).hide();
        })
    })
}

function showUnitWindow(id) {
    if ($("#" + id).css("display") != "none") {
        $("#" + id).slideUp();
    } else {
        $("#" + id).slideDown();
    }
}

//绑定click事件
function bindClick(btnId, menuId) {
    $("." + btnId).bind("click", function (e) {
        $("#" + menuId).slideDown();
        e.stopPropagation();
    })

    $("#" + menuId).bind("click", function (e) {
        e.stopPropagation();
    })
}