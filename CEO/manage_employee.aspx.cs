using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

public partial class CEO_manage_employee : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    string str = "";
    string usr = "";
    string pass = "";
    mail ma = new mail();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ds.Clear();
            ds = db.discont("select * from [tb_manage_employee]");
            DataList1.DataSource = ds;
            DataList1.DataBind();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username = "";
        usr = TextBox1.Text + db.MakePwd(5);
        username = db.extscalr("select username from tb_login where username='" + usr + "' or email='" + TextBox3.Text + "'");
        if (username == "")
        {

            pass = TextBox1.Text + db.MakePwd(5);
            if (FileUpload1.HasFile)
            {
                string[] ar = FileUpload1.FileName.Split('.');
                if (ar[1] == "jpg")
                {
                    str = "~/CEO/images/" + "123" + FileUpload1.FileName;
                    FileUpload1.SaveAs(MapPath(str));
                }
                else
                {
                    RegisterStartupScript("", "<script>alert('Please upload your image')</script>");
                }



            }
            else
            {
                str = "~/CEO/images/" + "123" +"de7.jpg";
                FileUpload1.SaveAs(MapPath(str));
            }
            string skey = db.MakePwd(3) + db.numpassword(4);
            string tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + usr);
            Directory.CreateDirectory(tok_path);
            string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + usr + "/" + usr + ".pbl");



            string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + usr + "/" + usr + ".pri");
           

            rsa_algorithm rsa = new rsa_algorithm();
            rsa.emp_generatkey(tok_path, public_path, private_path);
            string read_project = File.ReadAllText(private_path);
            bool b = db.extnon("insert into tb_manage_employee values('" + TextBox1.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + usr + "','" + RadioButtonList1.SelectedItem.Text + "','" + TextBox2.Text + "','" + TextBox5.Text + "','" + str + "','" + skey + "')");
            bool c = db.extnon("insert into tb_login values('" + TextBox3.Text + "','" + usr + "','" + pass + "','" + 1 + "','user')");
           
            string dwnld_path = Server.MapPath("~/RSA_KEYS/token_key/"+usr+".txt");
            string s = File.ReadAllText(private_path);
            File.WriteAllText(dwnld_path, s);

            if (b == c == true)
            {
                TextBox1.Text = TextBox2.Text = TextBox3.Text = TextBox4.Text = TextBox5.Text = null;
                RadioButtonList1.ClearSelection();
                ma.send_msg("Your secretKey", skey);
                ma.send_msg_attachment("Your Private Key","private", dwnld_path);

                ma.send_msg("Your UserId and Password are :", "UserName:" + usr + " Password:" + pass);
                ds.Clear();
                ds = db.discont("select * from [tb_manage_employee]");
                DataList1.DataSource = ds;
                DataList1.DataBind();
                RegisterStartupScript("", "<script Language=JavaScript>alert('Successfully Inserted')</Script>");

            }

        }
        else
        {

            RegisterStartupScript("", "<script Language=JavaScript>alert('You Already have an account with this email address')</Script>");

        }
    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        Label1.Visible = false;
        bool c = IsAlphaNumeric(TextBox1.Text);
        if((c==false)&&(TextBox1.Text.Length<=3))
        {
            Label1.Visible = true;
        }
    }
    public bool IsAlphaNumeric(string inputString)
    {
        Regex r = new Regex("^[a-zA-Z ]+$");
  
        if ((r.IsMatch(inputString)) && inputString.Length > 3)
            return true;
        else
            return false;
    }
}