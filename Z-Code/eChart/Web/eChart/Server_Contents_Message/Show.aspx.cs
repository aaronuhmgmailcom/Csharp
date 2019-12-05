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
namespace eChartProject.Web.eChart.Server_Contents_Message
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
		eChartProject.BLL.eChart.Server_Contents_Message bll=new eChartProject.BLL.eChart.Server_Contents_Message();
		eChartProject.Model.eChart.Server_Contents_Message model=bll.GetModel();
		this.lblID.Text=model.ID.ToString();
		this.lblFolderID.Text=model.FolderID.ToString();
		this.lblisOffLine.Text=model.isOffLine?"是":"否";
		this.lblisPublic.Text=model.isPublic?"是":"否";
		this.lblisVariations.Text=model.isVariations?"是":"否";
		this.lblsortOrder.Text=model.sortOrder.ToString();
		this.lblQuestion.Text=model.Question;
		this.lblRelatedID.Text=model.RelatedID.ToString();

	}


    }
}
