using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eChartProject.Web.Common;
using System.Data;
using System.Web.Script.Serialization;
using eChartProject.eChartManagement.Entity;

namespace eChartProject.Web
{
    public partial class Chatting : System.Web.UI.Page
    {
        public static eChartProject.BLL.eChart.server_contents_answers bll
        {
            get { return new eChartProject.BLL.eChart.server_contents_answers(); }
        }
        private static JavaScriptSerializer JsonSerializer = new JavaScriptSerializer();
        protected void Page_Load(object sender, EventArgs e)
        {
            string question = Request.Form["question"];

            if (SessionInfo.ClientUserInfo == null)
            {
                SessionInfo.ClientUserInfo = new ClientUserInfo();
            }
            DataTable dt = new DataTable();
            if (SessionInfo.ClientUserInfo.ChattingHistory != null)
            {
                dt = SessionInfo.ClientUserInfo.ChattingHistory;
            }
            else
            {
                dt.Columns.Add("question");
                dt.Columns.Add("answer");
                dt.Columns.Add("time");
            }
            string qus = question ;
            string uri = string.Empty;
            string hisans = string.Empty;

            string ans = Robot.QUERYROBOT(Utils.ConvertInvaidCharacter(qus));
            JSONEntityAns o = JsonSerializer.Deserialize<JSONEntityAns>(ans);
            if (o.uri != null)
            {
                DataSet ds = bll.GetList(" messageID=" + int.Parse(o.uri));
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    uri = o.uri;
                    ans = "";
                    ans += "<dd  style='text-align:left;margin-top:10px;margin-left:10px;' >";
                    ans += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span>" + SessionInfo.UserInfo.UserName + ":" + ds.Tables[0].Rows[0]["Answer"].ToString() + "</span>";
                    ans += "</dd>";

                    hisans = "";
                    hisans += SessionInfo.UserInfo.UserName + ":" + ds.Tables[0].Rows[0]["Answer"].ToString() + "<br>";
                }
                else
                {
                    ans = "";
                    ans += "<dd  style='text-align:left;margin-top:10px;margin-left:10px;' >";
                    ans += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span>" + SessionInfo.UserInfo.UserName + ": " + o.answer + "</span>";
                    ans += "</dd>";

                    hisans = "";
                    hisans += SessionInfo.UserInfo.UserName + ": " + o.answer + "<br>";
                }
            }
            else
            {
                JSONEntitySuggestion su = JsonSerializer.Deserialize<JSONEntitySuggestion>(ans);
                if (su != null && su.suggestion != null && su.suggestion.Count > 0)
                {
                    ans = "";
                    ans += "<dd   style='text-align:left;margin-top:10px;margin-left:10px;' >";
                    ans += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span>" + SessionInfo.UserInfo.UserName + ": Here are some suggestions:</span>";
                    ans += "</dd>";

                    hisans = "";
                    hisans += SessionInfo.UserInfo.UserName + ": Here are some suggestions:" + "<br>";
                    foreach (JSONEntityQuestion jq in su.suggestion)
                    {
                        ans += "<dd   style='text-align:left;margin-top:10px;margin-left:10px;' >";
                        ans += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span><a href='#' id='" + jq.uri + "' onclick=\"seggestClick('" + jq.question + "')\">" + jq.question + "</a></span>";
                        ans += "</dd>";

                        hisans += jq.question + "<br>";
                    }
                }
                else
                {
                    ans = "";
                    ans += "<dd  style='text-align:left;margin-top:10px;margin-left:10px;' >";
                    ans += "<span style='height:24px; '><img src='../App_Themes/DefaultTheme/images/blank.png' align='absmiddle' style='margin-right:8px;' /></span ><span>" + SessionInfo.UserInfo.UserName + ": Feel free to ask me something at any time, or you can change the subject whenever you feel like it.</span>";
                    ans += "</dd>";

                    hisans = "";
                    hisans += SessionInfo.UserInfo.UserName + ": Feel free to ask me something at any time, or you can change the subject whenever you feel like it." + "<br>";
                }
            }

            dt.Rows.Add(qus, hisans, DateTime.Now);

            UserChat uc = new UserChat();
            UserChatSubject his = new History();
            UserChatSubject lm = new LearnMore();
            uc.changeChatDTHandler += new UserChatObserver.ChangeChatDTHandler(uc.ChangeChatHis);
            uc.changeChatDTHandler += new UserChatObserver.ChangeChatDTHandler(his.ChangeChatHis);
            uc.changeChatDTHandler += new UserChatObserver.ChangeChatDTHandler(lm.ChangeChatHis);

            uc.Chatting(dt,uri);
            Response.Write(ans);
            Response.End();
        }
    }

    /// <summary>
    /// abstract class - Observer
    /// </summary>
    abstract class UserChatObserver
    {
        protected DataTable chatDT;
        public DataTable ChatDT
        {
            get { return chatDT; }
            set { chatDT = value; }
        }
        protected string currentURI;
        public string CurrentURI
        {
            get { return currentURI; }
            set { currentURI = value; }
        }

        public delegate void ChangeChatDTHandler(UserChatObserver sender);
        public event ChangeChatDTHandler changeChatDTHandler;

        protected void changeDT()
        {
            if (changeChatDTHandler != null)
                changeChatDTHandler(this);
        }
    }
    /// <summary>
    /// interface - Subject
    /// </summary>
    interface UserChatSubject
    {
        void ChangeChatHis(UserChatObserver sender);
    }


    /// <summary>
    /// UserChat - Subjector
    /// </summary>
    class UserChat : UserChatObserver ,UserChatSubject
    {
        
        public void Chatting(DataTable dt,string uri)
        {
            base.chatDT = dt;
            base.currentURI = uri;
            changeDT();
        }
        public void ChangeChatHis(UserChatObserver sender)
        {
            base.chatDT = sender.ChatDT;
            base.currentURI = sender.CurrentURI;
        }

    }
    /// <summary>
    /// observer of Learn more
    /// </summary>
    class LearnMore :  UserChatSubject
    {
        public void ChangeChatHis(UserChatObserver sender)
        {
            SessionInfo.ClientUserInfo.CurrentURI = sender.CurrentURI;
        }
       
    }
    /// <summary>
    /// observer of History
    /// </summary>
    class History :  UserChatSubject
    {
        public void ChangeChatHis(UserChatObserver sender)
        {
            DataTable chatDTHIS = sender.ChatDT;
            SessionInfo.ClientUserInfo.ChattingHistory = chatDTHIS;
        }

    }


}
