﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Servicesf
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;
    private string table;
    private string name;
    private string nameDS;

    public string Table
    {
        get
        {
            return table;
        }

        set
        {
            table = value;
        }
    }

    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public string NameDS
    {
        get
        {
            return nameDS;
        }

        set
        {
            nameDS = value;
        }
    }

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //
    public List<Product> readproducts()
    {

        SqlConnection con=null;

        try
        {


            con = connect("productNDBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM productN";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Product> products = new List<Product>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                Product p = new Product();
                p.ProductId = Convert.ToInt32(dr["product_id"]);
                p.CategoryId = Convert.ToInt32(dr["category_id"]);
                p.Title = (dr["title"]).ToString();
                p.ImagePath =( dr["img_url"]).ToString();
                p.Price =Convert.ToDouble (dr["price"]);
                p.Inventory =Convert.ToInt32 (dr["inventory"]) ;
                p.Active = (dr["active"]).ToString();

                products.Add(p);
            }

            return products;
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }


        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

       
    }
    public List<Category> readcategory()
    {

        SqlConnection con = null;

        try
        {


            con = connect("productNDBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            string selectSTR = "SELECT*FROM category";
            SqlCommand cmd = new SqlCommand(selectSTR, con);
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
            List<Category> categories = new List<Category>();
            while (dr.Read())
            {   // Read till the end of the data into a row
                Category c = new Category();
               c.CategoryName= dr["category_name"].ToString();

                categories.Add(c);
            }

            return categories;
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }


        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
        //--------------------------------------------------------------------------------------------------
        // This method creates a connection to the database according to the connectionString name in the web.config 
        //--------------------------------------------------------------------------------------------------
        public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }

    //--------------------------------------------------------------------------------------------------
    // This method inserts 
    //--------------------------------------------------------------------------------------------------
    public int insert(Category cat)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("productNDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(cat);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    //--------------------------------------------------------------------
    // insert a Product
    //--------------------------------------------------------------------
    public int insert(Product pdt)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("productNDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(pdt);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the Insert a category command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Category cat)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}')", cat.CategoryName);
        String prefix = "INSERT INTO category " + "(category_name) ";
        command = prefix + sb.ToString();

        return command;
    }

    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Product pdt)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}' ,'{2}', {3}, {4}, '{5}')", pdt.CategoryId, pdt.Title,pdt.ImagePath, pdt.Price, pdt.Inventory, pdt.Active);
        String prefix = "INSERT INTO productN " + "(category_id, title, img_url, price, inventory, active) ";
        command = prefix + sb.ToString();

        return command;
    }
    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

    //---------------------------------------------------------------------------------
    // Create the SqlCommand
    //---------------------------------------------------------------------------------

   

    //--------------------------------------------------------------------
    // Read from the DB into a table
    //--------------------------------------------------------------------
    public DataTable readproductNDataBase()
    {

        SqlConnection con = connect("productNDBConnectionString"); // open the connection to the database/

        String selectStr = "SELECT " +Name+ " FROM " + Table; // create the select that will be used by the adapter to select data from the DB

        SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

           DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB

        da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command
      //  da.Fill(dt);
        dt = ds.Tables[0]; // point to the cars table , which is the only table in this case
        return dt;
    }

    public DataTable readCategoryDataBase()
    {

        SqlConnection con = connect("productNDBConnectionString"); // open the connection to the database/

        String selectStr = "SELECT " + Name + " FROM " + Table; // create the select that will be used by the adapter to select data from the DB

        SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

        DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB

        da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command
                           //  da.Fill(dt);
        dt = ds.Tables[1]; // point to the cars table , which is the only table in this case
        return dt;
    }

    //--------------------------------------------------------------------
    // insert a movie
    //--------------------------------------------------------------------
    //--------------------------------------------------------------------
    // insert a Product
    //--------------------------------------------------------------------
    public int update(Product pdt)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("productNDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildUpdateCommand(pdt);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }


    //--------------------------------------------------------------------
    // Build the Insert a category command String
    //--------------------------------------------------------------------
    private String BuildUpdateCommand(Product pdt)
    {
        String command;
        
        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        String prefix = "UPDATE productN SET inventory = " +pdt.Inventory+ " Where product_id = " + pdt.ProductId ;
        command = prefix;

        return command;
    }
    //--------------------------------------------------------------------
    // insert a Product
    //--------------------------------------------------------------------
    public int insertSale(Sales sale)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("productNDBConnectionString"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommand(sale);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }
    private String BuildInsertCommand(Sales sale)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, {1} ,{2}, '{3}', {4}, '{5}')", sale.Productid, sale.Totalprice, sale.Amount, sale.P_method, sale.Cus_id, sale.Date);
        String prefix = "INSERT INTO sales " + "(product_id, total_price, amount, p_method, cust_id, Date) ";
        command = prefix + sb.ToString();

        return command;
    }

}

