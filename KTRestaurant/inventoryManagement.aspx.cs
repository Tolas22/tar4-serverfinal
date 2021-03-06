﻿using System;
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
        if (Session["adminLogin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        Session["grid"] = GridView1;
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
    private void BindData()
    {
        GridView1.DataSource = Session["grid"];
        GridView1.DataBind();
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
   
                int catIndex = GetColumnIndexByName(GridView1, "Category Name");
                int catidIndex = GetColumnIndexByName(GridView1, "category_id");
                string check = e.Row.Cells[catidIndex].Text;
                int cat_id = Convert.ToInt32(e.Row.Cells[catidIndex].Text);
                e.Row.Cells[catIndex].Text = getCatName(cat_id);
            
        }

        
    }




   public void GridView1_RowUpdated(Object sender, GridViewUpdatedEventArgs e)
    {

        // Indicate whether the update operation succeeded.
        if (e.Exception == null)
        {
                ClientScriptManager CSM = Page.ClientScript;       
                string strconfirm = "<script>if(!window.confirm('Are you sure you want to save the changes?')){' GridView1.EditIndex = -1;  BindData(); return false;' }</script>";
                CSM.RegisterClientScriptBlock(this.GetType(), "Confirm", strconfirm, false);
        }
        else
        {
            e.ExceptionHandled = true;
            Message.Text = "An error occurred while attempting to update the row.";
        }
    }

    public void GridView1_RowCancelingEdit(Object sender, GridViewCancelEditEventArgs e)
    {

        // The update operation was canceled. Clear the message label.
        Message.Text = "";

    }

    public void GridView1_RowEditing(Object sender, GridViewEditEventArgs e)
    {
        // The GridView control is entering edit mode. Clear the message label.
        Message.Text = "";
    }

}