﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addCategory : System.Web.UI.Page
{
    DBservices dbs = new DBservices();
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    protected void addctgBTN_Click(object sender, EventArgs e)
    {
        Category cat = new Category();
        cat.CategoryName = cnameTB.Text;
        dbs.insert(cat);
    }
}