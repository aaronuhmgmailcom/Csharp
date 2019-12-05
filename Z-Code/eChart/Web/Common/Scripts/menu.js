function bindClickShowMenu(tabId, btnIdName, ulIDName, arrIDName, imgBol) {
    $("#" + btnIdName).click(function (e) {
        if ($("#" + ulIDName).css("display") == "none") {
            $("#" + ulIDName).slideDown();
        }
        if (imgBol) {
            $("#" + ulIDName).click(function (e) {
                e.stopPropagation();
            })
        }
        for (i = 0; i < arrIDName.length; i++) {
            if (arrIDName[i] != ulIDName) {
                if ($("#" + arrIDName[i]).css("display") != "none") {
                    $("#" + arrIDName[i]).slideUp();

                }
            }
        }
        if (tabId != null) {
            closeTbal(tabId);
        }
        e.stopPropagation();
        //
    })
}
function closeBoxFuc(closeBtn, boxId) {
    if (closeBtn != "") {
        $("#" + closeBtn).click(function () {
            if ($("#" + boxId).css("display") != "none") {
                $("#" + boxId).slideUp();
            }
        })
    }
}
function closeBoxFucByClassBtn(closeBtn, boxId) {
    if (closeBtn != "") {
        $("." + closeBtn).click(function () {
            if ($("#" + boxId).css("display") != "none") {
                $("#" + boxId).slideUp();
            }
        })
    }
}
function closeTbal(tabId) {
    $("#" + tabId).find("dd").each(function () {
        $(this).removeClass("tr_bg2 ulIndex");
        $(this).find("ul").each(function () {
            if ($(this).css("display") != "none") {
                $(this).slideUp(10);
            }
        })
    })
}
function ManageListTable(tabId, arrIDName) {
    var recordDD = 0;
    $("#" + tabId).find("dd").each(function () {
        $(this).click(function (e) {
            //e.stopPropagation();
        })
        $(this).hover(function () {
            $(this).addClass("index-z");
            $(this).addClass('tr_bg');
            $(this).find(".imgArrTemp").each(function () {
                $(this).show();

                $(this).unbind().bind("click", function (e) {
                    for (i = 0; i < arrIDName.length; i++) {
                        if ($("#" + arrIDName[i]).css("display") != "none") {
                            $("#" + arrIDName[i]).slideUp();
                        }
                    }
                    if (recordDD > 0) {
                        $("#" + tabId).find("dd").each(function () {
                            //$(this).removeAttr("class");
                            $(this).removeClass("tr_bg2 ulIndex");
                            $(this).find("ul").css("display", "none");
                        })

                        recordDD = 0;

                    }
                    $(this).parents("dd").removeAttr("class");
                    $(this).parents("dd").addClass("tr_bg2 ulIndex");
                    $(this).parents("dd").find("ul").each(function () {
                        if ($(this).css("display") == "none") {
                            recordDD = 1;
                            $(this).parents("dd").find("ul").slideDown();
                            // $(this).parents("dd").find("ul").addClass("ulIndex");
                        }
                        else {

                            $(this).parents("dd").find("ul").slideUp();
                        }
                    })

                    e.stopPropagation();
                })

            })

        }, function () {
            $(this).removeClass('tr_bg');
            $(this).removeClass('index-z');
            $(this).find(".imgArrTemp").hide();
        })

    })
}
