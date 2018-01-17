using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
// REMEMBER TO ADD THIS NAMESPACE
using System.Web.Script.Serialization;
using System.Web.Script.Services;

/// <summary>
/// Summary description for ajaxWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService] // REMEMBER TO UNCOMMENT THIS LINE
public class ajaxWebService : System.Web.Services.WebService
{

    public ajaxWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    //קבלת כל הקטגוריות הקיימות
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public string getCategory()
    {
        Product P = new Product();
        //Category c = new Category();
        List<Product> LP = P.getProducts();
        List<Category> ls=new List<Category>() ;
        foreach (Product p in LP)
        {
            Category c = new Category();
            c.CategoryName = getCatName(p.CategoryId);
            ls.Add(c);

        }

        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(ls);
        return jsonStringCategory;
    }
    public string getCatName(int id)
    {
        Product P = new Product();
        //dbs.Name = "*";
        //dbs.Table = "category";
        //Populating a DataTable from database.
        List<Product> LP = P.getProducts();

        foreach (Product row in LP)
        {
            if (id == (Convert.ToInt32(row.CategoryId)))
            {
                return row.CategoryId.ToString();
            }
        }
        return null;
    }


    //קבלת המוצרים באותה הקטגוריה
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]

    public string getProductsByCat(string id)
    {

        int categoryId = Convert.ToInt32(id);
        Category c = new Category();
        //   List<Product> ls = c.getProductsByCat(categoryId);
        List<Product> ls = new List<Product>();
        Product P = new Product();
        List<Product> LP = P.getProducts();
        foreach (Product p in LP)
        {
            if (p.CategoryId==categoryId)
            {
                ls.Add(p);

            }
        }
        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(ls);
        return jsonStringCategory;
    }


    //קבלת כל הפרטים עבור מוצר
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public string getProduct(string id)
    {

        int productId = Convert.ToInt32(id);
        Product p = new Product();
        //        Product p1 = p.getProduct(productId);
         p.ProductId = (productId);

        JavaScriptSerializer js = new JavaScriptSerializer();
        // serialize to string
        string jsonStringCategory = js.Serialize(p);
        return jsonStringCategory;
    }

    
}
