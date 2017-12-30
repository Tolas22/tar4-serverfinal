using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addCategory : System.Web.UI.Page
{
    DBservices dbs = new DBservices();
    Category cat = new Category();

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void catexistVLD_ServerValidate(object source, ServerValidateEventArgs args)
    {
        if (IsPostBack)
        {

        foreach (GridViewRow item in catGRD.Rows)
        {
            if (cnameTB.Text == item.Cells[1].Text)
            {
                args.IsValid = false;
                Response.Write("new one please");
                cnameTB.Text = "";
                return;
            }
        }
        }
    }

    protected void addctgBTN_Click(object sender, EventArgs e)
    {
        dbs.Name = "*";
        dbs.Table = "category";
        DataTable dt = dbs.readproductNDataBase();

        //foreach (DataRow item in dt.Rows)
        //{
        //    if (item["category_name"]==cnameTB)
        //    {
        //        Response.Write("already exist!");
        //        return;
        //    }
        //}
                if (catexistVLD.IsValid)
        {
            cat.CategoryName = cnameTB.Text;
            dbs.insert(cat);
            
        }
        catGRD.DataBind();
        cnameTB.Text = "";
    }


   
}