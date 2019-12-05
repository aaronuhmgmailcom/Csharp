using System;
namespace eChartProject.Model.eChart
{
	/// <summary>
	/// server_contents_message:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class server_contents_message
	{
		public server_contents_message()
		{}
		#region Model
		private int _id;
		private int? _folderid;
		private int? _isoffline;
		private int? _ispublic;
		private int? _isvariations;
		private int? _sortorder;
		private string _question;
		private int? _relatedid;
		private int? _isdeleted;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FolderID
		{
			set{ _folderid=value;}
			get{return _folderid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isOffLine
		{
			set{ _isoffline=value;}
			get{return _isoffline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isPublic
		{
			set{ _ispublic=value;}
			get{return _ispublic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isVariations
		{
			set{ _isvariations=value;}
			get{return _isvariations;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sortOrder
		{
			set{ _sortorder=value;}
			get{return _sortorder;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Question
		{
			set{ _question=value;}
			get{return _question;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? RelatedID
		{
			set{ _relatedid=value;}
			get{return _relatedid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? isDeleted
		{
			set{ _isdeleted=value;}
			get{return _isdeleted;}
		}
		#endregion Model

	}
}

