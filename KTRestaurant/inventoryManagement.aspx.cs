using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class inventoryManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        BoundField bf = new BoundField();
        
        foreach (var item in GridView1.Rows)
        {

        if (bf.DataField== "category_id")
        {
               
            bf.DataField = "category_name";
        }
       }
    }
    protected void editFun(object sender,GridViewUpdatedEventArgs e)
    {
    
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}