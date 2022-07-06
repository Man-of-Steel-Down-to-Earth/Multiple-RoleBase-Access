using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Employee_approved_files : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            show_permission_of_files();
            show_permission_of_files_ceo();
            if (GridView1.Rows.Count > 0)
            {

                GridView1.Visible = true;
                Label4.Visible = false;

            }
            else
            {

                GridView1.Visible = false;
                Label4.Visible = true;

            }
        }
    }





    public void show_permission_of_files_ceo()
    {
        ds.Clear();
        ds = db.discont("select * from tb_requested_files r where  r.request_by='" + Session["user"].ToString() + "' and r.request_to not in(select username from tb_manage_employee)");
        GridView2.DataSource = ds;
        GridView2.DataBind();
        List<string> fname = new List<string>();
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            fname.Add(ds.Tables[0].Rows[i]["fname"].ToString());

        }
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {

            for (int j = 0; j < fname.Count; j++)
            {
                string fn = GridView2.Rows[i].Cells[2].Text;
                if (fn == fname[j].ToString())
                {

                    string fid = db.extscalr("select fid from tb_upload where fname='" + fn + "'");
                    string owner_name = db.extscalr("select owner_name from tb_upload where fname='" + fn + "'");
                    string des = db.extscalr("select discription from tb_upload where fname='" + fn + "'");
                    string udat = db.extscalr("select date from tb_upload where fname='" + fn + "'");

                    ((Label)GridView2.Rows[i].Cells[0].FindControl("Label7")).Text = fid;
                    ((Label)GridView2.Rows[i].Cells[1].FindControl("Label4")).Text = owner_name;

                    ((Label)GridView2.Rows[i].Cells[3].FindControl("Label5")).Text = des;
                    ((Label)GridView2.Rows[i].Cells[4].FindControl("Label6")).Text = udat;
                    string st = ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Text;
                    if (st == "1")
                    {
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Text = "Waiting For Approval";
                        ((Button)GridView2.Rows[i].Cells[7].FindControl("button2")).Visible = false;

                    }
                    else if (st == "4")
                    {
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Visible = false;
                        ((Button)GridView2.Rows[i].Cells[7].FindControl("button2")).Visible = true;
                    }
                    else if (st == "5")
                    {
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Text = "Your Requset is Rejected";
                        ((Button)GridView2.Rows[i].Cells[7].FindControl("button2")).Visible = false;

                    }
                    else
                    {


                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                        ((Label)GridView2.Rows[i].Cells[7].FindControl("label2")).Text = "Waiting For Approval";
                        ((Button)GridView2.Rows[i].Cells[7].FindControl("button2")).Visible = false;

                    }

                }
            }
        }
    }
    public void show_permission_of_files()
    {
       
        ds.Clear();
        ds = db.discont("select * from tb_upload u,tb_requested_files r,tb_manage_employee m where r.fname=u.fname and r.request_by='" + Session["user"].ToString() + "' and  m.username=u.owner_name");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            string st = ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Text;
            if (st == "1")
            {
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Text = "Waiting For Approval";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("button2")).Visible = false;

            }
            else if ( st == "4")
            {
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Visible = false;
                ((Button)GridView1.Rows[i].Cells[7].FindControl("button2")).Visible = true;
            }
            else if (st == "5")
            {
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Text = "Your Requset is Rejected";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("button2")).Visible = false;

            }
            else
            {


                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Visible = true;
                ((Label)GridView1.Rows[i].Cells[7].FindControl("label2")).Text = "Waiting For Approval";
                ((Button)GridView1.Rows[i].Cells[7].FindControl("button2")).Visible = false;

            }

        }


    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string fname = ((Label)GridView1.Rows[e.RowIndex].Cells[5].FindControl("label1")).Text;
        Session["fname"] = fname;
        string username =Session["user"].ToString();
        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
        rsa_algorithm rsa = new rsa_algorithm();
        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
        string read_public = File.ReadAllText(public_path);
        ViewState["token"] = db.extscalr("select token from tb_role_policy where filename='"+fname+"'");
        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + fname);
        if (!Directory.Exists(create_folder))
        {
            Directory.CreateDirectory(create_folder);
            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + fname + "/" +fname + ".txt");
            File.WriteAllText(enc_tok_path, rsa_encrypt);

        }




        Response.Redirect("~/Employee/download.aspx");
    }
    protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string fname = ((Label)GridView2.Rows[e.RowIndex].Cells[5].FindControl("label1")).Text;
        Session["fname"] = fname;
        string username = Session["user"].ToString();
        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
        rsa_algorithm rsa = new rsa_algorithm();
        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
        string read_public = File.ReadAllText(public_path);
        ViewState["token"] = db.extscalr("select token from tb_role_policy where filename='" + fname + "'");
        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + fname);
        if (!Directory.Exists(create_folder))
        {
            Directory.CreateDirectory(create_folder);
            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + fname + "/" + fname + ".txt");
            File.WriteAllText(enc_tok_path, rsa_encrypt);

        }




        Response.Redirect("~/Employee/download.aspx");
    }
}