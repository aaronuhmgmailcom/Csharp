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
    public partial class SaveFolderMsgAnswer : BasePage
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
                    string folderMsgname = Request.Form["human"];
                    string selectid = Request.Form["selectid"];
                    string answer = Request.Form["answer"];

                    if (selectid.Contains(Nodetype.folder.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.folder.ToString().Length);

                        eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();
                        model.Foldername = folderMsgname.Trim();
                        model.FolderID = int.Parse(selectid);
                        Fbll.UpdateByFolderName(model);

                        Response.Write("success");
                        Response.End();
                    }
                    else if (selectid.Contains(Nodetype.message.ToString()))
                    {
                        selectid = selectid.Remove(0, Nodetype.message.ToString().Length);
                        //update message
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model.Question= folderMsgname.Trim();
                        model.ID = int.Parse(selectid);
                        bll.UpdateByQuestion(model);

                        //update answer
                        eChartProject.Model.eChart.server_contents_answers modelans = new eChartProject.Model.eChart.server_contents_answers();
                        DataSet ds = abll.GetList(" messageID=" + int.Parse(selectid));

                        if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            string ID = ds.Tables[0].Rows[0]["ID"].ToString();
                            modelans.ID = int.Parse(ID);
                            modelans.Answer = answer.Trim();
                            modelans.MessageID = int.Parse(selectid);
                            modelans.isDeleted = 0;

                            if (abll.Update(modelans))
                            {
                                //send answer to ROBORT INTERFACE
                                DataTable dt = new DataTable();
                                dt.Columns.Add("uri");
                                dt.Columns.Add("question");
                                dt.Columns.Add("answer");

                                string qus ="\"" +  model.Question + GetQuestionAndVariations(modelans.MessageID)+ "\"" ;

                                dt.Rows.Add(modelans.MessageID, qus, HttpUtility.HtmlDecode(Utils.StrFormatD(Utils.RemoveHtml(answer.Trim()))));
                                Robot.SAVETOROBOT(dt);

                            }
                            Response.Write("success");
                            Response.End();
                        }
                    }
                }
                catch
                {

                }
            }
        }

        private string GetQuestionAndVariations(int msgid )
        {
            //get var
            DataSet ds = bll.GetList(" RelatedID=" + msgid);
            string str = string.Empty;
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                str += "\n" + dr["Question"].ToString() ;

            }
            return str;
        }

    }
}
