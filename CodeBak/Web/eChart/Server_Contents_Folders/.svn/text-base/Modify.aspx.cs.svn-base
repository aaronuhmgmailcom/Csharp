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
namespace eChartProject.Web.eChart.Server_Contents_Folders
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
		eChartProject.BLL.eChart.Server_Contents_Folders bll=new eChartProject.BLL.eChart.Server_Contents_Folders();
		eChartProject.Model.eChart.Server_Contents_Folders model=bll.GetModel();
		this.txtFolderID.Text=model.FolderID.ToString();
		this.txtFoldername.Text=model.Foldername;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtFolderID.Text))
			{
				strErr+="FolderID格式错误！\\n";	
			}
			if(this.txtFoldername.Text.Trim().Length==0)
			{
				strErr+="Foldername不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int FolderID=int.Parse(this.txtFolderID.Text);
			string Foldername=this.txtFoldername.Text;


			eChartProject.Model.eChart.Server_Contents_Folders model=new eChartProject.Model.eChart.Server_Contents_Folders();
			model.FolderID=FolderID;
			model.Foldername=Foldername;

			eChartProject.BLL.eChart.Server_Contents_Folders bll=new eChartProject.BLL.eChart.Server_Contents_Folders();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
