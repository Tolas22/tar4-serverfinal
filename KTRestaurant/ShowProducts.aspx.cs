using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ShowProducts : System.Web.UI.Page
{
    //    CheckBox cb;
    //    Product p = new Product();
    //    Category c = new Category();
    //    ProductList pl = new ProductList();
    //    List<Product> newList = new List<Product>();
    //    Product dp = new Product();
    //    int j = 0;

    //    protected void Page_Load(object sender, EventArgs e)
    //    {
    //        if (Request.Cookies["firstVisitDate"] == null)
    //        {

    //            discountlbl.Text = "This is your first visit to our site";
    //            Response.Cookies["firstVisitDate"].Value = DateTime.Now.ToString();
    //            // note that if we do set the expires to a specific date in the future ,
    //            // it will be removed when the browser is closed

    //            foreach (var item in dp.getProducts())
    //            {
    //                if (j == 3)
    //                {
    //                    HtmlGenericControl myDiv2 = new HtmlGenericControl("div");

    //                    myDiv2.Attributes["class"] = "myClass";
    //                    item.Price = item.Price * 0.5;
    //                    Image img = new Image();
    //                    img.ImageUrl = item.ImagePath;
    //                    Label l1 = new Label();
    //                    l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //                    "</br> Product Name: " + item.Title.ToString() +
    //                    "</br> Product Category: " + item.category.Name +
    //                    "</br> Product Price: " + item.Price.ToString();
    //                    cb = new CheckBox();
    //                    cb.ID = item.Id.ToString();
    //                    cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged);
    //                    //cb_CheckedChanged;
    //                    if (item.Inventory == 0)
    //                    {
    //                        cb.Enabled = false;
    //                    }
    //                    myDiv2.Controls.Add(img);
    //                    myDiv2.Controls.Add(l1);
    //                    //myDiv2.Controls.Add(cb);
    //                    discountPH.Controls.Add(myDiv2);
    //                }

    //                j++;

    //            }
    //            Response.Cookies["firstVisitDate"].Expires = DateTime.Now.AddSeconds(200);
    //        }
    //        else
    //        {
    //            discountlbl.Text = "Your first visit was on " + Request.Cookies["firstVisitDate"].Value;
    //            foreach (var item in dp.getProducts())
    //            {
    //                if (j == 3)
    //                {
    //                    HtmlGenericControl myDiv2 = new HtmlGenericControl("div");

    //                    myDiv2.Attributes["class"] = "myClass";
    //                    item.Price = item.Price * 0.8;
    //                    Image img = new Image();
    //                    img.ImageUrl = item.ImagePath;
    //                    Label l1 = new Label();
    //                    l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //                    "</br> Product Name: " + item.Title.ToString() +
    //                    "</br> Product Category: " + item.category.Name +
    //                    "</br> Product Price: " + item.Price.ToString();
    //                    cb = new CheckBox();
    //                    cb.ID = item.Id.ToString();
    //                    cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
    //                    if (item.Inventory == 0)
    //                    {
    //                        cb.Enabled = false;
    //                    }
    //                    myDiv2.Controls.Add(img);
    //                    myDiv2.Controls.Add(l1);
    //                    //myDiv2.Controls.Add(cb);
    //                    discountPH.Controls.Add(myDiv2);
    //                }
    //                j++;
    //            }

    //        }
    //        //pl.listProducts(p.getProducts(),productsPH, false);
    //        int i = 0;
    //        foreach (var item in p.getProducts())
    //        {


    //            HtmlGenericControl myDiv = new HtmlGenericControl("div");
    //            myDiv.ID = "myDiv" + i;
    //            myDiv.Attributes["class"] = "myClass";

    //            Image img = new Image();
    //            img.ImageUrl = item.ImagePath;
    //            Label l1 = new Label();
    //            l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //            "</br> Product Name: " + item.Title.ToString() +
    //            "</br> Product Category: " + item.category.Name +
    //            "</br> Product Price: " + item.Price.ToString() +
    //            "</br> Product Invetory: " + item.Inventory.ToString();
    //            cb = new CheckBox();
    //            cb.ID = item.Id.ToString();
    //            cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
    //            if (item.Inventory == 0)
    //            {
    //                cb.Enabled = false;
    //            }

    //            myDiv.Controls.Add(img);
    //            myDiv.Controls.Add(l1);
    //            myDiv.Controls.Add(cb);
    //            productsPH.Controls.Add(myDiv);
    //            i++;


    //        }


    //    }
    //    void cb_CheckedChanged(object sender, EventArgs e)
    //    {
    //        CheckBox Cbox = ((CheckBox)sender);
    //            int cbid = Convert.ToInt32(Cbox.ID);

    //        if (Cbox.Checked)
    //        {
    //            foreach (var item in p.getProducts())
    //            {


    //                if (cbid == item.Id)
    //                {
    //                    newList.Add(item);
    //                }
    //            }
    //        }
    //        else
    //        {
    //            foreach (var item in newList)
    //            {
    //                if (cbid == item.Id)
    //                {
    //                    newList.Remove(item);
    //                }
    //            }
    //        }

    //    }

    //    protected void Button1_Click(object sender, EventArgs e)
    //    {
    //        Label1.Text = "</br>List: </br>";

    //        foreach (var item in newList)
    //        {
    //            Label1.Text += item.Title + "</br>";



    //        }
    //        Session["MyCart"] = newList;
    //        Response.Redirect("Cart.aspx");
    //    }
    //    //public void listProducts(List<Product> pl)
    //    //{
    //    //    int i = 0;
    //    //    foreach (var item in pl)
    //    //    {


    //    //        HtmlGenericControl myDiv = new HtmlGenericControl("div");
    //    //        myDiv.ID = "myDiv" + i;
    //    //        myDiv.Attributes["class"] = "myClass";

    //    //        Image img = new Image();
    //    //        img.ImageUrl = item.ImagePath;
    //    //        Label l1 = new Label();
    //    //        l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //    //        "</br> Product Name: " + item.Title.ToString() +
    //    //        "</br> Product Category: " + item.category.Name +
    //    //        "</br> Product Price: " + item.Price.ToString() +
    //    //        "</br> Product Invetory: " + item.Inventory.ToString();
    //    //        cb = new CheckBox();
    //    //        cb.ID = item.Id.ToString();
    //    //        cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
    //    //        if (item.Inventory == 0)
    //    //        {
    //    //            cb.Enabled = false;
    //    //        }

    //    //        myDiv.Controls.Add(img);
    //    //        myDiv.Controls.Add(l1);
    //    //        myDiv.Controls.Add(cb);
    //    //        productsPH.Controls.Add(myDiv);
    //    //        i++;


    ////}

    ////    }
}

