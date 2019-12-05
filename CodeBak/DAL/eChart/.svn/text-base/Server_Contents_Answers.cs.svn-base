using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:server_contents_answers
	/// </summary>
	public partial class server_contents_answers
	{
		public server_contents_answers()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "server_contents_answers"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from server_contents_answers");
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
		public void Add(eChartProject.Model.eChart.server_contents_answers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into server_contents_answers(");
			strSql.Append("MessageID,Answer,isDeleted)");
			strSql.Append(" values (");
			strSql.Append("@MessageID,@Answer,@isDeleted)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Answer", MySqlDbType.VarChar,4000),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1)};
			parameters[0].Value = model.MessageID;
			parameters[1].Value = model.Answer;
			parameters[2].Value = model.isDeleted;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_answers model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update server_contents_answers set ");
			strSql.Append("MessageID=@MessageID,");
			strSql.Append("Answer=@Answer,");
			strSql.Append("isDeleted=@isDeleted");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@MessageID", MySqlDbType.Int32,11),
					new MySqlParameter("@Answer", MySqlDbType.VarChar,4000),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.MessageID;
			parameters[1].Value = model.Answer;
			parameters[2].Value = model.isDeleted;
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
			strSql.Append("delete from server_contents_answers ");
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
			strSql.Append("delete from server_contents_answers ");
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
		public eChartProject.Model.eChart.server_contents_answers GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,MessageID,Answer,isDeleted from server_contents_answers ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.server_contents_answers model=new eChartProject.Model.eChart.server_contents_answers();
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
				if(ds.Tables[0].Rows[0]["Answer"]!=null && ds.Tables[0].Rows[0]["Answer"].ToString()!="")
				{
					model.Answer=ds.Tables[0].Rows[0]["Answer"].ToString();
				}
				if(ds.Tables[0].Rows[0]["isDeleted"]!=null && ds.Tables[0].Rows[0]["isDeleted"].ToString()!="")
				{
					model.isDeleted=int.Parse(ds.Tables[0].Rows[0]["isDeleted"].ToString());
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
			strSql.Append("select ID,MessageID,Answer,isDeleted ");
			strSql.Append(" FROM server_contents_answers ");
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
			parameters[0].Value = "server_contents_answers";
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

