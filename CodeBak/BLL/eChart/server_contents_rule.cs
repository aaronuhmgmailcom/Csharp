using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// server_contents_rule
	/// </summary>
	public partial class server_contents_rule
	{
		private readonly eChartProject.DAL.eChart.server_contents_rule dal=new eChartProject.DAL.eChart.server_contents_rule();
		public server_contents_rule()
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
		public void Add(eChartProject.Model.eChart.server_contents_rule model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_rule model)
		{
			return dal.Update(model);
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
		public eChartProject.Model.eChart.server_contents_rule GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.server_contents_rule GetModelByCache(int ID)
		{
			
			string CacheKey = "server_contents_ruleModel-" + ID;
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
			return (eChartProject.Model.eChart.server_contents_rule)objModel;
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
		public List<eChartProject.Model.eChart.server_contents_rule> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.server_contents_rule> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.server_contents_rule> modelList = new List<eChartProject.Model.eChart.server_contents_rule>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.server_contents_rule model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.server_contents_rule();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["MessageID"]!=null && dt.Rows[n]["MessageID"].ToString()!="")
					{
						model.MessageID=int.Parse(dt.Rows[n]["MessageID"].ToString());
					}
					if(dt.Rows[n]["Rule1"]!=null && dt.Rows[n]["Rule1"].ToString()!="")
					{
					model.Rule1=dt.Rows[n]["Rule1"].ToString();
					}
					if(dt.Rows[n]["Rule2"]!=null && dt.Rows[n]["Rule2"].ToString()!="")
					{
					model.Rule2=dt.Rows[n]["Rule2"].ToString();
					}
					if(dt.Rows[n]["Rule3"]!=null && dt.Rows[n]["Rule3"].ToString()!="")
					{
					model.Rule3=dt.Rows[n]["Rule3"].ToString();
					}
					if(dt.Rows[n]["Rule4"]!=null && dt.Rows[n]["Rule4"].ToString()!="")
					{
					model.Rule4=dt.Rows[n]["Rule4"].ToString();
					}
					if(dt.Rows[n]["Rule5"]!=null && dt.Rows[n]["Rule5"].ToString()!="")
					{
					model.Rule5=dt.Rows[n]["Rule5"].ToString();
					}
					if(dt.Rows[n]["Rule6"]!=null && dt.Rows[n]["Rule6"].ToString()!="")
					{
					model.Rule6=dt.Rows[n]["Rule6"].ToString();
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

