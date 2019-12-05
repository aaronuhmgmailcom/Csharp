<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CustCalendar.ascx.cs"
    Inherits="Common_Controls_CustCalendar" %>
<script language="javascript" type="text/javascript" src="<%=Path %>Common/Script/My97DatePicker/WdatePicker.js"></script>
<script type="text/javascript">
    function ValidatorDate(obj, arg) {
        debugger;
        var maxid = obj.getAttribute('MaxDateClentID');
        var minid = obj.getAttribute('MinDateClentID');
        var canequal = obj.getAttribute('CanEqual');
        if ((maxid && maxid != '') || (minid && minid != '')) {
            var maxdate = '', mindate = '';
            if (maxid && maxid != '')
                maxdate = document.getElementById(maxid).value;
            if (minid && minid != '')
                mindate = document.getElementById(minid).value;

            var date = document.getElementById(obj.getAttribute('ValControl')).value;
            arg.IsValid = CompareDate(date, maxdate, mindate, obj.getAttribute('DateFormat'), null, canequal);
        }
        
        if (maxid)
        {
            if (maxdate != '')
            {
                var isValid = CompareDate(date, maxdate, '', obj.getAttribute('DateFormat'), null, canequal);
                if (isValid)
                {
                    var targetCtrl = document.getElementById(maxid);
                    var vals = targetCtrl.Validators;
                    if (typeof(vals) != "undefined" && vals != null)
                    {
                        for (var i = 0; i < vals.length; i++)
                        {
                            var val = vals[i];
                            var temp = val.getAttribute('MinDateClentID');
                            if (typeof(temp) == "undefined" || temp != obj.controltovalidate)
                            {
                                continue;
                            }
                            if (val.id.indexOf("ctrValComCtr") > 0)
                            {
                                val.isvalid = true;
                                ValidatorUpdateDisplay(val);
                                break;
                            }
                        }
                    }
                }
            }
        }
        
        if (minid)
        {
            if (mindate != '')
            {
                var isValid = CompareDate(date, '', mindate, obj.getAttribute('DateFormat'), null, canequal);
                if (isValid)
                {
                    var targetCtrl = document.getElementById(minid);
                    var vals = targetCtrl.Validators;
                    if (typeof(vals) != "undefined" && vals != null)
                    {
                        for (var i = 0; i < vals.length; i++)
                        {
                            var val = vals[i];
                            var temp = val.getAttribute('MaxDateClentID');
                            if (typeof(temp) == "undefined" || temp != obj.controltovalidate)
                            {
                                continue;
                            }
                            if (val.id.indexOf("ctrValComCtr") > 0)
                            {
                                val.isvalid = true;
                                ValidatorUpdateDisplay(val);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }

    function ValidatorRange(obj, arg) {
        var date = document.getElementById(obj.getAttribute('ValControl')).value;
        var maxdate = obj.getAttribute('MaxDate');
        var mindate = obj.getAttribute('MinDate');
        var defaultDate = obj.getAttribute('DefaultDate');
        if (maxdate != '' || mindate != '')
            arg.IsValid = CompareDate(date, maxdate, mindate, obj.getAttribute('DateFormat'), obj.getAttribute('SpiltFlag'), obj.getAttribute('CanEqual'), defaultDate);
    }

    function CompareDate(date, maxdate, mindate, format, splitFlag, canequal, defaultDate) {
        if (!splitFlag)
            splitFlag = '/';
        
        if (maxdate != '')
            maxdate = GetCurrentDate(maxdate, format, splitFlag);

        if (mindate != '')
            mindate = GetCurrentDate(mindate, format, splitFlag);

        var date = GetCurrentDate(date, format, splitFlag);
        var result = true;

        if (defaultDate && date == defaultDate) {
            return true;
        }

        if (maxdate != '')
            result = canequal ? (maxdate >= date) : (maxdate > date);
        if (result && mindate != '')
            result = canequal ? (mindate <= date) : (mindate < date);

        return result;
    }

    function GetCurrentDate(date, format, splitFlag) {
        var datetime = date.split(' ');
        var dateformat = format.split(splitFlag);
        var inputdate = datetime[0].split(splitFlag);
        var year;
        var month;
        var day
        for (var i = 0; i < dateformat.length; i++) {
            if (dateformat[i].indexOf('y') > -1)
                year = inputdate[i];
            else {
                if (dateformat[i].indexOf('M') > -1)
                    month = isNaN(inputdate[i]) ? inputdate[i] : inputdate[i];
                else
                    day = inputdate[i];
            }
        }
        if (!datetime[1])
            datetime[1] = '';
        //   alert(year + month + day + datetime[1]);
        return year + month + day + datetime[1];
    }

</script><wi:CustTextBox ID="txtDate" Width="80px" onfocus="WdatePicker()" runat="server"  
    MaxLength="10" CausesValidation="true" ontextchanged="txtDate_TextChanged" ></wi:CustTextBox>&nbsp;
<img id="imgCAL" onclick="WdatePicker({el:$dp.$('<%=txtDate.ClientID %>')});" src="<%=Path %>App_Themes/Default/images/calendar.gif"
    align="absmiddle">
<asp:RequiredFieldValidator ID="ctrValEmpty" runat="server" ControlToValidate="txtDate"
    Display="Dynamic" Visible="false"></asp:RequiredFieldValidator>
<asp:CustomValidator ID="ctrValComCtr" runat="server" ControlToValidate="txtDate"
    Display="Dynamic"  ClientValidationFunction="ValidatorDate" Visible="false"></asp:CustomValidator>
<asp:CustomValidator ID="ctrVarRangeValue" runat="server" ControlToValidate="txtDate"
    Display="Dynamic" ErrorMessage="" ClientValidationFunction="ValidatorRange" Visible="false"></asp:CustomValidator>
