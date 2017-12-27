using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inventoryManagement : System.Web.UI.Page
{
        DBservices dbs = new DBservices();
        Product p = new Product();
        string active; int inventory;
    protected void Page_Load(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    RadioButtonList rbl = (RadioButtonList)row.FindControl("RadioButtonList1");
        //    rbl.SelectedValue = SqlDataSource1.
        //    DropDownList ddl = (DropDownList)row.FindControl("DropDownList1");
        //    if (rbl != null)
        //    {
        //        p.Active = rbl.SelectedValue.ToString();
        //        p.Inventory = Convert.ToInt32(ddl.SelectedValue);
        //        return;
        //    }
        //}
    }
    protected void editFun(object sender, GridViewUpdatedEventArgs e)
    {
        

        foreach (GridViewRow row in GridView1.Rows)
        {
            RadioButtonList rbl = (RadioButtonList)row.FindControl("RadioButtonList1");
            DropDownList ddl = (DropDownList)row.FindControl("DropDownList1");
            if (rbl!= null)
            {
            p.Active = rbl.SelectedValue.ToString();
            p.Inventory = Convert.ToInt32(ddl.SelectedValue);
                return;
            }

        }
        dbs.update(p);

    }



    public static int GetColumnIndexByName(GridView grid, string name)
    {
        foreach (DataControlField col in grid.Columns)
        {
            if (col.HeaderText.ToLower().Trim() == name.ToLower().Trim())
            {
                return grid.Columns.IndexOf(col);
            }
        }

        return -1; // in case there in no such field
    }

    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
}