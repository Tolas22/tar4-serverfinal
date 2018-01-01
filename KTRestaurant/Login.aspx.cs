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
        Page.ClientScript.RegisterStartupScript(this.GetType(), "statusup", "SetDefaultPass('');", true);

        if (!IsPostBack)

        {

            if (Request.Cookies["userid"] != null)

                usernameTB.Value = Request.Cookies["userid"].Value;

            if (Request.Cookies["pwd"] != null)

                passTB.Attributes.Add("value", Request.Cookies["pwd"].Value );
            if (Request.Cookies["userid"] != null && Request.Cookies["pwd"] != null)
                saveCB.Checked = true;
        }
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
                    Session["adminLogin"] = row["cust_id"];
                    if (saveCB.Checked)
                    {
                        Response.Cookies["userid"].Value = usernameTB.Value;
                        Response.Cookies["pwd"].Value = passTB.Value;
                        Response.Cookies["userid"].Expires = DateTime.Now.AddMinutes(1);
                        Response.Cookies["pwd"].Expires = DateTime.Now.AddMinutes(1);
                    }
                    Response.Redirect("inventoryManagement.aspx");
                }
                else
                {
                    //customer page
                    Session["userLogin"] = row["cust_id"];
                    if (saveCB.Checked)
                    {
                        Response.Cookies["userid"].Value = usernameTB.Value;
                        Response.Cookies["pwd"].Value = passTB.Value;
                        Response.Cookies["userid"].Expires = DateTime.Now.AddMinutes(1);
                        Response.Cookies["pwd"].Expires = DateTime.Now.AddMinutes(1);
                    }
                    Response.Redirect("ShowProducts.aspx");

                }
            }
      
        }
        wpLBL.Text = "Wrong username or password";
    }


}