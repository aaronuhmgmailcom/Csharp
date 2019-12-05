using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using eChartProject.Web.Common;
using System.Data;
using System.Configuration;
using eChartProject.eChartManagement.Entity;
using System.Web.Script.Serialization;

namespace eChartProject.Web.Page
{
    public partial class GetFileList : BasePage
    {
        protected static readonly string RootFolderImageUrl = "../App_Themes/DefaultTheme/images/icon_19.gif";
        protected static readonly string DefaultTarget = "_Self";
        protected static readonly string DefaultTreeFont = "Verdana";
        protected static readonly FontUnit DefaultTreeUnit = FontUnit.Parse("9");
        protected static readonly string DefaultFolderIDTheme = "folder";
        protected static readonly string FolderImageUrl = "../App_Themes/DefaultTheme/images/icon_Explore.png";
        protected static readonly string MessageImageUrl = "../App_Themes/DefaultTheme/images/msgonline.png";
        protected static readonly string DefaultMessageIDTheme = "message";
        protected static readonly string DefaultRootIDTheme = "root";
        protected static readonly string OffLineFolderImageUrl = "../App_Themes/DefaultTheme/images/icon_Explore_gray.png";
        protected static readonly string OfflineMessageImageUrl = "../App_Themes/DefaultTheme/images/msgoffline.png";
        DirectoryInfo dir;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Get All data of Folders
                eChartProject.BLL.eChart.server_contents_folders sm = new eChartProject.BLL.eChart.server_contents_folders();
                DataSet ds;
                ds = sm.GetList(" isDeleted=1 ");

                dir = new DirectoryInfo();
                dir.Folders = new List<DirectoryInfo>();
                BindTreeView(DefaultTarget, ds.Tables[0]);

                string rowsJson = string.Empty;
                rowsJson = RowHelper.GetHtmlRows(dir);
                Response.Write(rowsJson);
                Response.End();

                //Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs args = new Microsoft.Web.UI.WebControls.TreeViewSelectEventArgs("0","0");
                //TreeView1_SelectedIndexChange(TreeView1,args);
            }
        }


        //bind the tree's root
        public void BindTreeView(string TargetFrame, DataTable dt)
        {
            DataRow[] drs = dt.Select("ParentID= " + -1);//　选出所有子节点	

            //菜单状态
            string MenuExpanded = ConfigurationManager.AppSettings.Get("MenuExpanded");
            bool menuExpand = bool.Parse(MenuExpanded);

            //TreeView1.Nodes.Clear(); // 清空树
            foreach (DataRow r in drs)
            {
                DirectoryInfo di = new DirectoryInfo();
                di.FolderInfo = new FolderInfo();

                di.FolderInfo.FolderID = int.Parse(r["FolderID"].ToString());
                di.FolderInfo.FolderName = r["Foldername"].ToString();
                di.FolderInfo.ParentID = int.Parse(r["ParentID"].ToString());
                di.FolderInfo.isOffline = bool.Parse(r["isOffline"].ToString());
                di.FolderInfo.IsDeleted = bool.Parse(r["isDeleted"].ToString());

                //string imageurl = RootFolderImageUrl;

                string framename = TargetFrame;

                //Microsoft.Web.UI.WebControls.TreeNode rootnode = new Microsoft.Web.UI.WebControls.TreeNode();
                //rootnode.Text = "<input  id='itemid' type='text' value=" + DefaultRootIDTheme + nodeid + " style='display: none' />" + text;
                //rootnode.NodeData = nodeid;
                //rootnode.ID = DefaultRootIDTheme + nodeid;
                //rootnode.NavigateUrl = "Content.aspx";

                //TreeView1.Nodes.Add(rootnode);
                dir.Folders.Add(di);

                int sonparentid = di.FolderInfo.FolderID;// or =location
                CreateNode(framename, sonparentid, dt, di);

            }

        }

        //bind the tree's folder nodes
        public void CreateNode(string TargetFrame, int parentid, DataTable dt, DirectoryInfo pdi)
        {
            pdi.Folders = new List<DirectoryInfo>();
            DataRow[] drs = dt.Select("ParentID= " + parentid);//选出所有子节点		
            string MenuExpanded = ConfigurationManager.AppSettings.Get("MenuExpanded");
            bool menuExpand = bool.Parse(MenuExpanded);


            foreach (DataRow r in drs)
            {
                DirectoryInfo di = new DirectoryInfo();
                di.FolderInfo = new FolderInfo();
                di.FolderInfo.FolderID = int.Parse(r["FolderID"].ToString());
                di.FolderInfo.FolderName = r["Foldername"].ToString();
                di.FolderInfo.isOffline = bool.Parse(r["isOffline"].ToString());
                di.FolderInfo.IsDeleted = bool.Parse(r["isDeleted"].ToString());

                //string imageurl = FolderImageUrl;

                //if (r["isOffline"].ToString().ToLower() == "true")
                //{   
                //    //image of offline
                //    imageurl = OffLineFolderImageUrl;
                //}

                string framename = TargetFrame;

                //Microsoft.Web.UI.WebControls.TreeNode node = new Microsoft.Web.UI.WebControls.TreeNode();
                //node.Text = "<input  id='itemid' type='text' value=" + DefaultFolderIDTheme + nodeid + " style='display: none' />" + text;
                //node.NodeData = nodeid;
                //node.ID = DefaultFolderIDTheme + nodeid;
                ////node.NavigateUrl = "Content.aspx";
                //node.Target = DefaultFolderIDTheme;
                //node.ImageUrl = imageurl;
                //node.Expanded = menuExpand;

                //node.Expanded=true;
                int sonparentid = di.FolderInfo.FolderID;// or =location

                pdi.Folders.Add(di);
                CreateSubNode(framename, sonparentid, di);

            }//endforeach		

        }


        //bind the tree's messages
        public void CreateSubNode(string TargetFrame, int parentid, DirectoryInfo di)
        {
            di.Msgs = new List<MsgInfo>();
            //Get All data of Messages
            eChartProject.BLL.eChart.server_contents_message scm = new eChartProject.BLL.eChart.server_contents_message();
            DataSet ds;
            ds = scm.GetList("FolderID = " + parentid + " and isdeleted=1 ORDER BY SORTORDER asc");

            DataRow[] drs = ds.Tables[0].Select("FolderID= " + parentid);//选出所有子节点			
            foreach (DataRow r in drs)
            {
                MsgInfo mi = new MsgInfo();
                mi.ID = int.Parse(r["ID"].ToString());
                mi.Question = r["Question"].ToString();
                mi.IsOffline = bool.Parse(r["isOffline"].ToString());
                mi.IsDeleted = bool.Parse(r["isDeleted"].ToString());


                string imageurl = MessageImageUrl;
                //if (r["isOffline"].ToString().ToLower() == "true")
                //{
                //    //image of offline
                //    imageurl = OfflineMessageImageUrl;
                //}


                string framename = TargetFrame;

                //Microsoft.Web.UI.WebControls.TreeNode node = new Microsoft.Web.UI.WebControls.TreeNode();
                //node.Text = "<input  id='itemid' type='text' value=" + DefaultMessageIDTheme + nodeid + " style='display: none' />" + text;
                //node.NodeData = nodeid;
                //node.ID = DefaultMessageIDTheme + nodeid;
                ////node.NavigateUrl = "Content.aspx";
                //node.Target = DefaultMessageIDTheme;
                //node.ImageUrl = imageurl;


                //node.Expanded=true;
                //int sonparentid = int.Parse(mi.ID);// or =location

                di.Msgs.Add(mi);


            }//endforeach		

        }

    }
}