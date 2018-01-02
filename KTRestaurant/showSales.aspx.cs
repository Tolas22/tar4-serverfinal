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

        if (e.Row.RowType == DataControlRowType.DataRow)
        {

            int prodIndex = GetColumnIndexByName(GridView1, "product_id");
            int prodNIndex = GetColumnIndexByName(GridView1, "Product Name");
        //    string check = e.Row.Cells[catidIndex].Text;
            int prod_id = Convert.ToInt32(e.Row.Cells[prodIndex].Text);
            string[] prodCat = getProductName(prod_id);
            e.Row.Cells[prodNIndex].Text = prodCat[0];
            if (fcategoryDDL.SelectedValue != "0" && fcategoryDDL.SelectedValue != prodCat[1])
            {
                e.Row.Visible = false;
            }

        }
  
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
    public string[] getProductName(int id)
    {
        string[] prodcat = new string[2];
        dbs.Name = "*";
        dbs.Table = "productN";
        //Populating a DataTable from database.
        DataTable dt = dbs.readproductNDataBase();


        foreach (DataRow row in dt.Rows)
        {
            if (id == (Convert.ToInt32(row["product_id"])))
            {
                prodcat[0] = row["product_name"].ToString();
                prodcat[1] = row["category_id"].ToString();
            }
        }
        return null;
    }
}
