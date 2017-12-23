using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CartPayment : System.Web.UI.Page
{
    double total;
    protected void Page_Load(object sender, EventArgs e)
    {
            total =  (double)(Session["MyCartpayment"]);
        Label1.Text = "</br>סכום לתשלום: " + total;

    }

    protected void pay_Click(object sender, EventArgs e)
    {
       
        Response.Write("<script>alert('קנייתך הושלמה');</script>");
    }
}