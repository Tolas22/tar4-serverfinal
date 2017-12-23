using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Product
/// \\\-	categoryId המכיל את מספר הקטגוריה (int)

/// </summary>
public class Product
{
    private int categoryId;
    private string title;
    private string imagePath;
    private double price;
    private int inventory;
    public Product()
    {

    }
    public int CategoryId
    {
        get
        {
            return categoryId;
        }

        set
        {
            categoryId = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string ImagePath
    {
        get
        {
            return imagePath;
        }

        set
        {
            imagePath = value;
        }
    }

    public double Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public int Inventory
    {
        get
        {
            return inventory;
        }

        set
        {
            inventory = value;
        }
    }

    public Product(int categoryId, string title, string imagePath, double price, int Inventory)
    {
        CategoryId = categoryId;
        Title = title;
        ImagePath = imagePath;
        Price = price;
        Inventory = inventory;
    }

    public int insert()
    {
        DBservices dbs = new DBservices();
        int numAffected = 0; /*dbs.insert(this);*/
        return numAffected;

    }

}