using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;
using eChartProject.eChartManagement.Enum;

namespace eChartProject.Web.Page
{
    public partial class GetFields : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string tablename = Request.Form["tablename"];
                    string rowsJson = string.Empty;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Name");
                    if (tablename == "Enumfund")
                    {
                        foreach (EnumFundFields c in Enum.GetValues(typeof(EnumFundFields)))
                        {
                            dt.Rows.Add(c.ToString());
                        }
                    }
                    else if (tablename == "Enumbankaccounttype")
                    {
                        foreach (EnumBankAccountTypeFields c in Enum.GetValues(typeof(EnumBankAccountTypeFields)))
                        {
                            dt.Rows.Add(c.ToString());
                        }
                    }
                    else if (tablename == "Enumfundbankaccounttransaction")
                    {
                        foreach (EnumFundBankAccountTransaction c in Enum.GetValues(typeof(EnumFundBankAccountTransaction)))
                        {
                            dt.Rows.Add(c.ToString());
                        }
                    }
                    else if (tablename == "Enumfundtrustee")
                    {
                        foreach (EnumfundtrusteeFields c in Enum.GetValues(typeof(EnumfundtrusteeFields)))
                        {
                            dt.Rows.Add(c.ToString());
                        }
                    }
                    else if (tablename == "Enumfundbankaccount")
                    {
                        foreach (EnumFundBankAccountFields c in Enum.GetValues(typeof(EnumFundBankAccountFields)))
                        {
                            dt.Rows.Add(c.ToString());
                        }
                    }
                         
                        rowsJson = FieldsRowHelper.GetHtmlRows(dt);
                        Response.Write(rowsJson);
                        Response.End();
                    
                }
                catch
                {

                }
            }
        }


    }
}
