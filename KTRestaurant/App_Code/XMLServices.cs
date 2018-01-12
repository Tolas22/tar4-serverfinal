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
            p.Title = NodeIter.Current.SelectSingleNode("title").Value;
            p.ImagePath = NodeIter.Current.SelectSingleNode("img_url").Value;
            p.Inventory = Convert.ToInt32( NodeIter.Current.SelectSingleNode("inventory").Value);
            p.CategoryId = Convert.ToInt32(NodeIter.Current.SelectSingleNode("category_id").Value);
            p.Active = NodeIter.Current.SelectSingleNode("active").Value;
            list.Add(p);
        }
        return list;

    }
}