using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using eChartProject.Model.eChart;
namespace eChartProject.BLL.eChart
{
	/// <summary>
	/// Server_Contents_Message
	/// </summary>
	public partial class Server_Contents_Message
	{
        private readonly eChartProject.DAL.eChart.Server_Contents_Message dal = new eChartProject.DAL.eChart.Server_Contents_Message();
		public Server_Contents_Message()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
        public int Add(eChartProject.Model.eChart.Server_Contents_Message model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
        public bool Update(eChartProject.Model.eChart.Server_Contents_Message model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public eChartProject.Model.eChart.Server_Contents_Message GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
        public eChartProject.Model.eChart.Server_Contents_Message GetModelByCache(int ID)
		{
			
			string CacheKey = "Server_Contents_MessageModel-" + ID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
            return (eChartProject.Model.eChart.Server_Contents_Message)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<eChartProject.Model.eChart.Server_Contents_Message> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
        public List<eChartProject.Model.eChart.Server_Contents_Message> DataTableToList(DataTable dt)
		{
            List<eChartProject.Model.eChart.Server_Contents_Message> modelList = new List<eChartProject.Model.eChart.Server_Contents_Message>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
                eChartProject.Model.eChart.Server_Contents_Message model;
				for (int n = 0; n < rowsCount; n++)
				{
                    model = new eChartProject.Model.eChart.Server_Contents_Message();
					if(dt.Rows[n]["ID"]!=null && dt.Rows[n]["ID"].ToString()!="")
					{
						model.ID=int.Parse(dt.Rows[n]["ID"].ToString());
					}
					if(dt.Rows[n]["FolderID"]!=null && dt.Rows[n]["FolderID"].ToString()!="")
					{
						model.FolderID=int.Parse(dt.Rows[n]["FolderID"].ToString());
					}
					if(dt.Rows[n]["isOffLine"]!=null && dt.Rows[n]["isOffLine"].ToString()!="")
					{
						if((dt.Rows[n]["isOffLine"].ToString()=="1")||(dt.Rows[n]["isOffLine"].ToString().ToLower()=="true"))
						{
						model.isOffLine=true;
						}
						else
						{
							model.isOffLine=false;
						}
					}
					if(dt.Rows[n]["isPublic"]!=null && dt.Rows[n]["isPublic"].ToString()!="")
					{
						if((dt.Rows[n]["isPublic"].ToString()=="1")||(dt.Rows[n]["isPublic"].ToString().ToLower()=="true"))
						{
						model.isPublic=true;
						}
						else
						{
							model.isPublic=false;
						}
					}
					if(dt.Rows[n]["isVariations"]!=null && dt.Rows[n]["isVariations"].ToString()!="")
					{
						if((dt.Rows[n]["isVariations"].ToString()=="1")||(dt.Rows[n]["isVariations"].ToString().ToLower()=="true"))
						{
						model.isVariations=true;
						}
						else
						{
							model.isVariations=false;
						}
					}
					if(dt.Rows[n]["sortOrder"]!=null && dt.Rows[n]["sortOrder"].ToString()!="")
					{
						model.sortOrder=int.Parse(dt.Rows[n]["sortOrder"].ToString());
					}
					if(dt.Rows[n]["Question"]!=null && dt.Rows[n]["Question"].ToString()!="")
					{
					model.Question=dt.Rows[n]["Question"].ToString();
					}
					if(dt.Rows[n]["RelatedID"]!=null && dt.Rows[n]["RelatedID"].ToString()!="")
					{
						model.RelatedID=int.Parse(dt.Rows[n]["RelatedID"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

