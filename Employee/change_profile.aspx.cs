using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

public partial class Employee_change_profile : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show();
        }
    }
    public void show()
    {
        ds.Clear();
        ds = db.discont("select * from tb_manage_employee where username='" + Session["user"].ToString() + "'");
        Image1.ImageUrl = ds.Tables[0].Rows[0]["pro_pic"].ToString();
        ViewState["img"] = ds.Tables[0].Rows[0]["pro_pic"].ToString();
        TextBox3.Text = ds.Tables[0].Rows[0]["name"].ToString();
        TextBox4.Text = ds.Tables[0].Rows[0]["email"].ToString();
        TextBox5.Text = ds.Tables[0].Rows[0]["address"].ToString();

        TextBox6.Text = ds.Tables[0].Rows[0]["age"].ToString();

        TextBox7.Text = ds.Tables[0].Rows[0]["contact"].ToString();
        TextBox8.Text = ds.Tables[0].Rows[0]["username"].ToString();
        ds.Clear();
        ds = db.discont("select * from tb_login where username='" + Session["user"].ToString() + "'");


        TextBox9.Text = ds.Tables[0].Rows[0]["password"].ToString();
        //TextBox15.Text = ds.Tables[0].Rows[0]["role"].ToString();

    }
    //protected void Button3_Click(object sender, EventArgs e)
    //{
    //    MultiView1.ActiveViewIndex = 0;
    //    ds.Clear();
    //    ds = db.discont("select * from tb_manage_employee where username='" + Session["user"].ToString() + "'");
    //    //   Image1.ImageUrl = ds.Tables[0].Rows[0]["pro_pic"].ToString();
    //    TextBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
    //    TextBox2.Text = ds.Tables[0].Rows[0]["email"].ToString();
    //    TextBox10.Text = ds.Tables[0].Rows[0]["address"].ToString();
    //    TextBox11.Text = ds.Tables[0].Rows[0]["age"].ToString();
    //    TextBox12.Text = ds.Tables[0].Rows[0]["contact"].ToString();
    //    TextBox13.Text = ds.Tables[0].Rows[0]["username"].ToString();
    //    ds.Clear();
    //    ds = db.discont("select * from tb_login where username='" + Session["user"].ToString() + "'");


    //    TextBox14.Text = ds.Tables[0].Rows[0]["password"].ToString();
    //    TextBox16.Text = ds.Tables[0].Rows[0]["role"].ToString();

      

    //}
    protected void Button1_Click(object sender, EventArgs e)
    {
        string str = "";
        if (FileUpload1.HasFile)
        {


            string[] ar = FileUpload1.FileName.Split('.');
            if (ar[1] == "jpg")
            {
                str = "~/CEO/images/" + FileUpload1.FileName;
                FileUpload1.SaveAs(MapPath(str));
            }
            else
            {
                str = ViewState["img"].ToString();
                RegisterStartupScript("", "<script>alert('Please upload your image')</script>");
            }
        }
        else
        {
            str = ViewState["img"].ToString();
        }
        bool b = db.extnon("update tb_manage_employee set name='"+TextBox1.Text+"',address='"+TextBox10.Text+"',age='"+TextBox11.Text+"',contact='"+TextBox12.Text+"',pro_pic='"+str+"'  where username='"+Session["user"].ToString()+"'");
        bool c = db.extnon("update tb_login set password='"+TextBox14.Text+"' where username='"+Session["user"].ToString()+"'");
        MultiView1.ActiveViewIndex = 1;

        show();

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
        ds.Clear();
        ds = db.discont("select * from tb_manage_employee where username='" + Session["user"].ToString() + "'");
        //   Image1.ImageUrl = ds.Tables[0].Rows[0]["pro_pic"].ToString();
        TextBox1.Text = ds.Tables[0].Rows[0]["name"].ToString();
        TextBox2.Text = ds.Tables[0].Rows[0]["email"].ToString();
        TextBox10.Text = ds.Tables[0].Rows[0]["address"].ToString();
        TextBox11.Text = ds.Tables[0].Rows[0]["age"].ToString();
        TextBox12.Text = ds.Tables[0].Rows[0]["contact"].ToString();
        TextBox13.Text = ds.Tables[0].Rows[0]["username"].ToString();
        ds.Clear();
        ds = db.discont("select * from tb_login where username='" + Session["user"].ToString() + "'");


        TextBox14.Text = ds.Tables[0].Rows[0]["password"].ToString();
       // TextBox16.Text = ds.Tables[0].Rows[0]["role"].ToString();

      
    }
    protected void TextBox14_TextChanged(object sender, EventArgs e)
    {
          Label19.Visible = false;
        string input = TextBox14.Text;
          if ((input.Length < 8) || (input.Length > 10))
            {
                Label19.Visible = true;
            }
        else if (!input.Contains('A') && !input.Contains('B') && !input.Contains('C') && !input.Contains('D') && !input.Contains('E') && !input.Contains('F') && !input.Contains('G') && !input.Contains('H') && !input.Contains('I') && !input.Contains('J') && !input.Contains('K') && !input.Contains('L') && !input.Contains('M') && !input.Contains('N') && !input.Contains('O') && !input.Contains('P') && !input.Contains('Q') && !input.Contains('R') && !input.Contains('S') && !input.Contains('T') && !input.Contains('U') && !input.Contains('V') && !input.Contains('W') && !input.Contains('X') && !input.Contains('Y') && !input.Contains('Z'))
            {
                Label19.Visible = true;
            }
        else if (!input.Contains('a') && !input.Contains('b') && !input.Contains('c') && !input.Contains('d') && !input.Contains('e') && !input.Contains('f') && !input.Contains('g') && !input.Contains('h') && !input.Contains('i') && !input.Contains('j') && !input.Contains('k') && !input.Contains('l') && !input.Contains('m') && !input.Contains('n') && !input.Contains('o') && !input.Contains('p') && !input.Contains('q') && !input.Contains('r') && !input.Contains('s') && !input.Contains('t') && !input.Contains('u') && !input.Contains('v') && !input.Contains('w') && !input.Contains('x') && !input.Contains('y') && !input.Contains('z'))
            {
                Label19.Visible = true;
            }
        else  if (!input.Contains('1') && !input.Contains('2') && !input.Contains('3') && !input.Contains('4') && !input.Contains('5') && !input.Contains('6') && !input.Contains('7') && !input.Contains('8') && !input.Contains('9') && !input.Contains('0'))
            {
                Label19.Visible = true;
            }
          else  if (!input.Contains('!') && !input.Contains('~') && !input.Contains('@') && !input.Contains('#') && !input.Contains('%') && !input.Contains('$') && !input.Contains('^') && !input.Contains('&') && !input.Contains('*') && !input.Contains('(') && !input.Contains(')') && !input.Contains('_'))
            {
                Label19.Visible = true;
            }
        
        else
        {
            Label19.Visible = false;
        }

    }
    protected void TextBox13_TextChanged(object sender, EventArgs e)
    {
        Label20.Visible = false;
        string input = TextBox13.Text;
        bool c = IsAlphaNumeric(input);
        if(c==false)
        {
            Label20.Visible = true;
        }
    }
    public bool IsAlphaNumeric(string inputString)
    {
        Regex r = new Regex("^[a-zA-Z0-9 ]+$");

        if ((r.IsMatch(inputString)) && inputString.Length > 3)
            return true;
        else
            return false;
    }
}