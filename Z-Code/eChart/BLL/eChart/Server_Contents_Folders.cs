using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// server_contents_folders
	/// </summary>
	public partial class server_contents_folders
	{
		private readonly eChartProject.DAL.eChart.server_contents_folders dal=new eChartProject.DAL.eChart.server_contents_folders();
		public server_contents_folders()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FolderID)
		{
			return dal.Exists(FolderID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.server_contents_folders model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_folders model)
		{
			return dal.Update(model);
		}

        /// <summary>
        /// 更新一条数据(只跟新Foldername)
        /// </summary>
        public bool UpdateByFolderName(eChartProject.Model.eChart.server_contents_folders model)
        {
            return dal.UpdateByFolderName(model);
        }
        /// <summary>
        /// 更新一条数据(只跟新ISDELETED)
        /// </summary>
        public bool UpdateByIsDelete(eChartProject.Model.eChart.server_contents_folders model)
        {
            return dal.UpdateByIsDelete(model);
        }

        /// <summary>
        /// 更新一条数据(只跟新ISoffline)
        /// </summary>
        public bool UpdateByIsOffline(eChartProject.Model.eChart.server_contents_folders model)
        {
            return dal.UpdateByIsoffline(model);
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
		public bool DeleteList(string FolderIDlist )
		{
			return dal.DeleteList(FolderIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public eChartProject.Model.eChart.server_contents_folders GetModel(int FolderID)
		{
			
			return dal.GetModel(FolderID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.server_contents_folders GetModelByCache(int FolderID)
		{
			
			string CacheKey = "server_contents_foldersModel-" + FolderID;
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
				catch{}
			}
			return (eChartProject.Model.eChart.server_contents_folders)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.server_contents_folders> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.server_contents_folders> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.server_contents_folders> modelList = new List<eChartProject.Model.eChart.server_contents_folders>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.server_contents_folders model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.server_contents_folders();
					if(dt.Rows[n]["FolderID"]!=null && dt.Rows[n]["FolderID"].ToString()!="")
					{
						model.FolderID=int.Parse(dt.Rows[n]["FolderID"].ToString());
					}
					if(dt.Rows[n]["Foldername"]!=null && dt.Rows[n]["Foldername"].ToString()!="")
					{
					model.Foldername=dt.Rows[n]["Foldername"].ToString();
					}
					if(dt.Rows[n]["ParentID"]!=null && dt.Rows[n]["ParentID"].ToString()!="")
					{
						model.ParentID=int.Parse(dt.Rows[n]["ParentID"].ToString());
					}
					if(dt.Rows[n]["isDeleted"]!=null && dt.Rows[n]["isDeleted"].ToString()!="")
					{
						model.isDeleted=int.Parse(dt.Rows[n]["isDeleted"].ToString());
					}
					if(dt.Rows[n]["isOffline"]!=null && dt.Rows[n]["isOffline"].ToString()!="")
					{
						model.isOffline=int.Parse(dt.Rows[n]["isOffline"].ToString());
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

