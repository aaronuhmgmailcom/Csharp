using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:bankaccounttype
	/// </summary>
	public partial class bankaccounttype
	{
		public bankaccounttype()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "bankaccounttype"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from bankaccounttype");
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
		public void Add(eChartProject.Model.eChart.bankaccounttype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into bankaccounttype(");
			strSql.Append("BankName,AccountTypeName,IsBankAccountTypeView)");
			strSql.Append(" values (");
			strSql.Append("@BankName,@AccountTypeName,@IsBankAccountTypeView)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BankName", MySqlDbType.VarChar,50),
					new MySqlParameter("@AccountTypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("@IsBankAccountTypeView", MySqlDbType.Int32,1)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.AccountTypeName;
			parameters[2].Value = model.IsBankAccountTypeView;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.bankaccounttype model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update bankaccounttype set ");
			strSql.Append("BankName=@BankName,");
			strSql.Append("AccountTypeName=@AccountTypeName,");
			strSql.Append("IsBankAccountTypeView=@IsBankAccountTypeView");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@BankName", MySqlDbType.VarChar,50),
					new MySqlParameter("@AccountTypeName", MySqlDbType.VarChar,50),
					new MySqlParameter("@IsBankAccountTypeView", MySqlDbType.Int32,1),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.BankName;
			parameters[1].Value = model.AccountTypeName;
			parameters[2].Value = model.IsBankAccountTypeView;
			parameters[3].Value = model.ID;

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
			strSql.Append("delete from bankaccounttype ");
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
			strSql.Append("delete from bankaccounttype ");
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
		public eChartProject.Model.eChart.bankaccounttype GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,BankName,AccountTypeName,IsBankAccountTypeView from bankaccounttype ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.bankaccounttype model=new eChartProject.Model.eChart.bankaccounttype();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["BankName"]!=null && ds.Tables[0].Rows[0]["BankName"].ToString()!="")
				{
					model.BankName=ds.Tables[0].Rows[0]["BankName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AccountTypeName"]!=null && ds.Tables[0].Rows[0]["AccountTypeName"].ToString()!="")
				{
					model.AccountTypeName=ds.Tables[0].Rows[0]["AccountTypeName"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsBankAccountTypeView"]!=null && ds.Tables[0].Rows[0]["IsBankAccountTypeView"].ToString()!="")
				{
					model.IsBankAccountTypeView=int.Parse(ds.Tables[0].Rows[0]["IsBankAccountTypeView"].ToString());
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
			strSql.Append("select ID,BankName,AccountTypeName,IsBankAccountTypeView ");
			strSql.Append(" FROM bankaccounttype ");
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
			parameters[0].Value = "bankaccounttype";
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

