using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
        List<Product> newList;
        List<Product> FinalList;
        double totalPrice ;
        CheckBox cb;


    protected void Page_PreRender(object sender, EventArgs e)
    { // PreRender is called when it still "sees" the previous controls
        
        List<Product> idList = getCheckedCBid(newList); // get the id's of the checked checkboxes
        foreach (var item in idList)
        {
            totalPrice += item.Price;
        }
        priceLBL.Text = "</br></br></br>Total Price:" + totalPrice + "</br></br></br>";



    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["firstCartVisitDate"] == null)//בודקים האם זהו הביקור הראשון באתר ע"י קוקיז
        {

            Label1.Text = "הגעתם לדף העגלה בפעם הראשונה";

            Response.Cookies["firstCartVisitDate"].Value = DateTime.Now.ToString();
            Response.Cookies["firstCartVisitDate"].Expires = DateTime.Now.AddSeconds(60);

        }
        else
        {
            Label1.Text = "Your Previous Visit was on: " + Request.Cookies["firstCartVisitDate"].Value;
        }

        int i = 0;
        newList = (List<Product>)(Session["MyCart"]);
        //ProductList p = new ProductList();

        if (Session["MyCart"] != null)
        {

            foreach (var item in newList)
            {

                HtmlGenericControl myDiv = new HtmlGenericControl("div");
                myDiv.ID = "myDiv" + i;
                myDiv.Attributes["class"] = "myClass";               
                Image img = new Image();
                img.ImageUrl = item.ImagePath;
                Label l1 = new Label();
                l1.Text = "</br> Product Number: " + item.Id.ToString() +
                "</br> Product Name: " + item.Title.ToString() +
                "</br> Product Price: " + item.Price.ToString() +
                "</br> Product Invetory: " + item.Inventory.ToString();
                cb = new CheckBox();
                cb.Checked = true;
                cb.AutoPostBack = true;
                cb.ID = item.Id.ToString();
                cb.CheckedChanged += new EventHandler(this.cb_CheckedChanged); //cb_CheckedChanged;
                if (item.Inventory == 0)
                {
                    cb.Enabled = false;
                }

                myDiv.Controls.Add(img);
                myDiv.Controls.Add(l1);
                myDiv.Controls.Add(cb);
                cartPH.Controls.Add(myDiv);
                i++;


            }


            //foreach (var item in newList)
            //{
            //    totalPrice += item.Price;
            //}
            //priceLBL.Text = "</br></br></br>Total Price:" + totalPrice+ "</br></br></br>";
           

        }
     
    }
    void cb_CheckedChanged(object sender, EventArgs e)
        {
        Label2.Text = "השינוי נשמר";
        return;
                CheckBox Cbox = ((CheckBox)sender);
                int cbid = Convert.ToInt32(Cbox.ID);

        if (!Cbox.Checked)
        {
            for (int i = newList.Count - 1; i >= 0; i--)
            {
                if (cbid == newList[i].Id)
                {
                    newList.RemoveAt(i);
                    totalPrice -= newList[i].Price;
                    priceLBL.Text = "Total Price:" + totalPrice;
                }
            }

        }
        else
        {
            foreach (var item in newList)
            {
                if (cbid == item.Id)
                {
                    newList.Add(item);
                   totalPrice += item.Price;
                   priceLBL.Text = "Total Price:" + totalPrice;

                }
            }
        }

               // FinalList = newList;
       
       
    }


    private List<Product> getCheckedCBid(List<Product> newList)
    {
        List<Product> idList = new List<Product>();
        foreach (var item in newList)
        {
            CheckBox cb = (CheckBox)cartPH.FindControl(item.Id.ToString());
            if (cb != null)
            {
                if (cb.Checked == true)
                    idList.Add(item);
            }
        }

        return idList;
    }
           

    

    protected void confirmbtn_Click(object sender, EventArgs e)
    {
        Page_PreRender(sender, e);
         Session["MyCartpayment"] = totalPrice;
        Response.Redirect("CartPayment.aspx");
    }
}

    
    
