using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:fundbankaccounttransaction
	/// </summary>
	public partial class fundbankaccounttransaction
	{
		public fundbankaccounttransaction()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "fundbankaccounttransaction"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fundbankaccounttransaction");
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
		public void Add(eChartProject.Model.eChart.fundbankaccounttransaction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fundbankaccounttransaction(");
			strSql.Append("FundID,FundBankAccountID,FinancialYear,TransDate,Narration,Debit,Credit,Balance,ClientDescription,Note1,Note2)");
			strSql.Append(" values (");
			strSql.Append("@FundID,@FundBankAccountID,@FinancialYear,@TransDate,@Narration,@Debit,@Credit,@Balance,@ClientDescription,@Note1,@Note2)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundBankAccountID", MySqlDbType.Int32,11),
					new MySqlParameter("@FinancialYear", MySqlDbType.Int32,11),
					new MySqlParameter("@TransDate", MySqlDbType.DateTime),
					new MySqlParameter("@Narration", MySqlDbType.VarChar,200),
					new MySqlParameter("@Debit", MySqlDbType.Double),
					new MySqlParameter("@Credit", MySqlDbType.Double),
					new MySqlParameter("@Balance", MySqlDbType.Double),
					new MySqlParameter("@ClientDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("@Note1", MySqlDbType.VarChar,1000),
					new MySqlParameter("@Note2", MySqlDbType.VarChar,1000)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.FundBankAccountID;
			parameters[2].Value = model.FinancialYear;
			parameters[3].Value = model.TransDate;
			parameters[4].Value = model.Narration;
			parameters[5].Value = model.Debit;
			parameters[6].Value = model.Credit;
			parameters[7].Value = model.Balance;
			parameters[8].Value = model.ClientDescription;
			parameters[9].Value = model.Note1;
			parameters[10].Value = model.Note2;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fundbankaccounttransaction model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fundbankaccounttransaction set ");
			strSql.Append("FundID=@FundID,");
			strSql.Append("FundBankAccountID=@FundBankAccountID,");
			strSql.Append("FinancialYear=@FinancialYear,");
			strSql.Append("TransDate=@TransDate,");
			strSql.Append("Narration=@Narration,");
			strSql.Append("Debit=@Debit,");
			strSql.Append("Credit=@Credit,");
			strSql.Append("Balance=@Balance,");
			strSql.Append("ClientDescription=@ClientDescription,");
			strSql.Append("Note1=@Note1,");
			strSql.Append("Note2=@Note2");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundBankAccountID", MySqlDbType.Int32,11),
					new MySqlParameter("@FinancialYear", MySqlDbType.Int32,11),
					new MySqlParameter("@TransDate", MySqlDbType.DateTime),
					new MySqlParameter("@Narration", MySqlDbType.VarChar,200),
					new MySqlParameter("@Debit", MySqlDbType.Double),
					new MySqlParameter("@Credit", MySqlDbType.Double),
					new MySqlParameter("@Balance", MySqlDbType.Double),
					new MySqlParameter("@ClientDescription", MySqlDbType.VarChar,2000),
					new MySqlParameter("@Note1", MySqlDbType.VarChar,1000),
					new MySqlParameter("@Note2", MySqlDbType.VarChar,1000),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.FundBankAccountID;
			parameters[2].Value = model.FinancialYear;
			parameters[3].Value = model.TransDate;
			parameters[4].Value = model.Narration;
			parameters[5].Value = model.Debit;
			parameters[6].Value = model.Credit;
			parameters[7].Value = model.Balance;
			parameters[8].Value = model.ClientDescription;
			parameters[9].Value = model.Note1;
			parameters[10].Value = model.Note2;
			parameters[11].Value = model.ID;

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
			strSql.Append("delete from fundbankaccounttransaction ");
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
			strSql.Append("delete from fundbankaccounttransaction ");
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
		public eChartProject.Model.eChart.fundbankaccounttransaction GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FundID,FundBankAccountID,FinancialYear,TransDate,Narration,Debit,Credit,Balance,ClientDescription,Note1,Note2 from fundbankaccounttransaction ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.fundbankaccounttransaction model=new eChartProject.Model.eChart.fundbankaccounttransaction();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundID"]!=null && ds.Tables[0].Rows[0]["FundID"].ToString()!="")
				{
					model.FundID=int.Parse(ds.Tables[0].Rows[0]["FundID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundBankAccountID"]!=null && ds.Tables[0].Rows[0]["FundBankAccountID"].ToString()!="")
				{
					model.FundBankAccountID=int.Parse(ds.Tables[0].Rows[0]["FundBankAccountID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FinancialYear"]!=null && ds.Tables[0].Rows[0]["FinancialYear"].ToString()!="")
				{
					model.FinancialYear=int.Parse(ds.Tables[0].Rows[0]["FinancialYear"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TransDate"]!=null && ds.Tables[0].Rows[0]["TransDate"].ToString()!="")
				{
					model.TransDate=DateTime.Parse(ds.Tables[0].Rows[0]["TransDate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Narration"]!=null && ds.Tables[0].Rows[0]["Narration"].ToString()!="")
				{
					model.Narration=ds.Tables[0].Rows[0]["Narration"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Debit"]!=null && ds.Tables[0].Rows[0]["Debit"].ToString()!="")
				{
					//model.Debit=ds.Tables[0].Rows[0]["Debit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Credit"]!=null && ds.Tables[0].Rows[0]["Credit"].ToString()!="")
				{
					//model.Credit=ds.Tables[0].Rows[0]["Credit"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Balance"]!=null && ds.Tables[0].Rows[0]["Balance"].ToString()!="")
				{
					//model.Balance=ds.Tables[0].Rows[0]["Balance"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ClientDescription"]!=null && ds.Tables[0].Rows[0]["ClientDescription"].ToString()!="")
				{
					model.ClientDescription=ds.Tables[0].Rows[0]["ClientDescription"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note1"]!=null && ds.Tables[0].Rows[0]["Note1"].ToString()!="")
				{
					model.Note1=ds.Tables[0].Rows[0]["Note1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Note2"]!=null && ds.Tables[0].Rows[0]["Note2"].ToString()!="")
				{
					model.Note2=ds.Tables[0].Rows[0]["Note2"].ToString();
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
			strSql.Append("select ID,FundID,FundBankAccountID,FinancialYear,TransDate,Narration,Debit,Credit,Balance,ClientDescription,Note1,Note2 ");
			strSql.Append(" FROM fundbankaccounttransaction ");
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
			parameters[0].Value = "fundbankaccounttransaction";
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

