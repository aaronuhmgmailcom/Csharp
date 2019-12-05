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
using System.Text;
namespace eChartProject.Web.eChart.Accounts_Users
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				#warning 代码生成提示：显示页面,请检查确认该语句是否正确
				ShowInfo();
			}
		}
		
	private void ShowInfo()
	{
		eChartProject.BLL.eChart.Accounts_Users bll=new eChartProject.BLL.eChart.Accounts_Users();
		eChartProject.Model.eChart.Accounts_Users model=bll.GetModel();
		this.lblUserID.Text=model.UserID.ToString();
		this.lblFundID.Text=model.FundID.ToString();
		this.lblUsername.Text=model.Username;
		this.lblPassword.Text=model.Password;
		this.lblAge.Text=model.Age.ToString();
		this.lblCity.Text=model.City;
		this.lblCountry.Text=model.Country;
		this.lblEmail.Text=model.Email;
		this.lblGender.Text=model.Gender.ToString();

	}


    }
}
