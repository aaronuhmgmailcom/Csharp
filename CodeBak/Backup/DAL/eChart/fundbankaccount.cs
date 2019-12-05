using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:fundbankaccount
	/// </summary>
	public partial class fundbankaccount
	{
		public fundbankaccount()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "fundbankaccount"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from fundbankaccount");
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
		public void Add(eChartProject.Model.eChart.fundbankaccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into fundbankaccount(");
			strSql.Append("FundID,BankAccountTypeID,FundBankAccountBSB,FundBankAccountNo,IsClientAdded,IsClientView,FundBankAccountName)");
			strSql.Append(" values (");
			strSql.Append("@FundID,@BankAccountTypeID,@FundBankAccountBSB,@FundBankAccountNo,@IsClientAdded,@IsClientView,@FundBankAccountName)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@BankAccountTypeID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundBankAccountBSB", MySqlDbType.VarChar,6),
					new MySqlParameter("@FundBankAccountNo", MySqlDbType.VarChar,50),
					new MySqlParameter("@IsClientAdded", MySqlDbType.Int32,1),
					new MySqlParameter("@IsClientView", MySqlDbType.Int32,1),
					new MySqlParameter("@FundBankAccountName", MySqlDbType.VarChar,100)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.BankAccountTypeID;
			parameters[2].Value = model.FundBankAccountBSB;
			parameters[3].Value = model.FundBankAccountNo;
			parameters[4].Value = model.IsClientAdded;
			parameters[5].Value = model.IsClientView;
			parameters[6].Value = model.FundBankAccountName;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.fundbankaccount model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update fundbankaccount set ");
			strSql.Append("FundID=@FundID,");
			strSql.Append("BankAccountTypeID=@BankAccountTypeID,");
			strSql.Append("FundBankAccountBSB=@FundBankAccountBSB,");
			strSql.Append("FundBankAccountNo=@FundBankAccountNo,");
			strSql.Append("IsClientAdded=@IsClientAdded,");
			strSql.Append("IsClientView=@IsClientView,");
			strSql.Append("FundBankAccountName=@FundBankAccountName");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@BankAccountTypeID", MySqlDbType.Int32,11),
					new MySqlParameter("@FundBankAccountBSB", MySqlDbType.VarChar,6),
					new MySqlParameter("@FundBankAccountNo", MySqlDbType.VarChar,50),
					new MySqlParameter("@IsClientAdded", MySqlDbType.Int32,1),
					new MySqlParameter("@IsClientView", MySqlDbType.Int32,1),
					new MySqlParameter("@FundBankAccountName", MySqlDbType.VarChar,100),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.BankAccountTypeID;
			parameters[2].Value = model.FundBankAccountBSB;
			parameters[3].Value = model.FundBankAccountNo;
			parameters[4].Value = model.IsClientAdded;
			parameters[5].Value = model.IsClientView;
			parameters[6].Value = model.FundBankAccountName;
			parameters[7].Value = model.ID;

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
			strSql.Append("delete from fundbankaccount ");
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
			strSql.Append("delete from fundbankaccount ");
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
		public eChartProject.Model.eChart.fundbankaccount GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FundID,BankAccountTypeID,FundBankAccountBSB,FundBankAccountNo,IsClientAdded,IsClientView,FundBankAccountName from fundbankaccount ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.fundbankaccount model=new eChartProject.Model.eChart.fundbankaccount();
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
				if(ds.Tables[0].Rows[0]["BankAccountTypeID"]!=null && ds.Tables[0].Rows[0]["BankAccountTypeID"].ToString()!="")
				{
					model.BankAccountTypeID=int.Parse(ds.Tables[0].Rows[0]["BankAccountTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundBankAccountBSB"]!=null && ds.Tables[0].Rows[0]["FundBankAccountBSB"].ToString()!="")
				{
					model.FundBankAccountBSB=ds.Tables[0].Rows[0]["FundBankAccountBSB"].ToString();
				}
				if(ds.Tables[0].Rows[0]["FundBankAccountNo"]!=null && ds.Tables[0].Rows[0]["FundBankAccountNo"].ToString()!="")
				{
					model.FundBankAccountNo=ds.Tables[0].Rows[0]["FundBankAccountNo"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsClientAdded"]!=null && ds.Tables[0].Rows[0]["IsClientAdded"].ToString()!="")
				{
                    model.IsClientAdded = ds.Tables[0].Rows[0]["IsClientAdded"].ToString() == "TRUE" ? 1 : 0;
				}
				if(ds.Tables[0].Rows[0]["IsClientView"]!=null && ds.Tables[0].Rows[0]["IsClientView"].ToString()!="")
				{
                    model.IsClientView = ds.Tables[0].Rows[0]["IsClientView"].ToString() == "TRUE" ? 1 : 0;
				}
				if(ds.Tables[0].Rows[0]["FundBankAccountName"]!=null && ds.Tables[0].Rows[0]["FundBankAccountName"].ToString()!="")
				{
					model.FundBankAccountName=ds.Tables[0].Rows[0]["FundBankAccountName"].ToString();
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
			strSql.Append("select ID,FundID,BankAccountTypeID,FundBankAccountBSB,FundBankAccountNo,IsClientAdded,IsClientView,FundBankAccountName ");
			strSql.Append(" FROM fundbankaccount ");
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
			parameters[0].Value = "fundbankaccount";
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

