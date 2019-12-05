using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:server_contents_theases
	/// </summary>
	public partial class server_contents_theases
	{
		public server_contents_theases()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "server_contents_theases"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from server_contents_theases");
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
		public void Add(eChartProject.Model.eChart.server_contents_theases model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into server_contents_theases(");
			strSql.Append("FolderID,isOffLine,sortOrder,Thease,isDeleted)");
			strSql.Append(" values (");
			strSql.Append("@FolderID,@isOffLine,@sortOrder,@Thease,@isDeleted)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11),
					new MySqlParameter("@isOffLine", MySqlDbType.Bit,1),
					new MySqlParameter("@sortOrder", MySqlDbType.Int32,11),
					new MySqlParameter("@Thease", MySqlDbType.VarChar,500),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1)};
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.isOffLine;
			parameters[2].Value = model.sortOrder;
			parameters[3].Value = model.Thease;
			parameters[4].Value = model.isDeleted;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_theases model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update server_contents_theases set ");
			strSql.Append("FolderID=@FolderID,");
			strSql.Append("isOffLine=@isOffLine,");
			strSql.Append("sortOrder=@sortOrder,");
			strSql.Append("Thease=@Thease,");
			strSql.Append("isDeleted=@isDeleted");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11),
					new MySqlParameter("@isOffLine", MySqlDbType.Bit,1),
					new MySqlParameter("@sortOrder", MySqlDbType.Int32,11),
					new MySqlParameter("@Thease", MySqlDbType.VarChar,500),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.isOffLine;
			parameters[2].Value = model.sortOrder;
			parameters[3].Value = model.Thease;
			parameters[4].Value = model.isDeleted;
			parameters[5].Value = model.ID;

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
			strSql.Append("delete from server_contents_theases ");
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
			strSql.Append("delete from server_contents_theases ");
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
		public eChartProject.Model.eChart.server_contents_theases GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FolderID,isOffLine,sortOrder,Thease,isDeleted from server_contents_theases ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.server_contents_theases model=new eChartProject.Model.eChart.server_contents_theases();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"]!=null && ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					model.ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FolderID"]!=null && ds.Tables[0].Rows[0]["FolderID"].ToString()!="")
				{
					model.FolderID=int.Parse(ds.Tables[0].Rows[0]["FolderID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isOffLine"]!=null && ds.Tables[0].Rows[0]["isOffLine"].ToString()!="")
				{
					model.isOffLine=int.Parse(ds.Tables[0].Rows[0]["isOffLine"].ToString());
				}
				if(ds.Tables[0].Rows[0]["sortOrder"]!=null && ds.Tables[0].Rows[0]["sortOrder"].ToString()!="")
				{
					model.sortOrder=int.Parse(ds.Tables[0].Rows[0]["sortOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Thease"]!=null && ds.Tables[0].Rows[0]["Thease"].ToString()!="")
				{
					model.Thease=ds.Tables[0].Rows[0]["Thease"].ToString();
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
			strSql.Append("select ID,FolderID,isOffLine,sortOrder,Thease,isDeleted ");
			strSql.Append(" FROM server_contents_theases ");
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
			parameters[0].Value = "server_contents_theases";
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

