using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    List<Sales> SalesList=new List<Sales>();
    List<Product> newList;
    List<Product> FinalList;
    DropDownList DDL;
    List<DropDownList> DDLList = new List<DropDownList>();
    DBservices dbs = new DBservices();
    double totalprice = 0;
    double itemTtlP = 0;
    Label ipriceLBL;
    List<Label> lblList;
    int QNT = 0;
    //    CheckBox cb;


    //protected void Page_PreRender(object sender, EventArgs e)
    //{ // PreRender is called when it still "sees" the previous controls
    //    if (IsPostBack)
    //    {

    //   //     lblList = (List<Label>)Session["MyCartpayment"];
    //        foreach (var item in newList)
    //        {

    //            foreach (Label lbl in lblList)
    //            {
    //                if (item.ProductId == Convert.ToInt32(lbl.ID))
    //                {
    //                    foreach (DropDownList ddl in DDLList)
    //                    {
    //                        if (item.Title == ddl.ID)
    //                        {
    //                            lbl.Text = (Convert.ToInt32(lbl.Text) * Convert.ToInt32(ddl.SelectedValue)).ToString();
    //                        }
    //                    }

    //                }
    //            }

    //        }
    //        //CreateCart();
    //        Session["MyCartpayment"] = lblList;
    //    }
    //    }
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Request.Cookies["firstCartVisitDate"] == null)//בודקים האם זהו הביקור הראשון באתר ע"י קוקיז
        //{

        //    Label1.Text = "הגעתם לדף העגלה בפעם הראשונה";

        //    Response.Cookies["firstCartVisitDate"].Value = DateTime.Now.ToString();
        //    Response.Cookies["firstCartVisitDate"].Expires = DateTime.Now.AddSeconds(60);

        //}
        //else
        //{
        //    Label1.Text = "Your Previous Visit was on: " + Request.Cookies["firstCartVisitDate"].Value;
        //}


        //ProductList p = new ProductList();
     
        if (Session["MyCart"] != null)
        {
        newList = (List<Product>)(Session["MyCart"]);
            CreateCart();
            if (!IsPostBack)
            {
           priceLBL.Text = "Total Price: " + CalculateTotalPrice();
            }
          

        }


        //foreach (var item in newList)
        //{
        //    itemTtlP = item.Price * DDL.SelectedValue;
        //    totalprice += ;
        //}

        //  < span class="selection"><span class="select2-selection select2-selection--single" role="combobox" aria-haspopup="true" aria-expanded="false" tabindex="0" aria-labelledby="select2-o602-container"><span class="select2-selection__rendered" id="select2-o602-container" title="1">1</span><span class="select2-selection__arrow" role="presentation"><b role = "presentation" ></ b ></ span ></ span ></ span >

        //cb = new CheckBox();
        //cb.Checked = true;
        //cb.AutoPostBack = true;
        //cb.ID = item.Id.ToString();
        //cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
        //if (item.Inventory == 0)
        //{
        //    cb.Enabled = false;
        //}









        //foreach (var item in newList)
        //{
        //    totalprice += item.Price;
        //}
        //priceLBL.Text = "</br></br></br>Total Price:" + totalprice + "</br></br></br>";



    }

    private string CalculateTotalPrice()
    {
        double updateTotal = 0;
        
        foreach (Label item in lblList)
        {
            updateTotal += Convert.ToDouble(item.Text);
        }
        return updateTotal.ToString();
    }

    void CreateCart()
    {
        lblList = new List<Label>();
        if (IsPostBack)
        {

        }


        foreach (var item in newList)
        {
            HtmlGenericControl productDiv = new HtmlGenericControl("div");
            HtmlGenericControl infoDiv = new HtmlGenericControl("div");
            HtmlGenericControl imgDiv = new HtmlGenericControl("div");
            productDiv.Attributes["class"] = "product-card";

            //Building the Header row.

            infoDiv.Attributes["class"] = "product-info";
            imgDiv.Attributes["class"] = "product-image";
            Image img = new Image();
            img.ImageUrl = item.ImagePath.ToString().Substring(1);
            infoDiv.InnerHtml = "<img src='" + img.ImageUrl + "'/><h5>Product Name: " + item.Title + "</h5><h5>Category: " + getCatName(Convert.ToInt32(item.CategoryId)) + "</h5>";
            infoDiv.InnerHtml += "<h5>Product Price:" + item.Price + "</h5>";

            DDL = new DropDownList();
            
            DDL.ID = item.Title;

            DDL.AutoPostBack = true;
                for (int j = 0; j <= item.Inventory; j++)
                {
                    ListItem li = new ListItem(j.ToString(), j.ToString());
                    DDL.Items.Add(li);
                    DDL.DataBind();
                }
            ipriceLBL = new Label();
            ipriceLBL.ID = item.ProductId.ToString();

            if (!IsPostBack)
            {
                DDL.SelectedValue = "1";
                ipriceLBL.Text = item.Price.ToString();
               lblList.Add(ipriceLBL);
                Session["MyCartpayment"] = lblList;
            }
            else
            {

                lblList = (List<Label>)(Session["MyCartpayment"]);
                foreach (Label lbl in lblList)
                {
                    if (ipriceLBL.ID == lbl.ID)
                    {
                        ipriceLBL.Text = lbl.Text;
                    }
                }
 
            }
         //   lblList.Add(ipriceLBL);
            DDL.SelectedIndexChanged += new EventHandler(ddl_IndexChange);
            DDLList.Add(DDL);
            infoDiv.Controls.Add(DDL);
       //    infoDiv.Controls.Add(ipriceLBL);
            productDiv.Controls.Add(infoDiv);
            cartPH.Controls.Add(productDiv);
        }

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
   



    private void ddl_IndexChange(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();
        DropDownList ddl = (DropDownList)sender;
        dbs.Name = "*";
        dbs.Table = "productN";
        DataTable dt = dbs.readproductNDataBase();
        foreach (DataRow row in dt.Rows)
        {
        if (ddl.ID ==  row["title"].ToString())
        {
                if (Convert.ToInt32(ddl.SelectedValue) > Convert.ToInt32(row["inventory"]))
                {
                    Response.Write("Someone has purchased this item already there are only " + row["inventory"] + " items left");
                    return;
                }
                lblList = (List<Label>)(Session["MyCartpayment"]);
                foreach (Label label in lblList)
                {
                    if (label.ID == row["product_id"].ToString())
                    {
                        if (Convert.ToInt32(ddl.SelectedValue) >= 5)
                        {
                            label.Text = (Convert.ToInt32(ddl.SelectedValue) * Convert.ToInt32(row["price"]) * 0.9).ToString();
                            discountLBL.Text = "You got a discount of " + (Convert.ToInt32(ddl.SelectedValue) * Convert.ToInt32(row["price"]) * 0.1).ToString() + "on " + ddl.ID;
                        }
                        else
                        {
                        label.Text = (Convert.ToInt32(ddl.SelectedValue) * Convert.ToInt32(row["price"])).ToString();

                        }
                    }

                }

            }




            }
        Session["MyCartpayment"] = lblList;
        priceLBL.Text = "Total Price: " + CalculateTotalPrice();

    }

    protected void payBTN_Click(object sender, EventArgs e)
    {
        foreach (var item in newList)
        {
            Sales sale = new Sales();
            sale.Productid = item.ProductId;
            foreach (Label lbl in lblList)
            {
                if (sale.Productid == Convert.ToInt32(lbl.ID))
                {
                    sale.Totalprice = Convert.ToDouble(lbl.Text);
                }
            }
            foreach (DropDownList ddl in DDLList)
            {
                if (item.Title == ddl.ID)
                {
                    sale.Amount = Convert.ToInt32(ddl.SelectedValue);
                }
            }
  
            
            SalesList.Add(sale);
        }
        
      
        Session["MyCartpayment"] = SalesList;
        Session["totalPrice"] = priceLBL.Text;
        Response.Redirect("CartPayment.aspx");
    }
}
    
