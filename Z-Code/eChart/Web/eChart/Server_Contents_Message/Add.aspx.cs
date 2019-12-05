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
namespace eChartProject.Web.eChart.Server_Contents_Message
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
			if(this.txtQuestion.Text.Trim().Length==0)
			{
				strErr+="Question不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRelatedID.Text))
			{
				strErr+="RelatedID格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int ID=int.Parse(this.txtID.Text);
			int FolderID=int.Parse(this.txtFolderID.Text);
			bool isOffLine=this.chkisOffLine.Checked;
			bool isPublic=this.chkisPublic.Checked;
			bool isVariations=this.chkisVariations.Checked;
			int sortOrder=int.Parse(this.txtsortOrder.Text);
			string Question=this.txtQuestion.Text;
			int RelatedID=int.Parse(this.txtRelatedID.Text);

			eChartProject.Model.eChart.Server_Contents_Message model=new eChartProject.Model.eChart.Server_Contents_Message();
			model.ID=ID;
			model.FolderID=FolderID;
			model.isOffLine=isOffLine;
			model.isPublic=isPublic;
			model.isVariations=isVariations;
			model.sortOrder=sortOrder;
			model.Question=Question;
			model.RelatedID=RelatedID;

			eChartProject.BLL.eChart.Server_Contents_Message bll=new eChartProject.BLL.eChart.Server_Contents_Message();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
