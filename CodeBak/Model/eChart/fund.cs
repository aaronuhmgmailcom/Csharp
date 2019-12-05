using System;
namespace eChartProject.Model.eChart
{
	/// <summary>
	/// fund:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class fund
	{
		public fund()
		{}
		#region Model
		private int _id;
		private string _fundtfn;
		private string _abn;
		private string _fundname;
		private int? _currentfinancialyear;
		private string _checkliststatus;
		private string _lodgementstatus;
		private string _emailaddress;
		private int? _emailsendnumber;
		private DateTime? _lastemaildate;
		private DateTime? _uploaddate;
		private DateTime? _submitdate;
		private DateTime? _lodgementdate;
		private int? _accountantid;
		private int? _iswipview=0;
		private int? _auditorid;
		private int? _referrerid;
		private DateTime? _estabdate;
		private int? _enableclientaddbankaccount=0;
		private int? _nnfundid;
		private int? _fundstatusid;
		private int? _isfreefirstyear;
		private int? _isfreesecondyear;
		private int? _isblacklist;
		private DateTime? _fundreceiveddate;
		private DateTime? _fundapproveddate;
		private string _smsfname;
		private int? _existingornewsmsf;
		private string _postaladdress;
		private string _postalsuburb;
		private string _postalstate;
		private string _postalpostcode;
		private string _residentialaddress;
		private string _residentialsuburb;
		private string _residentialstate;
		private string _residentialpostcode;
		private string _homephone;
		private string _mobile;
		private string _fax;
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
		public string FundTFN
		{
			set{ _fundtfn=value;}
			get{return _fundtfn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ABN
		{
			set{ _abn=value;}
			get{return _abn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FundName
		{
			set{ _fundname=value;}
			get{return _fundname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CurrentFinancialYear
		{
			set{ _currentfinancialyear=value;}
			get{return _currentfinancialyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ChecklistStatus
		{
			set{ _checkliststatus=value;}
			get{return _checkliststatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string LodgementStatus
		{
			set{ _lodgementstatus=value;}
			get{return _lodgementstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EmailAddress
		{
			set{ _emailaddress=value;}
			get{return _emailaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EmailSendNumber
		{
			set{ _emailsendnumber=value;}
			get{return _emailsendnumber;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LastEmailDate
		{
			set{ _lastemaildate=value;}
			get{return _lastemaildate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? UploadDate
		{
			set{ _uploaddate=value;}
			get{return _uploaddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? SubmitDate
		{
			set{ _submitdate=value;}
			get{return _submitdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? LodgementDate
		{
			set{ _lodgementdate=value;}
			get{return _lodgementdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AccountantID
		{
			set{ _accountantid=value;}
			get{return _accountantid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsWIPView
		{
			set{ _iswipview=value;}
			get{return _iswipview;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AuditorID
		{
			set{ _auditorid=value;}
			get{return _auditorid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ReferrerID
		{
			set{ _referrerid=value;}
			get{return _referrerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? EstabDate
		{
			set{ _estabdate=value;}
			get{return _estabdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EnableClientAddBankAccount
		{
			set{ _enableclientaddbankaccount=value;}
			get{return _enableclientaddbankaccount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? NnfundID
		{
			set{ _nnfundid=value;}
			get{return _nnfundid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FundStatusID
		{
			set{ _fundstatusid=value;}
			get{return _fundstatusid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsFreeFirstYear
		{
			set{ _isfreefirstyear=value;}
			get{return _isfreefirstyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsFreeSecondYear
		{
			set{ _isfreesecondyear=value;}
			get{return _isfreesecondyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? IsBlacklist
		{
			set{ _isblacklist=value;}
			get{return _isblacklist;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FundReceivedDate
		{
			set{ _fundreceiveddate=value;}
			get{return _fundreceiveddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? FundApprovedDate
		{
			set{ _fundapproveddate=value;}
			get{return _fundapproveddate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SMSFName
		{
			set{ _smsfname=value;}
			get{return _smsfname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ExistingOrNewSMSF
		{
			set{ _existingornewsmsf=value;}
			get{return _existingornewsmsf;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostalAddress
		{
			set{ _postaladdress=value;}
			get{return _postaladdress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostalSuburb
		{
			set{ _postalsuburb=value;}
			get{return _postalsuburb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostalState
		{
			set{ _postalstate=value;}
			get{return _postalstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PostalPostcode
		{
			set{ _postalpostcode=value;}
			get{return _postalpostcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResidentialAddress
		{
			set{ _residentialaddress=value;}
			get{return _residentialaddress;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResidentialSuburb
		{
			set{ _residentialsuburb=value;}
			get{return _residentialsuburb;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResidentialState
		{
			set{ _residentialstate=value;}
			get{return _residentialstate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ResidentialPostcode
		{
			set{ _residentialpostcode=value;}
			get{return _residentialpostcode;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string HomePhone
		{
			set{ _homephone=value;}
			get{return _homephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mobile
		{
			set{ _mobile=value;}
			get{return _mobile;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Fax
		{
			set{ _fax=value;}
			get{return _fax;}
		}
		#endregion Model

	}
}

