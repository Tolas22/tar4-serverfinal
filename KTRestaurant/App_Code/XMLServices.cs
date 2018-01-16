using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.XPath;

/// <summary>
/// Summary description for XMLServices
/// </summary>
public class XMLServices
{
    public XMLServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public List<Product> readProducts(XPathNavigator nav)
    {

        List<Product> list = new List<Product>();
        XPathNodeIterator NodeIter;

        NodeIter = nav.Select("/Products/Product");
        while (NodeIter.MoveNext())
        {
            Product p = new Product();
            p.ProductId = Convert.ToInt32( NodeIter.Current.GetAttribute("product_id", ""));
            p.Title = NodeIter.Current.GetAttribute("title","");
            p.ImagePath = NodeIter.Current.GetAttribute("img_url","");
            p.Inventory = Convert.ToInt32( NodeIter.Current.GetAttribute("inventory",""));
            p.CategoryId = Convert.ToInt32(NodeIter.Current.GetAttribute("category_id", ""));
            p.Active = NodeIter.Current.GetAttribute("active","");
            p.Price = Convert.ToInt32(NodeIter.Current.GetAttribute("price", ""));
            list.Add(p);
        }
        return list;

    }
}