<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="eChartProject.Web.Page.Login" %>

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
    <link href="../App_Themes/DefaultTheme/css/public.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/font.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/reset.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/layout.css" rel="stylesheet" type="text/css" />
    <link href="../App_Themes/DefaultTheme/css/demo.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Common/Scripts/jquery-1.4.1.min.js"></script>

    <script type="text/javascript">
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
            return true;
        }

       

    </script>
    <style type="text/css">
        .style1
        {
            font-family: Verdana, Geneva, sans-serif, sans-serif, "宋体";
            font-size: 14px;
            font-weight: bold;
            color: #6b6a6a;
            height: 52px;
        }
        .style2
        {
            height: 52px;
        }
        .style3
        {
            font-family: Verdana, Geneva, sans-serif, sans-serif, "宋体";
            font-size: 14px;
            font-weight: bold;
            color: #6b6a6a;
            height: 34px;
        }
        .style4
        {
            height: 34px;
        }
    </style>
</head>
<body >
    <form id="form1" runat="server">
    <div id="mainbody"  >
        
        <div class="login_bg" style="text-align: center; ">
              <table  style="margin:auto;" align="center" width="50%" border="0" cellspacing="0" cellpadding="0"  >
                 <tr> 
                    <td height="80px" colspan=2>
                        &nbsp; </td>
                </tr>
                <tr>
                    <td colspan=2 align=center ><img   src="../App_Themes/DefaultTheme/images/Esuperfund.jpg"   /></td>
                </tr>
                 <tr> 
                    <td colspan=2 height="135px">
                        &nbsp; </td>
                </tr>
                
                 <tr>
                    <td align="right" class="style3">
                       
                    </td>
                    <td style=" font-size:14px; font-weight:bold ; text-align:left" class="style4"> <asp:Literal ID="Literal3" runat="server" Text="<%$Resources:Global,Common_Form_Username%>" /><asp:Literal
                            ID="Literal4" runat="server" Text="<%$Resources:Global,Common_Colon%>" /></td>
                </tr>
                <tr>
                    <td align="right" class="text14b">
                       
                    </td>
                    <td  class="text14b">
                        <label for="textfield">
                        </label>
                        <span class="input_bg" >
                            <input class="input_sylte1" type="text" name="textfield" maxlength="254" runat="server"
                                id="txtEmail" /></span>
                    </td>
                </tr>
                 <tr>
                    <td align="left">
                       
                    </td>
                    <td align="left" style=" font-size:14px; font-weight:bold" class="style2">
                       <asp:Literal ID="Literal5" runat="server" Text="<%$Resources:Global,Common_Form_Password%>" /><asp:Literal
                            ID="Literal7" runat="server" Text="<%$Resources:Global,Common_Colon%>" />
                    </td>
                </tr>
                <tr>
                    <td align="left" class="text14b">
                       
                    </td>
                    <td align="left">
                        <span class="input_bg">
                            <input class="input_sylte1" type="password" name="textfield" maxlength="50" runat="server"
                                id="txtPassword" /></span>
                    </td>
                </tr>
                
                 <tr>
                    <td height="24">
                        &nbsp;
                    </td>
                    <td align="left">
                        <input style="margin: 0 0 0 4px;" type="checkbox" name="checkbox" id="cbRemember"
                            runat="server" />
                        <asp:Literal ID="Literal1" runat="server" Text="<%$Resources:Global,Common_Checkbox_RememberMe%>" />
                    </td>
                </tr>
                <tr>
                    <td height="24">
                        &nbsp;
                    </td>
                    <td align=left>
                        <span runat="server" id="ValidationSummary" style="display: none; color: #fe8300;
                            font-size: 10px;">
                            <asp:Literal ID="Literal6" runat="server" Text="<%$Resources:Global,Common_Valid_Login%>" />
                        </span>
                    </td>
                </tr>
                <tr>
                    <td height="44">
                        &nbsp;
                    </td>
                    <td>
                        <asp:Button runat="server" CssClass="btn_login left" ID="btnLogin" OnClick="btnLogin_Click"
                            OnClientClick="return validate()" />
                       
                    </td>
                </tr>
            </table>
        </div>
            
    
        <div class="clear">
        </div>
   
    
    
   
     </div>
     <div class="mainbody_end">
    </div>
      <div id="copyright" style="width:950px; height:26px; line-height:26px; margin:0 auto; text-align:center; color:#fff;">
        <asp:Literal ID="Literal8" runat="server" Text="<%$Resources:Global,Common_Footer_Copyright%>" />
    </div>
    
    </form>
</body>
</html>
