using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for dbconect
/// </summary>
public class dbconect
{
    SqlConnection con = new SqlConnection("server=.;uid=sa;pwd=admin123;database=db_RBAC");
    SqlCommand cmd;
    SqlDataAdapter adp;
    SqlDataReader rd;
    DataSet ds = new DataSet();

    public bool extnon(string str)
    {
        //try
        //{
            con.Close();
            cmd = new SqlCommand(str, con);
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        //}
        //catch (Exception ex)
        //{

        //    return false;
        //}
        


    }
    public SqlDataReader extread(string str)
    {
        con.Close();
        cmd = new SqlCommand(str, con);
        con.Open();
        rd = cmd.ExecuteReader();
        return rd;

    }
    public string extscalr(string str)
    {
        string name = "";
        try
        {
            con.Close();
            cmd = new SqlCommand(str, con);
            con.Open();
            name = cmd.ExecuteScalar().ToString();
            return name;
        }
        catch(Exception ex)
        {

          return   name;
           
        }
    }
    public DataSet discont(string str)
    {
        //try
        //{
            adp = new SqlDataAdapter(str, con);
            adp.Fill(ds);
            return ds;
        //}
        //catch (Exception ex)
        //{

        //    return ds;

        //}
    }
    DataSet ds1 = new DataSet();
    DataSet ds2 = new DataSet();
    public DataSet discont1(string str)
    {
        try
        {
            ds1.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(ds1);
            return ds1;
        }
        catch (Exception ex)
        {

            return ds1;
        }
    }
    public DataSet discont2(string str)
    {
        try
        {
            ds2.Clear();
            adp = new SqlDataAdapter(str, con);
            adp.Fill(ds2);
            return ds2;
        }
        catch (Exception ex)
        {

            return ds2;
        }

    }
    public string MakePwd(int pl)
    {
        string possibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        char[] passwords = new char[pl];
        Random rd = new Random();
        for (int i = 0; i < pl; i++)
        {
            passwords[i] = possibles[rd.Next(0, possibles.Length)];

        }
        return new string(passwords);


    }

    public string numpassword(int pl)
    {
        {
            string possibles = "@$1234567890";
            char[] passwords = new char[pl];
            Random rd = new Random();
            for (int i = 0; i < pl; i++)
            {
                passwords[i] = possibles[rd.Next(0, possibles.Length)];

            }
            return new string(passwords);
        }
    }


   
}