<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="Setting.aspx.cs" Inherits="eChartProject.Web.Page.Setting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>eChart Server Setting</title>
    <link href="../App_Themes/DefaultTheme/css/public.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/font.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/demo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Common/Scripts/jquery-1.4.1.min.js"></script>
<%--    <script type="text/javascript" src="../Common/Scripts/correctpng.js"></script>
    <script type="text/javascript" src="../Common/Scripts/changeImg.js"></script>--%>
    <script type="text/javascript" src="../Common/Scripts/menu.js"></script>

    <script type="text/javascript">
//        $(function () {
//            //document.onclick = function(e){
//            var arrIDName = new Array("moreMenu");
//            ManageListTable("tabId", arrIDName);
//            bindClickShowMenu("tabId", "spanMore", "moreMenu", arrIDName);
//            $("body").click(function () {
//                for (i = 0; i < arrIDName.length; i++) {
//                    if ($("#" + arrIDName[i]).css("display") != "none") {
//                        $("#" + arrIDName[i]).slideUp();
//                    }
//                }
//                closeTbal("tabId");

//            })
        //        })
        $(document).ready(function() {
            $("#btnSave").click(function() {
                

                if (ValidateInput()) {
                    var username = $.trim($("#username").val()).replace(/\"/ig, "\\\"").replace(/\'/ig, "\\\'");
                    var password = $.trim($("#password").val()).replace(/\"/ig, "\\\"").replace(/\'/ig, "\\\'");
                    var email = $.trim($("#email").val()).replace(/\"/ig, "\\\"").replace(/\'/ig, "\\\'");
                    var country = $.trim($("#country").val()).replace(/\"/ig, "\\\"").replace(/\'/ig, "\\\'");
                    var city = $.trim($("#city").val()).replace(/\"/ig, "\\\"").replace(/\'/ig, "\\\'");
                    var gender = $("#gender").val();
                    var age = $("#age").val();
                    SaveUserInfo(username, password, email, country, city, gender, age);
                }
            });

            function ValidateInput() {
                CleanMessage();
                var b = true;
                if ($.trim($("#username").val()) == "") {
                    $("#userNameEmpty").css("display", "inline");
                    return false;
                }
                if ($.trim($("#password").val()) == "") {
                    $("#passwordEmpty").css("display", "inline");
                    return false;
                }
                if (!ValidateMinLength($("#password").val().toString(), 6)) {
                    $("#passwordShort").css("display", "inline");
                    return false;
                }
                var passwordRegExp = new RegExp("([a-zA-Z]+[^a-zA-Z]+[a-zA-Z]*)|([^a-zA-Z]+[a-zA-Z]+[^a-zA-Z]*)|([0-9]+[^0-9]+[0-9]*)|([^0-9]+[0-9]+[^0-9]*)$");
                if (!passwordRegExp.test($("#password").val())) {
                    $("#passwordError").css("display", "inline");
                    return false;
                }
                if ($.trim($("#txtConfirmPassword").val()) == "") {
                    $("#confirmPasswordEmpty").css("display", "inline");
                    return false;
                }
                if ($("#password").val() != $("#txtConfirmPassword").val()) {
                    $("#passwordNotMatch").css("display", "inline");
                    return false;
                }
                if ($.trim($("#email").val()) == "") {
                    $("#emailEmpty").css("display", "inline");
                    return false;
                }
                var emailRegExp = /^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/;
                var trimEmail = $.trim($("#email").val());
                if (!emailRegExp.test(trimEmail)) {
                    $("#emailError").css("display", "inline");
                    return false;
                }
                else {
                    var index = trimEmail.indexOf("@");
                    if (index > 64) {
                        $("#emailError").css("display", "inline");
                        return false;
                    }
                    index = trimEmail.length - index;
                    if (index > 253) {
                        $("#emailError").css("display", "inline");
                        return false;
                    }
                }

                if ($.trim($("#country").val()) == "") {
                    $("#countryEmpty").css("display", "inline");
                    return false;
                }
                if ($.trim($("#city").val()) == "") {
                    $("#cityEmpty").css("display", "inline");
                    return false;
                }
                if ($.trim($("#age").val()) == "") {
                    $("#ageEmpty").css("display", "inline");
                    return false;
                }
                var ageRegExp = /^\d+$/;
                var trimAge = $.trim($("#age").val());
                if (!ageRegExp.test(trimAge)) {
                    $("#ageError").css("display", "inline");
                    return false;
                }

                return true;
            }

            function CleanMessage() {
                $("#ValidationSummary span").css("display", "none");

            }
            function ValidateMinLength(str, minLength) {
                var length = str.length;
                if (length < minLength) {
                    return false;
                }
                else
                    return true;
            }

            function ValidateMaxLength(str, maxLength) {
                var length = str.length;
                if (length > maxLength) {
                    return false;
                }
                else
                    return true;
            }

            $("#btnCloseAccount").click(function() {


                var username = $("#username").val();
                CloseAccount(username);
            });
        });

        function CloseAccount(username) {
            $.ajax({
                type: "POST",
                url: "SaveSetting.aspx",
                data: { "username": username
                },

                success: function(result) {
                    if (result != "")
                        error1.html("");
                },
                error: function(err) {
                    window.location.href = "login.aspx";
                }
            });
        }
        

        function SaveUserInfo(username, password, email, country, city, gender, age) {
            $.ajax({
                type: "POST",
                url: "SaveSetting.aspx",
                data: { "username": username,
                    "password": password,
                    "email": email,
                    "country": country,
                    "city": city,
                    "gender": gender,
                    "age": age
                },

                success: function(result) {
                if (result != "")
                    if (result == "success")
                    $("#success").css("display", "inline");
                },
                error: function(err) {
                    window.location.href = "login.aspx";
                }
            });
        }
        
    

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="padding: 12px 0; width: 99%" class="center">
        
    </div>
    <div>
        <h3 class="text14b underline">
            Your Information</h3>
        <div style="z-index: 9999; position: relative; width: 500px; margin-bottom: 20px;"
            class="center">
            <table class="sheet1 center" width="500" border="0" align="center" cellpadding="0"
                cellspacing="0">
                <tr>
                    <td width="111" height="24" align="right">
                        Display Picture:
                    </td>
                    <td style="z-index: 9999;">
                        <!--<img src="images/pic_people.gif" id="eventBtn" class="clickTm" />-->
                        <img id="spanImg" src="../App_Themes/DefaultTheme/images/pic_people.gif" class="btn02" />
                       
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Username:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id=username name="input" type="text" class="search2 left"  maxlength="50"/></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal20"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Password:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id=password class="search2 left" name="input" type="password"  maxlength="50" /></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal1"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                 <tr>
                    <td height="24" align="right">
                        Confirm password:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id="txtConfirmPassword" class="search2 left" name="input6" type="password"  
                                maxlength="50" /></span><span class="attentionForTable"><asp:Literal ID="Literal9"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Email:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id=email class="search2 left" name="input" type="text"  maxlength="50"/></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal2"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Country:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id=country class="search2 left" name="input" type="text"  maxlength="50"/></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal3"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        City:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id= city class="search2 left" name="input" type="text"  maxlength="50"/></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal4"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Gender:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <%--<input id=gender class="search2 left" name="input" type="text" />--%>
                            <select id="gender" name="gender">
                            <option value="1">M</option>
                            <option value="2">F</option>
                            </select>
                            
                            </span>
                            <span class="attentionForTable"><asp:Literal ID="Literal5"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
                <tr>
                    <td height="24" align="right">
                        Age:
                    </td>
                    <td>
                        <span class="search2_bg left">
                            <input id= age class="search2 left" name="input" type="text" /></span>
                            <span class="attentionForTable"><asp:Literal ID="Literal7"
                                    runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                    </td>
                </tr>
            <tr>
                    <td height="12" align="right">
                        &nbsp;
                    </td>
                    <td valign="top">
                        <span class="attention">
                            <asp:Literal ID="Literal21" runat="server" Text="<%$Resources:Global,Common_Asterisk%>" /></span>
                        <asp:Literal ID="Literal13" runat="server" Text="<%$Resources:Global,Common_Tips_Register%>" />
                        <br />
                        <br />
                        <div style="color: #fe8300; font-size: 10px; height: 22px" id="ValidationSummary">
                            <span style="display: none" id="userNameError">
                                <asp:Literal ID="Literal29" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionError_Username %>"></asp:Literal></span>
                            <span style="display: none" id="userNameLong">
                                <asp:Literal ID="Literal32" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionLong_Username %>"></asp:Literal></span>
                            <span style="display: none" id="countryError">
                                <asp:Literal ID="Literal30" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionError_Country %>"></asp:Literal></span>
                            <span style="display: none" id="countryLong">
                                <asp:Literal ID="Literal33" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionLong_Country %>"></asp:Literal></span>
                            <span style="display: none" id="userNameEmpty">
                                <asp:Literal ID="Literal22" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_Username %>"></asp:Literal></span>
                            <span style="display: none" id="countryEmpty">
                                <asp:Literal ID="Literal23" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_Country %>"></asp:Literal></span>
                               
                               <span style="display: none" id="ageError">
                                <asp:Literal ID="Literal12" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionError_Age %>"></asp:Literal></span>
                                    
                                 <span style="display: none" id="cityEmpty">
                                <asp:Literal ID="Literal10" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_City %>"></asp:Literal></span>
                                 <span style="display: none" id="ageEmpty">
                                <asp:Literal ID="Literal11" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_Age %>"></asp:Literal></span>
                                
                            <span style="display: none" id="emailEmpty">
                                <asp:Literal ID="Literal26" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_Email %>"></asp:Literal></span>
                            <span style="display: none" id="emailLong">
                                <asp:Literal ID="Literal34" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionLong_Email %>"></asp:Literal></span>
                            <span style="display: none" id="passwordEmpty">
                                <asp:Literal ID="Literal24" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_Password %>"></asp:Literal></span>
                            <span style="display: none" id="confirmPasswordEmpty">
                                <asp:Literal ID="Literal31" runat="server" Text="<%$Resources:Global,Common_Message_FieldEmpty_ConfirmPassword %>"></asp:Literal></span>
                            <span style="display: none" id="passwordShort">
                                <asp:Literal ID="Literal6" runat="server" Text="<%$Resources:Global,Common_Message_LengthShort_Password%>"></asp:Literal></span>
                            <span style="display: none" id="passwordNotMatch">
                                <asp:Literal ID="Literal25" runat="server" Text="<%$Resources:Global,Common_Message_Compare_Password%>"></asp:Literal></span>
                            <span style="display: none" id="emailError">
                                <asp:Literal ID="Literal27" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionError_Email %>"></asp:Literal></span>
                            <span style="display: none" id="emailExist">
                                <asp:Literal ID="Literal8" runat="server" Text="<%$Resources:Global,Common_Valid_EmailExist%>"></asp:Literal></span>
                            <span style="display: none" id="passwordError">
                                <asp:Literal ID="Literal28" runat="server" Text="<%$Resources:Global,Common_Message_ExpressionError_Password%>"></asp:Literal></span>
                        
                            <span style="display: none" id="success">
                                <asp:Literal ID="Literal14" runat="server" Text="<%$Resources:Global,Common_Message_Success%>"></asp:Literal></span>
                        
                        
                        
                        </div>
                    </td>
                </tr>
                
                <tr>
                    <td height="24" align="right">
                        &nbsp;
                    </td>
                    <td>
         
                        <span id="btnSave" class="btn5 left" >
                            <img alt="Save" style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle"  /><img
                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_Save.png"
                                align="middle" />Save</span>
                  
                        <span id="btnCloseAccount" class="btn5 left">
                          <img alt="Close Account" style="float: left;" src="../App_Themes/DefaultTheme/images/btn_bg1a.gif" align="middle" /><img
                                style="float: left; margin-top: 2px;" src="../App_Themes/DefaultTheme/images/icon_unshare.png"
                                align="middle" />Close Account</span>
                        
                    </td>
                </tr>
            </table>
        </div>
        
    </div>
</asp:Content>
