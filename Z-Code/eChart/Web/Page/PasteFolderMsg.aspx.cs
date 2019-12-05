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
    public partial class PasteFolderMsg : BasePage
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
                    string fromItemID = Request.Form["fromItemID"];
                    string selectid = Request.Form["selectid"];
                    string control = Request.Form["control"];

                    if (control == EnumControl.Copy.ToString())
                    {
                        PasteFromCopy(fromItemID, selectid);
                    }
                    else if (control == EnumControl.Cut.ToString())
                    {
                        PasteFromCut(fromItemID, selectid);
                    }
                }
                catch
                {

                }
            }
        }
        /// <summary>
        /// Copy method
        /// </summary>
        /// <param name="fromItemID"></param>
        /// <param name="selectid"></param>
        private void PasteFromCopy(string fromItemID, string selectid)
        {
            if (selectid.Contains(Nodetype.folder.ToString()))
            {
                INode folder = PasteFactory.factory("folder",selectid,fromItemID);
                folder.PasteFromCopy();


                Response.Write("success");
                Response.End();
            }
            else if (selectid.Contains(Nodetype.root.ToString()))
            {
                INode root = PasteFactory.factory("root",selectid,fromItemID);
                root.PasteFromCopy();


                Response.Write("success");
                Response.End();

            }

        }
        /// <summary>
        /// Cut method
        /// </summary>
        /// <param name="fromItemID"></param>
        /// <param name="selectid"></param>
        private void PasteFromCut(string fromItemID, string selectid)
        {
            if (selectid.Contains(Nodetype.folder.ToString()))
            {
                INode folder = PasteFactory.factory("folder",selectid,fromItemID);
                folder.PasteFromCut();


                Response.Write("success");
                Response.End();
            }
            else if (selectid.Contains(Nodetype.root.ToString()))
            {
                INode root = PasteFactory.factory("root", selectid, fromItemID);
                root.PasteFromCut();

                Response.Write("success");
                Response.End();

            }

        }

        /// <summary>
        /// factory 
        /// </summary>
        public class PasteFactory
        {
            public static INode factory(string which,string selectid,string fromItemID)
            {
                if (which.Equals("folder"))
                {
                    return new Folder(selectid,fromItemID);
                }
                else if (which.Equals("root"))
                {
                    return new Root(selectid, fromItemID);
                }
                else
                {
                    throw new Exception("");
                }
            }
        }
        /// <summary>
        /// interface
        /// </summary>
        public interface INode
        {
            //PasteFromCopy
            void PasteFromCopy();
            //PasteFromCut
            void PasteFromCut();
        }
        /// <summary>
        /// Folder
        /// </summary>
        public class Folder : INode
        {
            private string ID;
            private string toID;

            public Folder(string selectid,string fromItemID)
            {
                this.ID = selectid;
                this.toID = fromItemID;
            }

            public void PasteFromCopy()
            {
                try
                {
                    if (toID.Contains(Nodetype.message.ToString()))
                    {
                        int iMsgID = int.Parse(toID.Remove(0, Nodetype.message.ToString().Length));
                        int iToFolderID = int.Parse(ID.Remove(0, Nodetype.folder.ToString().Length));
                        eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                        model = bll.GetModel(iMsgID);
                        model.FolderID = iToFolderID;
                        model.sortOrder = SortOrderHelper.GetSortOrder(iToFolderID);

                        bll.Add(model);
                        int newID = bll.GetMaxId()-1;

                        //add variation
                        DataSet ds = bll.GetList(" relatedid = " + iMsgID);
                        if(ds!=null & ds.Tables!=null & ds.Tables[0].Rows.Count>0)
                        {
                            foreach (DataRow dr in ds.Tables[0].Rows)
                            {
                                model.ID= int.Parse(dr["ID"].ToString());
                                model.RelatedID = newID;
                                model.Question = dr["Question"].ToString();
                                model.isOffLine = 0;
                                model.isPublic = 1;
                                model.isVariations = 1;//设置成true
                                model.isDeleted = 1;
                                model.FolderID = null;
                                model.sortOrder = null;
                                bll.Add(model);
                            }
                        }
                        eChartProject.Model.eChart.server_contents_answers ansmodel = new eChartProject.Model.eChart.server_contents_answers();
                        //if answer exist, update answer ,else if answer not exist,add answer
                        ds = abll.GetList(" messageid = " + iMsgID);
                        if (ds != null & ds.Tables != null & ds.Tables[0].Rows.Count > 0)
                        {
                            //insert answer with answer content
                            ansmodel.Answer = ds.Tables[0].Rows[0]["answer"].ToString();
                            ansmodel.MessageID = newID;
                            ansmodel.isDeleted = 0;
                            abll.Add(ansmodel);
                        }
                        else
                        {
                            //insert answer without content
                            ansmodel.Answer = "";
                            ansmodel.MessageID = newID;
                            ansmodel.isDeleted = 0;
                            abll.Add(ansmodel);
                        }
                    }
                }
                catch
                {
                }
            }
            public void PasteFromCut()
            {
       
                if (toID.Contains(Nodetype.message.ToString()))
                {
                    int iMsgID = int.Parse(toID.Remove(0, Nodetype.message.ToString().Length));
                    int iToFolderID = int.Parse(ID.Remove(0, Nodetype.folder.ToString().Length));
                    eChartProject.Model.eChart.server_contents_message model = new eChartProject.Model.eChart.server_contents_message();
                    model = bll.GetModel(iMsgID);
                    model.FolderID = iToFolderID;
                    model.sortOrder = SortOrderHelper.GetSortOrder(iToFolderID);

                    bll.Add(model);

                    int newID = bll.GetMaxId()-1;
                    //add variation
                    DataSet ds = bll.GetList(" relatedid = " + iMsgID);
                    if (ds != null & ds.Tables != null & ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            model.ID = int.Parse(dr["ID"].ToString());
                            model.RelatedID = newID;
                            model.Question = dr["Question"].ToString();
                            model.isOffLine = 0;
                            model.isPublic = 1;
                            model.isVariations = 1;//设置成true
                            model.isDeleted = 1;
                            model.FolderID = null;
                            model.sortOrder = null;
                            bll.Add(model);
                        }
                    }
                    eChartProject.Model.eChart.server_contents_answers ansmodel = new eChartProject.Model.eChart.server_contents_answers();
                    //if answer exist, update answer ,else if answer not exist,add answer
                    ds = abll.GetList(" messageid = " + iMsgID);
                    if (ds != null & ds.Tables != null & ds.Tables[0].Rows.Count > 0)
                    {
                        //insert answer with answer content
                        ansmodel.Answer = ds.Tables[0].Rows[0]["answer"].ToString();
                        ansmodel.MessageID = newID;
                        ansmodel.isDeleted = 0;
                        abll.Add(ansmodel);
                    }
                    else
                    {
                        //insert answer
                        ansmodel.Answer = "";
                        ansmodel.MessageID = newID;
                        ansmodel.isDeleted = 0;
                        abll.Add(ansmodel);
                    }
                    bll.Delete(iMsgID);
                }
            
            }
            public string getID()
            {
                return ID;
            }
            public void setID(string id)
            {
                this.ID = id;
            }
            public string gettoID()
            {
                return toID;
            }
            public void settoID(string id)
            {
                this.toID = id;
            }

        }

        /// <summary>
        /// Root
        /// </summary>
        public class Root : INode
        {
            private string ID;
            private string toID;
            public Root(string selectid, string fromItemID)
            {
                this.ID = selectid;
                this.toID = fromItemID;
            }

            public void PasteFromCopy()
            {
                try
                {
                    if (toID.Contains(Nodetype.folder.ToString()))
                    {
                        int iFolderID = int.Parse(toID.Remove(0, Nodetype.folder.ToString().Length));
                        int iToRootID = int.Parse(ID.Remove(0, Nodetype.root.ToString().Length));
                        eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();
                        model = Fbll.GetModel(iFolderID);
                        model.ParentID = iToRootID;

                        Fbll.Add(model);
                    }
                }
                catch
                {
                }
            }
            public void PasteFromCut()
            {
                if (toID.Contains(Nodetype.folder.ToString()))
                {
                    int iFolderID = int.Parse(toID.Remove(0, Nodetype.folder.ToString().Length));
                    int iToRootID = int.Parse(ID.Remove(0, Nodetype.root.ToString().Length));
                    eChartProject.Model.eChart.server_contents_folders model = new eChartProject.Model.eChart.server_contents_folders();
                    model = Fbll.GetModel(iFolderID);
                    model.ParentID = iToRootID;

                    Fbll.Add(model);
                    Fbll.Delete(iFolderID);
                }
            }
            public string getID()
            {
                return ID;
            }
            public void setID(string id)
            {
                this.ID = id;
            }
            public string gettoID()
            {
                return toID;
            }
            public void settoID(string id)
            {
                this.toID = id;
            }


        }
    }
}
