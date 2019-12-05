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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace eChartProject.Web.eChart.Accounts_Users
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtUserID.Text))
			{
				strErr+="UserID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtFundID.Text))
			{
				strErr+="FundID格式错误！\\n";	
			}
			if(this.txtUsername.Text.Trim().Length==0)
			{
				strErr+="Username不能为空！\\n";	
			}
			if(this.txtPassword.Text.Trim().Length==0)
			{
				strErr+="Password不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAge.Text))
			{
				strErr+="Age格式错误！\\n";	
			}
			if(this.txtCity.Text.Trim().Length==0)
			{
				strErr+="City不能为空！\\n";	
			}
			if(this.txtCountry.Text.Trim().Length==0)
			{
				strErr+="Country不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="Email不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtGender.Text))
			{
				strErr+="Gender格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int UserID=int.Parse(this.txtUserID.Text);
			int FundID=int.Parse(this.txtFundID.Text);
			string Username=this.txtUsername.Text;
			string Password=this.txtPassword.Text;
			int Age=int.Parse(this.txtAge.Text);
			string City=this.txtCity.Text;
			string Country=this.txtCountry.Text;
			string Email=this.txtEmail.Text;
			int Gender=int.Parse(this.txtGender.Text);

			eChartProject.Model.eChart.Accounts_Users model=new eChartProject.Model.eChart.Accounts_Users();
			model.UserID=UserID;
			model.FundID=FundID;
			model.Username=Username;
			model.Password=Password;
			model.Age=Age;
			model.City=City;
			model.Country=Country;
			model.Email=Email;
			model.Gender=Gender;

			eChartProject.BLL.eChart.Accounts_Users bll=new eChartProject.BLL.eChart.Accounts_Users();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
