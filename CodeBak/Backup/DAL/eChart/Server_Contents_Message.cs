using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//Please add references
namespace eChartProject.DAL.eChart
{
	/// <summary>
	/// 数据访问类:server_contents_message
	/// </summary>
	public partial class server_contents_message
	{
		public server_contents_message()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperMySQL.GetMaxID("ID", "server_contents_message"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from server_contents_message");
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
		public void Add(eChartProject.Model.eChart.server_contents_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into server_contents_message(");
			strSql.Append("FolderID,isOffLine,isPublic,isVariations,sortOrder,Question,RelatedID,isDeleted)");
			strSql.Append(" values (");
            strSql.Append("@FolderID,@isOffLine,@isPublic,@isVariations,@sortOrder,@Question,@RelatedID,@isDeleted)");
            MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11),
					new MySqlParameter("@isOffLine", MySqlDbType.Bit,1),
					new MySqlParameter("@isPublic", MySqlDbType.Bit,1),
					new MySqlParameter("@isVariations", MySqlDbType.Bit,1),
					new MySqlParameter("@sortOrder", MySqlDbType.Int32,11),
					new MySqlParameter("@Question", MySqlDbType.VarChar,1000),
					new MySqlParameter("@RelatedID", MySqlDbType.Int32,11),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1)};
        
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.isOffLine;
			parameters[2].Value = model.isPublic;
			parameters[3].Value = model.isVariations;
			parameters[4].Value = model.sortOrder;
			parameters[5].Value = model.Question;
			parameters[6].Value = model.RelatedID;
			parameters[7].Value = model.isDeleted;
      

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(eChartProject.Model.eChart.server_contents_message model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update server_contents_message set ");
			strSql.Append("FolderID=@FolderID,");
			strSql.Append("isOffLine=@isOffLine,");
			strSql.Append("isPublic=@isPublic,");
			strSql.Append("isVariations=@isVariations,");
			strSql.Append("sortOrder=@sortOrder,");
			strSql.Append("Question=@Question,");
			strSql.Append("RelatedID=@RelatedID,");
			strSql.Append("isDeleted=@isDeleted");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FolderID", MySqlDbType.Int32,11),
					new MySqlParameter("@isOffLine", MySqlDbType.Bit,1),
					new MySqlParameter("@isPublic", MySqlDbType.Bit,1),
					new MySqlParameter("@isVariations", MySqlDbType.Bit,1),
					new MySqlParameter("@sortOrder", MySqlDbType.Int32,11),
					new MySqlParameter("@Question", MySqlDbType.VarChar,1000),
					new MySqlParameter("@RelatedID", MySqlDbType.Int32,11),
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@ID", MySqlDbType.Int32,11)};
			parameters[0].Value = model.FolderID;
			parameters[1].Value = model.isOffLine;
			parameters[2].Value = model.isPublic;
			parameters[3].Value = model.isVariations;
			parameters[4].Value = model.sortOrder;
			parameters[5].Value = model.Question;
			parameters[6].Value = model.RelatedID;
			parameters[7].Value = model.isDeleted;
			parameters[8].Value = model.ID;

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
        /// 更新一条数据(只更新RELATEDID)
        /// </summary>
        public bool UpdateByRelatedID(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("RelatedID=@RelatedID");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@RelatedID",  MySqlDbType.Int32,11),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.RelatedID;
            parameters[1].Value = model.ID;

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
        /// 更新一条数据(只更新question)
        /// </summary>
        public bool UpdateByQuestion(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("question=@question");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@question",  MySqlDbType.VarChar,1000),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.Question;
            parameters[1].Value = model.ID;

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
        /// 更新一条数据(只更新IsPublic)
        /// </summary>
        public bool UpdateByIsPublic(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("isPublic=@isPublic");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@isPublic", MySqlDbType.Bit,1),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.isPublic;
            parameters[1].Value = model.ID;

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
        /// 更新一条数据(只更新ISDELETED)
        /// </summary>
        public bool UpdateByIsdeleted(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("isDeleted=@isDeleted");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@isDeleted", MySqlDbType.Bit,1),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.isDeleted;
            parameters[1].Value = model.ID;

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
        /// 更新一条数据(只更新ISoffline)
        /// </summary>
        public bool UpdateByIsoffline(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("isOffLine=@isOffLine");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@isOffLine", MySqlDbType.Bit,1),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.isOffLine;
            parameters[1].Value = model.ID;

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
        /// 更新一条数据(只更新sortOrder)
        /// </summary>
        public bool UpdateBySortOrder(eChartProject.Model.eChart.server_contents_message model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update server_contents_message set ");
            strSql.Append("sortOrder=@sortOrder");
            strSql.Append(" where ID=@ID");
            MySqlParameter[] parameters = {
					new MySqlParameter("@sortOrder", MySqlDbType.Bit,1),
					new MySqlParameter("@ID",MySqlDbType.Int32,11)};

            parameters[0].Value = model.sortOrder;
            parameters[1].Value = model.ID;

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
		public bool Delete(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from server_contents_message ");
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
			strSql.Append("delete from server_contents_message ");
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
		public eChartProject.Model.eChart.server_contents_message GetModel(int ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,FolderID,isOffLine,isPublic,isVariations,sortOrder,Question,RelatedID,isDeleted from server_contents_message ");
			strSql.Append(" where ID=@ID");
			MySqlParameter[] parameters = {
					new MySqlParameter("@ID", MySqlDbType.Int32)
};
			parameters[0].Value = ID;

			eChartProject.Model.eChart.server_contents_message model=new eChartProject.Model.eChart.server_contents_message();
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
					model.isOffLine=ds.Tables[0].Rows[0]["isOffLine"].ToString().ToUpper()=="TRUE"?1:0;
				}
				if(ds.Tables[0].Rows[0]["isPublic"]!=null && ds.Tables[0].Rows[0]["isPublic"].ToString()!="")
				{
                    model.isPublic = ds.Tables[0].Rows[0]["isPublic"].ToString().ToUpper() == "TRUE" ? 1 : 0; ;
				}
				if(ds.Tables[0].Rows[0]["isVariations"]!=null && ds.Tables[0].Rows[0]["isVariations"].ToString()!="")
				{
                    model.isVariations = ds.Tables[0].Rows[0]["isVariations"].ToString().ToUpper() == "TRUE" ? 1 : 0; ;
				}
				if(ds.Tables[0].Rows[0]["sortOrder"]!=null && ds.Tables[0].Rows[0]["sortOrder"].ToString()!="")
				{
					model.sortOrder=int.Parse(ds.Tables[0].Rows[0]["sortOrder"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Question"]!=null && ds.Tables[0].Rows[0]["Question"].ToString()!="")
				{
					model.Question=ds.Tables[0].Rows[0]["Question"].ToString();
				}
				if(ds.Tables[0].Rows[0]["RelatedID"]!=null && ds.Tables[0].Rows[0]["RelatedID"].ToString()!="")
				{
					model.RelatedID=int.Parse(ds.Tables[0].Rows[0]["RelatedID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["isDeleted"]!=null && ds.Tables[0].Rows[0]["isDeleted"].ToString()!="")
				{
                    model.isDeleted = ds.Tables[0].Rows[0]["isDeleted"].ToString().ToUpper() == "TRUE" ? 1 : 0; ;
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
			strSql.Append("select ID,FolderID,isOffLine,isPublic,isVariations,sortOrder,Question,RelatedID,isDeleted ");
			strSql.Append(" FROM server_contents_message ");
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
			parameters[0].Value = "server_contents_message";
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

