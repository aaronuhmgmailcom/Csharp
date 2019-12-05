<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eChartProject.Web.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>eChart</title>
    <%--    <link href="../App_Themes/DefaultTheme/css/public.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/font.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/layout.css" rel="stylesheet" type="text/css" />--%>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="App_Themes/DefaultTheme/css/public.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/css/font.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="App_Themes/DefaultTheme/css/demo.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="Common/Scripts/jquery-1.4.1.min.js"></script>

    <script type="text/javascript">
        $(function() {
            $(document).keyup(function(event) {
                if (event.keyCode == 13) {
                    btnSendClick();
                    return false;
                }
            });
        });
        function seggestClick(question) {
            $("#human").attr("value", question);
            btnSendClick();
        }
        function btnSendClick() {
            
            if ($.trim($("#human").attr("value")) == "") {
                var _195 = $("#ddhuman");
                $("#quoto").remove();
                $("<div id=\"quoto\" class=\"bubble\" >We are waiting for your questions!</div>").appendTo(_195);

                $("#quoto").fadeOut(2800, function() { });
                
                return false;
            }

            var question = $.trim($("#human").attr("value"));

            var str = "";
            str += ConvertToChatRowHTML(question);
            RefreshChatList(str);
            $("#Div1").text("is thinking");
            
            Chatting(question);

        }
        function RefreshChatList(html) {
            $("#ChatList").append(html);

        }
        function ConvertToChatRowHTML(question) {
            var html = "";
            html += "<dd  title='" + question + "'   fullname='" + question + "' style='text-align:left;margin-top:10px;margin-left:10px;' >"
            html += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span style='color:#f3961c;'>You:" + question + "</span>";
            html += "</dd>";
            return html;
        }

        function Chatting(question) {
            $.ajax({
                type: "POST",
                url: "Chatting.aspx",
                data: { "question": question
                },

                success: function(result) {

                    RefreshChatList(result);
                    $("#human").attr("value", "");
                    $("#ChatList").attr("scrollTop", $("#ChatList").attr("scrollHeight"));
                    $("#Div1").text("is waiting for you to send a message");
                    GetLearnmore();

                },
                error: function(err) {
                    window.location.href = "Default.aspx";
                }
            });
        }
        function GetLearnmore() {
            $.ajax({
                type: "POST",
                url: "GetLearnMore.aspx",
                data: {
            },

            success: function(result) {
                if (result == "FAIL") {
                }
                else {
                    $("#learnMoreDL dd").remove();
                    $("#learnMoreDL").append(result);



                }
            },
            error: function(err) {
                window.location.href = "Default.aspx";
            }
        });
        }
        function validate() {
            $("#ValidationSummary").css("display", "none");
            if ($.trim($("#txtEmail").attr("value")) == "" || $.trim($("#txtPassword").attr("value")) == "") {
                $("#ValidationSummary").css("display", "inline");
                document.getElementById("txtPassword").value = "";
                return false;
            }
            //            var emailRegExp = /\w+([-+.']?\w*)@\w+([-.]\w+)*\.\w+([-.]\w+)*/;
            //            if (!emailRegExp.test($("#txtEmail").attr("value"))) {
            //                $("#ValidationSummary").css("display", "inline");
            //                document.getElementById("txtPassword").value = "";
            //                return false;
            //            }
            var _196 = $("#Dl3");
           
            $("<div id=maskDiv class=\"datagrid-mask\" style=\"display:block\"></div>").appendTo(_196);
            $("<div id= maskmsgDiv class=\"datagrid-mask-msg\" style=\"display:block\">Processing, please wait ...</div>").appendTo(_196);

            var id = $("#txtEmail").val();
            var pass = $("#txtPassword").val();
            var persist = $("#cbRemember").attr("checked");
           
            ClientLogin(id, pass, persist);
                
            return true;
        }

        function ClientLogin(id, pass, persist) {
            $.ajax({
                type: "POST",
                url: "ClientLogin.aspx",
                data: { "id": id,
                    "pass": pass,
                    "persist": persist
                },

                success: function(result) {
                    if (result == "success") {
                      
                        $("#maskDiv").remove();
                        $("#maskmsgDiv").remove();
                        $("#ValidationSummary").css("display", "none");
                        $("#PrivateValidation").css("display", "block");
                        $("#txtPassword").disabled = true;
                        $("#txtEmail").disabled = true;
                        $("#btnLogin").css("display", "none");
                        $("#lbtnLogout").css("display", "block");
                        $("#ddRemember").css("display", "none");

                    }
                    else {
                        $("#maskDiv").remove();
                        $("#maskmsgDiv").remove();
                        $("#ValidationSummary").css("display", "inline");
                        $("#ValidationSummary").InnerText = "The account or the password is invalid.";
                        $("#txtPassword").attr("value", "");
                        $("#ddRemember").css("display", "block");
                    }
                },
                error: function(err) {
                    window.location.href = "Default.aspx";
                }
            });
        }
        function ClearClick() {
            $("#ChatList dd").remove();
          
        }
        function ReadHistory()
        {
            var height = $(document).height();
            var width = $(window).width();
            showModalDialog("ViewChat.aspx","","dialogWidth=" + width + ";dialogHeight=" + height+ ";status=no;help=no;scroll=yes");
        }
    </script>

    <style type="text/css">
        .style5
        {
            overflow: auto;
            height: 26px;
        }
        .datagrid-mask-msg
        {
	        position:absolute;
	        cursor:wait;
	        left:100px;
	        top:50px;
	        width:auto;
	        height:16px;
	        padding:12px 5px 10px 30px;
	        background:#fff url('App_Themes/DefaultTheme/images/pagination_loading.gif') no-repeat scroll 5px 10px;
	        border:2px solid #6593CF;
	        color:#222;
	        display:none;
        }
        .datagrid-mask
        {
	        position:absolute;
	        left:0;
	        top:0;
	        background:#333333;
	        opacity:0.3;
	        filter:alpha(opacity=30);
	        display:none;
        }
        a{text-decoration: underline;} 
        a:link {color: #00007f;text-decoration: underline;} 
        a:visited {color: #65038e;text-decoration: underline;} 
        a:hover{color: #ff0000;text-decoration: underline;} 
        a:active {color: #ff0000;text-decoration: underline} 

    </style>
</head>
<body style=" padding:0px;">
    <form id="form1" runat="server">
    <div id="mainbody">
        <%--<img   src="App_Themes/DefaultTheme/images/Esuperfund.jpg"   />--%>
        <div style="width: 100%; float: left" >
            <table style="margin:10px; width: 98%;" align="center" border="0" cellspacing="0" 
                cellpadding="0">
                <tr style="width: 100%;">
                    <td id="UpTD" colspan="2" class="style5">
                    </td>
                </tr>
                <tr>
                    <td height="100%" width="50%" valign="top"  style="border: 1px;">
                        <dl  id="ChatList" class="filetree"
                            style="position: relative; height:388px; width:588px; margin:5px; background-color: #F7F7F7;overflow: auto; 
                            border: 1px solid #D7D7D7; ">
                        </dl>
                           <dl  id="Dl2" 
                            style="position: relative; height:88px; width:588px; margin:5px; background-color: #F7F7F7;
                            border: 1px solid #D7D7D7; ">
                     <dd id="ddhuman" style="text-align:left;margin-top:10px;margin-bottom:10px;margin-left:5px;" >

                                <span   style=" margin-bottom:20px;margin-top:20px;">  
                              <div   runat="server" style="background-color: #F7F7F7; border:0px; display:inline;" id="TextName" ></div><div   runat="server" style="background-color: #F7F7F7; border:0px; display:inline; margin-left:4px;" id="Div1" >is waiting for you to send a message</div>
                                </span >
                                
                                 <span   style=" margin-bottom:20px;margin-top:20px;margin-left:50px;text-decoration:underline;">  
                              <a href='#' id='clear' onclick='ClearClick()'>Clear</a>
                                </span >
                                 <span   style=" margin-bottom:20px;margin-top:20px;margin-left:20px;text-decoration:underline;">  
                              <a href='#' id='ReadHistory' onclick='ReadHistory()'>Read History</a>
                                </span >
                                
                    </dd>   
                           <dd   style="text-align:left;margin-top:10px;margin-bottom:10px;margin-left:5px; " >
                           
                                <span style=" margin-bottom:20px;">  
                                 <input id="human" name="input" type="text" style="width: 85%; float: left; height: 32px;
                                                    line-height: 32px;" /> </span >
                                 <span style=" margin-bottom:20px;">  
                                          <input id="send" onclick="btnSendClick()" type="button" value="Send"
                                                style="width: 55px; height: 32px; margin-left: 6px" /> </span >
                               
                    </dd>   
                            
                            
                        </dl>
                          <dl  id="Dl4" 
                            style="position: relative; height:220px; width:588px; margin:5px; background-color: #F7F7F7;
                            border: 1px solid #D7D7D7; ">
                            
                           <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                                <span style=" color:Black; height:55px; margin-bottom:20px;margin-top:5px;margin-left:5px; vertical-align:middle; " class="text14" >  
                              Learn more...
                                </span >
                    </dd>      
                         <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                            <dl id= "learnMoreDL" runat="server"  style="position: relative; margin:5px;overflow: auto; font-size:12px;">
                            
                            
                            </dl>
    
                    </dd>      
                        </dl>
                    </td>
                  
                    <td height="100%" width="50%" style="border: 1px;" valign=top >
                         <dl  id="Dl1" 
                            style="position: relative; margin:5px; background-color: #F7F7F7;
                            border: 1px solid #D7D7D7; ">
                        <dd  style="text-align:center; " >
    <span style="height:24px; margin-bottom:20px; "><img style="margin-top:20px;" src="App_Themes/DefaultTheme/images/Esuperfund.jpg"/></span >
    </dd>   
                        <dd  style="text-align:center;" >
    <span style="height:24px; margin-bottom:20px;"><img style="margin-top:20px;" src="App_Themes/DefaultTheme/images/tech_support.png"/></span >
    </dd>        
       <dd  style="text-align:center;" >
    <span style=" margin-bottom:20px;"><input type="text" name="textfield" class="text18b"  runat="server" style="margin-top:20px;text-align:center;background-color: #F7F7F7; border:0px;"
                                id="txtName" /> </span >
    </dd>        
                  
                    <dd  style="text-align:center;" >
    <span style=" margin-bottom:20px;">  
                                <input  type="text" name="textfield" class="text14" runat="server" style="margin-top:10px;margin-bottom:122px;text-align:right;background-color: #F7F7F7; border:0px; width:15%"
                                id="txtAge" /> 
                                <input  type="text" name="textfield" class="text14" runat="server" style="text-align:right;background-color: #F7F7F7; border:0px;width:15%"
                                id="txtGender" />   
                                <input  type="text" name="textfield" class="text14" runat="server" style="text-align:center;background-color: #F7F7F7; border:0px;width:35%"
                                id="txtCity" />   
                                 <input  type="text" name="textfield" class="text14" runat="server" style="text-align:left;background-color: #F7F7F7; border:0px;width:15%"
                                id="txtCountry" />  
                                
                                
                                </span >
                    </dd> 
                    
                        
                        </dl>
                        
                         <dl  id="Dl3" 
                            style="position: relative; height:320px; margin:5px; background-color: #F7F7F7;
                            border: 1px solid #D7D7D7; ">
                     <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                                <span style="height:24px; margin-bottom:20px;margin-top:5px; "><img style="margin-top:5px;" src="App_Themes/DefaultTheme/images/login.png"/></span >
                                <span style=" color:Black; height:55px; margin-bottom:20px;margin-top:5px;margin-left:10px; vertical-align:middle; " class="text14" >  
                              Esuperfund Users:
                                </span >
                    </dd>   
                          
                           <dd  style=" text-align:left;margin-top:25px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                           
                    <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:Global,Common_Form_Username%>" /><asp:Literal
                            ID="Literal4" runat="server" Text="<%$Resources:Global,Common_Colon%>" />
               
         
                        <span class="input_bg" >
                            <input class="input_sylte1" runat="server" type="text" name="textfield" maxlength="254" 
                                id="txtEmail" /></span>
                    </dd>
                <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                       <asp:Literal ID="Literal5" runat="server" Text="<%$Resources:Global,Common_Form_Password%>" /><asp:Literal
                            ID="Literal7" runat="server" Text="<%$Resources:Global,Common_Colon%>" />
                  
                        <span class="input_bg">
                            <input class="input_sylte1" runat="server" type="password" name="textfield" maxlength="50"  
                                id="txtPassword" /></span>
                 </dd>
                   <dd id="ddRemember" runat="server" style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                        &nbsp;
                    
                        <input style="margin: 0 0 0 4px;" type="checkbox" name="checkbox" id="cbRemember"
                            runat="server" />
                        <asp:Literal ID="Literal2" runat="server" Text="<%$Resources:Global,Common_Checkbox_RememberMe%>" />
                   </dd>
                
                 <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                        
                    </dd>
               <dd  style=" text-align:left;margin-top:5px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
               
                        <span runat="server" id="ValidationSummary" style="display: none; color: #fe8300;
                            font-size: 10px;">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$Resources:Global,Common_Valid_Login%>" />
                        </span>
                         <span runat="server" id="PrivateValidation" style="display: none; color: #fe8300;
                            font-size: 10px;">
                            <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:Global,Common_Valid_Private%>" />
                        </span>
                        
                   </dd>
               <dd  style=" text-align:left;margin-top:25px;margin-bottom:10px;margin-left:7px; vertical-align:top" >
                       
                            
                            <input runat="server" class="btn_login left" id="btnLogin" name="" onclick="validate()" type="button" />
                            
                     
                    <asp:LinkButton runat="server" ID="lbtnLogout"    Font-Underline="true"
                    Text="<%$Resources:Global,Common_Button_Logout%>" onclick="lbtnLogout_Click"></asp:LinkButton>
            
                   </dd>
                            
                        </dl>
                    </td>
                
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
    <div class="mainbody_end">
    </div>
    <div id="copyright" style="width: 950px; height: 26px; line-height: 26px; margin: 0 auto;
        text-align: center; color: #fff;">
        <asp:Literal ID="Literal8" runat="server" Text="<%$Resources:Global,Common_Footer_Copyright%>" />
    </div>
    


    </form>
</body>
</html>
