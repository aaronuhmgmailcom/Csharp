using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// fundbankaccounttransaction
	/// </summary>
	public partial class fundbankaccounttransaction
	{
		private readonly eChartProject.DAL.eChart.fundbankaccounttransaction dal=new eChartProject.DAL.eChart.fundbankaccounttransaction();
		public fundbankaccounttransaction()
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
		public void Add(eChartProject.Model.eChart.fundbankaccounttransaction model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fundbankaccounttransaction model)
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
		public eChartProject.Model.eChart.fundbankaccounttransaction GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.fundbankaccounttransaction GetModelByCache(int ID)
		{
			
			string CacheKey = "fundbankaccounttransactionModel-" + ID;
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
			return (eChartProject.Model.eChart.fundbankaccounttransaction)objModel;
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
		public List<eChartProject.Model.eChart.fundbankaccounttransaction> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.fundbankaccounttransaction> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.fundbankaccounttransaction> modelList = new List<eChartProject.Model.eChart.fundbankaccounttransaction>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.fundbankaccounttransaction model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.fundbankaccounttransaction();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FundID"]!=null && dt.Rows[n]["FundID"].ToString()!="")
					{
						model.FundID=int.Parse(dt.Rows[n]["FundID"].ToString());
					}
					if(dt.Rows[n]["FundBankAccountID"]!=null && dt.Rows[n]["FundBankAccountID"].ToString()!="")
					{
						model.FundBankAccountID=int.Parse(dt.Rows[n]["FundBankAccountID"].ToString());
					}
					if(dt.Rows[n]["FinancialYear"]!=null && dt.Rows[n]["FinancialYear"].ToString()!="")
					{
						model.FinancialYear=int.Parse(dt.Rows[n]["FinancialYear"].ToString());
					}
					if(dt.Rows[n]["TransDate"]!=null && dt.Rows[n]["TransDate"].ToString()!="")
					{
						model.TransDate=DateTime.Parse(dt.Rows[n]["TransDate"].ToString());
					}
					if(dt.Rows[n]["Narration"]!=null && dt.Rows[n]["Narration"].ToString()!="")
					{
					model.Narration=dt.Rows[n]["Narration"].ToString();
					}
					if(dt.Rows[n]["Debit"]!=null && dt.Rows[n]["Debit"].ToString()!="")
					{
					//model.Debit=dt.Rows[n]["Debit"].ToString();
					}
					if(dt.Rows[n]["Credit"]!=null && dt.Rows[n]["Credit"].ToString()!="")
					{
					//model.Credit=dt.Rows[n]["Credit"].ToString();
					}
					if(dt.Rows[n]["Balance"]!=null && dt.Rows[n]["Balance"].ToString()!="")
					{
					//model.Balance=dt.Rows[n]["Balance"].ToString();
					}
					if(dt.Rows[n]["ClientDescription"]!=null && dt.Rows[n]["ClientDescription"].ToString()!="")
					{
					model.ClientDescription=dt.Rows[n]["ClientDescription"].ToString();
					}
					if(dt.Rows[n]["Note1"]!=null && dt.Rows[n]["Note1"].ToString()!="")
					{
					model.Note1=dt.Rows[n]["Note1"].ToString();
					}
					if(dt.Rows[n]["Note2"]!=null && dt.Rows[n]["Note2"].ToString()!="")
					{
					model.Note2=dt.Rows[n]["Note2"].ToString();
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

