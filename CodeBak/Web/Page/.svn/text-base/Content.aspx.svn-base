<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Content.aspx.cs" Inherits="eChartProject.Web.Page.Content" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
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

    <script type="text/javascript" src="../js/content.js"></script>

    <%--	<script type="text/javascript" src="demo.js"></script>--%>
    <%--    <script type="text/javascript" src="../Common/Scripts/changeImg.js"></script>--%>
    <%--    <script type="text/javascript" src="../Common/Scripts/menu.js"></script>--%>

    <script type="text/javascript">
   
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
            style="float: left" />
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
    <div style="width: 100%; float: left">
        <table style="width: 100%; border: 1px solid #D7D7D7; padding: 0.25em;" border="0"
            cellpadding="0" cellspacing="0">
            <tr style="width: 100%;">
                <td style="width: 100%;">
                    <table id="INNERTable" style="width: 100%; height: 770px; border: 1px solid #D7D7D7;
                        padding: 0.25em;" border="1" cellpadding="0" cellspacing="0">
                        <tr>
                            <td height="100%" width="39px" valign="top" class="search2_bg left" style="border: 1px;">
                                <ul id="menu02">
                                    <li id="btnMoveUp" style="height: 24px;" class="btn7 left" title="MoveUp"><a href="#">
                                        <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                            style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Upload-a-file.png"
                                            align="middle" /></a></li>
                                    <li id="btnMoveDown" style="height: 24px; margin-bottom: 10px;" class="btn7 left"
                                        title="MoveDown"><a href="#">
                                            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Download.png"
                                                align="middle" /></a></li>
                                    <li id="btnNewADD" style="height: 24px;" class="btn7 left" title="Add"><a href="#">
                                        <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                            style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Add.png"
                                            align="middle" /></a></li>
                                    <li id="btnDelete" style="height: 24px; margin-bottom: 10px;" class="btn7 left" title="Delete">
                                        <a href="#">
                                            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Delete-a-file.png"
                                                align="middle" /></a></li>
                                    <li id="btnCopy" style="height: 24px;" class="btn7 left" title="Copy"><a href="#">
                                        <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                            style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Copy-to.png"
                                            align="middle" /></a></li>
                                    <li id="btnCut" style="height: 24px;" class="btn7 left" title="Cut"><a href="#">
                                        <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                            style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/cnicon_KDE_Crystal.png"
                                            align="middle" /></a></li>
                                    <li id="btnPaste" style="height: 24px; margin-bottom: 10px;" class="btn7 left" title="Paste">
                                        <a href="#">
                                            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/paste.png"
                                                align="middle" />
                                        </a></li>
                                    <li id="btnSetOnline" style="height: 24px;" class="btn7 left" title="SetOnline"><a
                                        href="#">
                                        <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                            style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Link-device.png"
                                            align="middle" />
                                    </a></li>
                                    <li id="btnSetOffline" style="height: 24px; margin-bottom: 0.75em;" class="btn7 left"
                                        title="SetOffline"><a href="#">
                                            <img style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Unlink-device.png"
                                                align="middle" /></a></li>
                                </ul>
                            </td>
                            <td height="100%" width="26%" valign="top">
                                <%-- 
					<iewc:treeview id="TreeView1" runat="server"  CssClass= "tree_table1"  AutoPostBack=false
                                 ></iewc:treeview>--%>
                                <%--           onselectedindexchange="TreeView1_SelectedIndexChange"  --%>
                                <ul id="browser" class="filetree" style="table-layout: auto; white-space: nowrap;
                                    overflow: scroll; width: 300px; height: 100%;">
                                </ul>
                            </td>
                            <td style="border: 1px solid #D7D7D7; padding: 0.25em;" width="1%" height="100%">
                                &nbsp;
                            </td>
                            <td width="69%" height="100%" valign="top">
                                <table style="width: 100%; border: 1px solid #D7D7D7; padding: 0.25em;" border="0"
                                    cellpadding="0" cellspacing="0">
                                    <tr style="width: 100%; height: 10%">
                                        <td id="msgTitle" style="background-color: #F7F7F7; border: 1px solid #D7D7D7; overflow: auto;
                                            padding: 0.25em; height: 32px;">
                                            &nbsp;&nbsp;Message
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 10%">
                                        <td id="humanTitle" style="height: 22px; background-color: #F7F7F7; border: 1px solid #D7D7D7;
                                            overflow: auto; padding: 0.25em;">
                                            &nbsp;&nbsp;Human
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 10%">
                                        <td>
                                            <span>
                                                <input id="human" name="input" type="text" style="width: 98%; float: left; height: 32px;
                                                    line-height: 32px;" />
                                            </span>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 10%">
                                        <td id="variousTitle" style="height: 25px; background-color: #F7F7F7; border: 1px solid #D7D7D7;
                                            overflow: auto; padding: 0.25em;">
                                            &nbsp;&nbsp;Variations<input id="btnAddVariation" onclick="btnAddVClick()" type="button"
                                                value="Add" style="width: 45px; height: 25px; margin-left: 70px"></input>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 30%">
                                        <td>
                                            <span style="width: 100%;">
                                                <dl class="filetree" id="variousList" style="position: relative; height: 88px; background-color: #F7F7F7;
                                                    border: 1px solid #D7D7D7; overflow: auto; padding: 0.25em;">
                                                </dl>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 10%">
                                        <td id="esuperTitle" style="overflow: auto; padding: 0.25em; height: 25px; background-color: #F7F7F7;
                                            border: 1px solid #D7D7D7;">
                                            &nbsp;&nbsp;ESuperfund
                                            <input id="addDBScheme" onclick="btnAddDBSchemeClick()" type="button" value="Add DBScheme"
                                                style="width: 105px; height: 25px; margin-left: 60px" />
                                            <input id="editDBScheme" onclick="btnEditDBSchemeClick()" type="button" value="Edit DBScheme"
                                                style="width: 105px; height: 25px;" />
                                            <input id="deleteDBScheme" onclick="btnDeleteDBSchemeClick()" type="button" value="Delete DBScheme"
                                                style="width: 110px; height: 25px;" />
                                        </td>
                                    </tr>
                                    <tr style="width: 100%; height: 80%;">
                                        <td>
                                            <span id="ckeditSpan" style="width: 100%;">
                                                <asp:TextBox ID="TxtContent" TextMode="MultiLine"></asp:TextBox>

                                                <script type="text/javascript">
                                                    var editor = CKEDITOR.replace("TxtContent");
                                                </script>

                                                <%--	<ckeditor:ckeditorcontrol ID="CKEditor1" runat="server" Height="200">

		</ckeditor:ckeditorcontrol>--%>
                                            </span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span id="btnSave" class="btn5 left" style="margin-top: 20px; margin-left: 20px;
                                                margin-bottom: 20px;">
                                                <img alt="Save" style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif"
                                                    align="middle" /><img style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Save.png"
                                                        align="middle" />Save</span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div style="clear:both;">
          <dl  style="color: #6B6A6A;">
          <dd style="float: left;margin-top: 10px; margin-left: 10px;padding-top:10px;">
                                                <img alt="Public Question"  style="float: left; margin-left: 10px; margin-right:10px; " src="../App_Themes/DefaultTheme/images/msgonline.png"
                                                    align="middle" />Public Question
           </dd>
           <dd style="float: left;margin-top: 10px; margin-left: 10px;padding-top:10px;">
                                                <img alt="Private Question"  style="float: left; margin-left: 10px; margin-right:10px;" src="../App_Themes/DefaultTheme/images/comment_private.png"
                                                    align="middle" />Private Question
           </dd>
           <dd style="float: left;margin-top: 10px; margin-left: 10px;padding-top:10px;">
                                                <img alt="Offline Question"  style="float: left; margin-left: 10px; margin-right:10px;" src="../App_Themes/DefaultTheme/images/msgoffline.png"
                                                    align="middle" />Offline Question
           </dd>
            <dd style="float: left;margin-top: 10px; margin-left: 10px;padding-top:10px;">
                                                <img alt="DB Scheme"  style="float: left; margin-left: 10px; margin-right:10px;" src="../App_Themes/DefaultTheme/images/database_add.png"
                                                    align="middle" />DB Scheme
           </dd>
            </dl>
    </div>
    <div class="clear">
    </div>
    <br />
    <br />
 
    <div class="clear">
    </div>
    <input runat="server" id="Citemtype" type="text" style="display: none" />
    <input runat="server" id="Citemid" type="text" style="display: none" />
    <input runat="server" id="CopiedCutedID" type="text" style="display: none" />
    <input runat="server" id="CopiedCutedType" type="text" style="display: none" />
    <input runat="server" id="tablename" type="text" style="display: none" />
    <input runat="server" id="fieldname" type="text" style="display: none" />
</asp:Content>
