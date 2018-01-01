using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addProduct : System.Web.UI.Page
{
    DBservices dbs = new DBservices();
        Product p = new Product();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["adminLogin"] == null)
        {
            Response.Redirect("Login.aspx");
        }
        DDlCat.DataBind();
        DDlCat.Items.Insert(0, new ListItem("Choose Category Name", "0"));

    }
 
    protected void addBTN_Click(object sender, EventArgs e)
    {
        
        int categoryId = Convert.ToInt32(DDlCat.SelectedValue);
        p.CategoryId = categoryId;
        string title = ProductTB.Text;
        string imagePath = "/images/" + FileUpload1.FileName ;
        double price = Convert.ToDouble(PriceTB.Text);
        int inventory = Convert.ToInt32(inventoryTB.Text);
         string active;
        if (ActiveRBL.SelectedValue=="yes")
        {
            active = "True" ;
        }
        else
        {
            active = "False";
        }
       
        p.Title = title;
        p.ImagePath = imagePath;
        p.Price = price;
        p.Inventory = inventory;
        p.Active = active;
        try
        {

            int numEffected = p.insert();

            Response.Write("num of effected rows are " + numEffected.ToString());
        }
        catch (Exception ex)
        {
            Response.Write("There was an error when trying to insert the product into the database" + ex.Message);
        }

        if (FileUpload1.HasFile)
        {
            SaveFile(FileUpload1.PostedFile);

        }

        dbs.insert(p);

    }

    private void SaveFile(HttpPostedFile file)
    {
        // Specify the path to save the uploaded file to.
        string savePath = Server.MapPath(".") + "/images/";

        // Get the name of the file to upload.
        string fileName = FileUpload1.FileName;

        // Create the path and file name to check for duplicates.
        string pathToCheck = savePath + fileName;

        // Create a temporary file name to use for checking duplicates.
        string tempfileName = "";

        // Check to see if a file already exists with the
        // same name as the file to upload.        
        if (System.IO.File.Exists(pathToCheck))
        {
            int counter = 2;
            while (System.IO.File.Exists(pathToCheck))
            {
                // if a file with this name already exists,
                // prefix the filename with a number.
                tempfileName = counter.ToString() + fileName;
                pathToCheck = savePath + tempfileName;
                counter++;
            }

            fileName = tempfileName;

            // Notify the user that the file name was changed.
            UploadStatusLabel.Text = "A file with the same name already exists." +
                "<br />Your file was saved as " + fileName;
        }
        else
        {
            // Notify the user that the file was saved successfully.
            UploadStatusLabel.Text = "Your file was uploaded successfully.";
        }

        // Append the name of the file to upload to the path.
        savePath += fileName;

        // Call the SaveAs method to save the uploaded
        // file to the specified directory.
        FileUpload1.SaveAs(savePath);


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