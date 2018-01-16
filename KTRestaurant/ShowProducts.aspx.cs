using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class ShowProducts : System.Web.UI.Page
{
    int realprice = 0;
    DBservices dbs = new DBservices();
        CheckBox cb;
        Product p = new Product();
        Category c = new Category();
        List<Product> newList = new List<Product>();
        Product dp = new Product();
        int j = 0;
        Double ChoosenDiscount;
    Double dis;

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["userLogin"] == null && Session["adminLogin"] == null)
        //{
        //    Response.Redirect("Login.aspx");
        //}
        if (!IsPostBack)
        {
            ModalPopupExtender1.Show();
            CreateProductDiscount();
        }
        CreateProductList();
        
    }

    
    public void CreateProductDiscount()
    {
        dbs.Name = "*";
        dbs.Table = "productN";
        //Populating a DataTable from database.
        DataTable dt = dbs.readproductNDataBase();
        //Building an HTML string.
        StringBuilder html = new StringBuilder();
        #region startdiscoountrange
        if (Request.Cookies["firstVisitDate"] == null)//בודקים האם זהו הביקור הראשון באתר ע"י קוקיז
    {

        discountlbl.Text = "This is your first visit to our site,you can get this product 50% just now!!!!!";
        Response.Cookies["firstVisitDate"].Value = DateTime.Now.ToString();


            foreach (DataRow row in dt.Rows)
            {
                if (row["active"].ToString() == "True")
                {
                    if (row["title"].ToString()=="Sea Bass")//בחרנו בסיבס להיות מוצר ההנחה שלנו
                    {
                        realprice = Convert.ToInt32(row["price"]);
                        Product p1 = new Product(Convert.ToInt32(row["category_id"]),row["title"].ToString(), row["img_url"].ToString(), Convert.ToDouble( row["price"]));
                        row["price"]= p1.getDiscount(row["title"].ToString(), 50);
                        ChoosenDiscount = Convert.ToDouble(row["price"]);

                    html.Append("<div class='product-card'>");
                    //Building the Header row.
                    html.Append("<div class='product-image'>" + "<img src='" + row["img_url"] + "'/></div>");
                    html.Append("<div class='product-info'>");
                    html.Append("<h5>Product Name: " + row["title"] + "</h5>");
                    html.Append("<h5>Product Category: " + getCatName(Convert.ToInt32(row["category_id"])) + "</h5>");
                    html.Append("<h5>Product Price: " + row["price"] + "</h5>");
                    html.Append("</div>");
                    html.Append("</div>");
                   discountPH.Controls.Add(new Literal { Text = html.ToString() });
                   
                }
            }

                    }

        Response.Cookies["firstVisitDate"].Expires = DateTime.Now.AddSeconds(20);
            
        }
    else
        {
            foreach (DataRow row in dt.Rows)
            {
                if (row["active"].ToString() == "True")
                {
                    if (row["title"].ToString() == "Sea Bass")//בחרנו בסיבס להיות מוצר ההנחה שלנו
                    {
                        realprice = Convert.ToInt32(row["price"]);
                        Product p1 = new Product(Convert.ToInt32(row["category_id"]), row["title"].ToString(), row["img_url"].ToString(), Convert.ToDouble(row["price"]));
                        row["price"] = p1.getDiscount(row["title"].ToString(), 20);
                        ChoosenDiscount = Convert.ToDouble(row["price"]);


                        html.Append("<div class='product-card'>");
                        //Building the Header row.
                        html.Append("<div class='product-image'>" + "<img src='" + row["img_url"] + "'/></div>");
                        html.Append("<div class='product-info'>");
                        html.Append("<h5>Product Name: " + row["title"] + "</h5>");
                        html.Append("<h5>Product Category: " + getCatName(Convert.ToInt32(row["category_id"])) + "</h5>");
                        html.Append("<h5>Product Price: " + row["price"] + "</h5>");
                        html.Append("</div>");
                        html.Append("</div>");
                        discountPH.Controls.Add(new Literal { Text = html.ToString() });

                    }
                }

            }
            discountlbl.Text = "Your first visit was on " + Request.Cookies["firstVisitDate"].Value + "</br> you can get just now 20% off on this product!!!";

    }
            Session["discount"] = ChoosenDiscount;

        #endregion
       // html.Clear();
        
    }
   
    public void CreateProductList() {
        #region showproduct
        dbs.Name = "*";
        dbs.Table = "productN";
        // int realprice = 0;
        //Populating a DataTable from database.
        //DataTable dt = dbs.readproductNDataBase();
        List<Product> LP = new List<Product>();
//        il.ac.ruppin.proj.WebService pro = new il.ac.ruppin.proj.WebService();
        List<Product> LP2 = new List<Product>();
        

        foreach (Product p in LP)
        {
            HtmlGenericControl productDiv = new HtmlGenericControl("div");
            HtmlGenericControl infoDiv = new HtmlGenericControl("div");
            HtmlGenericControl imgDiv = new HtmlGenericControl("div");
            if (p.Active == "True")
            {
                productDiv.Attributes["class"] = "product-card";


                //Building the Header row.

                infoDiv.Attributes["class"] = "product-info";
                imgDiv.Attributes["class"] = "product-image";
                Image img = new Image();
                img.ImageUrl = p.ImagePath.Substring(0);
                infoDiv.InnerHtml = "<img src='" + img.ImageUrl + "'/><h5>Product Name: " +p.Title + "</h5><h5>Category: " + getCatName(p.CategoryId) + "</h5>";

                if (p.Title == "Sea Bass")//בחרנו בסיבס להיות מוצר ההנחה שלנו
                {
                    p.Price = ChoosenDiscount;

                    infoDiv.InnerHtml += "<h5 class='line'>Product Price:<h5 class='realprice line '>was : " + realprice + " </h5>" + p.Price + "</h5>";
                }
                else
                {
                    infoDiv.InnerHtml += "<h5>Product Price:" + p.Price + "</h5>";

                }
                infoDiv.InnerHtml += "<h5>Product Inventory: " + p.Inventory + "</h5>";

                cb = new CheckBox();
                cb.ID = p.ProductId.ToString();
                //cb.AutoPostBack = true;
                cb.CheckedChanged += new EventHandler(cb_CheckedChanged);//cb_CheckedChanged;
                if (p.Inventory <= 0)
                {
                    cb.Enabled = false;
                }
                infoDiv.Controls.Add(cb);
            }

            productDiv.Controls.Add(infoDiv);
            productsPH.Controls.Add(productDiv);
        }
        #endregion

    }
    void cb_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox Cbox = ((CheckBox)sender);
        dbs.Name = "*";
        dbs.Table = "productN";
        DataTable dt = dbs.readproductNDataBase();
        int cbid = Convert.ToInt32(Cbox.ID);
        Product LP = new Product();

        if (Cbox.Checked)
        {
                foreach (DataRow item in dt.Rows)
            {
              
                if (cbid == Convert.ToInt32(item["product_id"]))
                {
                    LP.ProductId = Convert.ToInt32(item["product_id"]);
                    LP.CategoryId = Convert.ToInt32(item["category_id"]);
                    LP.Title = item["title"].ToString();
                    LP.ImagePath = item["img_url"].ToString();
                    if ((item["title"]).ToString() == "Sea Bass")
                    {
                        LP.Price = (double)Session["discount"];
                    }
                    else
                    {

                        LP.Price = Convert.ToInt32(item["price"].ToString());
                    }
                    LP.Inventory = Convert.ToInt32(item["inventory"]);
                    newList.Add(LP);
                }
            }
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
    protected void addCartBTN_Click(object sender, EventArgs e)
    {   
        Session["MyCart"] = newList;
        Response.Redirect("Cart.aspx");
    }
}

