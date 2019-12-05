using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// fund
	/// </summary>
	public partial class fund
	{
		private readonly eChartProject.DAL.eChart.fund dal=new eChartProject.DAL.eChart.fund();
		public fund()
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
		public void Add(eChartProject.Model.eChart.fund model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fund model)
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
		public eChartProject.Model.eChart.fund GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public eChartProject.Model.eChart.fund GetModelByCache(int ID)
		{
			
			string CacheKey = "fundModel-" + ID;
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
			return (eChartProject.Model.eChart.fund)objModel;
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
		public List<eChartProject.Model.eChart.fund> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<eChartProject.Model.eChart.fund> DataTableToList(DataTable dt)
		{
			List<eChartProject.Model.eChart.fund> modelList = new List<eChartProject.Model.eChart.fund>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				eChartProject.Model.eChart.fund model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new eChartProject.Model.eChart.fund();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FundTFN"]!=null && dt.Rows[n]["FundTFN"].ToString()!="")
					{
					model.FundTFN=dt.Rows[n]["FundTFN"].ToString();
					}
					if(dt.Rows[n]["ABN"]!=null && dt.Rows[n]["ABN"].ToString()!="")
					{
					model.ABN=dt.Rows[n]["ABN"].ToString();
					}
					if(dt.Rows[n]["FundName"]!=null && dt.Rows[n]["FundName"].ToString()!="")
					{
					model.FundName=dt.Rows[n]["FundName"].ToString();
					}
					if(dt.Rows[n]["CurrentFinancialYear"]!=null && dt.Rows[n]["CurrentFinancialYear"].ToString()!="")
					{
						model.CurrentFinancialYear=int.Parse(dt.Rows[n]["CurrentFinancialYear"].ToString());
					}
					if(dt.Rows[n]["ChecklistStatus"]!=null && dt.Rows[n]["ChecklistStatus"].ToString()!="")
					{
					model.ChecklistStatus=dt.Rows[n]["ChecklistStatus"].ToString();
					}
					if(dt.Rows[n]["LodgementStatus"]!=null && dt.Rows[n]["LodgementStatus"].ToString()!="")
					{
					model.LodgementStatus=dt.Rows[n]["LodgementStatus"].ToString();
					}
					if(dt.Rows[n]["EmailAddress"]!=null && dt.Rows[n]["EmailAddress"].ToString()!="")
					{
					model.EmailAddress=dt.Rows[n]["EmailAddress"].ToString();
					}
					if(dt.Rows[n]["EmailSendNumber"]!=null && dt.Rows[n]["EmailSendNumber"].ToString()!="")
					{
						model.EmailSendNumber=int.Parse(dt.Rows[n]["EmailSendNumber"].ToString());
					}
					if(dt.Rows[n]["LastEmailDate"]!=null && dt.Rows[n]["LastEmailDate"].ToString()!="")
					{
						model.LastEmailDate=DateTime.Parse(dt.Rows[n]["LastEmailDate"].ToString());
					}
					if(dt.Rows[n]["UploadDate"]!=null && dt.Rows[n]["UploadDate"].ToString()!="")
					{
						model.UploadDate=DateTime.Parse(dt.Rows[n]["UploadDate"].ToString());
					}
					if(dt.Rows[n]["SubmitDate"]!=null && dt.Rows[n]["SubmitDate"].ToString()!="")
					{
						model.SubmitDate=DateTime.Parse(dt.Rows[n]["SubmitDate"].ToString());
					}
					if(dt.Rows[n]["LodgementDate"]!=null && dt.Rows[n]["LodgementDate"].ToString()!="")
					{
						model.LodgementDate=DateTime.Parse(dt.Rows[n]["LodgementDate"].ToString());
					}
					if(dt.Rows[n]["AccountantID"]!=null && dt.Rows[n]["AccountantID"].ToString()!="")
					{
						model.AccountantID=int.Parse(dt.Rows[n]["AccountantID"].ToString());
					}
					if(dt.Rows[n]["IsWIPView"]!=null && dt.Rows[n]["IsWIPView"].ToString()!="")
					{
                        model.IsWIPView = dt.Rows[n]["IsWIPView"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["AuditorID"]!=null && dt.Rows[n]["AuditorID"].ToString()!="")
					{
						model.AuditorID=int.Parse(dt.Rows[n]["AuditorID"].ToString());
					}
					if(dt.Rows[n]["ReferrerID"]!=null && dt.Rows[n]["ReferrerID"].ToString()!="")
					{
						model.ReferrerID=int.Parse(dt.Rows[n]["ReferrerID"].ToString());
					}
					if(dt.Rows[n]["EstabDate"]!=null && dt.Rows[n]["EstabDate"].ToString()!="")
					{
						model.EstabDate=DateTime.Parse(dt.Rows[n]["EstabDate"].ToString());
					}
					if(dt.Rows[n]["EnableClientAddBankAccount"]!=null && dt.Rows[n]["EnableClientAddBankAccount"].ToString()!="")
					{
                        model.EnableClientAddBankAccount = dt.Rows[n]["EnableClientAddBankAccount"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["NnfundID"]!=null && dt.Rows[n]["NnfundID"].ToString()!="")
					{
						model.NnfundID=int.Parse(dt.Rows[n]["NnfundID"].ToString());
					}
					if(dt.Rows[n]["FundStatusID"]!=null && dt.Rows[n]["FundStatusID"].ToString()!="")
					{
						model.FundStatusID=int.Parse(dt.Rows[n]["FundStatusID"].ToString());
					}
					if(dt.Rows[n]["IsFreeFirstYear"]!=null && dt.Rows[n]["IsFreeFirstYear"].ToString()!="")
					{
                        model.IsFreeFirstYear = dt.Rows[n]["IsFreeFirstYear"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["IsFreeSecondYear"]!=null && dt.Rows[n]["IsFreeSecondYear"].ToString()!="")
					{
                        model.IsFreeSecondYear = dt.Rows[n]["IsFreeSecondYear"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["IsBlacklist"]!=null && dt.Rows[n]["IsBlacklist"].ToString()!="")
					{
                        model.IsBlacklist = dt.Rows[n]["IsBlacklist"].ToString() == "TRUE" ? 1 : 0;
					}
					if(dt.Rows[n]["FundReceivedDate"]!=null && dt.Rows[n]["FundReceivedDate"].ToString()!="")
					{
						model.FundReceivedDate=DateTime.Parse(dt.Rows[n]["FundReceivedDate"].ToString());
					}
					if(dt.Rows[n]["FundApprovedDate"]!=null && dt.Rows[n]["FundApprovedDate"].ToString()!="")
					{
						model.FundApprovedDate=DateTime.Parse(dt.Rows[n]["FundApprovedDate"].ToString());
					}
					if(dt.Rows[n]["SMSFName"]!=null && dt.Rows[n]["SMSFName"].ToString()!="")
					{
					model.SMSFName=dt.Rows[n]["SMSFName"].ToString();
					}
					if(dt.Rows[n]["ExistingOrNewSMSF"]!=null && dt.Rows[n]["ExistingOrNewSMSF"].ToString()!="")
					{
						model.ExistingOrNewSMSF=int.Parse(dt.Rows[n]["ExistingOrNewSMSF"].ToString());
					}
					if(dt.Rows[n]["PostalAddress"]!=null && dt.Rows[n]["PostalAddress"].ToString()!="")
					{
					model.PostalAddress=dt.Rows[n]["PostalAddress"].ToString();
					}
					if(dt.Rows[n]["PostalSuburb"]!=null && dt.Rows[n]["PostalSuburb"].ToString()!="")
					{
					model.PostalSuburb=dt.Rows[n]["PostalSuburb"].ToString();
					}
					if(dt.Rows[n]["PostalState"]!=null && dt.Rows[n]["PostalState"].ToString()!="")
					{
					model.PostalState=dt.Rows[n]["PostalState"].ToString();
					}
					if(dt.Rows[n]["PostalPostcode"]!=null && dt.Rows[n]["PostalPostcode"].ToString()!="")
					{
					model.PostalPostcode=dt.Rows[n]["PostalPostcode"].ToString();
					}
					if(dt.Rows[n]["ResidentialAddress"]!=null && dt.Rows[n]["ResidentialAddress"].ToString()!="")
					{
					model.ResidentialAddress=dt.Rows[n]["ResidentialAddress"].ToString();
					}
					if(dt.Rows[n]["ResidentialSuburb"]!=null && dt.Rows[n]["ResidentialSuburb"].ToString()!="")
					{
					model.ResidentialSuburb=dt.Rows[n]["ResidentialSuburb"].ToString();
					}
					if(dt.Rows[n]["ResidentialState"]!=null && dt.Rows[n]["ResidentialState"].ToString()!="")
					{
					model.ResidentialState=dt.Rows[n]["ResidentialState"].ToString();
					}
					if(dt.Rows[n]["ResidentialPostcode"]!=null && dt.Rows[n]["ResidentialPostcode"].ToString()!="")
					{
					model.ResidentialPostcode=dt.Rows[n]["ResidentialPostcode"].ToString();
					}
					if(dt.Rows[n]["HomePhone"]!=null && dt.Rows[n]["HomePhone"].ToString()!="")
					{
					model.HomePhone=dt.Rows[n]["HomePhone"].ToString();
					}
					if(dt.Rows[n]["Mobile"]!=null && dt.Rows[n]["Mobile"].ToString()!="")
					{
					model.Mobile=dt.Rows[n]["Mobile"].ToString();
					}
					if(dt.Rows[n]["Fax"]!=null && dt.Rows[n]["Fax"].ToString()!="")
					{
					model.Fax=dt.Rows[n]["Fax"].ToString();
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

