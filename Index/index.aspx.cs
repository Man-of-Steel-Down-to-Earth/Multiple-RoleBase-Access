using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class NewFolder1_index : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["user"] = "";

       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        ds.Clear();
        ds = db.discont("select * from tb_login where username='" + TextBox1.Text + "' and password='" + TextBox2.Text + "'");
        if (ds.Tables[0].Rows.Count != 0)
        {
            string type = ds.Tables[0].Rows[0]["utype"].ToString();
            string status = ds.Tables[0].Rows[0]["st"].ToString();
           // string role = ds.Tables[0].Rows[0]["role"].ToString();
            if (status == "1"  )
            {
               // Session["role"] = ds.Tables[0].Rows[0]["role"].ToString();
                Session["user"] = TextBox1.Text;

                if (type == "ceo")
                {
                    Response.Redirect("~/CEO/home.aspx");
                }
                else if (type == "user")
                {
                    Response.Redirect("~/Employee/home.aspx");
                }
                else if (type == "proxy")
                {
                    Response.Redirect("~/Proxy/home.aspx");
                }


            }
            else
            {
                RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry You been blocked')</Script>");
            }
        }
        else
        {
            RegisterStartupScript("", "<script Language=JavaScript>alert('Invalid username or password')</Script>");
        }

    }
}