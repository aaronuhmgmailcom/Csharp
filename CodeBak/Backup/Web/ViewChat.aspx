<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewChat.aspx.cs" Inherits="eChartProject.Web.ViewChat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>View Chat</title>
    <style type="text/css">

div.conversations
{
	font-family: Verdana, Geneva, sans-serif, sans-serif, "宋体";
	font-size: 12px;
}

tr.dark
{
font-family: Verdana, Geneva, sans-serif, sans-serif, "宋体";
	font-size: 12px;
	background-color:#F7F7F7;
}

tr.light
{
	font-family: Verdana, Geneva, sans-serif, sans-serif, "宋体";
	font-size: 12px;
	background-color:#FFFFFF;
}


</style>
</head>
<body>
   
   <div>
		<!-- <img src="images/logo.jpg" alt="logo" width="700" border="0"/> -->
	</div>
	<div class="conversations" id ="viewtable"  runat="server" style=" overflow:auto" >
		
	
	</div>

	<br>
	<table cellpadding="3">
	<tr>
	<td>
		<form><input type="button" value=" Print "
		onclick="window.print();return false;" /></form>
	</td>
	<td>
		<form><input type="button" value=" Close "
		onclick="window.close();return false;" /></form>
	</td>
	</tr>
	</table>

   
</body>
</html>
