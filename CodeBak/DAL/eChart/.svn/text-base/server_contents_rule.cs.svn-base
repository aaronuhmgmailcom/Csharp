using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:server_contents_rule
	/// </summary>
	public partial class server_contents_rule
	{
		public server_contents_rule()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "server_contents_rule"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from server_contents_rule");
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
		public void Add(eChartProject.Model.eChart.server_contents_rule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into server_contents_rule(");
			strSql.Append("MessageID,Rule1,Rule2,Rule3,Rule4,Rule5,Rule6)");
			strSql.Append(" values (");
			strSql.Append("@MessageID,@Rule1,@Rule2,@Rule3,@Rule4,@Rule5,@Rule6)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Rule1", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule2", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule3", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule4", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule5", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule6", MySqlDbType.VarChar,4000)};
			parameters[0].Value = model.MessageID;
			parameters[1].Value = model.Rule1;
			parameters[2].Value = model.Rule2;
			parameters[3].Value = model.Rule3;
			parameters[4].Value = model.Rule4;
			parameters[5].Value = model.Rule5;
			parameters[6].Value = model.Rule6;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_rule model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update server_contents_rule set ");
			strSql.Append("MessageID=@MessageID,");
			strSql.Append("Rule1=@Rule1,");
			strSql.Append("Rule2=@Rule2,");
			strSql.Append("Rule3=@Rule3,");
			strSql.Append("Rule4=@Rule4,");
			strSql.Append("Rule5=@Rule5,");
			strSql.Append("Rule6=@Rule6");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Rule1", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule2", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule3", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule4", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule5", MySqlDbType.VarChar,4000),
					new MySqlParameter("@Rule6", MySqlDbType.VarChar,4000),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.MessageID;
			parameters[1].Value = model.Rule1;
			parameters[2].Value = model.Rule2;
			parameters[3].Value = model.Rule3;
			parameters[4].Value = model.Rule4;
			parameters[5].Value = model.Rule5;
			parameters[6].Value = model.Rule6;
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
			strSql.Append("delete from server_contents_rule ");
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
			strSql.Append("delete from server_contents_rule ");
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
		public eChartProject.Model.eChart.server_contents_rule GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MessageID,Rule1,Rule2,Rule3,Rule4,Rule5,Rule6 from server_contents_rule ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.server_contents_rule model=new eChartProject.Model.eChart.server_contents_rule();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MessageID"]!=null && ds.Tables[0].Rows[0]["MessageID"].ToString()!="")
				{
					model.MessageID=int.Parse(ds.Tables[0].Rows[0]["MessageID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Rule1"]!=null && ds.Tables[0].Rows[0]["Rule1"].ToString()!="")
				{
					model.Rule1=ds.Tables[0].Rows[0]["Rule1"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rule2"]!=null && ds.Tables[0].Rows[0]["Rule2"].ToString()!="")
				{
					model.Rule2=ds.Tables[0].Rows[0]["Rule2"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rule3"]!=null && ds.Tables[0].Rows[0]["Rule3"].ToString()!="")
				{
					model.Rule3=ds.Tables[0].Rows[0]["Rule3"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rule4"]!=null && ds.Tables[0].Rows[0]["Rule4"].ToString()!="")
				{
					model.Rule4=ds.Tables[0].Rows[0]["Rule4"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rule5"]!=null && ds.Tables[0].Rows[0]["Rule5"].ToString()!="")
				{
					model.Rule5=ds.Tables[0].Rows[0]["Rule5"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Rule6"]!=null && ds.Tables[0].Rows[0]["Rule6"].ToString()!="")
				{
					model.Rule6=ds.Tables[0].Rows[0]["Rule6"].ToString();
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
			strSql.Append("select ID,MessageID,Rule1,Rule2,Rule3,Rule4,Rule5,Rule6 ");
			strSql.Append(" FROM server_contents_rule ");
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
			parameters[0].Value = "server_contents_rule";
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

