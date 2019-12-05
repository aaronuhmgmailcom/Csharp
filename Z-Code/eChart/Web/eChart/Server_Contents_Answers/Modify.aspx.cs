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
namespace eChartProject.Web.eChart.Server_Contents_Answers
{
    public partial class Modify : Page
    {       

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
		eChartProject.BLL.eChart.Server_Contents_Answers bll=new eChartProject.BLL.eChart.Server_Contents_Answers();
		eChartProject.Model.eChart.Server_Contents_Answers model=bll.GetModel();
		this.txtID.Text=model.ID.ToString();
		this.txtMessageID.Text=model.MessageID.ToString();
		this.txtAnswer.Text=model.Answer;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtID.Text))
			{
				strErr+="ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMessageID.Text))
			{
				strErr+="MessageID格式错误！\\n";	
			}
			if(this.txtAnswer.Text.Trim().Length==0)
			{
				strErr+="Answer不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.txtID.Text);
			int MessageID=int.Parse(this.txtMessageID.Text);
			string Answer=this.txtAnswer.Text;


			eChartProject.Model.eChart.Server_Contents_Answers model=new eChartProject.Model.eChart.Server_Contents_Answers();
			model.ID=ID;
			model.MessageID=MessageID;
			model.Answer=Answer;

			eChartProject.BLL.eChart.Server_Contents_Answers bll=new eChartProject.BLL.eChart.Server_Contents_Answers();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
