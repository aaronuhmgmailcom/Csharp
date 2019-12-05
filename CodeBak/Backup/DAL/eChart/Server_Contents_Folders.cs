using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:server_contents_folders
	/// </summary>
	public partial class server_contents_folders
	{
		public server_contents_folders()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("FolderID", "server_contents_folders"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int FolderID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from server_contents_folders");
			strSql.Append(" where FolderID=@FolderID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32)
};
			parameters[0].Value = FolderID;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(eChartProject.Model.eChart.server_contents_folders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into server_contents_folders(");
			strSql.Append("Foldername,ParentID,isDeleted,isOffline)");
			strSql.Append(" values (");
			strSql.Append("@Foldername,@ParentID,@isDeleted,@isOffline)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Foldername", MySqlDbType.VarChar,50),
					new MySqlParameter("@ParentID", MySqlDbType.Int32,11),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@isOffline", MySqlDbType.Bit,1)};
			parameters[0].Value = model.Foldername;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.isDeleted;
			parameters[3].Value = model.isOffline;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_folders model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update server_contents_folders set ");
			strSql.Append("Foldername=@Foldername,");
			strSql.Append("ParentID=@ParentID,");
			strSql.Append("isDeleted=@isDeleted,");
			strSql.Append("isOffline=@isOffline");
			strSql.Append(" where FolderID=@FolderID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@Foldername", MySqlDbType.VarChar,50),
					new MySqlParameter("@ParentID", MySqlDbType.Int32,11),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@isOffline", MySqlDbType.Bit,1),
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.Foldername;
			parameters[1].Value = model.ParentID;
			parameters[2].Value = model.isDeleted;
			parameters[3].Value = model.isOffline;
			parameters[4].Value = model.FolderID;

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
        /// 更新一条数据(只更新isdelete)
        /// </summary>
        public bool UpdateByIsDelete(eChartProject.Model.eChart.server_contents_folders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_folders set ");
            strSql.Append("isDeleted=@isDeleted");
            strSql.Append(" where FolderID=@FolderID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11)};

            parameters[0].Value = model.isDeleted;
            parameters[1].Value = model.FolderID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据(只更新FolderName)
        /// </summary>
        public bool UpdateByFolderName(eChartProject.Model.eChart.server_contents_folders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_folders set ");
            strSql.Append("Foldername=@Foldername");
            strSql.Append(" where FolderID=@FolderID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@Foldername", MySqlDbType.VarChar,50),
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11)};

            parameters[0].Value = model.Foldername;
            parameters[1].Value = model.FolderID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
        /// 更新一条数据(只更新isoffline)
        /// </summary>
        public bool UpdateByIsoffline(eChartProject.Model.eChart.server_contents_folders model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_folders set ");
            strSql.Append("isOffline=@isOffline");
            strSql.Append(" where FolderID=@FolderID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@isOffline", MySqlDbType.Bit,1),
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11)};

            parameters[0].Value = model.isOffline;
            parameters[1].Value = model.FolderID;

            int rows = DbHelperMySQL.ExecuteSql(strSql.ToString(), parameters);
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
		public bool Delete(int FolderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from server_contents_folders ");
			strSql.Append(" where FolderID=@FolderID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32)
};
			parameters[0].Value = FolderID;

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
		public bool DeleteList(string FolderIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from server_contents_folders ");
			strSql.Append(" where FolderID in ("+FolderIDlist + ")  ");
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
		public eChartProject.Model.eChart.server_contents_folders GetModel(int FolderID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FolderID,Foldername,ParentID,isDeleted,isOffline from server_contents_folders ");
			strSql.Append(" where FolderID=@FolderID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32)
};
			parameters[0].Value = FolderID;

			eChartProject.Model.eChart.server_contents_folders model=new eChartProject.Model.eChart.server_contents_folders();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["FolderID"]!=null && ds.Tables[0].Rows[0]["FolderID"].ToString()!="")
				{
					model.FolderID=int.Parse(ds.Tables[0].Rows[0]["FolderID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Foldername"]!=null && ds.Tables[0].Rows[0]["Foldername"].ToString()!="")
				{
					model.Foldername=ds.Tables[0].Rows[0]["Foldername"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ParentID"]!=null && ds.Tables[0].Rows[0]["ParentID"].ToString()!="")
				{
					model.ParentID=int.Parse(ds.Tables[0].Rows[0]["ParentID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isDeleted"]!=null && ds.Tables[0].Rows[0]["isDeleted"].ToString()!="")
				{
					model.isDeleted=ds.Tables[0].Rows[0]["isDeleted"].ToString().ToUpper()=="TRUE"?1:0;
				}
				if(ds.Tables[0].Rows[0]["isOffline"]!=null && ds.Tables[0].Rows[0]["isOffline"].ToString()!="")
				{
					model.isOffline=ds.Tables[0].Rows[0]["isOffline"].ToString().ToUpper()=="TRUE"?1:0;
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
			strSql.Append("select FolderID,Foldername,ParentID,isDeleted,isOffline ");
			strSql.Append(" FROM server_contents_folders ");
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
			parameters[0].Value = "server_contents_folders";
			parameters[1].Value = "FolderID";
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

