using System;
namespace eChartProject.Model.eChart
{
	/// <summary>
	/// bankaccounttype:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class bankaccounttype
	{
		public bankaccounttype()
		{}
		#region Model
		private int _id;
		private string _bankname;
		private string _accounttypename;
		private int? _isbankaccounttypeview=1;
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
		public string BankName
		{
			set{ _bankname=value;}
			get{return _bankname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AccountTypeName
		{
			set{ _accounttypename=value;}
			get{return _accounttypename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsBankAccountTypeView
		{
			set{ _isbankaccounttypeview=value;}
			get{return _isbankaccounttypeview;}
		}
		#endregion Model

	}
}

