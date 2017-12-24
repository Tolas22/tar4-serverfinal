using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inventoryManagement : System.Web.UI.Page
{
        string active; int inventory;
    protected void Page_Load(object sender, EventArgs e)
    {
        BoundField bf = new BoundField();

        foreach (var item in GridView1.Rows)
        {

            if (bf.DataField == "category_id")
            {

                bf.DataField = "category_name";
            }
        }
    }
    protected void editFun(object sender, GridViewUpdatedEventArgs e)
    {
        DBservices dbs = new DBservices();
        Product p = new Product();
        //foreach (GridViewRow row in GridView1.Rows)
        //{
        //    for (int i = 0; i < GridView1.Columns.Count; i++)
        //    {
        //        if (GridView1.Columns[i].HeaderText== "inventory")
        //        {
        //             inventory = Convert.ToInt32(row.Cells[i].Text);
        //        }
        //        if (GridView1.Columns[i].HeaderText == "Active")
        //        {
        //             if (row.Cells[i].ToString() == "True")
        //             {
        //    active = "True";
        //}
        //else
        //{
        //    active = "False";
        //}
        
        //        }  
        //    }
        //}
        
       
        p.Active =active;
        p.Inventory =inventory;
        dbs.update(p);
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}