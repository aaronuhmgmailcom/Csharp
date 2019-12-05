var defaultFolderIDTheme = "folder";
var defaultMessageIDTheme = "message";
var defaultRootIDTheme = "root";
var defaultVarIDTheme = "variationedit";
var global_rowCount = 0;
$(document).ready(function() {
    //initialize tree
    GetFileList();
    InitializeCssConfig();
  
    $("#btnCloseAddOrEditWindow").click(function() {
        $("#demo_table1").hide("slow");
        $("#greybackground").remove();

    });

    $("#btnCloseAddOrEditMsgWindow").click(function() {
        $("#demo_table4").hide("slow");
        $("#greybackground").remove();

    });

    $("#btnCloseAddOrEditVarWindow").click(function() {
        $("#demo_table5").hide("slow");
        $("#greybackground").remove();

    });
    $("#btnC").click(function() {
        $("#demo_table5").hide("slow");
        $("#greybackground").remove();

    });
    $("#btnCloseAddDBSCH").click(function() {
        $("#demo_table6").hide("slow");
        $("#greybackground").remove();

    });
    $("#btnDBSCHCancel").click(function() {
        $("#demo_table6").hide("slow");
        $("#greybackground").remove();

    });

    $("#BtnCancle").click(function() {
        $("#demo_table4").hide("slow");
        $("#greybackground").remove();

    });

    $("#btnCloseAddOrEditWindow1").click(function() {
        $("#demo_table1").hide("slow");
        $("#greybackground").remove();

    });

    //add folder message start 
    $("#btnNewADD").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype == "root") {
            floatWindow('demo_table1');
            $("#addfoldername").focus();
        }
        else if (selecttype == "folder") {
            floatWindow('demo_table4');
            $("#msgcontent").focus();
        }
        else
            alert("Please select Root node or Folder node!");

        $("#btnAddOrEdit").unbind("click");
        $("#btnAddOrEdit").click(function() {
            var foldername = $("#addfoldername").val();
            AddFolder(foldername, selectID);
        });

        $("#BtnOKmsg").unbind("click");
        $("#BtnOKmsg").click(function() {
            var Msgname = $("#msgcontent").val();
            AddMsg(Msgname, selectID);
        });

    });

    function AddFolder(foldername, selectID) {
        $.ajax({
            type: "POST",
            url: "AddFolderMessage.aspx",
            data: { "foldername": foldername,
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#demo_table1").hide("slow");
                $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    //add msg
    function AddMsg(foldername, selectID) {
        $.ajax({
            type: "POST",
            url: "AddFolderMessage.aspx",
            data: { "message": foldername,
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#demo_table4").hide("slow");
                $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    //add folder message end
    //delete folder message start 
    $("#btnDelete").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

        if (selecttype == "root")
            alert("Please select Folder node or Message node!");
        else if (selecttype == "folder") {
            if (confirm("Are you sure to delete it?")) {
                DeleteFolder(selectID);
            }
        }
        else if (selecttype == "message") {
            if (confirm("Are you sure to delete it?")) {
                DeleteMsg(selectID);
            }
        }
        else {
            alert("Please select Folder node or Message node!");
        }
    });

    function DeleteFolder(selectID) {
        $.ajax({
            type: "POST",
            url: "DeleteFolderMessage.aspx",
            data: {
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    //delete msg
    function DeleteMsg(selectID) {
        $.ajax({
            type: "POST",
            url: "DeleteFolderMessage.aspx",
            data: {
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    //delete folder message end

    //setonoffline folder message start 
    $("#btnSetOnline").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

        if (selecttype == "root")
            alert("Please select Folder node or Message node!");
        else if (selecttype == "folder") {
            if (confirm("Are you sure to set it online?")) {
                SetFolderMessageOnOffline(selectID, false); //online is false ,offline is true
            }
        }
        else if (selecttype == "message") {
            if (confirm("Are you sure to set it online?")) {
                SetFolderMessageOnOffline(selectID, false);
            }
        }
        else {
            alert("Please select Folder node or Message node!");
        }

    });
    $("#btnSetOffline").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype == "root")
            alert("Please select Folder node or Message node!");
        else if (selecttype == "folder") {
            if (confirm("Are you sure to set it offline?")) {
                SetFolderMessageOnOffline(selectID, true); //online is false ,offline is true
            }
        }
        else if (selecttype == "message") {
            if (confirm("Are you sure to set it offline?")) {
                SetFolderMessageOnOffline(selectID, true);
            }
        }
        else {
            alert("Please select Folder node or Message node!");
        }
    });
    function SetFolderMessageOnOffline(selectID, flag) {
        $.ajax({
            type: "POST",
            url: "SetFolderMsgonoff.aspx",
            data: { "onoroff": flag,
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                //location.reload();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }

    //setonoffline folder message end
    //move up down message start
    $("#btnMoveUp").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype == "root")
            alert("Please select  Message node!");
        else if (selecttype == "folder") {
            alert("Please select  Message node!");
        }
        else if (selecttype == "message") {
            SetMessageMoveUpDown(selectID, "up");
        }
        else {
            alert("Please select Folder node or Message node!");
        }

    });
    $("#btnMoveDown").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype == "root")
            alert("Please select  Message node!");
        else if (selecttype == "folder") {
            alert("Please select  Message node!");
        }
        else if (selecttype == "message") {
            SetMessageMoveUpDown(selectID, "down");
        }
        else {
            alert("Please select Folder node or Message node!");
        }
    });

    function SetMessageMoveUpDown(selectID, flag) {
        $.ajax({
            type: "POST",
            url: "MoveMsgUpDown.aspx",
            data: { "action": flag,
                "selectid": selectID
            },

            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }

    //move up down message end
    //copy message folder start
    $("#btnCopy").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype != "message" && selecttype != "folder") {
            alert("Please select  Folder node or Message node!");
            $("#btnCopy").css("background-position", "100%");
        }
        else {
            $("#ctl00_ContentPlaceHolder1_CopiedCutedID").attr("value", selectID);
            $("#ctl00_ContentPlaceHolder1_CopiedCutedType").attr("value", "Copy");

            $("#btnCopy").css("background-position", "100% -42px");
            $("#btnCopy").css("background-color", "gray");
            $("#btnCut").css("background-position", "100%");
        }
    });
    //copy message folder END
    //CUT message folder start
    $("#btnCut").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        if (selecttype != "message" && selecttype != "folder") {
            alert("Please select  Folder node or Message node!");
            $("#btnCut").css("background-position", "100%");
        }
        else {
            $("#ctl00_ContentPlaceHolder1_CopiedCutedID").attr("value", selectID);
            $("#ctl00_ContentPlaceHolder1_CopiedCutedType").attr("value", "Cut");

            $("#btnCut").css("background-position", "100% -42px");
            $("#btnCut").css("background-color", "gray");
            $("#btnCopy").css("background-position", "100%");
        }
    });
    //CUT message folder END
    //CUT message folder start
    $("#btnPaste").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
        var fromItemID = $("#ctl00_ContentPlaceHolder1_CopiedCutedID").val();
        var control = $("#ctl00_ContentPlaceHolder1_CopiedCutedType").val();
        if (selecttype == "message")
            alert("Please select  Root node or Folder node!");
        else {
            PasteFolderMsg(selectID, fromItemID, control);
            $("#btnCopy").css("background-position", "100%");
            $("#btnCut").css("background-position", "100%");
        }
    });
    function PasteFolderMsg(selectID, fromItemID, control) {
        $.ajax({
            type: "POST",
            url: "PasteFolderMsg.aspx",
            data: { "fromItemID": fromItemID,
                "selectid": selectID,
                "control": control
            },

            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    //CUT message folder END
    //btn save click start
    $("#btnSave").click(function() {
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

        //CKEDITOR.instances.TxtContent.setData('<b>编辑的文字</b>');
        var data = CKEDITOR.instances.TxtContent.getData();

        var human = $("#human").attr("value");

        if (selecttype == "root")
            alert("Please select  Folder node or Message node!");
        else if (selecttype == "folder") {
            SaveFoderName(selectID, human);
        }
        else if (selecttype == "message") {

            SaveFoderMsgAnswer(selectID, human, data);

        }
        else {
            alert("Please select Folder node or Message node!");
        }
    });

    function SaveFoderMsgAnswer(selectID, human, answer) {
        $.ajax({
            type: "POST",
            url: "SaveFolderMsgAnswer.aspx",
            data: { "human": human,
                "selectid": selectID,
                "answer": answer
            },
            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
                alert("Success!");
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }
    function SaveFoderName(selectID, human) {
        $.ajax({
            type: "POST",
            url: "SaveFolderMsgAnswer.aspx",
            data: { "human": human,
                "selectid": selectID
            },
            success: function(result) {
                if (result == "success")
                    $("#greybackground").remove();
                GetFileList();
                alert("Success!");
            },
            error: function(err) {
                window.location.href = "login.aspx";
            }
        });
    }

    //btn save click end
})
function RefreshFileList(html) {
    $("#browser li").remove();
    $("#browser").append(html); 
    $("#browser").treeview();
}


function GetFileList() {
    $.ajax({
        type: "POST",
        url: "GetFileList.aspx",
        data: "",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function(result) {
            var str = "";
            for (key in result) {

                str += ConvertToRootRowHTML(result[key].Name, result[key].Icon, result[key].Id, result[key].Type, result[key].IsDeleted, result[key].Isoffline, result[key].Rows);
            }
            RefreshFileList(str);
            var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
            if (selectID != "") {
                $("#" + selectID).focus();
                $("#" + selectID).css("background-color", "#08246B");
                $("#" + selectID).css("color", "cyan");
                $("#" + selectID).css("width", "100%");
                $("#" + selectID).css("display", "inline");
            }
        },
        error: function(err) {

            window.location.href = "login.aspx";
        }
    });
}
function ConvertToRootRowHTML(Name, Icon, Id, Type, IsDeleted, Isoffline, Rows) {
    //debugger;

    var html = "";

    html += "<li><span onclick=NodeClick(this) class=folder id =root" + Id + " style='background: url(../App_Themes/DefaultTheme/images/" + Icon + ") 0 0 no-repeat;'>" + Name + "</span><ul>";
    for (key in Rows) {
        html += ConvertToFolderRowHTML(Rows[key].Name, Rows[key].Icon, Rows[key].Id, Rows[key].Type, Rows[key].IsDeleted, Rows[key].Isoffline, Rows[key].Rows);

    }

    html += "</ul></li>";
    return html;
}

function ConvertToFolderRowHTML(Name, Icon, Id, Type, IsDeleted, Isoffline, Rows) {
    //debugger;

    var html = "";

    html += "<li ><span onclick=NodeClick(this) class=folder id =folder" + Id + " style='background: url(../App_Themes/DefaultTheme/images/" + Icon + ") 0 0 no-repeat;'>" + Name + "</span><ul>";
    for (key in Rows) {
        html += ConvertToMsgRowHTML(Rows[key].Name, Rows[key].Icon, Rows[key].Id, Rows[key].Type, Rows[key].IsDeleted, Rows[key].Isoffline, Rows[key].Rows);

    }

    html += "</ul></li>";
    return html;
}
function ConvertToMsgRowHTML(Name, Icon, Id, Type, IsDeleted, Isoffline, Rows) {
    //debugger;

    var html = "";

    html += "<li title='"+Name+"'><span onclick='NodeClick(this)' class='file' id ='message" + Id + "'  style='background: url(../App_Themes/DefaultTheme/images/" + Icon + ") 0 0 no-repeat; '>" + Name + "</span>";

    html += "</li>";
    return html;
}

//function when btnAddVClick Click start
function btnAddVClick() {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

    if (selecttype == "root")
        alert("Please select Message node!");
    else if (selecttype == "folder") {
        alert("Please select Message node!");
    }
    else if (selecttype == "message") {
        floatWindow('demo_table5');
        $("#addOrEditVarDiaTitle").text("Add Variation");
        $("#VarContent").focus();
    }
    else {
        alert("Please select Message node!");
    }
    $("#BtnOkVar").unbind("click");
    $("#BtnOkVar").click(function() {
        var varContent = $("#VarContent").val();
        AddVar(varContent, selectID);
    });
}
function AddVar(varContent, selectID) {
    $.ajax({
        type: "POST",
        url: "AddVariation.aspx",
        data: { "varContent": varContent,
            "selectid": selectID
        },
        success: function(result) {
            if (result == "success")
                $("#demo_table5").hide("slow");
            $("#greybackground").remove();
            GetVariations(selectID);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
//function when btnAddVClick Click end

//function when nodes clicked start
function NodeClick(iteminput) {
    var item = $(iteminput).attr("id").toString();
    var text = $(iteminput).text();
    $("#human").attr("value", text);

    if (item.indexOf(defaultFolderIDTheme) >= 0) {
        $("#ctl00_ContentPlaceHolder1_Citemid").attr("value", item);
        $("#ctl00_ContentPlaceHolder1_Citemtype").attr("value", item.substring(0, defaultFolderIDTheme.length));
        FolderNodeCssConfig();
    }
    else if (item.indexOf(defaultMessageIDTheme) >= 0) {
        $("#ctl00_ContentPlaceHolder1_Citemid").attr("value", item);
        $("#ctl00_ContentPlaceHolder1_Citemtype").attr("value", item.substring(0, defaultMessageIDTheme.length));
        var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
        //change node css
        MsgNodeCssConfig();
        //view message content
        GetAnswerContent(selectID);
        //View variations
        GetVariations(selectID);
    }
    else if (item.indexOf(defaultRootIDTheme) >= 0) {
        $("#ctl00_ContentPlaceHolder1_Citemid").attr("value", item);
        $("#ctl00_ContentPlaceHolder1_Citemtype").attr("value", item.substring(0, defaultRootIDTheme.length));
        FolderNodeCssConfig();
    }
    $("#browser span").css("background-color", "white");
    $("#browser span").css("color", "#5B5B5B");

    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");
    return false;
};
//function when nodes clicked  end
//when click message node,get the content start
function GetAnswerContent(selectID) {
    $.ajax({
        type: "POST",
        url: "GetAnswerContent.aspx",
        data: { "selectID": selectID
        },
        success: function(result) {
            //Set the value of CKEDIT
            CKEDITOR.instances.TxtContent.setData(result);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
//when click message node,get the content end
//when click message node,get the variations start
function GetVariations(selectID) {
    $.ajax({
        type: "POST",
        url: "GetVariations.aspx",
        data: { "selectID": selectID
        },
        //                contentType: "application/json;charset=utf-8",
        //                dataType: "json",
        success: function(result) {
            var str = "";
            var rows = $.parseJSON(result);
            for (key in rows) {

                str += ConvertToVariationRowHTML(rows[key].Name, rows[key].Id, rows[key].Type, rows[key].IsDeleted, rows[key].Isoffline);
            }
            RefreshVariationList(str);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
function ComputeLength(str) {
    return str.replace(/[^\u0000-\u007f]/g, "11").length;
}
function ConvertToVariationRowHTML(Name, Id, Type, IsDeleted, Isoffline) {
    var shortname = Name;
    if (ComputeLength(Name) > 60) {
        shortname = Name.substring(0, 50) + "...";
    }
    var html = "";
    html += "<dd  title='" + Name + "'  fid='variation" + Id + "' fullname='" + Name + "' >"
    html += "<span style='height:24px; margin-bottom:20px;'><img src='../App_Themes/DefaultTheme/images/doc.png' align='absmiddle' style='margin-right:8px;' /></span ><span id =variationspan" + Id + " >" + shortname + "</span>";
    html += "<span  style='text-decoration:underline;float:right; margin-right:15px'><a href='#' id=variationedit" + Id + " onclick=varEditClick(this.id);>Edit</a></span><span style='float:right;text-decoration:underline;margin-right:5px;'><a href='#' id=variationdelete" + Id + " onclick=varDeleteClick(this.id);>Delete</a></span>"

    html += "</dd>";
    return html;
}
function varDeleteClick(id) {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
    if (confirm("Are you sure to delete it?")) {
        EditVar("", selectID, id, "delete");
    }
}
function varEditClick(id) {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();
    var tempid = id.toString().replace("variationedit", "variationspan");
    var varcontent = $("#" + tempid).text();
    if (id.indexOf(defaultVarIDTheme) >= 0) {
        floatWindow('demo_table5');
        $("#addOrEditVarDiaTitle").text("Edit Variation");
        $("#VarContent").focus();
        $("#VarContent").attr("value", varcontent);
    }
    $("#BtnOkVar").unbind("click");
    $("#BtnOkVar").click(function() {
        var varContent = $("#VarContent").val();
        EditVar(varContent, selectID, id, "edit");
    });

}
function EditVar(varContent, selectID, varid, control) {
    $.ajax({
        type: "POST",
        url: "EditVariation.aspx",
        data: { "varContent": varContent,
            "selectid": selectID,
            "varid": varid,
            "control": control
        },
        success: function(result) {
            if (result == "success")
                $("#demo_table5").hide("slow");
            $("#greybackground").remove();
            GetVariations(selectID);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}

function RefreshVariationList(html) {
    $("#variousList dd").remove();
    $("#variousList").append(html);

}

//when click message node,get the variations end

function FolderNodeCssConfig() {
    $("#ckeditSpan").css("display", "none");
    $("#variousList").css("display", "none");
    $("#variousTitle").css("display", "none");
    $("#esuperTitle").css("display", "none");
    $("#humanTitle").html("&nbsp;&nbsp;Name");
    $("#msgTitle").html("&nbsp;&nbsp;Folder");
    $("#btnSave").css("display", "block");

    $("#msgTitle").css("display", "block");
    $("#humanTitle").css("display", "block");
    $("#human").css("display", "block");
}
function MsgNodeCssConfig() {
    $("#ckeditSpan").css("display", "block");
    $("#variousList").css("display", "block");
    $("#variousTitle").css("display", "block");
    $("#esuperTitle").css("display", "block");
    $("#humanTitle").html("&nbsp;&nbsp;Human");
    $("#msgTitle").html("&nbsp;&nbsp;Message");
    $("#btnSave").css("display", "block");

    $("#msgTitle").css("display", "block");
    $("#humanTitle").css("display", "block");
    $("#human").css("display", "block");
}
function InitializeCssConfig() {
    $("#ckeditSpan").css("display", "none");
    $("#variousList").css("display", "none");
    $("#variousTitle").css("display", "none");
    $("#esuperTitle").css("display", "none");
    $("#btnSave").css("display", "none");

    $("#msgTitle").css("display", "none");
    $("#humanTitle").css("display", "none");
    $("#human").css("display", "none");

}


//btn delete db scheme click start
function btnDeleteDBSchemeClick() {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

    var data = "";
    var valu = CKEDITOR.instances.TxtContent.getSelection();
    if (valu == null) { alert("Please select the DBScheme item"); return false; }
    if (CKEDITOR.env.ie) {
        data = valu.getNative().createRange().text;
    } else {
        data = valu.getNative();
    }

    var valu2 = valu.getSelectedElement();
    if (valu2 == null) { alert("Please select the DBScheme item"); return false; }
    var id = valu2.getAttribute('id');

    if (id == null) {
        alert("Please select the DBScheme item");
    }
    else {
        if (confirm("Are you sure to delete it?")) {
            valu2.remove();
            var answer = CKEDITOR.instances.TxtContent.getData();
            DeleteRule(id, selectID, answer);
        }
    }
}
function DeleteRule(id, selectID, answer) {
    $.ajax({
        type: "POST",
        url: "DeleteRule.aspx",
        data: { "ruleid": id,
            "selectid": selectID,
            "answer": answer
        },

        success: function(result) {
            if (result == "success") {
                alert("Success!");
                GetFileList();
            }
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}

//btn delete db scheme click end

//btn edit db scheme click start
function btnEditDBSchemeClick() {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

    var data = "";
    var valu = CKEDITOR.instances.TxtContent.getSelection();
    if (valu == null) { alert("Please select the DBScheme item"); return false; }
    if (CKEDITOR.env.ie) {
        data = valu.getNative().createRange().text;
    } else {
        data = valu.getNative();
    }

    var valu2 = valu.getSelectedElement();
    if (valu2 == null) { alert("Please select the DBScheme item"); return false; }
    var id = valu2.getAttribute('id');

    if (id == null) {
        alert("Please choose the DBScheme");
    }
    else {
        if (selecttype == "root")
            alert("Please select Message node!");
        else if (selecttype == "folder") {
            alert("Please select Message node!");
        }
        else if (selecttype == "message") {
            floatWindow('demo_table6');
            $("#AddDBScheme").text("Edit DBScheme");
            GetDBTableFieldName(id, selectID);
        }
        else {
            alert("Please select Message node!");
        }
        $("#btnDBSCHOK").unbind("click");
        $("#btnDBSCHOK").click(function() {
            var tablename = $("#ctl00_ContentPlaceHolder1_tablename").val();
            var fieldname = $("#ctl00_ContentPlaceHolder1_fieldname").val();
            var answer = CKEDITOR.instances.TxtContent.getData();
            EditRule(tablename, fieldname, id, selectID);

        });
    }
}
function EditRule(tablename, fieldname, id, selectid) {
    $.ajax({
        type: "POST",
        url: "EditRule.aspx",
        data: {
            id: id,
            tablename: tablename,
            fieldname: fieldname,
            selectid: selectid
        },
        success: function(result) {
            if (result == "success") {
                $("#demo_table6").hide("slow");
                $("#greybackground").remove();

            }
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
function GetDBTableFieldName(id, selectID) {
    $.ajax({
        type: "POST",
        url: "GetDBTableFieldName.aspx",
        data: { "ruleid": id
        },

        success: function(result) {
            var tablename = result.toString().substring(0, result.toString().indexOf("&"));
            var fieldname = result.toString().substring(result.toString().indexOf("&") + 1, result.toString().length);
            //$("#" + tablename)
            GetFieldsAndSelectField("Enum" + tablename, fieldname);
            $("#dltable dd span").css("background-color", "#F7F7F7");
            $("#dltable dd span").css("color", "#5B5B5B");
            $("#" + tablename).css("background-color", "#08246B");
            $("#" + tablename).css("color", "cyan");
            $("#ctl00_ContentPlaceHolder1_tablename").attr("value", tablename);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
function GetFieldsAndSelectField(tablename, fieldname) {
    $.ajax({
        type: "POST",
        url: "GetFields.aspx",
        data: {
            tablename: tablename
        },
        success: function(result) {
            var str = "";
            var rows = $.parseJSON(result);
            for (key in rows) {
                str += ConvertToFieldsRowHTML(rows[key].Name);
            }
            RefreshFieldsList(str);
            $("#" + fieldname).click();

        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
//btn edit db scheme click end

//btn add db scheme click start
function btnAddDBSchemeClick() {
    var selectID = $("#ctl00_ContentPlaceHolder1_Citemid").val();
    var selecttype = $("#ctl00_ContentPlaceHolder1_Citemtype").val();

    if (selecttype == "root")
        alert("Please select Message node!");
    else if (selecttype == "folder") {
        alert("Please select Message node!");
    }
    else if (selecttype == "message") {
        floatWindow('demo_table6');
        $("#AddDBScheme").text("Add DBScheme");

    }
    else {
        alert("Please select Message node!");
    }
    $("#btnDBSCHOK").unbind("click");
    $("#btnDBSCHOK").click(function() {
        var tablename = $("#ctl00_ContentPlaceHolder1_tablename").val();
        var fieldname = $("#ctl00_ContentPlaceHolder1_fieldname").val();
        ADDRule(tablename, fieldname, selectID);

    });
}
function ADDRule(tablename, fieldname, selectID) {
    $.ajax({
        type: "POST",
        url: "AddRule.aspx",
        data: { "tablename": tablename,
            "fieldname": fieldname,
            "selectid": selectID
        },

        success: function(result) {
            if (result.indexOf("success") >= 0) {
                var ruleid = result.substring(7, result.toString().length);

                $("#demo_table6").hide("slow");
                $("#greybackground").remove();

                str = "<img id=" + ruleid + " src='../App_Themes/DefaultTheme/images/database_add.png'</img>";
                CKEDITOR.instances.TxtContent.insertHtml(str);

                var data = CKEDITOR.instances.TxtContent.getData();
                var human = $("#human").attr("value");

                $.ajax({
                    type: "POST",
                    url: "SaveFolderMsgAnswer.aspx",
                    data: { "human": human,
                        "selectid": selectID,
                        "answer": data,
                        "isPrivate": "true"
                    },
                    success: function(result) {
                        if (result == "success")
                            $("#greybackground").remove();

                        GetFileList();
                    },
                    error: function(err) {
                        window.location.href = "login.aspx";
                    }
                });

            }
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
//btn add db scheme click end

//btn fundsClick start
function fundsClick(iteminput) {

    GetFields("Enumfund");
    $("#dltable dd span").css("background-color", "#F7F7F7");
    $("#dltable dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");
    $("#ctl00_ContentPlaceHolder1_tablename").attr("value", $(iteminput).attr("id"));
};
//btn fundsClick end

//btn fundbankaccountSClick start
function fundbankaccountSClick(iteminput) {

    GetFields("Enumfundbankaccount");
    $("#dltable dd span").css("background-color", "#F7F7F7");
    $("#dltable dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");
    $("#ctl00_ContentPlaceHolder1_tablename").attr("value", $(iteminput).attr("id"));
};
//btn fundsClick end

//btn fundtrusteeSClick start
function fundtrusteeSClick(iteminput) {

    GetFields("Enumfundtrustee");
    $("#dltable dd span").css("background-color", "#F7F7F7");
    $("#dltable dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");
    $("#ctl00_ContentPlaceHolder1_tablename").attr("value", $(iteminput).attr("id"));
};
//btn fundtrusteeSClick end

//btn fundbankaccounttraSClick start
function fundbankaccounttraSClick(iteminput) {

    GetFields("Enumfundbankaccounttransaction");
    $("#dltable dd span").css("background-color", "#F7F7F7");
    $("#dltable dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");

    $("#ctl00_ContentPlaceHolder1_tablename").attr("value", $(iteminput).attr("id"));
};
//btn fundbankaccounttraSClick end
//btn bankaccounttypeSClick start
function bankaccounttypeSClick(iteminput) {

    GetFields("Enumbankaccounttype");
    $("#dltable dd span").css("background-color", "#F7F7F7");
    $("#dltable dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");
    $("#ctl00_ContentPlaceHolder1_tablename").attr("value", $(iteminput).attr("id"));
};
//btn bankaccounttypeSClick end
//btn FieldsClick start
function FieldsClick(iteminput) {

    $("#dlfield dd span").css("background-color", "#F7F7F7");
    $("#dlfield dd span").css("color", "#5B5B5B");
    $(iteminput).css("background-color", "#08246B");
    $(iteminput).css("color", "cyan");
    $(iteminput).css("width", "100%");
    $(iteminput).css("display", "inline");

    $("#ctl00_ContentPlaceHolder1_fieldname").attr("value", $(iteminput).attr("id"));
};
//btn FieldsClick end
function GetFields(tablename) {
    $.ajax({
        type: "POST",
        url: "GetFields.aspx",
        data: {
            tablename: tablename
        },
        success: function(result) {
            var str = "";
            var rows = $.parseJSON(result);
            for (key in rows) {
                str += ConvertToFieldsRowHTML(rows[key].Name);
            }
            RefreshFieldsList(str);
        },
        error: function(err) {
            window.location.href = "login.aspx";
        }
    });
}
function RefreshFieldsList(html) {
    $("#dlfield dd").remove();
    $("#dlfield").append(html);

}

function ConvertToFieldsRowHTML(Name) {
    var shortname = Name;
    if (ComputeLength(Name) > 60) {
        shortname = Name.substring(0, 50) + "...";
    }
    var html = "";
    html += "<dd  title='" + Name + "'  fid='dd" + Name + "' fullname='" + Name + "' style='text-align:left;' >"
    html += "<span style='height:24px; margin-bottom:20px;'><img src='../App_Themes/DefaultTheme/images/table_column_alt.png' align='absmiddle' style='margin-right:8px;' /></span ><span id =" + Name + " onclick=FieldsClick(this); style='text-decoration:underline;'>" + shortname + "</span>";
    html += "</dd>";
    return html;
}

 