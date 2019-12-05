using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// accounts_users
	/// </summary>
	public partial class accounts_users
	{
		private readonly eChartProject.DAL.eChart.accounts_users dal=new eChartProject.DAL.eChart.accounts_users();
		public accounts_users()
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
		public bool Exists(int UserID)
		{
			return dal.Exists(UserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.accounts_users model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.accounts_users model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int UserID)
		{
			
			return dal.Delete(UserID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string UserIDlist )
		{
			return dal.DeleteList(UserIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public eChartProject.Model.eChart.accounts_users GetModel(int UserID)
		{
			
			return dal.GetModel(UserID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.accounts_users GetModelByCache(int UserID)
		{
			
			string CacheKey = "accounts_usersModel-" + UserID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (eChartProject.Model.eChart.accounts_users)objModel;
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
		public List<eChartProject.Model.eChart.accounts_users> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.accounts_users> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.accounts_users> modelList = new List<eChartProject.Model.eChart.accounts_users>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.accounts_users model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.accounts_users();
					if(dt.Rows[n]["UserID"]!=null && dt.Rows[n]["UserID"].ToString()!="")
					{
						model.UserID=int.Parse(dt.Rows[n]["UserID"].ToString());
					}
					if(dt.Rows[n]["FundID"]!=null && dt.Rows[n]["FundID"].ToString()!="")
					{
						model.FundID=int.Parse(dt.Rows[n]["FundID"].ToString());
					}
					if(dt.Rows[n]["Username"]!=null && dt.Rows[n]["Username"].ToString()!="")
					{
					model.Username=dt.Rows[n]["Username"].ToString();
					}
					if(dt.Rows[n]["Password"]!=null && dt.Rows[n]["Password"].ToString()!="")
					{
					model.Password=dt.Rows[n]["Password"].ToString();
					}
					if(dt.Rows[n]["Age"]!=null && dt.Rows[n]["Age"].ToString()!="")
					{
						model.Age=int.Parse(dt.Rows[n]["Age"].ToString());
					}
					if(dt.Rows[n]["City"]!=null && dt.Rows[n]["City"].ToString()!="")
					{
					model.City=dt.Rows[n]["City"].ToString();
					}
					if(dt.Rows[n]["Country"]!=null && dt.Rows[n]["Country"].ToString()!="")
					{
					model.Country=dt.Rows[n]["Country"].ToString();
					}
					if(dt.Rows[n]["Email"]!=null && dt.Rows[n]["Email"].ToString()!="")
					{
					model.Email=dt.Rows[n]["Email"].ToString();
					}
					if(dt.Rows[n]["Gender"]!=null && dt.Rows[n]["Gender"].ToString()!="")
					{
						model.Gender=int.Parse(dt.Rows[n]["Gender"].ToString());
					}
					if(dt.Rows[n]["UserStatus"]!=null && dt.Rows[n]["UserStatus"].ToString()!="")
					{
						model.UserStatus=int.Parse(dt.Rows[n]["UserStatus"].ToString());
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

