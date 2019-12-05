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
		eChartProject.BLL.eChart.Server_Contents_Theases bll=new eChartProject.BLL.eChart.Server_Contents_Theases();
		eChartProject.Model.eChart.Server_Contents_Theases model=bll.GetModel();
		this.txtID.Text=model.ID.ToString();
		this.txtFolderID.Text=model.FolderID.ToString();
		this.chkisOffLine.Checked=model.isOffLine;
		this.txtsortOrder.Text=model.sortOrder.ToString();
		this.txtThease.Text=model.Thease;

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
