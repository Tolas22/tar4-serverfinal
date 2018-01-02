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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminLogin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        fcategoryDDL.DataBind();
        fcategoryDDL.Items.Insert(0, new ListItem("Choose Category Name", "0"));
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        DataTable dt = dbs.readproductNDataBase();


    //    foreach (DataRow row in dt.Rows)
    //    {
    //        if (id == (Convert.ToInt32(row["category_id"])))
    //        {
    //            return row["category_name"].ToString();
    //        }
    //    }
    //    return null;
    //}
}
}