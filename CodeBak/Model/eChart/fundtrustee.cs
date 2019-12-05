using System;
namespace eChartProject.Model.eChart
{
	/// <summary>
	/// fundtrustee:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fundtrustee
	{
		public fundtrustee()
		{}
		#region Model
		private int _id;
		private int? _fundid;
		private int? _fundtrusteeno;
		private string _title;
		private string _firstname;
		private string _middlename;
		private string _lastname;
		private string _trusteetfn;
		private DateTime? _dob;
		private DateTime? _dateofretirement;
		private int? _ismember=1;
		private DateTime? _joindate;
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
		public int? FundID
		{
			set{ _fundid=value;}
			get{return _fundid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FundTrusteeNo
		{
			set{ _fundtrusteeno=value;}
			get{return _fundtrusteeno;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FirstName
		{
			set{ _firstname=value;}
			get{return _firstname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MiddleName
		{
			set{ _middlename=value;}
			get{return _middlename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LastName
		{
			set{ _lastname=value;}
			get{return _lastname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TrusteeTFN
		{
			set{ _trusteetfn=value;}
			get{return _trusteetfn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DOB
		{
			set{ _dob=value;}
			get{return _dob;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? DateOfRetirement
		{
			set{ _dateofretirement=value;}
			get{return _dateofretirement;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsMember
		{
			set{ _ismember=value;}
			get{return _ismember;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? JoinDate
		{
			set{ _joindate=value;}
			get{return _joindate;}
		}
		#endregion Model

	}
}

