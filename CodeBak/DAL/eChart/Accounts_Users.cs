using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:accounts_users
	/// </summary>
	public partial class accounts_users
	{
		public accounts_users()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("UserID", "accounts_users"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from accounts_users");
			strSql.Append(" where UserID=@UserID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.Int32)
};
			parameters[0].Value = UserID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.accounts_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into accounts_users(");
			strSql.Append("FundID,Username,Password,Age,City,Country,Email,Gender,UserStatus)");
			strSql.Append(" values (");
			strSql.Append("@FundID,@Username,@Password,@Age,@City,@Country,@Email,@Gender,@UserStatus)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@Username", MySqlDbType.VarChar,50),
					new MySqlParameter("@Password", MySqlDbType.VarChar,50),
					new MySqlParameter("@Age", MySqlDbType.Int32,11),
					new MySqlParameter("@City", MySqlDbType.VarChar,50),
					new MySqlParameter("@Country", MySqlDbType.VarChar,50),
					new MySqlParameter("@Email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Gender", MySqlDbType.Int32,11),
					new MySqlParameter("@UserStatus", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.Username;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Age;
			parameters[4].Value = model.City;
			parameters[5].Value = model.Country;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Gender;
			parameters[8].Value = model.UserStatus;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.accounts_users model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update accounts_users set ");
			strSql.Append("FundID=@FundID,");
			strSql.Append("Username=@Username,");
			strSql.Append("Password=@Password,");
			strSql.Append("Age=@Age,");
			strSql.Append("City=@City,");
			strSql.Append("Country=@Country,");
			strSql.Append("Email=@Email,");
			strSql.Append("Gender=@Gender,");
			strSql.Append("UserStatus=@UserStatus");
			strSql.Append(" where UserID=@UserID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FundID", MySqlDbType.Int32,11),
					new MySqlParameter("@Username", MySqlDbType.VarChar,50),
					new MySqlParameter("@Password", MySqlDbType.VarChar,50),
					new MySqlParameter("@Age", MySqlDbType.Int32,11),
					new MySqlParameter("@City", MySqlDbType.VarChar,50),
					new MySqlParameter("@Country", MySqlDbType.VarChar,50),
					new MySqlParameter("@Email", MySqlDbType.VarChar,50),
					new MySqlParameter("@Gender", MySqlDbType.Int32,11),
					new MySqlParameter("@UserStatus", MySqlDbType.Int32,11),
					new MySqlParameter("@UserID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FundID;
			parameters[1].Value = model.Username;
			parameters[2].Value = model.Password;
			parameters[3].Value = model.Age;
			parameters[4].Value = model.City;
			parameters[5].Value = model.Country;
			parameters[6].Value = model.Email;
			parameters[7].Value = model.Gender;
			parameters[8].Value = model.UserStatus;
			parameters[9].Value = model.UserID;

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
		public bool Delete(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from accounts_users ");
			strSql.Append(" where UserID=@UserID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.Int32)
};
			parameters[0].Value = UserID;

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
		public bool DeleteList(string UserIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from accounts_users ");
			strSql.Append(" where UserID in ("+UserIDlist + ")  ");
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
		public eChartProject.Model.eChart.accounts_users GetModel(int UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID,FundID,Username,Password,Age,City,Country,Email,Gender,UserStatus from accounts_users ");
			strSql.Append(" where UserID=@UserID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@UserID", MySqlDbType.Int32)
};
			parameters[0].Value = UserID;

			eChartProject.Model.eChart.accounts_users model=new eChartProject.Model.eChart.accounts_users();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserID"]!=null && ds.Tables[0].Rows[0]["UserID"].ToString()!="")
				{
					model.UserID=int.Parse(ds.Tables[0].Rows[0]["UserID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FundID"]!=null && ds.Tables[0].Rows[0]["FundID"].ToString()!="")
				{
					model.FundID=int.Parse(ds.Tables[0].Rows[0]["FundID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Username"]!=null && ds.Tables[0].Rows[0]["Username"].ToString()!="")
				{
					model.Username=ds.Tables[0].Rows[0]["Username"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Password"]!=null && ds.Tables[0].Rows[0]["Password"].ToString()!="")
				{
					model.Password=ds.Tables[0].Rows[0]["Password"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Age"]!=null && ds.Tables[0].Rows[0]["Age"].ToString()!="")
				{
					model.Age=int.Parse(ds.Tables[0].Rows[0]["Age"].ToString());
				}
				if(ds.Tables[0].Rows[0]["City"]!=null && ds.Tables[0].Rows[0]["City"].ToString()!="")
				{
					model.City=ds.Tables[0].Rows[0]["City"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Country"]!=null && ds.Tables[0].Rows[0]["Country"].ToString()!="")
				{
					model.Country=ds.Tables[0].Rows[0]["Country"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email"]!=null && ds.Tables[0].Rows[0]["Email"].ToString()!="")
				{
					model.Email=ds.Tables[0].Rows[0]["Email"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Gender"]!=null && ds.Tables[0].Rows[0]["Gender"].ToString()!="")
				{
					model.Gender=int.Parse(ds.Tables[0].Rows[0]["Gender"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserStatus"]!=null && ds.Tables[0].Rows[0]["UserStatus"].ToString()!="")
				{
					model.UserStatus=int.Parse(ds.Tables[0].Rows[0]["UserStatus"].ToString());
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
			strSql.Append("select UserID,FundID,Username,Password,Age,City,Country,Email,Gender,UserStatus ");
			strSql.Append(" FROM accounts_users ");
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
			parameters[0].Value = "accounts_users";
			parameters[1].Value = "UserID";
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

