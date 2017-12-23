using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
        DBservices dbs = new DBservices();
        DataTable dt = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void loginBTN_Click(object sender, EventArgs e)
    {
        dbs.Name = "*";
        dbs.NameDS = "users";
        dbs.Table = "customers";
        dt = dbs.readproductNDataBase();
        foreach (DataRow row in dt.Rows)
        {
            if (row["customer"].ToString() == usernameTB.Value && row["pass"].ToString() == passTB.Value)
            {
                //redirect to next page
                if ((bool)row["cust_type"] == true)
                {
                    //admin page
                    Response.Redirect("inventoryManagement.aspx");
                }
                else
                {
                    //customer page
                    Response.Redirect("ShowProducts.aspx");
                }
            }
      
        }
        wpLBL.Text = "Wrong username or password";
    }
}