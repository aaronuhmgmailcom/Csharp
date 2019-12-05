using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
    /// <summary>
    /// Server_Contents_Folders
    /// </summary>
    public partial class Server_Contents_Folders
    {
        private readonly eChartProject.DAL.eChart.Server_Contents_Folders dal = new eChartProject.DAL.eChart.Server_Contents_Folders();
        public Server_Contents_Folders()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(eChartProject.Model.eChart.Server_Contents_Folders model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(eChartProject.Model.eChart.Server_Contents_Folders model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int FolderID)
        {

            return dal.Delete(FolderID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string FolderIDlist)
        {
            return dal.DeleteList(FolderIDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public eChartProject.Model.eChart.Server_Contents_Folders GetModel(int FolderID)
        {

            return dal.GetModel(FolderID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public eChartProject.Model.eChart.Server_Contents_Folders GetModelByCache(int FolderID)
        {

            string CacheKey = "Server_Contents_FoldersModel-" + FolderID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(FolderID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (eChartProject.Model.eChart.Server_Contents_Folders)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<eChartProject.Model.eChart.Server_Contents_Folders> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<eChartProject.Model.eChart.Server_Contents_Folders> DataTableToList(DataTable dt)
        {
            List<eChartProject.Model.eChart.Server_Contents_Folders> modelList = new List<eChartProject.Model.eChart.Server_Contents_Folders>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                eChartProject.Model.eChart.Server_Contents_Folders model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new eChartProject.Model.eChart.Server_Contents_Folders();
                    if (dt.Rows[n]["FolderID"] != null && dt.Rows[n]["FolderID"].ToString() != "")
                    {
                        model.FolderID = int.Parse(dt.Rows[n]["FolderID"].ToString());
                    }
                    if (dt.Rows[n]["Foldername"] != null && dt.Rows[n]["Foldername"].ToString() != "")
                    {
                        model.Foldername = dt.Rows[n]["Foldername"].ToString();
                    }
                    if (dt.Rows[n]["ParentID"] != null && dt.Rows[n]["ParentID"].ToString() != "")
                    {
                        model.ParentID = int.Parse(dt.Rows[n]["ParentID"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  Method
    }
}

