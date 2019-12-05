using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:fund
	/// </summary>
	public partial class fund
	{
		public fund()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "fund"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fund");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.fund model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fund(");
			strSql.Append("FundTFN,ABN,FundName,CurrentFinancialYear,ChecklistStatus,LodgementStatus,EmailAddress,EmailSendNumber,LastEmailDate,UploadDate,SubmitDate,LodgementDate,AccountantID,IsWIPView,AuditorID,ReferrerID,EstabDate,EnableClientAddBankAccount,NnfundID,FundStatusID,IsFreeFirstYear,IsFreeSecondYear,IsBlacklist,FundReceivedDate,FundApprovedDate,SMSFName,ExistingOrNewSMSF,PostalAddress,PostalSuburb,PostalState,PostalPostcode,ResidentialAddress,ResidentialSuburb,ResidentialState,ResidentialPostcode,HomePhone,Mobile,Fax)");
			strSql.Append(" values (");
			strSql.Append("@FundTFN,@ABN,@FundName,@CurrentFinancialYear,@ChecklistStatus,@LodgementStatus,@EmailAddress,@EmailSendNumber,@LastEmailDate,@UploadDate,@SubmitDate,@LodgementDate,@AccountantID,@IsWIPView,@AuditorID,@ReferrerID,@EstabDate,@EnableClientAddBankAccount,@NnfundID,@FundStatusID,@IsFreeFirstYear,@IsFreeSecondYear,@IsBlacklist,@FundReceivedDate,@FundApprovedDate,@SMSFName,@ExistingOrNewSMSF,@PostalAddress,@PostalSuburb,@PostalState,@PostalPostcode,@ResidentialAddress,@ResidentialSuburb,@ResidentialState,@ResidentialPostcode,@HomePhone,@Mobile,@Fax)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundTFN", MySqlDbType.VarChar,20),
					new MySqlParameter("@ABN", MySqlDbType.VarChar,20),
					new MySqlParameter("@FundName", MySqlDbType.VarChar,200),
					new MySqlParameter("@CurrentFinancialYear", MySqlDbType.Int32,11),
					new MySqlParameter("@ChecklistStatus", MySqlDbType.VarChar,20),
					new MySqlParameter("@LodgementStatus", MySqlDbType.VarChar,20),
					new MySqlParameter("@EmailAddress", MySqlDbType.VarChar,100),
					new MySqlParameter("@EmailSendNumber", MySqlDbType.Int32,11),
					new MySqlParameter("@LastEmailDate", MySqlDbType.DateTime),
					new MySqlParameter("@UploadDate", MySqlDbType.DateTime),
					new MySqlParameter("@SubmitDate", MySqlDbType.DateTime),
					new MySqlParameter("@LodgementDate", MySqlDbType.DateTime),
					new MySqlParameter("@AccountantID", MySqlDbType.Int32,11),
					new MySqlParameter("@IsWIPView", MySqlDbType.Int32,1),
					new MySqlParameter("@AuditorID", MySqlDbType.Int32,11),
					new MySqlParameter("@ReferrerID", MySqlDbType.Int32,11),
					new MySqlParameter("@EstabDate", MySqlDbType.DateTime),
					new MySqlParameter("@EnableClientAddBankAccount", MySqlDbType.Int32,1),
					new MySqlParameter("@NnfundID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundStatusID", MySqlDbType.Int32,11),
					new MySqlParameter("@IsFreeFirstYear", MySqlDbType.Int32,11),
					new MySqlParameter("@IsFreeSecondYear", MySqlDbType.Int32,11),
					new MySqlParameter("@IsBlacklist", MySqlDbType.Int32,11),
					new MySqlParameter("@FundReceivedDate", MySqlDbType.DateTime),
					new MySqlParameter("@FundApprovedDate", MySqlDbType.DateTime),
					new MySqlParameter("@SMSFName", MySqlDbType.VarChar,500),
					new MySqlParameter("@ExistingOrNewSMSF", MySqlDbType.Int32,11),
					new MySqlParameter("@PostalAddress", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalSuburb", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalState", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalPostcode", MySqlDbType.VarChar,100),
					new MySqlParameter("@ResidentialAddress", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialSuburb", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialState", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialPostcode", MySqlDbType.VarChar,100),
					new MySqlParameter("@HomePhone", MySqlDbType.VarChar,100),
					new MySqlParameter("@Mobile", MySqlDbType.VarChar,100),
					new MySqlParameter("@Fax", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.FundTFN;
			parameters[1].Value = model.ABN;
			parameters[2].Value = model.FundName;
			parameters[3].Value = model.CurrentFinancialYear;
			parameters[4].Value = model.ChecklistStatus;
			parameters[5].Value = model.LodgementStatus;
			parameters[6].Value = model.EmailAddress;
			parameters[7].Value = model.EmailSendNumber;
			parameters[8].Value = model.LastEmailDate;
			parameters[9].Value = model.UploadDate;
			parameters[10].Value = model.SubmitDate;
			parameters[11].Value = model.LodgementDate;
			parameters[12].Value = model.AccountantID;
			parameters[13].Value = model.IsWIPView;
			parameters[14].Value = model.AuditorID;
			parameters[15].Value = model.ReferrerID;
			parameters[16].Value = model.EstabDate;
			parameters[17].Value = model.EnableClientAddBankAccount;
			parameters[18].Value = model.NnfundID;
			parameters[19].Value = model.FundStatusID;
			parameters[20].Value = model.IsFreeFirstYear;
			parameters[21].Value = model.IsFreeSecondYear;
			parameters[22].Value = model.IsBlacklist;
			parameters[23].Value = model.FundReceivedDate;
			parameters[24].Value = model.FundApprovedDate;
			parameters[25].Value = model.SMSFName;
			parameters[26].Value = model.ExistingOrNewSMSF;
			parameters[27].Value = model.PostalAddress;
			parameters[28].Value = model.PostalSuburb;
			parameters[29].Value = model.PostalState;
			parameters[30].Value = model.PostalPostcode;
			parameters[31].Value = model.ResidentialAddress;
			parameters[32].Value = model.ResidentialSuburb;
			parameters[33].Value = model.ResidentialState;
			parameters[34].Value = model.ResidentialPostcode;
			parameters[35].Value = model.HomePhone;
			parameters[36].Value = model.Mobile;
			parameters[37].Value = model.Fax;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fund model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fund set ");
			strSql.Append("FundTFN=@FundTFN,");
			strSql.Append("ABN=@ABN,");
			strSql.Append("FundName=@FundName,");
			strSql.Append("CurrentFinancialYear=@CurrentFinancialYear,");
			strSql.Append("ChecklistStatus=@ChecklistStatus,");
			strSql.Append("LodgementStatus=@LodgementStatus,");
			strSql.Append("EmailAddress=@EmailAddress,");
			strSql.Append("EmailSendNumber=@EmailSendNumber,");
			strSql.Append("LastEmailDate=@LastEmailDate,");
			strSql.Append("UploadDate=@UploadDate,");
			strSql.Append("SubmitDate=@SubmitDate,");
			strSql.Append("LodgementDate=@LodgementDate,");
			strSql.Append("AccountantID=@AccountantID,");
			strSql.Append("IsWIPView=@IsWIPView,");
			strSql.Append("AuditorID=@AuditorID,");
			strSql.Append("ReferrerID=@ReferrerID,");
			strSql.Append("EstabDate=@EstabDate,");
			strSql.Append("EnableClientAddBankAccount=@EnableClientAddBankAccount,");
			strSql.Append("NnfundID=@NnfundID,");
			strSql.Append("FundStatusID=@FundStatusID,");
			strSql.Append("IsFreeFirstYear=@IsFreeFirstYear,");
			strSql.Append("IsFreeSecondYear=@IsFreeSecondYear,");
			strSql.Append("IsBlacklist=@IsBlacklist,");
			strSql.Append("FundReceivedDate=@FundReceivedDate,");
			strSql.Append("FundApprovedDate=@FundApprovedDate,");
			strSql.Append("SMSFName=@SMSFName,");
			strSql.Append("ExistingOrNewSMSF=@ExistingOrNewSMSF,");
			strSql.Append("PostalAddress=@PostalAddress,");
			strSql.Append("PostalSuburb=@PostalSuburb,");
			strSql.Append("PostalState=@PostalState,");
			strSql.Append("PostalPostcode=@PostalPostcode,");
			strSql.Append("ResidentialAddress=@ResidentialAddress,");
			strSql.Append("ResidentialSuburb=@ResidentialSuburb,");
			strSql.Append("ResidentialState=@ResidentialState,");
			strSql.Append("ResidentialPostcode=@ResidentialPostcode,");
			strSql.Append("HomePhone=@HomePhone,");
			strSql.Append("Mobile=@Mobile,");
			strSql.Append("Fax=@Fax");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundTFN", MySqlDbType.VarChar,20),
					new MySqlParameter("@ABN", MySqlDbType.VarChar,20),
					new MySqlParameter("@FundName", MySqlDbType.VarChar,200),
					new MySqlParameter("@CurrentFinancialYear", MySqlDbType.Int32,11),
					new MySqlParameter("@ChecklistStatus", MySqlDbType.VarChar,20),
					new MySqlParameter("@LodgementStatus", MySqlDbType.VarChar,20),
					new MySqlParameter("@EmailAddress", MySqlDbType.VarChar,100),
					new MySqlParameter("@EmailSendNumber", MySqlDbType.Int32,11),
					new MySqlParameter("@LastEmailDate", MySqlDbType.DateTime),
					new MySqlParameter("@UploadDate", MySqlDbType.DateTime),
					new MySqlParameter("@SubmitDate", MySqlDbType.DateTime),
					new MySqlParameter("@LodgementDate", MySqlDbType.DateTime),
					new MySqlParameter("@AccountantID", MySqlDbType.Int32,11),
					new MySqlParameter("@IsWIPView", MySqlDbType.Int32,1),
					new MySqlParameter("@AuditorID", MySqlDbType.Int32,11),
					new MySqlParameter("@ReferrerID", MySqlDbType.Int32,11),
					new MySqlParameter("@EstabDate", MySqlDbType.DateTime),
					new MySqlParameter("@EnableClientAddBankAccount", MySqlDbType.Int32,1),
					new MySqlParameter("@NnfundID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundStatusID", MySqlDbType.Int32,11),
					new MySqlParameter("@IsFreeFirstYear", MySqlDbType.Int32,11),
					new MySqlParameter("@IsFreeSecondYear", MySqlDbType.Int32,11),
					new MySqlParameter("@IsBlacklist", MySqlDbType.Int32,11),
					new MySqlParameter("@FundReceivedDate", MySqlDbType.DateTime),
					new MySqlParameter("@FundApprovedDate", MySqlDbType.DateTime),
					new MySqlParameter("@SMSFName", MySqlDbType.VarChar,500),
					new MySqlParameter("@ExistingOrNewSMSF", MySqlDbType.Int32,11),
					new MySqlParameter("@PostalAddress", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalSuburb", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalState", MySqlDbType.VarChar,500),
					new MySqlParameter("@PostalPostcode", MySqlDbType.VarChar,100),
					new MySqlParameter("@ResidentialAddress", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialSuburb", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialState", MySqlDbType.VarChar,500),
					new MySqlParameter("@ResidentialPostcode", MySqlDbType.VarChar,100),
					new MySqlParameter("@HomePhone", MySqlDbType.VarChar,100),
					new MySqlParameter("@Mobile", MySqlDbType.VarChar,100),
					new MySqlParameter("@Fax", MySqlDbType.VarChar,100),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FundTFN;
			parameters[1].Value = model.ABN;
			parameters[2].Value = model.FundName;
			parameters[3].Value = model.CurrentFinancialYear;
			parameters[4].Value = model.ChecklistStatus;
			parameters[5].Value = model.LodgementStatus;
			parameters[6].Value = model.EmailAddress;
			parameters[7].Value = model.EmailSendNumber;
			parameters[8].Value = model.LastEmailDate;
			parameters[9].Value = model.UploadDate;
			parameters[10].Value = model.SubmitDate;
			parameters[11].Value = model.LodgementDate;
			parameters[12].Value = model.AccountantID;
			parameters[13].Value = model.IsWIPView;
			parameters[14].Value = model.AuditorID;
			parameters[15].Value = model.ReferrerID;
			parameters[16].Value = model.EstabDate;
			parameters[17].Value = model.EnableClientAddBankAccount;
			parameters[18].Value = model.NnfundID;
			parameters[19].Value = model.FundStatusID;
			parameters[20].Value = model.IsFreeFirstYear;
			parameters[21].Value = model.IsFreeSecondYear;
			parameters[22].Value = model.IsBlacklist;
			parameters[23].Value = model.FundReceivedDate;
			parameters[24].Value = model.FundApprovedDate;
			parameters[25].Value = model.SMSFName;
			parameters[26].Value = model.ExistingOrNewSMSF;
			parameters[27].Value = model.PostalAddress;
			parameters[28].Value = model.PostalSuburb;
			parameters[29].Value = model.PostalState;
			parameters[30].Value = model.PostalPostcode;
			parameters[31].Value = model.ResidentialAddress;
			parameters[32].Value = model.ResidentialSuburb;
			parameters[33].Value = model.ResidentialState;
			parameters[34].Value = model.ResidentialPostcode;
			parameters[35].Value = model.HomePhone;
			parameters[36].Value = model.Mobile;
			parameters[37].Value = model.Fax;
			parameters[38].Value = model.ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fund ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from fund ");
			strSql.Append(" where ID in ("+IDlist + ")  ");
			int rows=DbHelperMySQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public eChartProject.Model.eChart.fund GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FundTFN,ABN,FundName,CurrentFinancialYear,ChecklistStatus,LodgementStatus,EmailAddress,EmailSendNumber,LastEmailDate,UploadDate,SubmitDate,LodgementDate,AccountantID,IsWIPView,AuditorID,ReferrerID,EstabDate,EnableClientAddBankAccount,NnfundID,FundStatusID,IsFreeFirstYear,IsFreeSecondYear,IsBlacklist,FundReceivedDate,FundApprovedDate,SMSFName,ExistingOrNewSMSF,PostalAddress,PostalSuburb,PostalState,PostalPostcode,ResidentialAddress,ResidentialSuburb,ResidentialState,ResidentialPostcode,HomePhone,Mobile,Fax from fund ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.fund model=new eChartProject.Model.eChart.fund();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundTFN"]!=null && ds.Tables[0].Rows[0]["FundTFN"].ToString()!="")
				{
					model.FundTFN=ds.Tables[0].Rows[0]["FundTFN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ABN"]!=null && ds.Tables[0].Rows[0]["ABN"].ToString()!="")
				{
					model.ABN=ds.Tables[0].Rows[0]["ABN"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FundName"]!=null && ds.Tables[0].Rows[0]["FundName"].ToString()!="")
				{
					model.FundName=ds.Tables[0].Rows[0]["FundName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CurrentFinancialYear"]!=null && ds.Tables[0].Rows[0]["CurrentFinancialYear"].ToString()!="")
				{
					model.CurrentFinancialYear=int.Parse(ds.Tables[0].Rows[0]["CurrentFinancialYear"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ChecklistStatus"]!=null && ds.Tables[0].Rows[0]["ChecklistStatus"].ToString()!="")
				{
					model.ChecklistStatus=ds.Tables[0].Rows[0]["ChecklistStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["LodgementStatus"]!=null && ds.Tables[0].Rows[0]["LodgementStatus"].ToString()!="")
				{
					model.LodgementStatus=ds.Tables[0].Rows[0]["LodgementStatus"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EmailAddress"]!=null && ds.Tables[0].Rows[0]["EmailAddress"].ToString()!="")
				{
					model.EmailAddress=ds.Tables[0].Rows[0]["EmailAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["EmailSendNumber"]!=null && ds.Tables[0].Rows[0]["EmailSendNumber"].ToString()!="")
				{
					model.EmailSendNumber=int.Parse(ds.Tables[0].Rows[0]["EmailSendNumber"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LastEmailDate"]!=null && ds.Tables[0].Rows[0]["LastEmailDate"].ToString()!="")
				{
					model.LastEmailDate=DateTime.Parse(ds.Tables[0].Rows[0]["LastEmailDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UploadDate"]!=null && ds.Tables[0].Rows[0]["UploadDate"].ToString()!="")
				{
					model.UploadDate=DateTime.Parse(ds.Tables[0].Rows[0]["UploadDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SubmitDate"]!=null && ds.Tables[0].Rows[0]["SubmitDate"].ToString()!="")
				{
					model.SubmitDate=DateTime.Parse(ds.Tables[0].Rows[0]["SubmitDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LodgementDate"]!=null && ds.Tables[0].Rows[0]["LodgementDate"].ToString()!="")
				{
					model.LodgementDate=DateTime.Parse(ds.Tables[0].Rows[0]["LodgementDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AccountantID"]!=null && ds.Tables[0].Rows[0]["AccountantID"].ToString()!="")
				{
					model.AccountantID=int.Parse(ds.Tables[0].Rows[0]["AccountantID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsWIPView"]!=null && ds.Tables[0].Rows[0]["IsWIPView"].ToString()!="")
				{
					model.IsWIPView=ds.Tables[0].Rows[0]["IsWIPView"].ToString()=="TRUE"?1:0;
				}
				if(ds.Tables[0].Rows[0]["AuditorID"]!=null && ds.Tables[0].Rows[0]["AuditorID"].ToString()!="")
				{
					model.AuditorID=int.Parse(ds.Tables[0].Rows[0]["AuditorID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReferrerID"]!=null && ds.Tables[0].Rows[0]["ReferrerID"].ToString()!="")
				{
					model.ReferrerID=int.Parse(ds.Tables[0].Rows[0]["ReferrerID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EstabDate"]!=null && ds.Tables[0].Rows[0]["EstabDate"].ToString()!="")
				{
					model.EstabDate=DateTime.Parse(ds.Tables[0].Rows[0]["EstabDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EnableClientAddBankAccount"]!=null && ds.Tables[0].Rows[0]["EnableClientAddBankAccount"].ToString()!="")
				{
					model.EnableClientAddBankAccount=int.Parse(ds.Tables[0].Rows[0]["EnableClientAddBankAccount"].ToString());
				}
				if(ds.Tables[0].Rows[0]["NnfundID"]!=null && ds.Tables[0].Rows[0]["NnfundID"].ToString()!="")
				{
					model.NnfundID=int.Parse(ds.Tables[0].Rows[0]["NnfundID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundStatusID"]!=null && ds.Tables[0].Rows[0]["FundStatusID"].ToString()!="")
				{
					model.FundStatusID=int.Parse(ds.Tables[0].Rows[0]["FundStatusID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsFreeFirstYear"]!=null && ds.Tables[0].Rows[0]["IsFreeFirstYear"].ToString()!="")
				{
                    model.IsFreeFirstYear = ds.Tables[0].Rows[0]["IsFreeFirstYear"].ToString() == "TRUE" ? 1 : 0;
				}
				if(ds.Tables[0].Rows[0]["IsFreeSecondYear"]!=null && ds.Tables[0].Rows[0]["IsFreeSecondYear"].ToString()!="")
				{
                    model.IsFreeSecondYear = ds.Tables[0].Rows[0]["IsFreeSecondYear"].ToString() == "TRUE" ? 1 : 0;
				}
				if(ds.Tables[0].Rows[0]["IsBlacklist"]!=null && ds.Tables[0].Rows[0]["IsBlacklist"].ToString()!="")
				{
                    model.IsBlacklist = ds.Tables[0].Rows[0]["IsBlacklist"].ToString() == "TRUE" ? 1 : 0;
				}
				if(ds.Tables[0].Rows[0]["FundReceivedDate"]!=null && ds.Tables[0].Rows[0]["FundReceivedDate"].ToString()!="")
				{
					model.FundReceivedDate=DateTime.Parse(ds.Tables[0].Rows[0]["FundReceivedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundApprovedDate"]!=null && ds.Tables[0].Rows[0]["FundApprovedDate"].ToString()!="")
				{
					model.FundApprovedDate=DateTime.Parse(ds.Tables[0].Rows[0]["FundApprovedDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SMSFName"]!=null && ds.Tables[0].Rows[0]["SMSFName"].ToString()!="")
				{
					model.SMSFName=ds.Tables[0].Rows[0]["SMSFName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ExistingOrNewSMSF"]!=null && ds.Tables[0].Rows[0]["ExistingOrNewSMSF"].ToString()!="")
				{
					model.ExistingOrNewSMSF=int.Parse(ds.Tables[0].Rows[0]["ExistingOrNewSMSF"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PostalAddress"]!=null && ds.Tables[0].Rows[0]["PostalAddress"].ToString()!="")
				{
					model.PostalAddress=ds.Tables[0].Rows[0]["PostalAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PostalSuburb"]!=null && ds.Tables[0].Rows[0]["PostalSuburb"].ToString()!="")
				{
					model.PostalSuburb=ds.Tables[0].Rows[0]["PostalSuburb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PostalState"]!=null && ds.Tables[0].Rows[0]["PostalState"].ToString()!="")
				{
					model.PostalState=ds.Tables[0].Rows[0]["PostalState"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PostalPostcode"]!=null && ds.Tables[0].Rows[0]["PostalPostcode"].ToString()!="")
				{
					model.PostalPostcode=ds.Tables[0].Rows[0]["PostalPostcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ResidentialAddress"]!=null && ds.Tables[0].Rows[0]["ResidentialAddress"].ToString()!="")
				{
					model.ResidentialAddress=ds.Tables[0].Rows[0]["ResidentialAddress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ResidentialSuburb"]!=null && ds.Tables[0].Rows[0]["ResidentialSuburb"].ToString()!="")
				{
					model.ResidentialSuburb=ds.Tables[0].Rows[0]["ResidentialSuburb"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ResidentialState"]!=null && ds.Tables[0].Rows[0]["ResidentialState"].ToString()!="")
				{
					model.ResidentialState=ds.Tables[0].Rows[0]["ResidentialState"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ResidentialPostcode"]!=null && ds.Tables[0].Rows[0]["ResidentialPostcode"].ToString()!="")
				{
					model.ResidentialPostcode=ds.Tables[0].Rows[0]["ResidentialPostcode"].ToString();
				}
				if(ds.Tables[0].Rows[0]["HomePhone"]!=null && ds.Tables[0].Rows[0]["HomePhone"].ToString()!="")
				{
					model.HomePhone=ds.Tables[0].Rows[0]["HomePhone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Mobile"]!=null && ds.Tables[0].Rows[0]["Mobile"].ToString()!="")
				{
					model.Mobile=ds.Tables[0].Rows[0]["Mobile"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Fax"]!=null && ds.Tables[0].Rows[0]["Fax"].ToString()!="")
				{
					model.Fax=ds.Tables[0].Rows[0]["Fax"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FundTFN,ABN,FundName,CurrentFinancialYear,ChecklistStatus,LodgementStatus,EmailAddress,EmailSendNumber,LastEmailDate,UploadDate,SubmitDate,LodgementDate,AccountantID,IsWIPView,AuditorID,ReferrerID,EstabDate,EnableClientAddBankAccount,NnfundID,FundStatusID,IsFreeFirstYear,IsFreeSecondYear,IsBlacklist,FundReceivedDate,FundApprovedDate,SMSFName,ExistingOrNewSMSF,PostalAddress,PostalSuburb,PostalState,PostalPostcode,ResidentialAddress,ResidentialSuburb,ResidentialState,ResidentialPostcode,HomePhone,Mobile,Fax ");
			strSql.Append(" FROM fund ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "fund";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

