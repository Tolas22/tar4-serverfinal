using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Sales
/// </summary>
public class Sales
{
    int productid;
    double totalprice;
    int amount;
    string p_method;
    int cus_id;

    public int Productid
    {
        get
        {
            return productid;
        }

        set
        {
            productid = value;
        }
    }

    public double Totalprice
    {
        get
        {
            return totalprice;
        }

        set
        {
            totalprice = value;
        }
    }

    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value;
        }
    }

    public string P_method
    {
        get
        {
            return p_method;
        }

        set
        {
            p_method = value;
        }
    }

    public int Cus_id
    {
        get
        {
            return cus_id;
        }

        set
        {
            cus_id = value;
        }
    }

    public Sales()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Sales(int productid, double totalprice, int amount, string p_method, int cus_id)
    {
        Productid = productid;
        Totalprice = totalprice;
        Amount = amount;
        P_method = p_method;
        Cus_id = cus_id;
    }
}