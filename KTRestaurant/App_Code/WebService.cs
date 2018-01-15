using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Xml.XPath;

/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
    public string getProducts()
    {
        XPathNavigator nav;
        XPathDocument docNav;

        // Open the XML.
        string fname = Server.MapPath(".") + "/xml\\WS.xml";
        docNav = new XPathDocument(fname);

        // Create a navigator to query with XPath.
        nav = docNav.CreateNavigator();

 

        
        List<Product> prods = new List <Product>();
        XMLServices XMS = new XMLServices();
        prods =  XMS.readProducts(nav);

        JavaScriptSerializer js = new JavaScriptSerializer();
        string jsonString = js.Serialize(prods);
        return jsonString;
    }

}
