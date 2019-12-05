using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Text;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Uri uri = new Uri("http://renfeng.ath.cx/chatterbot/?q=where are you now");

        byte[] postData = Encoding.ASCII.GetBytes("hi");



        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri); 
        String result = String.Empty; 
        request.Method = "POST"; 
        request.ContentType = "application/x-www-form-urlencoded"; 
        request.ContentLength = postData.Length; 
        Stream requestStream = request.GetRequestStream(); 
        requestStream.Write(postData, 0, postData.Length); 
        requestStream.Close(); 
        using (StreamReader reader = new StreamReader(request.GetResponse().GetResponseStream(), true))
        { 
            result = reader.ReadToEnd();
        } 
        


    }
}
