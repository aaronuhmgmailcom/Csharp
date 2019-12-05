using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// fundtrustee
	/// </summary>
	public partial class fundtrustee
	{
		private readonly eChartProject.DAL.eChart.fundtrustee dal=new eChartProject.DAL.eChart.fundtrustee();
		public fundtrustee()
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
		public void Add(eChartProject.Model.eChart.fundtrustee model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fundtrustee model)
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
		public eChartProject.Model.eChart.fundtrustee GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.fundtrustee GetModelByCache(int ID)
		{
			
			string CacheKey = "fundtrusteeModel-" + ID;
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
			return (eChartProject.Model.eChart.fundtrustee)objModel;
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
		public List<eChartProject.Model.eChart.fundtrustee> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.fundtrustee> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.fundtrustee> modelList = new List<eChartProject.Model.eChart.fundtrustee>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.fundtrustee model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.fundtrustee();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FundID"]!=null && dt.Rows[n]["FundID"].ToString()!="")
					{
						model.FundID=int.Parse(dt.Rows[n]["FundID"].ToString());
					}
					if(dt.Rows[n]["FundTrusteeNo"]!=null && dt.Rows[n]["FundTrusteeNo"].ToString()!="")
					{
						model.FundTrusteeNo=int.Parse(dt.Rows[n]["FundTrusteeNo"].ToString());
					}
					if(dt.Rows[n]["Title"]!=null && dt.Rows[n]["Title"].ToString()!="")
					{
					model.Title=dt.Rows[n]["Title"].ToString();
					}
					if(dt.Rows[n]["FirstName"]!=null && dt.Rows[n]["FirstName"].ToString()!="")
					{
					model.FirstName=dt.Rows[n]["FirstName"].ToString();
					}
					if(dt.Rows[n]["MiddleName"]!=null && dt.Rows[n]["MiddleName"].ToString()!="")
					{
					model.MiddleName=dt.Rows[n]["MiddleName"].ToString();
					}
					if(dt.Rows[n]["LastName"]!=null && dt.Rows[n]["LastName"].ToString()!="")
					{
					model.LastName=dt.Rows[n]["LastName"].ToString();
					}
					if(dt.Rows[n]["TrusteeTFN"]!=null && dt.Rows[n]["TrusteeTFN"].ToString()!="")
					{
					model.TrusteeTFN=dt.Rows[n]["TrusteeTFN"].ToString();
					}
					if(dt.Rows[n]["DOB"]!=null && dt.Rows[n]["DOB"].ToString()!="")
					{
						model.DOB=DateTime.Parse(dt.Rows[n]["DOB"].ToString());
					}
					if(dt.Rows[n]["DateOfRetirement"]!=null && dt.Rows[n]["DateOfRetirement"].ToString()!="")
					{
						model.DateOfRetirement=DateTime.Parse(dt.Rows[n]["DateOfRetirement"].ToString());
					}
					if(dt.Rows[n]["IsMember"]!=null && dt.Rows[n]["IsMember"].ToString()!="")
					{
						model.IsMember=int.Parse(dt.Rows[n]["IsMember"].ToString());
					}
					if(dt.Rows[n]["JoinDate"]!=null && dt.Rows[n]["JoinDate"].ToString()!="")
					{
						model.JoinDate=DateTime.Parse(dt.Rows[n]["JoinDate"].ToString());
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

