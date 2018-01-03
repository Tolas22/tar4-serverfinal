using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class showSales : System.Web.UI.Page
{
    DBservices dbs = new DBservices();
    string li;
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminLogin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        //if (!Page.IsPostBack)
        //{

        //fcategoryDDL.DataBind();
        //fcategoryDDL.Items.Insert(0, new ListItem("Choose Category Name", "0"));
        //}
        
    }

   
   
    //protected void fcategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    Session["selected"]= fcategoryDDL.SelectedItem;

    //}



    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            DataRow dr = ((DataRowView)e.Row.DataItem).Row;
            if (Convert.ToBoolean(dr["p_method"]))
            {
            e.Row.Cells[5].Text = "Credit Card";

            }
            else
            {
                e.Row.Cells[5].Text = "Cash";
            }
        

        }
    }
}
