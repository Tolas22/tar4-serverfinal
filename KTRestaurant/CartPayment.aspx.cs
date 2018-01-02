using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartPayment : System.Web.UI.Page
{
    string total;
    CustomValidator Cvalidator = new CustomValidator();
    TextBox TB2 = new TextBox();
    List<Sales> saleslist;
    Product p ;
    DBservices dbs = new DBservices();
    Sales s;
    protected void Page_Load(object sender, EventArgs e)
    {
        total =  (string)(Session["totalPrice"]);
        saleslist = (List<Sales>)(Session["MyCartpayment"]);
        Label1.Text =  total;
    }
    private void UpdateInventory()
    {
        dbs.Name = "*";
        dbs.Table = "productN";
        int productInv = 0;
        if (Session["userLogin"] != null )
        {

            
            //Populating a DataTable from database.
            DataTable dt = dbs.readproductNDataBase();
            foreach (var sale in saleslist)
            {
                foreach (DataRow row in dt.Rows)
                {
                    if (row["product_id"].ToString() == sale.Productid.ToString())
                    {
                        productInv = Convert.ToInt32(row["inventory"]);
                    }
                p = new Product(sale.Productid, (productInv - sale.Amount));//אפשר גם לעשות בכפתור התשלום את הכל כבר 
                sale.Cus_id = (int)Session["userLogin"];
                if (CHbPhone.Checked == true)
                {
                    sale.P_method = "False";
                }
                else
                {
                    sale.P_method = "True";
                }
                    sale.Date = DateTime.Now;
                s = new Sales(sale.Productid,sale.Totalprice,sale.Amount,sale.P_method,sale.Cus_id);
                
                }
                dbs.update(p);
                dbs.insertSale(s);
            }

        }

       
    }
    private void InitializeComponent()
    {


        this.pay.Click += new System.EventHandler(this.pay_Click);


        this.Load += new System.EventHandler(this.Page_Load);


    }
    protected void pay_Click(object sender, EventArgs e)
    {
        string message = "קנייתך השולמה!";

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        sb.Append("<script type = 'text/javascript'>");

        sb.Append("window.onload=function(){");

        sb.Append("alert('");

        sb.Append(message);

        sb.Append("')};");

        sb.Append("</script>");

        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        //  Response.Write("<div>alert('קנייתך הושלמה');<div>");
        UpdateInventory();
    }
    protected void CheckBoxRequired_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (ChBCredit.Checked || CHbPhone.Checked)
        {
            e.IsValid = true;

        }
        CheckBoxRequired.ErrorMessage = "must choose payment method";
    }

    protected void ChBCredit_CheckedChanged(object sender, EventArgs e)
    {
        CHbPhone.Checked = false;//only one can be checked

        if (ChBCredit.Checked == true)
        {


            Label LBL1 = new Label();
            LBL1.Text = "Number Of Payments:";
            PH.Controls.Add(LBL1);
            DropDownList DDL = new DropDownList();
            DDL.EnableViewState = false;

            DDL.ID = "DDL";
            for (int i = 1; i <= 12; i++)
            {
                ListItem li = new ListItem();
                li.Value = i.ToString();

                DDL.Items.Add(li);
            }

            RequiredFieldValidator validator1 = new RequiredFieldValidator();
            validator1.ControlToValidate = "DDL";
            validator1.ForeColor = System.Drawing.Color.Red;
            validator1.Text = "Must Choose Number Of Payments";
            PH.Controls.Add(DDL);
            PH.Controls.Add(validator1);



            RequiredFieldValidator validator2 = new RequiredFieldValidator();

            Label LBL = new Label();
            LBL.Text = "Credit Card Number:";
            PH.Controls.Add(LBL);
            TextBox TB = new TextBox();
            TB.ID = "CCTb";
            TB.EnableViewState = false;
            PH.Controls.Add(TB);
            validator2.ControlToValidate = "CCTb";
            validator2.ForeColor = System.Drawing.Color.Red;
            validator2.Text = "Must Enter Credit Card Number";
            PH.Controls.Add(validator2);



            RequiredFieldValidator validator3 = new RequiredFieldValidator();

            Label LBL2 = new Label();
            LBL2.Text = "T.Z";
            PH.Controls.Add(LBL2);
            TB2.ID = "TZTB2";
            TB2.EnableViewState = false;
            PH.Controls.Add(TB2);
            validator3.ControlToValidate = "TZTB2";
            validator3.ForeColor = System.Drawing.Color.Red;
            //Cvalidator.ClientValidationFunction = "TZvalidation";
            validator3.ErrorMessage = "must enter 9 digits";
            PH.Controls.Add(validator3);





            RequiredFieldValidator validator4 = new RequiredFieldValidator();
            Label LBL3 = new Label();
            LBL3.Text = "Credit Type";
            PH.Controls.Add(LBL3);

            DropDownList DDL2 = new DropDownList();
            DDL2.EnableViewState = false;
            string[] names = new string[] { "master card", "visa", "american express" };
            DDL2.ID = "DDL2";
            for (int i = 0; i < names.Length; i++)
            {
                ListItem li = new ListItem();
                li.Value = names[i].ToString();

                DDL2.Items.Add(li);
            }

            PH.Controls.Add(DDL2);
            validator4.ControlToValidate = "DDL2";
            validator4.ForeColor = System.Drawing.Color.Red;
            validator4.Text = "Must Enter Credit Type";

            PH.Controls.Add(validator4);




        }
        else
        {
            PH.Controls.Clear();
        }
    }
    protected void TZvalidation(object sender, ServerValidateEventArgs args)
    {

        //int[] tznum = new int[9];
        //int sum = 0;
        //int tz = Convert.ToInt32(args.Value);
        //if (args.Value.Length == 9)
        //{
        //    args.IsValid = true;

        //    //while (tz>1)
        //    //{
        //    //    int i = 0;
        //    //    tznum[i] = (tz % 10);
        //    //    tz = tz / 10;
        //    //    i++;
        //    //}
        //    //for (int i = 0; i < tznum.Length ; i++)
        //    //{
        //    //    sum += tznum[i];    
        //    //}
        //    //if (sum % 7 == tznum[0])
        //    //{
        //    //    args.IsValid = true;

        //    //}
        //    //else
        //    //{
        //    //    args.IsValid = false;

        //    //}
        //}
        //else
        //{
        //    args.IsValid = false;
        //}    
        //if (TB2.Text.Length!=9)
        //{
        //Cvalidator.ErrorMessage = "must enter 9 digits";
        //    args.IsValid = false;
        //}
        //   args.IsValid = (args.Value.Length ==9);

    }
    protected void CHbPhone_CheckedChanged(object sender, EventArgs e)
    {
        ChBCredit.Checked = false;//only one can be checked
        RequiredFieldValidator validator2 = new RequiredFieldValidator();




        if (CHbPhone.Checked == true)
        {



        }
        else
        {
            PH.Controls.Clear();
        }
    }
    private void SaveFile(HttpPostedFile file)
    {
        // Specify the path to save the uploaded file to.
        string savePath  = Server.MapPath(".") + "/images/";


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

    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {

            TextBox1.Text = Calendar1.SelectedDate.ToString();

    }
}