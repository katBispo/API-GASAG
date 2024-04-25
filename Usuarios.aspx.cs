using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Sistemas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int userId = 0;

            userId = Convert.ToInt32(Session["user"]);

            Parameter pUser = new Parameter("idUser", DbType.Int32, userId.ToString());

            ObjectDataSource1.SelectMethod = "GetFewFieldsAppForAdm";
            ObjectDataSource1.SelectParameters.Clear();            
            ObjectDataSource1.SelectParameters.Add(pUser);
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int resto = 0;
        int index = e.Row.RowIndex;

        resto = index % 2;

        //Para linha alternativa
        if (e.Row.RowType == DataControlRowType.DataRow && resto == 1)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#DCDCDC'; this.style.cursor='hand';");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#E6E6FA';");
        }
        //Para linha normal
        else if (e.Row.RowType == DataControlRowType.DataRow && resto == 0)
        {
            e.Row.Attributes.Add("onMouseOver", "this.style.backgroundColor='#DCDCDC'; this.style.cursor='hand';");
            e.Row.Attributes.Add("onMouseOut", "this.style.backgroundColor='#F8F8FF';");
        }
        
        if (e.Row.RowType == DataControlRowType.DataRow || e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[3].Text = Server.HtmlDecode(e.Row.Cells[3].Text).ToString();
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string idApp = "";
        int index;
        GridViewRow row;

        try
        {
            if (e.CommandName == "UsuariosSemAcess")
            {
                //string lvStrItemId = Request.QueryString["idApp"];

                index = Convert.ToInt32(e.CommandArgument);
                row = GridView1.Rows[index];
                idApp = row.Cells[2].Text;

                //Response.Write("valor celula: " + idApp);
                Session["idApp"] = idApp;
                Response.Redirect("MeusUsuarios.aspx?idApp=" + idApp + "#ancora");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }

        if (e.CommandName == "TodosUsuarios")
        {
            //string lvStrItemId = Request.QueryString["idApp"];

            index = Convert.ToInt32(e.CommandArgument);
            row = GridView1.Rows[index];
            idApp = row.Cells[2].Text;

            //Response.Write("valor celula: " + idApp);
            Session["idApp"] = idApp;
            //Response.Redirect("TodosUsuarios.aspx#ancora");
            Response.Redirect("TodosUsuarios.aspx?idApp=" + idApp + "#ancora");
        }       
    }
    
    protected void ObjectDataSource1_ObjectCreating(object sender, ObjectDataSourceEventArgs e)
    {
        e.ObjectInstance = new Usuario();
    }
}
