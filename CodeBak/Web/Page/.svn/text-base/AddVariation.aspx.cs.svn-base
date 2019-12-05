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
    public partial class AddVariation : BasePage
    {
        public static eChartProject.BLL.eChart.server_contents_message bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_message(); }
        }
        public static eChartProject.BLL.eChart.server_contents_folders Fbll
        {
            get { return new eChartProject.BLL.eChart.server_contents_folders(); }
        }
        public static eChartProject.BLL.eChart.server_contents_answers abll
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string varContent = Request.Form["varContent"];
                    string selectid = Request.Form["selectid"];


                    if (selectid.Contains(Nodetype.message.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.message.ToString().Length);

                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.Question = varContent.Trim();
                        //model.FolderID = int.Parse(selectid);
                        model.isOffLine = 0;
                        model.isPublic = 1;
                        model.isVariations = 1;//设置成true
                        model.RelatedID = int.Parse(selectid);
                        //model.sortOrder = SortOrderHelper.GetSortOrder(model.FolderID);
                        model.isDeleted = 1;
                        bll.Add(model);

                        DataSet ds =abll.GetList(" messageID=" + model.RelatedID);
                        if(ds!=null & ds.Tables!=null & ds.Tables[0].Rows.Count>0)
                        {
                            //send answer to ROBORT INTERFACE
                            DataTable dt = new DataTable();
                            dt.Columns.Add("uri");
                            dt.Columns.Add("question");
                            dt.Columns.Add("answer");

                            string qus = GetQuestionAndVariations(model.RelatedID) ;

                            dt.Rows.Add(model.RelatedID, qus, HttpUtility.HtmlDecode(Utils.StrFormatD(Utils.RemoveHtml(ds.Tables[0].Rows[0]["answer"].ToString().Trim()))));
                            Robot.SAVETOROBOT(dt);

                        }


                        Response.Write("success");
                        Response.End();
                    }
                 
                }
                catch
                {

                }
            }
        }
        private string GetQuestionAndVariations(int? msgid)
        {
            //get var
            DataSet ds = bll.GetList(" RelatedID=" + msgid);
            DataSet ds2 = bll.GetList(" ID =" + msgid);
            string str = "\"";
            foreach (DataRow dr in ds2.Tables[0].Rows)
            {
                str += dr["Question"].ToString();
            }
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str += "\n" + dr["Question"].ToString();

            }
            str += "\"";
            return str;
        }




    }
}
