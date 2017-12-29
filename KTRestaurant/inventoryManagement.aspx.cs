using System;
using System.Collections.Generic;
using System.Data;
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
    public string getCatName(int id)
    {
        dbs.Name = "*";
        dbs.Table = "category";
        //Populating a DataTable from database.
        DataTable dt = dbs.readproductNDataBase();


        foreach (DataRow row in dt.Rows)
        {
            if (id == (Convert.ToInt32(row["category_id"])))
            {
                return row["category_name"].ToString();
            }
        }
        return null;
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int cat_id = Convert.ToInt32(e.Row.Cells[1].Text);
            e.Row.Cells[2].Text = getCatName(cat_id);
        }
    }
}