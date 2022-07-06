using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Employee_view_my_uploaded_files : System.Web.UI.Page
{
    dbconect db = new dbconect();
    DataSet ds2 = new DataSet();
    DataSet ds1 = new DataSet();
    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            show_grid1();
        }
    }
    public void show_grid1()
    {
     
        ds.Clear();
        ds = db.discont("select * from tb_upload where owner_name='" + Session["user"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            GridView1.DataSource = ds;
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                string fname = GridView1.Rows[i].Cells[0].Text;
                ds.Clear();
                ds = db.discont("select distinct roles from tb_role_policy where filename='" + fname + "'");
                for (int k = 0; k < ds.Tables[0].Rows.Count; k++)
                {
                    ((BulletedList)GridView1.Rows[i].Cells[5].FindControl("BulletedList1")).Items.Add(ds.Tables[0].Rows[k]["roles"].ToString());


                }
            }
        }
        else
        {
            Button1.Visible = false;
        }
    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "add")
        {
            MultiView1.ActiveViewIndex = 1;
            ViewState["change_filename"] = e.CommandArgument.ToString();
            ViewState["token"] = db.extscalr("select token from tb_role_policy where filename='" + ViewState["change_filename"].ToString() + "'");
            show();
        }
        else if (e.CommandName == "remove")
        {

            show_grid2(e.CommandArgument.ToString());
        }
        else if (e.CommandName == "del")
        {
            bool b = db.extnon("delete from tb_upload where fname='" + e.CommandArgument.ToString() + "'");
            bool c = db.extnon("delete from tb_role_policy where filename='" + e.CommandArgument.ToString() + "'");
            bool d = db.extnon("delete from tb_requested_files where fname='" + e.CommandArgument.ToString() + "'");


            show_grid2(e.CommandArgument.ToString());

        }

    }
    public void show()
    {
        ds.Clear();
        ds = db.discont("select distinct role from tb_role");
        DataList1.DataSource = ds;
        DataList1.DataBind();
        for (int i = 0; i < DataList1.Items.Count; i++)
        {
            string role = ((Label)DataList1.Items[i].FindControl("label5")).Text;
            string check = db.extscalr("select role  from tb_role where role='" + role + "' and  role not in (select role from tb_Sub_main_role) and role not in (select role from tb_subroles_of_subrole)");
            if (check != "")
            {

                ((CheckBox)DataList1.Items[i].FindControl("CheckBox1")).Visible = true;
            }
            else
            {
                ((CheckBox)DataList1.Items[i].FindControl("CheckBox1")).Visible = false;

            }
        }
    }
    public void show_grid2(string role)
    {
        ds.Clear();
        ds = db.discont1("truncate table tb_temp_role");
        ds.Clear();

        ds = db.discont("select * from tb_role_policy where filename='" + role + "'");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string role_chk = ds.Tables[0].Rows[i]["roles"].ToString();
            string check = db.extscalr("select roles from tb_temp_role where roles='" + role_chk + "' ");
            if (check == "")
            {
                bool b = db.extnon("insert into   tb_temp_role values('" + ds.Tables[0].Rows[i]["p_id"] + "','" + ds.Tables[0].Rows[i]["roles"] + "','" + ds.Tables[0].Rows[i]["filename"] + "')");
            }
        }
        ds.Clear();
        MultiView1.ActiveViewIndex = 2;

        ds = db.discont("select * from tb_temp_role where filename='" + role + "'");

        GridView2.DataSource = ds;
        GridView2.DataBind();
        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            ((Label)GridView2.Rows[i].Cells[0].FindControl("label1")).Text = (i + 1).ToString();
        }
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string filename = db.extscalr("select filename from tb_role_policy where p_id='" + e.CommandArgument.ToString() + "'");
        bool b = db.extnon("delete from tb_role_policy where p_id='" + e.CommandArgument.ToString() + "'");
        show_grid2(filename);
    }
    

    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
     
        string role = ((Label)e.Item.FindControl("label5")).Text;
        ds1.Clear();
        ds1 = db.discont1("select * from tb_Sub_main_role where role='" + role + "'");
        if (ds1.Tables[0].Rows.Count != 0)
        {
            ((DataList)e.Item.FindControl("datalist2")).DataSource = ds1;
            ((DataList)e.Item.FindControl("datalist2")).DataBind();
            for (int i = 0; i < ((DataList)e.Item.FindControl("datalist2")).Items.Count; i++)
            {
                string role_check = ((Label)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("label6")).Text;
                string check = db.extscalr("select sub_main_role from tb_Sub_main_role where sub_main_role='" + role_check + "' and  sub_main_role not in (select sub_main_role from tb_subroles_of_subrole)");
                if (check != "")
                {

                    ((CheckBox)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("CheckBox2")).Visible = true;
                }
                else
                {
                    ((CheckBox)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("CheckBox2")).Visible = false;

                }
            }


            for (int i = 0; i < ((DataList)e.Item.FindControl("datalist2")).Items.Count; i++)
            {
                ds2.Clear();
                string sub_roles = ((Label)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("label6")).Text;

                ds2 = db.discont2("select * from tb_subroles_of_subrole where role='" + role + "' and sub_main_role='" + sub_roles + "'");
                if (ds2.Tables[0].Rows.Count != 0)
                {
                    ((DataList)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("datalist3")).DataSource = ds2;
                    ((DataList)((DataList)e.Item.FindControl("datalist2")).Items[i].FindControl("datalist3")).DataBind();

                
            }

        }
    }
}

    protected void Button2_Click(object sender, EventArgs e)
    {
        int flag_role = 0;
        for (int i = 0; i < DataList1.Items.Count; i++)
        {

            bool b = ((CheckBox)DataList1.Items[i].FindControl("checkbox1")).Checked;
            string role = ((Label)DataList1.Items[i].FindControl("label5")).Text;
            ViewState["r1"] = role;
            if (b == true)
            {
                string priority = db.extscalr("select priority from tb_role where role='" + role + "'");
                if (priority == "3")
                {
                    flag_role = 1;
                }
                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + ViewState["r1"].ToString() + "'");
                if (insert_check == "")
                {
                    bool d = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"] + "','" + ViewState["r1"].ToString() + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");


                    DataSet ds5 = new DataSet();
                    ds5.Clear();
                    ds5 = db.discont2("select * from tb_employee_role where role='" + ViewState["r1"].ToString() + "'");
                    for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                    {
                        string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                        rsa_algorithm rsa = new rsa_algorithm();
                        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                        string read_public = File.ReadAllText(public_path);

                        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                        if (!Directory.Exists(create_folder))
                        {
                            Directory.CreateDirectory(create_folder);
                            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                            File.WriteAllText(enc_tok_path, rsa_encrypt);

                        }
                    }
                }


            }
            for (int j = 0; j < ((DataList)DataList1.Items[i].FindControl("datalist2")).Items.Count; j++)
            {
                flag_role = 1;
                bool v = ((CheckBox)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("checkbox2")).Checked;
                string sub_main_role = ((Label)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("label6")).Text;
                string prior = ((Label)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("label80")).Text;

                ViewState["r2"] = sub_main_role;

                if (v == true)
                {

                    if (prior == "1")
                    {
                        string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString();
                        string priority = db.extscalr("select priority from tb_Sub_main_role where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "'");
                        string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                        if (insert_check == "")
                        {
                            bool d = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
                            DataSet ds5 = new DataSet();
                            ds5.Clear();
                            ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                            for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                            {
                                string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                rsa_algorithm rsa = new rsa_algorithm();
                                ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                string read_public = File.ReadAllText(public_path);

                                string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

                                }
                            }
                        }
                    }
                    else if (prior == "2")
                    {
                        ds.Clear();
                        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + role + "' and priority<='" + int.Parse(prior) + "'");
                        for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                        {
                            string priority = db.extscalr("select priority from tb_Sub_main_role where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ds.Tables[0].Rows[ab]["sub_main_role"].ToString() + "'");

                            string tot_rol = ViewState["r1"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_main_role"].ToString();
                            string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                            if (insert_check == "")
                            {
                                bool O = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
                                DataSet ds5 = new DataSet();
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                {
                                    string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

                                    }
                                }
                            }
                        }

                    }
                    else if (prior == "3")
                    {
                        ds.Clear();
                        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + role + "' and priority<='" + int.Parse(prior) + "'");
                        for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                        {
                            string tot_rol = ViewState["r1"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_main_role"].ToString();
                            string priority = db.extscalr("select priority from tb_Sub_main_role where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ds.Tables[0].Rows[ab]["sub_main_role"].ToString() + "'");
                            string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                            if (insert_check == "")
                            {
                                bool O = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
                                DataSet ds5 = new DataSet();
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                {
                                    string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

                                    }
                                }
                            }
                        }

                    }
                    else if (prior == "4")
                    {
                        ds.Clear();
                        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + role + "' and priority<='" + int.Parse(prior) + "'");
                        for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                        {
                            string tot_rol = ViewState["r1"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_main_role"].ToString();
                            string priority = db.extscalr("select priority from tb_Sub_main_role where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ds.Tables[0].Rows[ab]["sub_main_role"].ToString() + "'");
                            string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                            if (insert_check == "")
                            {
                                bool O = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
                                DataSet ds5 = new DataSet();
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                {
                                    string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

                                    }
                                }
                            }
                        }

                    }
                    else if (prior == "5")
                    {
                        ds.Clear();
                        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + role + "' and priority<='" + int.Parse(prior) + "'");
                        for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                        {
                            string priority = db.extscalr("select priority from tb_Sub_main_role where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ds.Tables[0].Rows[ab]["sub_main_role"].ToString() + "'");

                            string tot_rol = ViewState["r1"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_main_role"].ToString();
                            string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                            if (insert_check == "")
                            {
                                bool O = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
                                DataSet ds5 = new DataSet();
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                {
                                    string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

                                    }
                                }
                            }
                        }

                    }


                }

                for (int k = 0; k < ((DataList)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("datalist3")).Items.Count; k++)
                {
                    flag_role = 1;
                    bool c = ((CheckBox)((DataList)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("datalist3")).Items[k].FindControl("checkbox3")).Checked;
                    string sub_role = ((Label)((DataList)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("datalist3")).Items[k].FindControl("label7")).Text;
                    string priority = ((Label)((DataList)((DataList)DataList1.Items[i].FindControl("datalist2")).Items[j].FindControl("datalist3")).Items[k].FindControl("label8")).Text;
                    ViewState["r3"] = sub_role;

                    if (c == true)
                    {
                        if (priority == "1")
                        {
                            string priority_role = db.extscalr("select priority from tb_subroles_of_subrole where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "' and sub_role='" + ViewState["r3"].ToString() + "'");

                            string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString() + '-' + ViewState["r3"].ToString();
                            string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                            if (insert_check == "")
                            {
                                bool d = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
                                DataSet ds5 = new DataSet();
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                {
                                    string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

                                    }
                                }
                            }
                        }
                        else if (priority == "2")
                        {
                            ds.Clear();
                            ds = db.discont("select sub_role from tb_subroles_of_subrole where sub_main_role='" + sub_main_role + "' and Priority<='" + int.Parse(priority) + "'");
                            for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                            {
                                string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_role"].ToString();
                                string priority_role = db.extscalr("select priority from tb_subroles_of_subrole where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "' and sub_role='" + ds.Tables[0].Rows[ab]["sub_role"].ToString() + "'");
                                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                                if (insert_check == "")
                                {
                                    bool f = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
                                    DataSet ds5 = new DataSet();
                                    ds5.Clear();
                                    ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                    for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                    {
                                        string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                        rsa_algorithm rsa = new rsa_algorithm();
                                        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                        string read_public = File.ReadAllText(public_path);

                                        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                        if (!Directory.Exists(create_folder))
                                        {
                                            Directory.CreateDirectory(create_folder);
                                            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                            File.WriteAllText(enc_tok_path, rsa_encrypt);

                                        }
                                    }
                                }
                            }

                        }
                        else if (priority == "3")
                        {
                            ds.Clear();
                            ds = db.discont("select sub_role from tb_subroles_of_subrole where sub_main_role='" + sub_main_role + "' and Priority<='" + int.Parse(priority) + "'");
                            for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                            {
                                string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_role"].ToString();
                                string priority_role = db.extscalr("select priority from tb_subroles_of_subrole where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "' and sub_role='" + ds.Tables[0].Rows[ab]["sub_role"].ToString() + "'");
                                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                                if (insert_check == "")
                                {
                                    bool f = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
                                    DataSet ds5 = new DataSet();
                                    ds5.Clear();
                                    ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                    for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                    {
                                        string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                        rsa_algorithm rsa = new rsa_algorithm();
                                        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                        string read_public = File.ReadAllText(public_path);

                                        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                        if (!Directory.Exists(create_folder))
                                        {
                                            Directory.CreateDirectory(create_folder);
                                            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                            File.WriteAllText(enc_tok_path, rsa_encrypt);

                                        }
                                    }
                                }
                            }

                        }
                        else if (priority == "4")
                        {
                            ds.Clear();
                            ds = db.discont("select sub_role from tb_subroles_of_subrole where sub_main_role='" + sub_main_role + "' and Priority<='" + int.Parse(priority) + "'");
                            for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                            {
                                string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_role"].ToString();
                                string priority_role = db.extscalr("select priority from tb_subroles_of_subrole where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "' and sub_role='" + ds.Tables[0].Rows[ab]["sub_role"].ToString() + "'");
                                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                                if (insert_check == "")
                                {
                                    bool f = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
                                    DataSet ds5 = new DataSet();
                                    ds5.Clear();
                                    ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                    for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                    {
                                        string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                        rsa_algorithm rsa = new rsa_algorithm();
                                        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                        string read_public = File.ReadAllText(public_path);

                                        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                        if (!Directory.Exists(create_folder))
                                        {
                                            Directory.CreateDirectory(create_folder);
                                            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                            File.WriteAllText(enc_tok_path, rsa_encrypt);

                                        }
                                    }
                                }
                            }

                        }
                        else if (priority == "5")
                        {
                            ds.Clear();
                            ds = db.discont("select sub_role from tb_subroles_of_subrole where sub_main_role='" + sub_main_role + "' and Priority<='" + int.Parse(priority) + "'");
                            for (int ab = 0; ab < ds.Tables[0].Rows.Count; ab++)
                            {
                                string tot_rol = ViewState["r1"].ToString() + '-' + ViewState["r2"].ToString() + '-' + ds.Tables[0].Rows[ab]["sub_role"].ToString();
                                string priority_role = db.extscalr("select priority from tb_subroles_of_subrole where role='" + ViewState["r1"].ToString() + "' and sub_main_role='" + ViewState["r2"].ToString() + "' and sub_role='" + ds.Tables[0].Rows[ab]["sub_role"].ToString() + "'");
                                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + tot_rol + "'");
                                if (insert_check == "")
                                {
                                    bool f = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
                                    DataSet ds5 = new DataSet();
                                    ds5.Clear();
                                    ds5 = db.discont2("select * from tb_employee_role where role='" + tot_rol + "'");
                                    for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
                                    {
                                        string username = ds5.Tables[0].Rows[cc]["username"].ToString();
                                        string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                        //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                        rsa_algorithm rsa = new rsa_algorithm();
                                        ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                        string read_public = File.ReadAllText(public_path);

                                        string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
                                        string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString());
                                        if (!Directory.Exists(create_folder))
                                        {
                                            Directory.CreateDirectory(create_folder);
                                            string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + ViewState["change_filename"].ToString() + "/" + ViewState["change_filename"].ToString() + ".txt");
                                            File.WriteAllText(enc_tok_path, rsa_encrypt);

                                        }

                                    }
                                }

                            }


                        }


                    }

                }


            }
            string fr_role = db.extscalr("select role from  tb_role where priority='1'");
            if (fr_role != "")
            {
                string insert_check = db.extscalr("select role from tb_role_policy where filename='" + ViewState["change_filename"] + "' and roles='" + fr_role + "'");
                if (insert_check == "")
                {
                    bool d = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + fr_role + "','0','" + ViewState["token"].ToString() + "','" + '1' + "')");
                }
            }
        }
        if (flag_role == 1)
        {
            string mn_role = db.extscalr("select role from tb_role where priority=2");
            ds.Clear();
            ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + mn_role + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string st_role = mn_role + '-' + ds.Tables[0].Rows[i]["sub_main_role"].ToString();
                    string chk = db.extscalr("select filename from tb_role_policy where roles='" + st_role + "' and filename='" + ViewState["change_filename"].ToString() + "'");
                    if (st_role == "")
                    {
                        bool d = db.extnon("insert into tb_role_policy values('" + ViewState["change_filename"].ToString() + "','" + st_role + "','0','" + ViewState["token"].ToString() + "','" + '1' + "')");


                    }


                }
            }

        }

        MultiView1.ActiveViewIndex = 0;
        show_grid1();
        RegisterStartupScript("", "<script Language=JavaScript>alert('Successfully Added new Privacy')</Script>");



    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("view_my_uploaded_files.aspx");
    }
}