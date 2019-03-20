﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication2.Models;

/// <summary>
/// DBServices is a class created by me to provides some DataBase Services
/// </summary>
public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
        //
        // TODO: Add constructor logic here
        //
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
    // This method inserts a car to the cars table 
    //--------------------------------------------------------------------------------------------------
   //הכנסת פרטי משתמש לתוך בסיס נתונים
    public int insertS(SalesPerson S)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("ConnectionStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandS(S);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
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

   
    private String BuildInsertCommandS(SalesPerson S)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}','{6}' )", S.UserName, S.Password, S.FirstName, S.LastName, S.PhoneNumber, S.Area,S.Email);
        String prefix = "INSERT INTO SalesPerson " + "(UserName,Password,FirstName,LastName,PhoneNumber,Area,Email)";
        command = prefix + sb.ToString();

        return command;
    }

    public int insertC(Customer C)
    {

        SqlConnection con;
        SqlCommand cmd;

        try
        {
            con = connect("ConnectionStringName"); // create the connection
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }

        String cStr = BuildInsertCommandC(C);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
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


    private String BuildInsertCommandC(Customer C)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}','{6}','{7}','{8}' )", C.UserName, C.Password, C.FirstName, C.LastName, C.PhoneNumber, C.CompanyName, C.Address, C.City, C.Country);
        String prefix = "INSERT INTO Customer " + "(UserName,Password,FirstName,LastName,PhoneNumber,CompanyName,Address,CityName,CountryName)";
        command = prefix + sb.ToString();

        return command;
    }


    public List<City> Read(string conString, string tableName)
    {

        SqlConnection con;
        List<City> f = new List<City>();

        try
        {

            con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM " + tableName;

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                City c = new City();
      
                c.Name = Convert.ToString(dr["cityName"]).TrimEnd();


                f.Add(c);
            }
            return f;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

    }
    //הכנסת תחביבים לטבלה מקשרת תחביבים של משתמשים
    //public int insert1(Person p,int num)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringName"); // create the connection

    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //        // helper method to build the insert string

    //              // create the command

    //    try
    //    {

    //        int change = 0;
    //        for (int i = 0; i < p.Hobbies.Count; i++)
    //        {
    //            String cStr = BuildInsertCommand1(num,p.Hobbies[i]);
    //            cmd = CreateCommand(cStr, con);
    //            change = cmd.ExecuteNonQuery();
    //        }
    //        return change;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    //private String BuildInsertCommand1(int personid,int hobbiesid)
    //{
    //    String command;

    //    StringBuilder sb = new StringBuilder();
    //    // use a string builder to create the dynamic string
    //    sb.AppendFormat("Values({0}, {1})", personid, hobbiesid);
    //    String prefix = "INSERT INTO PersonsHobbies " + "(personID, hobbyID) ";
    //    command = prefix + sb.ToString();

    //    return command;
    //}


    //אפשרות לביצוע עריכת נתונים של המשתמש
    //public int Update(Person p)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringName"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    String cStr = BuildUpdateCommand(p);      // helper method to build the insert string

    //    cmd = CreateCommand(cStr, con);             // create the command

    //    try
    //    {

    //        int numEffected = cmd.ExecuteNonQuery();
    //        Update1(p);/// execute the command
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    //private String BuildUpdateCommand(Person mov)
    //{ 
    //    String prefix = "UPDATE PersonTbl1 SET Name='"+mov.Name+"',FamilyName='"+mov.FamilyName+ "', Address='"+mov.Address+ "', Gender='"+mov.Gender+ "', Age="+mov.Age+ ", Height="+mov.Height+ ", Primeum="+mov.Primeum+ ", Phone="+mov.Phone+ ", Password='"+mov.Password+ "', Image='" + mov.Image + "' where id=" + mov.ID;

    //    return prefix;
    //}



    //public int Update1(Person p)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringName"); // create the connection

    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    // helper method to build the insert string

    //    // create the command

    //    try
    //    {

    //        int change = 0;
    //        delete(p);
    //        for (int i = 0; i < p.Hobbies.Count; i++)
    //        {
    //            String cStr = BuildUpdateCommand1(p.ID, p.Hobbies[i]);
    //            cmd = CreateCommand(cStr, con);
    //            change = cmd.ExecuteNonQuery();
    //        }
    //        return change;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    //private String BuildUpdateCommand1(int personid, int hobbiesid)
    //{
    //    String command;

    //    StringBuilder sb = new StringBuilder();
    //    // use a string builder to create the dynamic string
    //    sb.AppendFormat("Values({0}, {1})", personid, hobbiesid);
    //    String prefix = "INSERT INTO PersonsHobbies " + "(personID, hobbyID) ";
    //    command = prefix + sb.ToString();

    //    return command;
    //}
    //--------------------------------------------------------------------
    // Build the Insert command String
    //--------------------------------------------------------------------

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
    //הצגת נתונים
    public List<SalesPerson> Show(string conString, string tableName)
    {

        SqlConnection con;
        List<SalesPerson> f = new List<SalesPerson>();

        try
        {

            con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM " + tableName;

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (dr.Read())
            {
                SalesPerson S = new SalesPerson();

                S.UserName = Convert.ToString(dr["UserName"]).TrimEnd();
                S.Password = Convert.ToString(dr["Password"]).TrimEnd();
                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]);
                S.Area = Convert.ToString(dr["Area"]).TrimEnd();
                S.Email = Convert.ToString(dr["Email"]).TrimEnd();

                
              
                f.Add(S);
            }
            return f;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

    }
    ////אימות נתונים בכניסת משתמש התאמה של שם משתמש וסיסמא מהקלדה בHTML מול SQL
    public SalesPerson Login(string conString, string tableName, string username, string password)
    {

        SqlConnection con;
        SalesPerson S = new SalesPerson();

        try
        {

            con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM " + tableName + " WHERE UserName='" + username + "' and Password='" + password + "'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            
            while (dr.Read())
            {

                S.UserName = Convert.ToString(dr["UserName"]).TrimEnd();
                S.Password = Convert.ToString(dr["Password"]).TrimEnd();
                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]);
                S.Area = Convert.ToString(dr["Area"]).TrimEnd();
                S.Email = Convert.ToString(dr["Email"]).TrimEnd();


            }
            return S;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

    }

    public SalesPerson Test(string conString, string tableName, string username)
    {

        SqlConnection con;
        SalesPerson S = new SalesPerson();

        try
        {

            con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
        }

        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

        try
        {
            String selectSTR = "SELECT * FROM " + tableName + " WHERE UserName='" + username + "'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

                S.UserName = Convert.ToString(dr["UserName"]).TrimEnd();
                S.Password = Convert.ToString(dr["Password"]).TrimEnd();
                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.PhoneNumber = Convert.ToInt32(dr["PhoneNumber"]);
                S.Area = Convert.ToString(dr["Area"]).TrimEnd();
                S.Email = Convert.ToString(dr["Email"]).TrimEnd();


            }
            return S;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);

        }

    }
    ////קריאת נתונים מהSQL
    //public List<Hobbies> Read(string conString, string tableName)
    //{

    //    SqlConnection con;
    //    List<Hobbies> f = new List<Hobbies>();

    //    try
    //    {

    //        con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
    //    }

    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);

    //    }

    //    try
    //    {
    //        String selectSTR = "SELECT * FROM " + tableName;

    //        SqlCommand cmd = new SqlCommand(selectSTR, con);

    //        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

    //        while (dr.Read())
    //        {
    //            Hobbies p = new Hobbies();

    //            p.ID = Convert.ToInt32(dr["id"]);
    //            p.Name = Convert.ToString(dr["name"]).TrimEnd();


    //            f.Add(p);
    //        }
    //        return f;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);

    //    }

    //}


    //--------------------------------------------------------------------
    // Read from the DB into a table
    //--------------------------------------------------------------------
    //public void readCarsDataBase()
    //{

    //    SqlConnection con = connect("carsConnectionString"); // open the connection to the database/

    //    String selectStr = "SELECT * FROM Cars"; // create the select that will be used by the adapter to select data from the DB

    //    SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

    //    DataSet ds = new DataSet("carsDS"); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB

    //    da.Fill(ds);       // Fill the datatable (in the dataset), using the Select command

    //    dt = ds.Tables[0]; // point to the cars table , which is the only table in this case
    //}
    ////הכנסת נתונים לבן אדם ספציפי לפי ID
    //public void Put(string conString, string tableName, int Active, int personID)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {

    //        con = connect("ConnectionStringName"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    String cStr = BuildputCommand(Active, personID);      // helper method to build the insert string

    //    cmd = CreateCommand(cStr, con);             // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command


    //    }
    //    catch (Exception ex)
    //    {
    //        ;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}


    ////--------------------------------------------------------------------
    //// Build the Insert a movie command String
    ////--------------------------------------------------------------------
    //private String BuildputCommand(int a, int p)
    //{



    //    // use a string builder to create the dynamic string

    //    String prefix = "UPDATE PersonTbl1 SET Active=" + a + " where id=" + p;


    //    return prefix;
    //}

    ////מחיקת נתונים מבסיס הנתונים ,לצורך החלפתם בחדשים
    //public int delete(Person p)
    //{

    //    SqlConnection con;
    //    SqlCommand cmd;

    //    try
    //    {
    //        con = connect("ConnectionStringName"); // create the connection
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw (ex);
    //    }

    //    String cStr = BuildDeleteCommand(p.ID);      // helper method to build the insert string

    //    cmd = CreateCommand(cStr, con);             // create the command

    //    try
    //    {
    //        int numEffected = cmd.ExecuteNonQuery(); // execute the command
    //        return numEffected;
    //    }
    //    catch (Exception ex)
    //    {
    //        return 0;
    //        // write to log
    //        throw (ex);
    //    }

    //    finally
    //    {
    //        if (con != null)
    //        {
    //            // close the db connection
    //            con.Close();
    //        }
    //    }

    //}
    //public DBservices ReadFromDataBase(string conString)
    //{

    //    SqlConnection con = null;

    //    try
    //    {
    //        con = connect(conString); // open the connection to the database/

    //        String selectStr = "SELECT * FROM PersonsHobbies "; // create the select that will be used by the adapter to select data from the DB

    //        SqlDataAdapter da = new SqlDataAdapter(selectStr, con); // create the data adapter

    //        DataSet ds = new DataSet(); // create a DataSet and give it a name (not mandatory) as defualt it will be the same name as the DB
    //        da.Fill(ds);                        // Fill the datatable (in the dataset), using the Select command

    //        DataTable dt = ds.Tables[0];

    //        // add the datatable and the dataa adapter to the dbS helper class in order to be able to save it to a Session Object
    //        this.dt = dt;
    //        this.da = da;

    //        return this;
    //    }
    //    catch (Exception ex)
    //    {
    //        // write to log
    //        throw ex;
    //    }
    //    finally
    //    {
    //        if (con != null)
    //        {
    //            con.Close();
    //        }
    //    }
    //}
    //private string BuildDeleteCommand(int personid) { 


    //    string cmdStr = "DELETE FROM PersonsHobbies WHERE personID=" + personid;
    //    return cmdStr;


    //}

}
