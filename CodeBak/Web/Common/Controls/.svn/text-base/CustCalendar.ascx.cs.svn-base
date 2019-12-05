using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Globalization;
using System.Text;

/// <summary>
/// 作者：Mark
/// 时间：2009-4-20
/// 功能：日期控件
/// 修改记录：1.2007-07-04  扩展日期格式。
///           2.2007-07-05  添加验证功能，包括非空、比较验证。
///           3.2007-07-12  添加DateValue属性，支持null数据，可以直接对实体内的数据进行赋值。
///           3.2007-07-13  添加范围验证。
/// </summary>
public partial class Common_Controls_CustCalendar : BaseUserControl
{

    #region 属性

    public delegate void CalendarChangeHandler(object sender, EventArgs e); //定义日期變化委托 

    private bool m_IsDisplayTime = false; //是否显示时间
    /// <summary>
    /// 设置是否显示时间
    /// </summary>
    [Category("CustProperty"), Description("是否在文本框中显示时间")]
    public bool IsDisplayTime
    {
        get { return m_IsDisplayTime; }
        set { m_IsDisplayTime = value; }
    }

    private string strDateSplitFlag = "/";
    /// <summary>
    /// 日期分割符
    /// </summary>
    [Category("CustProperty"), Description("日期分割符")]
    public string DateSplitFlag
    {
        get { return this.strDateSplitFlag; }
        set
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentOutOfRangeException("日期分割符不能输入空值");
            else
            {
                if (this.DateFormat.IndexOf(value) < 0)
                    this.strDateFormat = this.strDateFormat.Replace(this.strDateSplitFlag, value);
                this.strDateSplitFlag = value;
            }

        }
    }

    private string strDateFormat = "yyyy/MM/dd";
    /// <summary>
    /// 日期部份格式
    /// </summary>
    [Category("CustProperty"), DefaultValue("yyyy/MM/dd"), Description("日期部份格式")]
    public string DateFormat
    {
        get
        {
            if (this.strDateFormat.IndexOf(this.strDateSplitFlag) > -1)
                return this.strDateFormat;
            else
                return string.Format("dd{0}MM{0}yyyy", this.strDateSplitFlag);
        }
        set
        {
            this.strDateFormat = value;
            //if (value.IndexOf(this.strDateSplitFlag) > -1)
            //    this.strDateFormat = value.ToLower();
        }
    }

    [Category("CustProperty"), DefaultValue(0), Description("TabIndex")]
    public short TabIndex
    {
        get { return this.txtDate.TabIndex; }
        set { this.txtDate.TabIndex = value; }
    }

    [Category("CustProperty"), DefaultValue(false), Description("自動回發")]
    public bool AutoPostBack
    {
        get { return this.txtDate.AutoPostBack; }
        set { this.txtDate.AutoPostBack = value; }
    }


    [Category("CustProperty"), DefaultValue("-1"), Description("參數值")]
    public string Argument
    {
        get { return ViewState["argument"].ToString(); }
        set { ViewState["argument"] = value; }
    }

    /// <summary>
    /// Text
    /// </summary>
    [Browsable(false)]
    public string Text
    {
        get
        {
            string ReturnValue = string.Empty;
            if (!this.txtDate.Text.Equals(string.Empty))
            {
                string strFormat = this.DateFormat.Replace("mmm", "MM");
                if (IsDisplayTime)
                {
                    if (strFormat.IndexOf("ii") < 0 && strFormat.IndexOf("hh") < 0)
                        strFormat += " HH:mm";
                    else
                        strFormat.Replace("ii", "mm").Replace("hh", "HH");
                }
                DateTime dt = new DateTime(); ;
                if (DateTime.TryParse(this.txtDate.Text, out dt))
                    ReturnValue = dt.ToString(strFormat);
            }
            return ReturnValue;
        }
        set
        {
            if (!value.Equals(string.Empty))
            {
                string strFormat = this.DateFormat.Replace("mmm", "MMM");
                if (IsDisplayTime)
                {
                    if (strFormat.IndexOf("ii") < 0 && strFormat.IndexOf("hh") < 0)
                        strFormat += " HH:mm";
                    else
                        strFormat.Replace("ii", "mm").Replace("hh", "HH");
                }
                DateTime dt = new DateTime(); ;
                if (DateTime.TryParse(value, out dt))
                    this.txtDate.Text = dt.ToString(strFormat, DateTimeFormatInfo.InvariantInfo);
            }
            else
                this.txtDate.Text = value;
        }
    }

    /// <summary>
    /// 返回选择或输入的日期/时间
    /// </summary>
    [Browsable(false)]
    public System.Nullable<System.DateTime> DateValue
    {
        get
        {
            if (!this.txtDate.Text.Equals(string.Empty))
            {
                string strFormat = this.DateFormat.Replace("mmm", "MM");
                if (IsDisplayTime)
                {
                    if (strFormat.IndexOf("ii") < 0 && strFormat.IndexOf("hh") < 0)
                        strFormat += " HH:mm";
                    else
                        strFormat.Replace("ii", "mm").Replace("hh", "HH");
                }
                DateTime dt = new DateTime(); ;
                if (DateTime.TryParse(this.txtDate.Text, out dt))
                    return dt;
            }
            return null;
        }
        set
        {
            if (value != null)
            {
                string strFormat = this.DateFormat.Replace("mmm", "MMM");
                if (IsDisplayTime)
                {
                    if (strFormat.IndexOf("ii") < 0 && strFormat.IndexOf("hh") < 0)
                        strFormat += " HH:mm";
                    else
                        strFormat.Replace("ii", "mm").Replace("hh", "HH");
                }
                DateTime dt = (DateTime)value;
                this.txtDate.Text = dt.ToString(strFormat, DateTimeFormatInfo.InvariantInfo);
            }
            else
                this.txtDate.Text = string.Empty;
        }
    }

    /// <summary>
    /// 文本框宽度
    /// </summary>
    [Browsable(true), Description("文本框宽度")]
    public Unit TextWidth
    {
        get { return this.txtDate.Width; }
        set { this.txtDate.Width = value; }
    }

    /// <summary>
    /// 设置是否ReadOnly
    /// </summary>
    [Category("CustProperty"), DefaultValue(true), Description("ReadOnly")]
    public bool ReadOnly
    {
        set { this.txtDate.Attributes["readonly"] = value ? "readonly" : ""; }
    }

    // {{ Begin
    /// <summary>
    /// Purpose: 控制控件是否能被鼠标点击
    /// author: liuxiuk
    /// create date: 2010/07/08
    /// </summary>
    public bool Enable
    {
        get { return this.txtDate.Enabled; }
        set { this.txtDate.Enabled = value ? true : false; }
    }
    // }} End
    #endregion

    #region 验证
    #region 验证信息
    public static string MsgValNameFormat = "{0}";//验证名字格式
    public static string MsgEmpty = "<br />Please enter mandatory data.";
    public static string MsgRange = "<br />{0} should be between {1} and {2}.";
    public static string MsgRangeStringMin = "<br />{0} should be later than {1}.";
    public static string MsgRangeStringMax = "<br />{0} should be before than {1}.";
    #endregion

    #region ---验证公共属性
    private DateTime? _defaultValue;
    /// <summary>
    /// 数据初始值，当用户的选择不等于初始值时才校验
    /// </summary>
    [Category("Validator"), Description("数据初始值，当用户的选择不等于初始值时才校验")]
    public DateTime? DefaultValue
    {
        get { return _defaultValue; }
        set { _defaultValue = value; }
    }

    private string strValName = "";
    /// <summary>
    /// 验证名
    /// </summary>
    [Category("Validator"), Description("验证名")]
    public string ValName
    {
        get { return this.strValName; }
        set { this.strValName = value; }
    }

    /// <summary>
    /// 分组验证
    /// </summary>
    [Category("Validator"), Description("分组验证")]
    public string ValidationGroup
    {
        get { return this.txtDate.ValidationGroup; }
        set { this.txtDate.ValidationGroup = value; }
    }

    /// <summary>
    /// 验证显示格式
    /// </summary>
    private ValidatorDisplay eDisplay = ValidatorDisplay.Dynamic;
    [Category("Validator"), Description("验证显示格式")]
    public ValidatorDisplay Display
    {
        get { return this.eDisplay; }
        set { this.eDisplay = value; }
    }
    #endregion

    #region ---非空验证
    /// <summary>
    /// 是否非空验证
    /// </summary>
    [Category("ValidatorEmpty"), Description("是否非空验证")]
    public bool IsValEmpty
    {
        get { return this.ctrValEmpty.Visible; }
        set { this.ctrValEmpty.Visible = value; }
    }

    /// <summary>
    /// 自定义非空验证消息
    /// </summary>
    [Category("ValidatorEmpty"), Description("自定义非空验证消息")]
    public string ValEmptyMsg
    {
        get { return this.ctrValEmpty.ErrorMessage; }
        set { this.ctrValEmpty.ErrorMessage = value; }
    }
    #endregion

    #region ---范围验证
    /// <summary>
    /// 是否范围验证
    /// </summary>
    [Category("ValidatorRange"), Description("是否比较验证")]
    public bool IsValRange
    {
        get { return this.ctrVarRangeValue.Visible; }
        set { this.ctrVarRangeValue.Visible = value; }
    }

    /// <summary>
    /// 自定义范围验证消息
    /// </summary>
    [Category("ValidatorEmpty"), Description("自定义非空验证消息")]
    public string ValRangeMsg
    {
        get { return this.ctrVarRangeValue.ErrorMessage; }
        set { this.ctrVarRangeValue.ErrorMessage = value; }
    }

    private string strMaxDate = "";
    /// <summary>
    /// 最大日期
    /// </summary>
    [Category("ValidatorRange"), Description("最大值")]
    public string MaxDate
    {
        get { return this.strMaxDate; }
        set { this.strMaxDate = value; }
    }
    private string strMinDate = "";
    /// <summary>
    /// 最小日期
    /// </summary>
    [Category("ValidatorRange"), Description("最小值")]
    public string MinDate
    {
        get { return this.strMinDate; }
        set { this.strMinDate = value; }
    }
    #endregion

    #region ---比较验证
    /// <summary>
    /// 是否可以等于
    /// </summary>
    [Category("ValidatorCompare"), Description("是否可以等于")]
    public bool CanEqual
    {
        get
        {
            return this.ViewState["CanEqual"] == null ? false : true;
        }
        set
        {
            if (value)
            {
                this.ViewState["CanEqual"] = "";
            }
            else
            {
                this.ViewState.Remove("CanEqual");
            }
        }
    }
    /// <summary>
    /// 是否比较验证
    /// </summary>
    [Category("ValidatorCompare"), Description("是否比较验证")]
    public bool IsValCompare
    {
        get { return this.ctrValComCtr.Visible; }
        set { this.ctrValComCtr.Visible = value; }
    }

    /// <summary>
    /// 日期文本控件客户端ID
    /// </summary>
    public string txtDateClientID
    {
        get { return this.txtDate.ClientID; }
    }

    private string strMaxDateClentID = "";
    /// <summary>
    /// 比较日期控件客户端ID（最大日期）
    /// </summary>
    [Category("ValidatorCompare"), Description("比较日期控件ID（最大日期）")]
    public string MaxDateClentID
    {
        get { return this.strMaxDateClentID; }
        set { this.strMaxDateClentID = value; }
    }

    private string strMaxDateName = "";
    /// <summary>
    /// 比较日期控件Name（最大日期）
    /// </summary>
    [Category("ValidatorCompare"), Description("比较日期控件Name（最大日期）")]
    public string MaxDateName
    {
        get { return this.strMaxDateName; }
        set { this.strMaxDateName = value; }
    }

    private string strMinDateClentID = "";
    /// <summary>
    /// 比较日期控件客户端ID（最小日期）
    /// </summary>
    [Category("ValidatorCompare"), Description("比较日期控件ID（最小日期）")]
    public string MinDateClentID
    {
        get { return this.strMinDateClentID; }
        set { this.strMinDateClentID = value; }
    }

    private string strMinDateName = "";
    /// <summary>
    /// 比较日期控件Name（最小日期）
    /// </summary>
    [Category("ValidatorCompare"), Description("比较日期控件Name（最小日期）")]
    public string MinDateName
    {
        get { return this.strMinDateName; }
        set { this.strMinDateName = value; }
    }

    /// <summary>
    /// 自定义比较控件验证消息
    /// </summary>
    [Category("ValidatorCompare"), Description("自定义比较验证消息")]
    public string ValCompareMsg
    {
        get { return this.ctrValComCtr.ErrorMessage; }
        set { this.ctrValComCtr.ErrorMessage = value; }
    }

    #endregion

    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime dt = DateTime.Now;
        ScriptManager.RegisterHiddenField(this, "hfYYYY", dt.Year.ToString());
        ScriptManager.RegisterHiddenField(this, "hfMM", dt.Month.ToString());
        ScriptManager.RegisterHiddenField(this, "hfDD", dt.Day.ToString());
        ScriptManager.RegisterHiddenField(this, "hfHH", dt.Hour.ToString());
        ScriptManager.RegisterHiddenField(this, "hfM", dt.Minute.ToString());
        ScriptManager.RegisterHiddenField(this, "hfSS", dt.Second.ToString());

        ScriptManager.RegisterHiddenField(this, "hfDatePickerMinYear", ConfigurationManager.AppSettings["DatePickerMinYear"]);
        ScriptManager.RegisterHiddenField(this, "hfDatePickerMaxYear", ConfigurationManager.AppSettings["DatePickerMaxYear"]);

        if (!Page.IsPostBack)
        {
            this.SetValControls();
        }
    }

    public event CalendarChangeHandler CalendarChanged;//定义日期改變事件

    /// <summary>
    /// 文檔說明:文本框變化觸發事件
    /// 作    者:Johnny Jiang
    /// 創建日期:2010/07/06
    /// 修改日期:2010/07/06
    /// 修改記錄:
    ///         □2010/07/06
    /// </summary>
    protected void txtDate_TextChanged(object sender, EventArgs e)
    {
        if (AutoPostBack)
        {
            if(CalendarChanged!=null)
                CalendarChanged(this, e);            
        }
    }

    private void SetValControls()
    {
        //add by johnnyj 2010/07/06
        if (AutoPostBack)
        {
            this.txtDate.Attributes.Remove("OnTextChanged");
        }

        string strName = string.Format(MsgValNameFormat, strValName);
        if (this.ctrValEmpty.Visible)
        {
            if (this.ctrValEmpty.ErrorMessage.Equals(string.Empty))
            {
                this.ctrValEmpty.ErrorMessage = string.Format(MsgEmpty, strName);
            }
            this.ctrValEmpty.Display = eDisplay;
            this.ctrValEmpty.ValidationGroup = this.txtDate.ValidationGroup;
        }
        //比较控件验证
        if (this.ctrValComCtr.Visible)
        {
            if (!this.strMaxDateClentID.Equals(string.Empty))
                this.ctrValComCtr.Attributes["MaxDateClentID"] = this.strMaxDateClentID;
            if (!this.strMinDateClentID.Equals(string.Empty))
                this.ctrValComCtr.Attributes["MinDateClentID"] = this.strMinDateClentID;

            this.ctrValComCtr.Attributes["SpiltFlag"] = this.DateSplitFlag;
            this.ctrValComCtr.Attributes["DateFormat"] = this.DateFormat;
            this.ctrValComCtr.Attributes["ValControl"] = this.txtDate.ClientID;
            if (this.CanEqual)
            {
                this.ctrValComCtr.Attributes["CanEqual"] = this.CanEqual.ToString();
            }
            else
            {
                this.ctrValComCtr.Attributes.Remove("CanEqual");
            }

            this.ctrValComCtr.Display = eDisplay;
            this.ctrValComCtr.ValidationGroup = this.txtDate.ValidationGroup;
            if (this.ctrValComCtr.ErrorMessage.Equals(string.Empty))
            {
                if (!this.MaxDateClentID.Equals(string.Empty) && !this.MinDateClentID.Equals(string.Empty))
                {
                    this.ctrValComCtr.ErrorMessage = string.Format(MsgRange, strName, this.MinDateName, this.MaxDateName);
                }
                else
                {
                    if (!this.MaxDateClentID.Equals(string.Empty))
                        this.ctrValComCtr.ErrorMessage += string.Format(MsgRangeStringMax, strName, (this.CanEqual ? "or equal to " : "") + this.MaxDateName);
                    else
                    {
                        if (!this.MinDateClentID.Equals(string.Empty))
                            this.ctrValComCtr.ErrorMessage += string.Format(MsgRangeStringMin, strName, (this.CanEqual ? "or equal to " : "") + this.MinDateName);
                    }
                }
            }
        }
        //范围验证
        if (this.ctrVarRangeValue.Visible)
        {
            this.ctrVarRangeValue.Attributes["MaxDate"] = this.strMaxDate;
            this.ctrVarRangeValue.Attributes["MinDate"] = this.strMinDate;

            this.ctrVarRangeValue.Attributes["SpiltFlag"] = this.DateSplitFlag;
            this.ctrVarRangeValue.Attributes["DateFormat"] = this.DateFormat;
            this.ctrVarRangeValue.Attributes["ValControl"] = this.txtDate.ClientID;
            if (this.CanEqual)
            {
                this.ctrVarRangeValue.Attributes["CanEqual"] = this.CanEqual.ToString();
            }
            else
            {
                this.ctrVarRangeValue.Attributes.Remove("CanEqual");
            }
            if (this.DefaultValue.HasValue)
            {
                this.ctrVarRangeValue.Attributes["DefaultDate"] = this.DefaultValue.Value.ToString("yyyyMMdd");
            }
            else
            {
                this.ctrVarRangeValue.Attributes.Remove("DefaultDate");
            }

            this.ctrVarRangeValue.Display = eDisplay;
            this.ctrVarRangeValue.ValidationGroup = this.txtDate.ValidationGroup;
            if (this.ctrVarRangeValue.ErrorMessage.Equals(string.Empty))
            {
                if (!this.MaxDate.Equals(string.Empty) && !this.MinDate.Equals(string.Empty))
                {
                    this.ctrVarRangeValue.ErrorMessage = string.Format(MsgRange, strName, this.MaxDate, this.MinDate);
                }
                else
                {
                    if (!this.MaxDate.Equals(string.Empty))
                        this.ctrVarRangeValue.ErrorMessage += string.Format(MsgRangeStringMax, strName, (this.CanEqual ? "or equal to " : "") + this.MaxDate);
                    else
                    {
                        if (!this.MinDate.Equals(string.Empty))
                            this.ctrVarRangeValue.ErrorMessage += string.Format(MsgRangeStringMin, strName, (this.CanEqual ? "or equal to " : "") + this.MinDate);
                    }
                }
            }
        }
    }


    
}
