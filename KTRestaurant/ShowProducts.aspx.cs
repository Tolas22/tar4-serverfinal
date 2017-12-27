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
    //    ProductList pl = new ProductList();
        List<Product> newList = new List<Product>();
        Product dp = new Product();
        int j = 0;
        Double ChoosenDiscount;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ModalPopupExtender1.Show();
        }

        if (!IsPostBack)
        {
            dbs.Name = "*";
            dbs.Table = "productN";
            //Populating a DataTable from database.
            DataTable dt = dbs.readproductNDataBase() ;

            //Building an HTML string.
            StringBuilder html = new StringBuilder();

            foreach (DataRow row in dt.Rows)
            {
            //Table start.
            html.Append("<div class='product-card'>");

            //Building the Header row.
            html.Append("<div class='product-image'>" + "<img src='" + row["img_url"] + "'/></div>");
                html.Append("<div class='product-info'>");
                    html.Append("<h5>Product Name: " + row["title"] + "</h5>");
                html.Append("</div>");

            }
            html.Append("</div>");

            //Building the Data rows.
            //foreach (DataRow row in dt.Rows)
            //{
            //    html.Append("<tr>");
            //    foreach (DataColumn column in dt.Columns)
            //    {
            //        html.Append("<td>");
            //        html.Append(row[column.ColumnName]);
            //        html.Append("</td>");
            //    }
            //    html.Append("</tr>");
            //}

            //Table end.
            //html.Append("</table>");

            //Append the HTML string to Placeholder.
            productsPH.Controls.Add(new Literal { Text = html.ToString() });
        }

        #region startdiscoountrange
        if (Request.Cookies["firstVisitDate"] == null)//בודקים האם זהו הביקור הראשון באתר ע"י קוקיז
        {

            discountlbl.Text = "This is your first visit to our site,you can get this product 50% just now!!!!!";

            Response.Cookies["firstVisitDate"].Value = DateTime.Now.ToString();
            // foreach (var item in dt.Rows)

            //{
            //    if (j == 5)//בחרנו במוצר מספר 6 להיות בהנחה!
            //    {
            //       
      //  HtmlGenericControl mypopupDiv = new HtmlGenericControl("div");

            //        //myDiv2.Attributes["class"] = "myClass";
            //        item.Price = p.getDiscount(j, 50);
            //        ChoosenDiscount = item.Price;
            //        Image img = new Image();
            //        img.ImageUrl = item.ImagePath;
            //        Label l1 = new Label();
            //        l1.Text = "</br> Product Number: " + item.Id.ToString() +
            //        "</br> Product Name: " + item.Title.ToString() +
            //        "</br> Product Price: " + item.Price.ToString();
            //        cb = new CheckBox();
            //        cb.ID = item.Id.ToString();
            //        cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged);//cb_CheckedChanged;
            //        if (item.Inventory == 0)
            //        {
            //            cb.Enabled = false;
            //        }
            //        myDiv2.Controls.Add(img);
            //        myDiv2.Controls.Add(l1);
               //     discountPH.Controls.Add(mypopupDiv);
            //    }

            //    j++;

            //}
            Response.Cookies["firstVisitDate"].Expires = DateTime.Now.AddSeconds(100);
        }
        else
        {
            discountlbl.Text = "Your first visit was on " + Request.Cookies["firstVisitDate"].Value + "</br> you can get just now 20% off on this product!!!";
            //foreach (var item in dp.getProducts())
            //{
            //    if (j == 5)
            //    {
            //        HtmlGenericControl myDiv2 = new HtmlGenericControl("div");
            //        item.Price = p.getDiscount(j, 20);
            //        ChoosenDiscount = item.Price;
            //        Image img = new Image();
            //        img.ImageUrl = item.ImagePath;
            //        Label l1 = new Label();
            //        l1.Text = "</br> Product Number: " + item.Id.ToString() +
            //        "</br> Product Name: " + item.Title.ToString() +
            //        "</br> Product Price: " + item.Price.ToString();
            //        cb = new CheckBox();
            //        cb.ID = item.Id.ToString();
            //        cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
            //        if (item.Inventory == 0)
            //        {
            //            cb.Enabled = false;
            //        }
            //        myDiv2.Controls.Add(img);
            //        myDiv2.Controls.Add(l1);
            //        // myDiv2.Controls.Add(cb);
            //        discountPH.Controls.Add(myDiv2);
            //    }
            //    j++;
            }

        //}
        #endregion

        //pl.listProducts(p.getProducts(),productsPH, false);
        #region mainDiv
    //    int i = 0;
    //    foreach (var item in p.getProducts())//רשימת המוצרים המלאה המופיעה באתר
    //    {



    //        HtmlGenericControl myDiv = new HtmlGenericControl("div");
    //        myDiv.ID = "myDiv" + i;
    //        myDiv.Attributes["class"] = "myClass";
    //        Image img = new Image();
    //        img.ImageUrl = item.ImagePath;
    //        Label l1 = new Label();
    //        if (i == 5)
    //        {
    //            item.Price = ChoosenDiscount;
    //            l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //          "</br> Product Name: " + item.Title.ToString() +
    //          "</br> Product Price:(was 250) " + item.Price.ToString() +
    //          "</br> Product Invetory: " + item.Inventory.ToString();
    //        }
    //        else
    //        {

    //            l1.Text = "</br> Product Number: " + item.Id.ToString() +
    //            "</br> Product Name: " + item.Title.ToString() +
    //            "</br> Product Price: " + item.Price.ToString() +
    //            "</br> Product Invetory: " + item.Inventory.ToString();
    //        }
    //        cb = new CheckBox();
    //        cb.ID = item.Id.ToString();
    //        cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
    //        if (item.Inventory == 0)
    //        {
    //            cb.Enabled = false;
    //        }

    //        myDiv.Controls.Add(img);
    //        myDiv.Controls.Add(l1);
    //        myDiv.Controls.Add(cb);
    //        productsPH.Controls.Add(myDiv);
    //        i++;



        }
    #endregion


    //    void cb_CheckedChanged(object sender, EventArgs e)
    //    {
    //        CheckBox Cbox = ((CheckBox)sender);
    //            int cbid = Convert.ToInt32(Cbox.ID);

    //        if (Cbox.Checked)
    //        {
    //            foreach (var item in p.getProducts())
    //            {
    //               if (item.Id == 6)
    //                    {
    //                        item.Price = ChoosenDiscount;

    //                    }

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

    //   }

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
    public static int GetColumnIndexByName(DataTable table, string name)
    {
        foreach (DataColumn col in table.Columns)
        {
            if (col.ColumnName.ToLower().Trim() == name.ToLower().Trim())
            {
                return table.Columns.IndexOf(col);
            }
        }

        return -1; // in case there in no such field
    }

}

