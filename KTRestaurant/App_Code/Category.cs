using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Category
/// </summary>
public class Category
{
    int categoryID;
    string categoryName;
    public Category()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int CategoryID
    {
        get
        {
            return categoryID;
        }

        set
        {
            categoryID = value;
        }
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