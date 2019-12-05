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
namespace eChartProject.Web.eChart.Server_Contents_Theases
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
			if(!PageValidate.IsNumber(txtFolderID.Text))
			{
				strErr+="FolderID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtsortOrder.Text))
			{
				strErr+="sortOrder格式错误！\\n";	
			}
			if(this.txtThease.Text.Trim().Length==0)
			{
				strErr+="Thease不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.txtID.Text);
			int FolderID=int.Parse(this.txtFolderID.Text);
			bool isOffLine=this.chkisOffLine.Checked;
			int sortOrder=int.Parse(this.txtsortOrder.Text);
			string Thease=this.txtThease.Text;

			eChartProject.Model.eChart.Server_Contents_Theases model=new eChartProject.Model.eChart.Server_Contents_Theases();
			model.ID=ID;
			model.FolderID=FolderID;
			model.isOffLine=isOffLine;
			model.sortOrder=sortOrder;
			model.Thease=Thease;

			eChartProject.BLL.eChart.Server_Contents_Theases bll=new eChartProject.BLL.eChart.Server_Contents_Theases();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
