using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
 
    string categoryName;
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public string CategoryName
    {
        get
        {
            return categoryName;
        }

        set
        {
            categoryName = value;
        }
    }
}