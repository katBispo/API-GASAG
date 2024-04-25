using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string user = "";
        string referrer = "";

        //string server = Request.UrlReferrer.ToString();
        try
        {
            referrer = Request.UrlReferrer.ToString();
            user = Request.QueryString["userId"];
            //Response.Write(referrer);
        }
        catch (Exception ex)
        {
            referrer = null;
            user = null;
            //Response.Write("exceção");
        }
        

		if (!IsPostBack)
		{
			if ((Session["user"] != null) && (Session["user"].ToString() != ""))
			{
				Log.Logar("Session[user] on redirect to HomeUser.aspx = '" + Session["user"].ToString() + "'");
                Response.Write("1");
                Response.Redirect("HomeUser.aspx");
			}
			else
			{
				if (user != null && referrer != null)
				{
					Session["user"] = user;
					Log.Logar("Session[user] on redirect to HomeUser.aspx = '" + Session["user"].ToString() + "'");

                    Response.Write("2"); 
                    //Response.Redirect("HomeUser.aspx");
				}
			}
		}
		else
		{
			if ((Session["user"] != null) && (Session["user"].ToString() != ""))
			{
				Response.Write("3");
				//Response.Redirect("HomeUser.aspx");
			}
			else
			{
				if (user != null && referrer != null)
				{
					Session["user"] = user;
					Log.Logar("Session[user] on redirect to HomeUser.aspx = '" + Session["user"].ToString() + "'");

                    Response.Write("4"); 
                    //Response.Redirect("HomeUser.aspx");
				}
			}
		}
        
    }
}
