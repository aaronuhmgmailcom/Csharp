using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// server_contents_message
	/// </summary>
	public partial class server_contents_message
	{
		private readonly eChartProject.DAL.eChart.server_contents_message dal=new eChartProject.DAL.eChart.server_contents_message();
		public server_contents_message()
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
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.server_contents_message model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_message model)
		{
			return dal.Update(model);
		}
        /// <summary>
        /// 更新一条数据(只更新RelatedID)
        /// </summary>
        public bool UpdateByRelatedID(eChartProject.Model.eChart.server_contents_message model)
        {
            return dal.UpdateByRelatedID(model);
        }
        /// <summary>
        /// 更新一条数据(只更新QUESTION)
        /// </summary>
        public bool UpdateByQuestion(eChartProject.Model.eChart.server_contents_message model)
        {
            return dal.UpdateByQuestion(model);
        }
        /// <summary>
        /// 更新一条数据(只更新ISDELETED)
        /// </summary>
        public bool UpdateByIsdeleted(eChartProject.Model.eChart.server_contents_message model)
        {
            return dal.UpdateByIsdeleted(model);
        }

        /// <summary>
        /// 更新一条数据(只更新ISoffline)
        /// </summary>
        public bool UpdateByIsoffline(eChartProject.Model.eChart.server_contents_message model)
        {
            return dal.UpdateByIsoffline(model);
        }
        /// <summary>
        /// 更新一条数据(只更新sortorder)
        /// </summary>
        public bool UpdateBySortOrder(eChartProject.Model.eChart.server_contents_message model)
        {
            return dal.UpdateBySortOrder(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public eChartProject.Model.eChart.server_contents_message GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.server_contents_message GetModelByCache(int ID)
		{
			
			string CacheKey = "server_contents_messageModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (eChartProject.Model.eChart.server_contents_message)objModel;
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
		public List<eChartProject.Model.eChart.server_contents_message> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.server_contents_message> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.server_contents_message> modelList = new List<eChartProject.Model.eChart.server_contents_message>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.server_contents_message model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.server_contents_message();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FolderID"]!=null && dt.Rows[n]["FolderID"].ToString()!="")
					{
						model.FolderID=int.Parse(dt.Rows[n]["FolderID"].ToString());
					}
					if(dt.Rows[n]["isOffLine"]!=null && dt.Rows[n]["isOffLine"].ToString()!="")
					{
						model.isOffLine=int.Parse(dt.Rows[n]["isOffLine"].ToString());
					}
					if(dt.Rows[n]["isPublic"]!=null && dt.Rows[n]["isPublic"].ToString()!="")
					{
						model.isPublic=int.Parse(dt.Rows[n]["isPublic"].ToString());
					}
					if(dt.Rows[n]["isVariations"]!=null && dt.Rows[n]["isVariations"].ToString()!="")
					{
						model.isVariations=int.Parse(dt.Rows[n]["isVariations"].ToString());
					}
					if(dt.Rows[n]["sortOrder"]!=null && dt.Rows[n]["sortOrder"].ToString()!="")
					{
						model.sortOrder=int.Parse(dt.Rows[n]["sortOrder"].ToString());
					}
					if(dt.Rows[n]["Question"]!=null && dt.Rows[n]["Question"].ToString()!="")
					{
					model.Question=dt.Rows[n]["Question"].ToString();
					}
					if(dt.Rows[n]["RelatedID"]!=null && dt.Rows[n]["RelatedID"].ToString()!="")
					{
						model.RelatedID=int.Parse(dt.Rows[n]["RelatedID"].ToString());
					}
					if(dt.Rows[n]["isDeleted"]!=null && dt.Rows[n]["isDeleted"].ToString()!="")
					{
						model.isDeleted=int.Parse(dt.Rows[n]["isDeleted"].ToString());
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

