using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using WebApplication2.Models;
using Desktop.Models;


public class DBservices
{
    public SqlDataAdapter da;
    public DataTable dt;

    public DBservices()
    {
       
    }
    
    public SqlConnection connect(String conString)
    {

        // read the connection string from the configuration file
        string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
        SqlConnection con = new SqlConnection(cStr);
        con.Open();
        return con;
    }


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
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', {4}, '{5}','{6}' )", S.UserName, S.Password, S.FirstName, S.LastName, S.PhoneNumber, S.Area, S.Email);
        String prefix = "INSERT INTO SalesPerson " + "(UserName,Password,FirstName,LastName,PhoneNumber,Area,Email)";
        command = prefix + sb.ToString();

        return command;
    }

    public int insertO(Order O, List<string> parts, List<string> quantity, int addressid)
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

        String cStr = BuildInsertCommandO(O);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);

        // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
            for (int i = 0; i < parts.Count; i++)
            {
                InsertOrderItem(parts[i], quantity[i], numEffected, O.Email, addressid,cmd);

            }
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

    private String BuildInsertCommandO(Order O)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}')", O.Email, O.OrderDate, O.Status);
        String prefix = "INSERT INTO Orders " + "(Email,OrderDate,Status)";
        command = prefix + sb.ToString() + ";SELECT CAST(scope_identity() AS int)";

        return command;
    }

    public int InsertIOC(int itemid, int orderid, string email, string quantity, int addressid,SqlCommand cmd)
    {

        //SqlConnection con;
        //SqlCommand cmd;

        //try
        //{
        //    con = connect2("ConnectionStringName"); // create the connection
        //}
        //catch (Exception ex)
        //{
        //    // write to log
        //    throw (ex);
        //}

        String cStr = BuildInsertCommandIOC(itemid, orderid, email, quantity, addressid);      // helper method to build the insert string

        cmd.CommandText=cStr;          // create the command

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

        //finally
        //{
        //    if (con != null)
        //    {
        //        // close the db connection
        //        con.Close();
        //    }
        //}

    }

    private String BuildInsertCommandIOC(int itemid, int orderid, string email, string quantity, int addressid)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0},{1},'{2}','{3}',{4})", itemid, orderid, email, quantity, addressid);
        String prefix = "INSERT INTO IOC " + "(ItemID,OrderNum,Email,Quantity,AdressID)";
        command = prefix + sb.ToString();

        return command;
    }

    public int InsertOrderItem(string item, string quantity, int orderid, string email, int addressid,SqlCommand cmd)
    {

        //SqlConnection con;
        //SqlCommand cmd;
        Items i = new Items(item, email);

        //try
        //{
        //    con = connect2("ConnectionStringName"); // create the connection
        //}
        //catch (Exception ex)
        //{
        //    // write to log
        //    throw (ex);
        //}

        String cStr = BuildInsertCommandOrderItem(i);      // helper method to build the insert string

        cmd.CommandText=cStr;            // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
            //InsertItemCustomer(numEffected, email);
            InsertIOC(numEffected, orderid, email, quantity, addressid,cmd);
            return numEffected;
        }
        catch (Exception ex)
        {
            return 0;
            // write to log
            throw (ex);
        }

        //finally
        //{
        //    if (con != null)
        //    {
        //        // close the db connection
        //        con.Close();
        //    }
        //}

    }

    private String BuildInsertCommandOrderItem(Items i)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}','{3}')", i.ItemSerial, i.IsStandard, i.ItemName,i.Type);
        String prefix = "INSERT INTO Items " + "(ItemSerial,IsStandard,ItemName,Type)";
        command = prefix + sb.ToString() + ";SELECT CAST(scope_identity() AS int)";

        return command;
    }

    public int InsertItemCustomer(int ItemID, string email,SqlCommand cmd)
    {

        //SqlConnection con;
        //SqlCommand cmd;

        //try
        //{
        //    con = connect2("ConnectionStringName"); // create the connection
        //}
        //catch (Exception ex)
        //{
        //    // write to log
        //    throw (ex);
        //}

        String cStr = BuildInsertCommandtemCustomer(ItemID, email);      // helper method to build the insert string

        cmd.CommandText=cStr;             // create the command

        try
        {

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            //return 0;
            // write to log
            throw (ex);
        }


        //finally
        //{

        //    if (con != null)
        //    {
        //        // close the db connection

        //        con.Close();

        //    }


        //}






    }

    private String BuildInsertCommandtemCustomer(int ItemID, string email)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', {1})", email, ItemID);
        String prefix = "INSERT INTO ItemsCustomer " + "(Email,ItemID)";
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
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Categories> gettype()
    {

        SqlConnection con;
        List<Categories> f = new List<Categories>();

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
            String selectSTR = "SELECT * FROM Categories";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Categories c = new Categories();

                c.Type = Convert.ToString(dr["Type"]).TrimEnd();
                c.Stages= Convert.ToString(dr["Stages"]).TrimEnd();


                f.Add(c);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }

    public Categories FilterType(string type)
    {

        SqlConnection con;
       Categories f = new Categories();

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
            String selectSTR = "SELECT * FROM Categories where [Type]='"+type+"'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

                f.Type = Convert.ToString(dr["Type"]).TrimEnd();
                f.Stages = Convert.ToString(dr["Stages"]).TrimEnd();
                
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Questions> ShowQ(string type, string tableName)
    {

        SqlConnection con;
        List<Questions> f = new List<Questions>();

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
            String selectSTR = "SELECT * FROM " + tableName+ " where Type='"+type+"'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Questions c = new Questions();

                c.Name = Convert.ToString(dr["Name"]).TrimEnd();
                c.QID = Convert.ToInt32(dr["QID"]);
                c.Question = Convert.ToString(dr["Question"]).TrimEnd();


                f.Add(c);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }
    }

    public List<Customer> ShowEmail(string conString, string tableName)
    {

        SqlConnection con;
        List<Customer> f = new List<Customer>();

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
                Customer c = new Customer();

                c.Email = Convert.ToString(dr["Email"]).TrimEnd();
                f.Add(c);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }
  
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
    {

        SqlCommand cmd = new SqlCommand(); // create the command object

        cmd.Connection = con;              // assign the connection to the command object

        cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

        cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

        cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

        return cmd;
    }

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
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

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
        finally
        {
            if (con != null)
            {
                // close the db connection
                con.Close();
            }
        }

    }

    public Address getcustomer(string conString, string tableName, string address)
    {

        SqlConnection con;
        Address S = new Address();

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

            String selectSTR = "SELECT * FROM " + tableName + " WHERE Address='" + address + "'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

                S.Email = Convert.ToString(dr["Email"]).TrimEnd();
                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.PhoneNumber = Convert.ToString(dr["PhoneNumber"]).TrimEnd();
                S.CompanyName = Convert.ToString(dr["CompanyName"]).TrimEnd();
                S.Adress = Convert.ToString(dr["Address"]).TrimEnd();
                S.City = Convert.ToString(dr["City"]).TrimEnd();
                S.ID = Convert.ToInt32(dr["ID"]);


            }
            return S;
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
                // close the db connection
                con.Close();
            }
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
        finally
        {
            if (con != null)
            {
                con.Close();
            }


        }


    }
    
    public Dictionary<int, List<Stage>> read1(string type,string stages)
    {
        Dictionary<int, List<Stage>> dic = new Dictionary<int, List<Stage>>();


        SqlConnection con = null;
        //List<Stage> lc = new List<Stage>();

        try
        {
            con = connect("ConnectionStringName"); // create a connection to the database using the connection String defined in the web config file
            for (int i = 1; i <= int.Parse(stages); i++)
            {
                List<Stage> tmp = new List<Stage>();
                String selectSTR = "SELECT * FROM Stage" + i+" where Type='"+type+"'";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

                while (dr.Read())
                {   // Read till the end of the data into a row
                    Stage p = new Stage();

                    p.ID = Convert.ToString(dr["ID"]);
                    p.Description = Convert.ToString(dr["Description"]);
                    p.Type= Convert.ToString(dr["Type"]);

                    tmp.Add(p);
                }
                dic.Add(i, tmp);
                if (dr != null)
                    dr.Close();
            }


            return dic;
        }
        catch (Exception ex)
        {
            //write to log
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
    
    private String BuilddelCommand(string id,string table,string filed)
    {
        // use a string builder to create the dynamic string

        String prefix = "DELETE FROM "+table+" where "+filed+"=" + id;


        return prefix;
    }

    public List<Address> ShowA(string conString, string tableName)
    {

        SqlConnection con;
        List<Address> f = new List<Address>();

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
                Address S = new Address();

                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.City = Convert.ToString(dr["City"]).TrimEnd();
                S.Adress = Convert.ToString(dr["Address"]).TrimEnd();
                S.PhoneNumber = Convert.ToString(dr["PhoneNumber"]);
                S.CompanyName = Convert.ToString(dr["CompanyName"]).TrimEnd();
                S.ID = Convert.ToInt32(dr["ID"]);
                f.Add(S);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }

    public int insertA(Address A)
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

        String cStr = BuildInsertCommandA(A);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
            InsertAddressCustomer(numEffected,A.Email,cmd);
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

    private String BuildInsertCommandA(Address A)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", A.FirstName, A.LastName, A.PhoneNumber, A.CompanyName, A.Adress, A.City);
        String prefix = "INSERT INTO [Addresses] " + "(FirstName,LastName,PhoneNumber,CompanyName,[Address],City)";
        command = prefix + sb.ToString() + ";SELECT CAST(scope_identity() AS int)";

        return command;
    }

    public int InsertAddressCustomer(int ID, string Email,SqlCommand cmd)
    { 

        //SqlConnection con;
        //SqlCommand cmd;

        //try
        //{
        //    con = connect2("ConnectionStringName"); // create the connection
        //}
        //catch (Exception ex)
        //{
        //    // write to log
        //    throw (ex);
        //}

        String cStr = BuildInsertCommandAddressCustomer(ID, Email);      // helper method to build the insert string

        cmd.CommandText=cStr;             // create the command

        try
        {

            int numEffected = cmd.ExecuteNonQuery();

            return numEffected;
        }
        catch (Exception ex)
        {
            //return 0;
            // write to log
            throw (ex);
        }


        //finally
        //{

        //    if (con != null)
        //    {
        //        // close the db connection

        //        con.Close();

        //    }


        //}



    }

    private String BuildInsertCommandAddressCustomer(int ID, string Email)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, '{1}')", ID, Email);
        String prefix = "INSERT INTO AddressCustomer " + "(AddressID,Email)";
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
        sb.AppendFormat("Values('{0}')", C.Email);
        String prefix = "INSERT INTO Customers " + "(Email)";
        command = prefix + sb.ToString();

        return command;
    }

    public List<Address> FilterAddress(string conString, string tableName, string email)
    {

        SqlConnection con;
        List<Address> f = new List<Address>();

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
            String selectSTR = "SELECT ID,Email,FirstName,LastName,PhoneNumber,CompanyName,[Address],City FROM AddressCustomer inner join Addresses on AddressCustomer.AddressID=Addresses.ID where Email='"+email+"'";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                Address S = new Address();


                S.Email = Convert.ToString(dr["Email"]).TrimEnd();
                S.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                S.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                S.PhoneNumber = Convert.ToString(dr["PhoneNumber"]).TrimEnd();
                S.CompanyName = Convert.ToString(dr["CompanyName"]).TrimEnd();
                S.Adress = Convert.ToString(dr["Address"]).TrimEnd();
                S.City = Convert.ToString(dr["City"]).TrimEnd();
                S.ID = Convert.ToInt32(dr["ID"]);

                f.Add(S);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }

    public int InsertItem(Items item)
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

        String cStr = BuildInsertCommandItem(item);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {

            int numEffected = (int)cmd.ExecuteScalar();
            InsertItemCustomer(numEffected, item.Email,cmd);
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

    private String BuildInsertCommandItem(Items i)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values('{0}', '{1}','{2}','{3}')", i.ItemSerial, i.IsStandard, i.ItemName,i.Type);
        String prefix = "INSERT INTO Items " + "(ItemSerial,IsStandard,ItemName,[Type])";
        command = prefix + sb.ToString() + ";SELECT CAST(scope_identity() AS int)";

        return command;
    }

    public List<Order> GetOrders()
    {

        SqlConnection con;
        List<Order> f = new List<Order>();

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
            String selectSTR = "select IOC.Email,Orders.OrderNum,Orders.OrderDate,Orders.[Status],Items.ItemSerial,"+
                "IOC.Quantity,Addresses.FirstName,Addresses.LastName,Addresses.CompanyName,"+
                "Addresses.City,Addresses.[Address],Addresses.PhoneNumber from IOC inner join Orders on "+
                "IOC.OrderNum = Orders.OrderNum inner join Items on IOC.ItemID = Items.ItemID inner join Addresses on Addresses.ID = IOC.AdressID";

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["OrderNum"]);
                Order S = new Order();
                if (f.Exists(x=>x.OrderId == id))
                {
                    Order tmp =f.Find(x => x.OrderId.Equals(id));
                    tmp.Part.Add(Convert.ToString(dr["ItemSerial"]).TrimEnd());
                    tmp.Quantity.Add(Convert.ToString(dr["Quantity"]).TrimEnd());
                }
                else {
                    S.Email = Convert.ToString(dr["Email"]).TrimEnd();
                    S.OrderId = Convert.ToInt32(dr["OrderNum"]);
                    S.OrderDate = Convert.ToString(dr["OrderDate"]).TrimEnd();
                    S.Address.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                    S.Address.PhoneNumber = Convert.ToString(dr["PhoneNumber"]).TrimEnd();
                    S.Address.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                    S.Address.CompanyName = Convert.ToString(dr["CompanyName"]).TrimEnd();
                    S.Address.City = Convert.ToString(dr["City"]).TrimEnd();
                    S.Status = Convert.ToString(dr["Status"]).TrimEnd();
                    S.Part.Add(Convert.ToString(dr["ItemSerial"]).TrimEnd());
                    S.Quantity.Add(Convert.ToString(dr["Quantity"]).TrimEnd());
                }

                f.Add(S);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }

    }

    public List<Order> FilterOrders(string email)
    {

        SqlConnection con;
        List<Order> f = new List<Order>();

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
            String selectSTR = "select IOC.Email,Orders.OrderNum,Orders.OrderDate,Orders.[Status],Items.ItemSerial," +
                "IOC.Quantity,Addresses.ID,Addresses.FirstName,Addresses.LastName,Addresses.CompanyName," +
                "Addresses.City,Addresses.[Address],Addresses.PhoneNumber from IOC inner join Orders on " +
                "IOC.OrderNum = Orders.OrderNum inner join Items on IOC.ItemID = Items.ItemID inner join Addresses on Addresses.ID = IOC.AdressID where IOC.Email='"+email+"'";
;

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                int id = Convert.ToInt32(dr["OrderNum"]);
                Order S = new Order();
                if (f.Exists(x => x.OrderId == id))
                {
                    Order tmp = f.Find(x => x.OrderId.Equals(id));
                    tmp.Part.Add(Convert.ToString(dr["ItemSerial"]).TrimEnd());
                    tmp.Quantity.Add(Convert.ToString(dr["Quantity"]).TrimEnd());
                }
                else
                {
                    S.Email = Convert.ToString(dr["Email"]).TrimEnd();
                    S.OrderId = Convert.ToInt32(dr["OrderNum"]);
                    S.OrderDate = Convert.ToString(dr["OrderDate"]).TrimEnd();
                    S.Address.FirstName = Convert.ToString(dr["FirstName"]).TrimEnd();
                    S.Address.PhoneNumber = Convert.ToString(dr["PhoneNumber"]).TrimEnd();
                    S.Address.LastName = Convert.ToString(dr["LastName"]).TrimEnd();
                    S.Address.CompanyName = Convert.ToString(dr["CompanyName"]).TrimEnd();
                    S.Address.City = Convert.ToString(dr["City"]).TrimEnd();
                    S.Address.Adress = Convert.ToString(dr["Address"]).TrimEnd();
                    S.Address.Email = Convert.ToString(dr["Email"]).TrimEnd();
                    S.Address.ID = Convert.ToInt32(dr["ID"]);
                    S.Status = Convert.ToString(dr["Status"]).TrimEnd();
                    S.Part.Add(Convert.ToString(dr["ItemSerial"]).TrimEnd());
                    S.Quantity.Add(Convert.ToString(dr["Quantity"]).TrimEnd());
                }

                f.Add(S);
            }
            return f;
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
                // close the db connection
                con.Close();
            }
        }


    }

    public List<Items> FilterItems(string email)
    {

        SqlConnection con;
        List<Items> f = new List<Items>();

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
            String selectSTR ="select Items.ItemID,Items.ItemName,Items.ItemSerial,Items.IsStandard,Items.Type,ItemsCustomer.Email"+
               " from Items INNER JOIN ItemsCustomer ON Items.ItemID = ItemsCustomer.ItemID where ItemsCustomer.Email='"+email+"'";
            

            SqlCommand cmd = new SqlCommand(selectSTR, con);

            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
                
                Items S = new Items();
               
                    S.Email = Convert.ToString(dr["Email"]).TrimEnd();
                    S.ItemID = Convert.ToInt32(dr["ItemID"]);
                    S.ItemName = Convert.ToString(dr["ItemName"]).TrimEnd();
                    S.ItemSerial = Convert.ToString(dr["ItemSerial"]).TrimEnd();
                    S.IsStandard = Convert.ToBoolean(dr["IsStandard"]);
                S.Type = Convert.ToString(dr["Type"]).TrimEnd();

                f.Add(S);

            }
            return f;

        
         
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
                // close the db connection
                con.Close();
            }
        }


    }

    public void del(string id,string table,string filed)
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


        String cStr = BuilddelCommand(id,table,filed);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command


        }
        catch (Exception ex)
        {
            ;
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
    public int updateA(Address A, string id)
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


        String cStr = BuildUpdateCommandA(A,id);      // helper method to build the insert string

        cmd = CreateCommand(cStr, con);             // create the command

        try
        {
            int numEffected = cmd.ExecuteNonQuery(); // execute the command
            return numEffected;

        }
        catch (Exception ex)
        {
            ;
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
    private String BuildUpdateCommandA(Address A,string id)
    {
        String command;


        command = "UPDATE [Addresses] SET FirstName='" + A.FirstName + "', LastName='" + A.LastName + "' , PhoneNumber ='" + A.PhoneNumber + "' , CompanyName='" + A.CompanyName + "' ,[Address]='" + A.Adress + "' , City='" + A.City + "'WHERE ID =" + id;


        return command;

    }

}

