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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
