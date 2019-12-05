using System;
namespace eChartProject.Model.eChart
{
	/// <summary>
	/// accounts_users:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class accounts_users
	{
		public accounts_users()
		{}
		#region Model
		private int _userid;
		private int? _fundid;
		private string _username;
		private string _password;
		private int? _age;
		private string _city;
		private string _country;
		private string _email;
		private int? _gender;
		private int? _userstatus;
		/// <summary>
		/// auto_increment
		/// </summary>
		public int UserID
		{
			set{ _userid=value;}
			get{return _userid;}
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
		public string Username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Age
		{
			set{ _age=value;}
			get{return _age;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string City
		{
			set{ _city=value;}
			get{return _city;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Country
		{
			set{ _country=value;}
			get{return _country;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Gender
		{
			set{ _gender=value;}
			get{return _gender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserStatus
		{
			set{ _userstatus=value;}
			get{return _userstatus;}
		}
		#endregion Model

	}
}

