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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
