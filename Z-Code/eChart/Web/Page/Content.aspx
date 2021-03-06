<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="eChartProject.Web.Page.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7"/>
    <title>eChart Server Content</title>
   <link href="../App_Themes/DefaultTheme/css/public.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/font.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/demo.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/sample.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="../Common/Scripts/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="../Common/Scripts/correctpng.js"></script>
  	<link rel="stylesheet" href="../jquery.treeview.css" />
	<link rel="stylesheet" href="screen.css" />

<%--	<script src="../lib/jquery.js" type="text/javascript"></script>--%>
	<script src="../lib/jquery.cookie.js" type="text/javascript"></script>
	<script src="../jquery.treeview.js" type="text/javascript"></script>
	<script type="text/javascript" src="../ckeditor/ckeditor.js"></script>
 
	
<%--	<script type="text/javascript" src="demo.js"></script>--%>
  
  
  
  <%--    <script type="text/javascript" src="../Common/Scripts/changeImg.js"></script>--%>
<%--    <script type="text/javascript" src="../Common/Scripts/menu.js"></script>--%>
    <script type="text/javascript">
        var defaultFolderIDTheme = "folder";
        var defaultMessageIDTheme = "message";
        var defaultRootIDTheme = "root";
        var defaultVarIDTheme = "variationedit";
        var global_rowCount = 0;
        $(document).ready(function() {
            //initialize tree
            GetFileList();
            InitializeCssConfig();
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
                        }
                    },
                    error: function(err) {

                        window.location.href = "login.aspx";
                    }
                });
            }
            function RefreshFileList(html) {
                $("#browser li").remove();
                $("#browser").append(html); 0
                $("#browser").treeview();
            }

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

                //CKEDITOR.instances.TxtContent.setData('<b>�༭������</b>');
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

                html += "<li ><span onclick=NodeClick(this) class=file id =message" + Id + "  style='background: url(../App_Themes/DefaultTheme/images/" + Icon + ") 0 0 no-repeat; '>" + Name + "</span>";

                html += "</li>";
                return html;
            }

        })
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
       function NodeClick(iteminput) 
         {
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
                EditVar(varContent, selectID, id,"edit");
            });

        }
        function EditVar(varContent, selectID,varid,control) {
            $.ajax({
                type: "POST",
                url: "EditVariation.aspx",
                data: { "varContent": varContent,
                    "selectid": selectID,
                    "varid": varid,
                    "control":control
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
        
    </script>
    <style type="text/css">
        .style1
        {
            height: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="current_place" style="width: 100%">
        <img src="../App_Themes/DefaultTheme/images/icon_currentplace.gif" align="middle"
            style="float: left " />
        <span class="txt">eChart</span>
    </div>
    
<%--     <div>
        <span class="btn5 left">
            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_14.gif"
                align="middle" /><a href="#" onclick="javascript:floatWindow('demo_table2');swfu_isDialogShow=true;">Add</a></span>
        <span class="btn5 left" id="btnNewFolder">
            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Create-a-folder.png"
                align="middle" />Delete</span> <span class="btn5 left" id="btnShowDeletedFiles">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                        style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Show-delete-files.png"
                        align="middle" /><span>Update</span></span>
                        
          </div>--%>
         <div style="width:100%;  float:left">
           <table  style="width:100%; border: 1px solid #D7D7D7;padding: 0.25em; " border="0" cellpadding="0" cellspacing="0">             
            <tr style="width:100%; ">
                    <td  style="width:100%; ">
			<table id="INNERTable" style="width:100%; height:770px; border: 1px solid #D7D7D7;padding: 0.25em;" border="1"  cellpadding="0" cellspacing="0">
				<tr>
				    <td height="100%" width="39px" valign="top" class="search2_bg left" style=" border:1px;">
				    
				<ul  id="menu02" >
				<li id="btnMoveUp" style="height:24px; " class="btn7 left" title="MoveUp"><a href="#" >
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Upload-a-file.png" align="middle" /></a></li>
                <li id="btnMoveDown" style="height:24px; margin-bottom:10px;" class="btn7 left" title="MoveDown" ><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Download.png" align="middle" /></a></li>
				
				
				<li id="btnNewADD" style="height:24px; " class="btn7 left" title="Add"><a href="#">
                    <img style=" float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Add.png" align="middle" /></a></li>
                <li id="btnDelete" style="height:24px;margin-bottom:10px;"  class="btn7 left" title="Delete"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Delete-a-file.png" align="middle" /></a></li>
            
              
                <li id="btnCopy" style="height:24px;"  class="btn7 left" title="Copy"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Copy-to.png" align="middle" /></a></li>
                <li id="btnCut"  style="height:24px; " class="btn7 left" title="Cut"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/cnicon_KDE_Crystal.png" align="middle" /></a></li>
                <li id="btnPaste" style="height:24px; margin-bottom:10px;" class="btn7 left" title="Paste"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/paste.png" align="middle" />
                    </a></li>
                    
              
                    
                <li id="btnSetOnline" style="height:24px;" class="btn7 left" title="SetOnline"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Link-device.png" align="middle" />
                    </a></li>
                <li id="btnSetOffline" style="height:24px; margin-bottom: 0.75em; " class="btn7 left" title="SetOffline"><a href="#">
                    <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Unlink-device.png" align="middle" /></a></li>
				    </ul>    
				    
				    </td>
				
					<td height="100%" width="26%" valign="top"  >
					
				   <%-- 
					<iewc:treeview id="TreeView1" runat="server"  CssClass= "tree_table1"  AutoPostBack=false
                                 ></iewc:treeview>--%>
                            
                <%--           onselectedindexchange="TreeView1_SelectedIndexChange"  --%>
                
 
	            <ul id="browser" class="filetree" style="table-layout:auto;white-space:nowrap;overflow:scroll;width:300px;height:100%;">
		           
	            </ul>
            	

                
                
                
                
                            </td>
                    <td  style="border: 1px solid #D7D7D7;padding: 0.25em;" width="1%" height="100%">&nbsp;</td>
                    <td width="69%"  height="100%" valign=top>
                        <table style="width:100%;   border: 1px solid #D7D7D7;padding: 0.25em; "  border="0" cellpadding="0" cellspacing="0">
                        
                        
                        <tr style="width:100%; height:10%"><td id ="msgTitle" style="background-color: #F7F7F7;border: 1px solid #D7D7D7;overflow: auto;padding: 0.25em; height:32px; ">&nbsp;&nbsp;Message</td></tr>
                        <tr style="width:100%; height:10%">
                         <td id="humanTitle" style=" height:22px;background-color: #F7F7F7;border: 1px solid #D7D7D7;overflow: auto;padding: 0.25em; ">&nbsp;&nbsp;Human</td>
                        </tr>
                        
                           <tr  style="width:100%;height:10%"> 
                        <td ><span  >
                        <input id="human"  name="input" type="text"  style=" width:98%;  float:left;height:32px; line-height:32px; " />
                         </span>
                         </td>
                        </tr>
                        
                         <tr style="width:100%; height:10%">
                         <td id="variousTitle" style="height:22px;background-color: #F7F7F7;border: 1px solid #D7D7D7;overflow: auto;padding: 0.25em; ">&nbsp;&nbsp;Variations<input id="btnAddVariation" onclick="btnAddVClick()" type="button" value="Add" style=" width:45px; height:25px; margin-left:70px"></input></td>
                        
                        </tr>
                        <tr style="width:100%;height:30%" > 
                        <td><span style="width:100%;">
                        
                        
                        
                       <dl class="filetree" id="variousList" style="position: relative;height:88px;background-color: #F7F7F7;border: 1px solid #D7D7D7;overflow: auto;padding: 0.25em;">
       
      
                    
                        </dl>
                        
                        
                        
                        
                         </span>
                         </td>
                        </tr>
                        <tr style="width:100%;height:10%">
                         <td id="esuperTitle" style=" overflow: auto;padding: 0.25em;height:22px;background-color: #F7F7F7;border: 1px solid #D7D7D7;">&nbsp;&nbsp;ESuperfund<input id="addDBScheme" onclick="btnAddDBSchemeClick()" type="button" value="Add DB Scheme" style=" width:105px; height:25px; margin-left:70px"></input></td>
                        </tr>
                        <tr style="width:100%; height:80%;">
                        
                        <td  ><span id="ckeditSpan" style="width:100%;">
                        
                        <asp:TextBox ID="TxtContent"   TextMode="MultiLine"></asp:TextBox>
                        
                        <script type="text/javascript">
                            var editor = CKEDITOR.replace("TxtContent");
                        </script>
                        <%--	<ckeditor:ckeditorcontrol ID="CKEditor1" runat="server" Height="200">

		</ckeditor:ckeditorcontrol>--%>
                        
                        </span>
                        </td></tr>
                      
                        <tr ><td >    <span id="btnSave" class="btn5 left" style="margin-top:20px; margin-left:20px; margin-bottom:20px;" >
                            <img alt="Save" style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle"  /><img
                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Save.png"
                                align="middle" />Save</span>
                                </td></tr>
                                
                                
                        </table>
                   </td>
				</tr>
				
			</table>
			
		
		
            </td>
            </tr>
	      </table>
	        
	 </div>
	 
	     <div class="clear">
    </div>
    <br />
    <br />
	    <!-- float IDV start add folder -->
    <form action="#">
    <div id="demo_table1">
        <div class="text14b box_title" id="AddOrEditDialogTitle">
            Add Folder</div>
        <a href="#" class="demo_close_btn" id="btnCloseAddOrEditWindow"><span style="margin: 10px 10px 0 0;"
            class="right">
            <img src="../App_Themes/DefaultTheme/images/btn_close.gif" /></span></a>
        <div class="box_content">
            <div class="center border_line" style="width: 541px; height: 205px; overflow: hidden; vertical-align:middle">
            <table class="sheet1 center" style=" width:100%; height:100%"  border="0" align="center"  cellpadding="0"
                cellspacing="0">
               <tr>
                    <td height="24" align="right">
                        Folder Name:
                    </td>
                    <td>
                        <span class="search2_bg left" >
                            <input id="addfoldername" class="search2 left" name="input" type="text"  maxlength="50"/></span>
                        
                    </td>
                </tr>
                </table>
            </div>
            <div class="hr_style">
            </div>
            <div>
                <input class="btn_cancel right" name="" type="button" id="btnCloseAddOrEditWindow1" /><input
                    class="btn_ok right" id="btnAddOrEdit" name="" type="button" /></div>
            <div class="clear">
            </div>
        </div>
        <div style="width: 570px;">
            <img src="../App_Themes/DefaultTheme/images/box_bgbottom.gif" />
        </div>
    </div>
    </form>
    <!--add folder  float IDV end-->
    
    	    <!--  float IDV start add Msg -->
    <form action="#">
    <div id="demo_table4">
        <div class="text14b box_title" id="AddOrEditMsgDialogTitle">
            Add Message</div>
        <a href="#" class="demo_close_btn" id="btnCloseAddOrEditMsgWindow"><span style="margin: 10px 10px 0 0;"
            class="right">
            <img src="../App_Themes/DefaultTheme/images/btn_close.gif" /></span></a>
        <div class="box_content">
            <div class="center border_line" style="width: 541px; height: 205px; overflow: hidden;">
                <table class="sheet1 center"  style=" width:100%; height:100%" border="0" align="center" cellpadding="0"
                cellspacing="0">
               <tr>
                    <td height="24" align="right">
                        Message Content:
                    </td>
                    <td>
                        <span class="search2_bg left" >
                            <input id="msgcontent"  class="search2 left" name="input" type="text"  maxlength="50"/></span>
                        
                    </td>
                </tr>
                </table>
            </div>
            <div class="hr_style">
            </div>
            <div>
                <input class="btn_cancel right" name="" type="button" id="BtnCancle" /><input
                    class="btn_ok right" id="BtnOKmsg" name="" type="button" /></div>
            <div class="clear">
            </div>
        </div>
        <div style="width: 570px;">
            <img src="../App_Themes/DefaultTheme/images/box_bgbottom.gif" />
        </div>
    </div>
    </form>
    <!--add  Msg  float IDV END-->
    
        <!--  float IDV start add Variations -->
    <form action="#">
    <div id="demo_table5">
        <div class="text14b box_title" id="addOrEditVarDiaTitle">
            Add Variation</div>
        <a href="#" class="demo_close_btn" id="btnCloseAddOrEditVarWindow"><span style="margin: 10px 10px 0 0;"
            class="right">
            <img src="../App_Themes/DefaultTheme/images/btn_close.gif" /></span></a>
        <div class="box_content">
            <div class="center border_line" style="width: 541px; height: 205px; overflow: hidden;">
                <table class="sheet1 center"  style=" width:100%; height:100%" border="0" align="center" cellpadding="0"
                cellspacing="0">
               <tr>
                    <td height="24" align="right">
                        Variation Content:
                    </td>
                    <td>
                        <span class="search2_bg left" >
                            <input id="VarContent"  class="search2 left" name="input" type="text"  maxlength="50"/></span>
                        
                    </td>
                </tr>
                </table>
            </div>
            <div class="hr_style">
            </div>
            <div>
                <input class="btn_cancel right" name="" type="button" id="btnC" /><input
                    class="btn_ok right" id="BtnOkVar" name="" type="button" /></div>
            <div class="clear">
            </div>
        </div>
        <div style="width: 570px;">
            <img src="../App_Themes/DefaultTheme/images/box_bgbottom.gif" />
        </div>
    </div>
    </form>
    <!--add  Variations  float IDV END-->
    
    
     <div class="clear">
    </div>
        <input runat="server" id="Citemtype" type="text" style="display: none" />
        <input runat="server" id="Citemid" type="text" style="display: none" />
	    <input runat="server" id="CopiedCutedID" type="text" style="display: none" />
	    <input runat="server" id="CopiedCutedType" type="text" style="display: none" />

</asp:Content>





