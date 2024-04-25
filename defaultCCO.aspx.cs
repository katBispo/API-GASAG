using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Services;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

         int userId = 0;
        if (!IsPostBack)
        {
            if (ConfigurationManager.AppSettings["SECURITY_USER"].Equals("true"))
            {
                if (Session["userId"] != null)
                {
                    if (Session["userId"].ToString() != "")
                    {
                        userId = Convert.ToInt32(Session["userId"]);
                        this.updateLinks();
                    }
                    else
                    {
                        Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + "/gasag/");
                    }
                }
                else
                {
                    Response.Redirect("http://" + Request.ServerVariables["SERVER_NAME"] + "/gasag/");
                }
            }
            else
            {
                Session["userId"] = 0;
            }
        }
    }

   

}
