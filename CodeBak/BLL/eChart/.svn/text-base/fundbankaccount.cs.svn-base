using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// fundbankaccount
	/// </summary>
	public partial class fundbankaccount
	{
		private readonly eChartProject.DAL.eChart.fundbankaccount dal=new eChartProject.DAL.eChart.fundbankaccount();
		public fundbankaccount()
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
		public void Add(eChartProject.Model.eChart.fundbankaccount model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fundbankaccount model)
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
		public eChartProject.Model.eChart.fundbankaccount GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.fundbankaccount GetModelByCache(int ID)
		{
			
			string CacheKey = "fundbankaccountModel-" + ID;
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
			return (eChartProject.Model.eChart.fundbankaccount)objModel;
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
		public List<eChartProject.Model.eChart.fundbankaccount> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.fundbankaccount> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.fundbankaccount> modelList = new List<eChartProject.Model.eChart.fundbankaccount>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.fundbankaccount model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.fundbankaccount();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FundID"]!=null && dt.Rows[n]["FundID"].ToString()!="")
					{
						model.FundID=int.Parse(dt.Rows[n]["FundID"].ToString());
					}
					if(dt.Rows[n]["BankAccountTypeID"]!=null && dt.Rows[n]["BankAccountTypeID"].ToString()!="")
					{
						model.BankAccountTypeID=int.Parse(dt.Rows[n]["BankAccountTypeID"].ToString());
					}
					if(dt.Rows[n]["FundBankAccountBSB"]!=null && dt.Rows[n]["FundBankAccountBSB"].ToString()!="")
					{
					model.FundBankAccountBSB=dt.Rows[n]["FundBankAccountBSB"].ToString();
					}
					if(dt.Rows[n]["FundBankAccountNo"]!=null && dt.Rows[n]["FundBankAccountNo"].ToString()!="")
					{
					model.FundBankAccountNo=dt.Rows[n]["FundBankAccountNo"].ToString();
					}
					if(dt.Rows[n]["IsClientAdded"]!=null && dt.Rows[n]["IsClientAdded"].ToString()!="")
					{
                        model.IsClientAdded = dt.Rows[n]["IsClientAdded"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["IsClientView"]!=null && dt.Rows[n]["IsClientView"].ToString()!="")
					{
                        model.IsClientView = dt.Rows[n]["IsClientView"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["FundBankAccountName"]!=null && dt.Rows[n]["FundBankAccountName"].ToString()!="")
					{
					model.FundBankAccountName=dt.Rows[n]["FundBankAccountName"].ToString();
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

