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
        DBservices dbs = new DBservices();
        CheckBox cb;
        Product p = new Product();
        Category c = new Category();
        List<Product> newList = new List<Product>();
        Product dp = new Product();
        int j = 0;
        Double ChoosenDiscount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ModalPopupExtender1.Show();
            CreateProductList();
        }
    }

    private void cb_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox Cbox = ((CheckBox)sender);
        dbs.Name = "*";
        dbs.Table = "productN";
        DataTable dt = dbs.readproductNDataBase();
        int cbid = Convert.ToInt32(Cbox.ID); 

        if (Cbox.Checked)
        {
            foreach (DataRow item in dt.Rows)
            {
                if ((item["product_name"]).ToString() == "Sea Bass")
                {
                    item["price"] = ChoosenDiscount;
                }
                if (cbid == Convert.ToInt32(item["product_id"]))
                {
                    p.ProductId = Convert.ToInt32(item["product_id"]);
                    p.CategoryId = Convert.ToInt32(item["category_id"]);
                    p.Title = item["title"].ToString();
                    p.ImagePath = item["img_url"].ToString();
                    p.Inventory = Convert.ToInt32(item["inventory"]);
                    newList.Add(p);
                }
            }
        }
        else
        {
            // remove item from list
            foreach (DataRow item in dt.Rows)
            {
                if (cbid == p.ProductId)
                {
                    newList.Remove(p);
                }
            }
        }
    }

    public void CreateProductList()
    {
        dbs.Name = "*";
        dbs.Table = "productN";
        int realprice=0;
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

        #endregion
        html.Clear();
        HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
        #region showproduct
        foreach (DataRow row in dt.Rows)
        {
            if (row["active"].ToString() == "True")
            {
                html.Append("<div class='product-card'>");

                //Building the Header row.
                html.Append("<div class='product-info'>");
                html.Append("<div class='product-image'>" + "<img src='" + row["img_url"] + "'/></div>");
                html.Append("<h5>Product Name: " + row["title"] + "</h5>");
                html.Append("<h5>Product Category: " + getCatName(Convert.ToInt32(row["category_id"])) + "</h5>");
                if (row["title"].ToString() == "Sea Bass")//בחרנו בסיבס להיות מוצר ההנחה שלנו
                {
                    row["price"] = ChoosenDiscount; 
                html.Append("<h5 class='line'>Product Price:<h5 class='realprice line '>was : " + realprice+" </h5>" + row["price"] + "</h5>");}
                else
                {
                    html.Append("<h5>Product Price:" + row["price"] + "</h5>");

                }
                html.Append("<h5>Product Inventory: " + row["inventory"] + "</h5>");
                //html.Append("<asp:CheckBox ID='" + row["product_id"] + "' runat='server' AutoPostBack='true' OnCheckedCanged='cb_CheckedChanged()'");
                ////html.Append(" <input type='checkbox' AutoPostBack='true' runat='server' onchange='cb_CheckedChanged()' ID='" + row["product_id"] + "' ");
                //if (Convert.ToInt32(row["inventory"]) == 0)
                //{
                //    html.Append("Enabled='false'");
                //}
                //html.Append("></asp:CheckBox>");
                cb = new CheckBox();
                cb.ID = row["product_id"].ToString();
                cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged);//cb_CheckedChanged;
                if (Convert.ToInt32(row["inventory"]) == 0)
                {
                    cb.Enabled = false;
                }
            }
            html.Append("</div>");
            html.Append("</div>");
        }

  

        //Append the HTML string to Placeholder.
        productsPH.Controls.Add(new Literal { Text = html.ToString() });
      //  productsPH.Controls.AddAt()
        #endregion

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

