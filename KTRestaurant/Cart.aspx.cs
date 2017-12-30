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
    List<Product> newList;
    List<Product> FinalList;
    DropDownList DDL;
    DBservices dbs = new DBservices();
    double totalprice = 0;
    double itemTtlP = 0;
    //    CheckBox cb;


    //protected void Page_PreRender(object sender, EventArgs e)
    //{ // PreRender is called when it still "sees" the previous controls

    //    List<Product> idList = getCheckedCBid(newList); // get the id's of the checked checkboxes
    //    foreach (var item in idList)
    //    {
    //        totalPrice += item.Price;
    //    }
    //    priceLBL.Text = "</br></br></br>Total Price:" + totalPrice + "</br></br></br>";



    //}
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

                for (int j = 0; j <= item.Inventory; j++)
                {
                    ListItem li = new ListItem(j.ToString(), j.ToString());
                    DDL.Items.Add(li);
                    DDL.DataBind();
                }
                DDL.ID = item.ProductId.ToString();
                DDL.SelectedValue = "1";
                DDL.SelectedIndexChanged += new EventHandler(ddl_IndexChange);
                infoDiv.Controls.Add(DDL);
                productDiv.Controls.Add(infoDiv);
               cartPH.Controls.Add(productDiv);
            }
          

        }

        foreach (var item in newList)
        {
            itemTtlP = item.Price * DDL.SelectedValue;
            totalprice += ;
        }
        priceLBL.Text = "</br></br></br>Total Price:" + totalprice + "</br></br></br>";
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
    //}
    //void cb_CheckedChanged(object sender, EventArgs e)
    //    {
    //    Label2.Text = "השינוי נשמר";
    //    return;
    //            CheckBox Cbox = ((CheckBox)sender);
    //            int cbid = Convert.ToInt32(Cbox.ID);

    //    if (!Cbox.Checked)
    //    {
    //        for (int i = newList.Count - 1; i >= 0; i--)
    //        {
    //            if (cbid == newList[i].Id)
    //            {
    //                newList.RemoveAt(i);
    //                totalPrice -= newList[i].Price;
    //                priceLBL.Text = "Total Price:" + totalPrice;
    //            }
    //        }

    //    }
    //    else
    //    {
    //        foreach (var item in newList)
    //        {
    //            if (cbid == item.Id)
    //            {
    //                newList.Add(item);
    //               totalPrice += item.Price;
    //               priceLBL.Text = "Total Price:" + totalPrice;

    //            }
    //        }
    //    }

    //           // FinalList = newList;


    //}


    //private List<Product> getCheckedCBid(List<Product> newList)
    //{
    //    List<Product> idList = new List<Product>();
    //    foreach (var item in newList)
    //    {
    //        CheckBox cb = (CheckBox)cartPH.FindControl(item.Id.ToString());
    //        if (cb != null)
    //        {
    //            if (cb.Checked == true)
    //                idList.Add(item);
    //        }
    //    }

    //    return idList;
    //}




    //protected void confirmbtn_Click(object sender, EventArgs e)
    //{
    //    Page_PreRender(sender, e);
    //     Session["MyCartpayment"] = totalPrice;
    //    Response.Redirect("CartPayment.aspx");
    //}



    private void ddl_IndexChange(object sender, EventArgs e)
    {
        DBservices dbs = new DBservices();
        DropDownList ddl = (DropDownList)sender;
        dbs.Name = "*";
        dbs.Table = "productN";
        DataTable dt = dbs.readproductNDataBase();
        foreach (DataRow row in dt.Rows)
        {
        if (ddl.ID ==  row["product_id"].ToString())
        {
                if (Convert.ToInt32(ddl.SelectedValue) > Convert.ToInt32(row["inventory"]))
                {
                    Response.Write("Someone has purchased this item already there are only " + row["inventory"] + " items left");
                    return;
                }

                totalprice += Convert.ToInt32(ddl.SelectedValue) * Convert.ToInt32(row["price"]);
        }

        }
    }

    protected void payBTN_Click(object sender, EventArgs e)
    {


        Session["MyCartpayment"] = totalprice;
    }
}
    
