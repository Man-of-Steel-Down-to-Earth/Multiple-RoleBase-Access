using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;


public partial class Employee_upload_files : System.Web.UI.Page
{
    dbconect db = new dbconect();
    DataSet ds = new DataSet();
    DataSet ds1 = new DataSet();
    read_doc read_doc = new read_doc();
    pdfreader read_pdf = new pdfreader();
    read_txt read_txtt = new read_txt();
    string data = "";
    cloud cld = new cloud();
    cryptography crypt = new cryptography();
    string enc_string = "";
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        string f=FileUpload1.FileName;
        string [] ar=f.Split('.');
        string ext=ar[1];
        if (ext == "jpg" || ext == "png" || ext == "PNG" || ext == "JPG" || ext == "doc" || ext == "docx" || ext == "txt" || ext == "pdf")
        {
            ds.Clear();
            ds = db.discont("select fname from tb_upload where fname='" + TextBox1.Text + "'");
            if (ds.Tables[0].Rows.Count != 0)
            {

                RegisterStartupScript("", "<script Language=JavaScript>alert('Filename Already Existed')</Script>");


            }
            else
            {

                if (FileUpload1.HasFile)
                {
                    string path = "~/Employee/files/upload/" + FileUpload1.FileName;
                    FileUpload1.SaveAs(MapPath(path));
                    string server_path = Server.MapPath(path);
                    string extension = System.IO.Path.GetExtension(FileUpload1.FileName);
                    if (extension == ".docx" || extension == ".doc")
                    {
                        data = read_doc.read_from_doc(server_path);

                    }
                    else if (extension == ".txt")
                    {

                        data = read_txtt.readtxt(server_path);

                    }
                    else if (extension == ".pdf")
                    {

                        data = read_pdf.pdfText(server_path);

                    }


                    ds.Clear();
                    string attribute = Session["user"].ToString().Substring(0, 3);
                    string e_key = db.MakePwd(5);
                    string token = attribute + db.numpassword(3);
                    ViewState["token"] = token;

                    DataSet ds8 = new DataSet();
                    string enc_path = Server.MapPath("~/Employee/files/efile/" + TextBox1.Text + ".txt");
                    if (extension == ".jpg" || extension == ".png" || extension == ".PNG" || extension == ".JPG")
                    {
                        string enc_pathimage = Server.MapPath("~/Employee/files/efile/" + TextBox1.Text + extension);
                        crypt.Encrypt(server_path, enc_pathimage, e_key);
                    }
                    else
                    {
                        enc_string = cld.encrypt(data, e_key);
                        File.WriteAllText(enc_path, enc_string);
                    }


                    DataSet ds5 = new DataSet();

                    bool b = db.extnon("insert into tb_upload values('" + Session["user"].ToString() + "','" + TextBox1.Text + "','" + e_key + "','" + TextBox2.Text + "','0','0','" + DateTime.Now.ToString() + "','" + extension + "')");
                    ds.Clear();
                    ds = db.discont("select * from tb_employee_role where username='" + Session["user"].ToString() + "'");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string[] ar_chk = ds.Tables[0].Rows[i]["role"].ToString().Split('-');
                            string employeerole = ds.Tables[0].Rows[i]["role"].ToString();
                            string role = ar_chk[0].ToString();
                            //string subrole = ar_chk[1].ToString();
                            //string subrole_tech = ar_chk[2].ToString();

                            string prio = db.extscalr("select priority from tb_role where role='" + ar_chk[0].ToString() + "'");
                            if (int.Parse(prio) > 2)
                            {
                                string mn_role = db.extscalr("select role from tb_role where priority=2");
                                ds8.Clear();
                                ds8 = db.discont1("select sub_main_role from tb_Sub_main_role where role='" + mn_role + "'");
                                if (ds8.Tables[0].Rows.Count > 0)
                                {
                                    for (int i1 = 0; i1 < ds8.Tables[0].Rows.Count; i1++)
                                    {
                                        string sub_mn = ds8.Tables[0].Rows[i1]["sub_main_role"].ToString();
                                        string st_role = mn_role + '-' + ds8.Tables[0].Rows[i1]["sub_main_role"].ToString();
                                        string chk = db.extscalr("select filename from tb_role_policy where roles='" + st_role + "' and filename='" + TextBox1.Text + "'");
                                        if (chk == "")
                                        {
                                            bool kh = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + st_role + "','0','" + ViewState["token"].ToString() + "','" + '1' + "')");


                                        }


                                    }
                                }

                                //********************

                                //DataSet d6 = new DataSet();
                                //DataSet d7 = new DataSet();
                                ////d6 = db.discont2("select * from [tb_subroles_of_subrole] where [role]='" + role + "'");
                                ////{
                                //if (ar_chk.Count() ==3)
                                //{
                                //   //d7 = db.discont1("select * from tb_employee_role where username='" + Session["user"].ToString() + "'");
                                //   // if (d7.Tables[0].Rows.Count > 0)
                                //   // {
                                //   //     for (int k = 0; k < d7.Tables[0].Rows.Count; k++)
                                //   //     {
                                //            string[] ar_chk1 = employeerole.Split('-');
                                //            string role1 = ar_chk[0].ToString();
                                //            string subrole = ar_chk[1].ToString();
                                //            string subrole_tech = ar_chk[2].ToString();
                                //            string priority = db.extscalr("select [Priority] from [tb_subroles_of_subrole] where [role]='" + role1 + "' and [sub_main_role]='" + subrole + "' and [sub_role]='" + subrole_tech + "'");

                                //            DataSet d4 = new DataSet();
                                //            DataSet d5 = new DataSet();
                                //            if (priority != "")
                                //            {
                                //                int pr = int.Parse(priority);
                                //                d4 = db.discont1("Select * from tb_subroles_of_subrole where [role]='" + role1 + "' and [sub_main_role]='" + subrole + "' ");
                                //                if (d4.Tables[0].Rows.Count > 0)
                                //                {
                                //                    d5 = db.discont1("Select * from tb_subroles_of_subrole where [role]='" + role1 + "' and [sub_main_role]='" + subrole + "' and [Priority] < '" + pr + "'");
                                //                    if (d5.Tables[0].Rows.Count > 0)
                                //                    {
                                //                        for (int j = 0; j < d5.Tables[0].Rows.Count; j++)
                                //                        {

                                //                            string sub_role = d5.Tables[0].Rows[j]["sub_role"].ToString();
                                //                            string rl = role1 + "-" + subrole + "-" + sub_role;

                                //                            bool r = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + rl + "','0','" + token + "','" + d5.Tables[0].Rows[j]["priority"] + "')");



                                //                        }
                                //                    }
                                //                }
                                //            }
                                //}

                                //************************





                                //**************************************************




                                //if (ar_chk.Count() == 2)
                                //{

                                //    //d6 = db.discont1("select * from tb_employee_role where username='" + Session["user"].ToString() + "'");
                                //    //if (d6.Tables[0].Rows.Count > 0)
                                //    //{

                                //    //    for (int k = 0; k < d6.Tables[0].Rows.Count; k++)
                                //    //    {

                                //            string[] ar_chk1 = employeerole.Split('-');
                                //            string role1 = ar_chk[0].ToString();
                                //            string subrole = ar_chk[1].ToString();
                                //            string priority = db.extscalr("select [Priority] from tb_Sub_main_role where [role]='" + role1 + "' and [sub_main_role]='" + subrole + "' ");
                                //             DataSet d4 = new DataSet();
                                //            DataSet d5 = new DataSet();
                                //            if (priority != "")
                                //            {
                                //                int pr = int.Parse(priority);
                                //                d5 = db.discont1("Select * from tb_Sub_main_role where [role]='" + role1 + "' and [Priority] < '" + pr + "'");
                                //                if (d5.Tables[0].Rows.Count > 0)
                                //                {
                                //                    for (int j = 0; j < d5.Tables[0].Rows.Count; j++)
                                //                    {
                                //                        string rl = role1 + "-" + d5.Tables[0].Rows[j]["sub_main_role"].ToString(); ;
                                //                        bool r = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + rl + "','0','" + token + "','" + d5.Tables[0].Rows[j]["priority"] + "')");


                                //                    }
                                //                }
                                //            }
                                //}



                                //**************************************************
                            }
                            bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + ds.Tables[0].Rows[i]["role"].ToString() + "','0','" + token + "','" + ds.Tables[0].Rows[i]["priority"] + "')");
                             if (b == true)
                            {
                                ds5.Clear();
                                ds5 = db.discont2("select * from tb_employee_role where role='" + ds.Tables[0].Rows[i]["role"].ToString() + "'");
                                for (int j = 0; j < ds5.Tables[0].Rows.Count; j++)
                                {
                                    string username = ds5.Tables[0].Rows[j]["username"].ToString();
                                    string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
                                    //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                                    rsa_algorithm rsa = new rsa_algorithm();
                                    ///  rsa.emp_generatkey(tok_path, public_path, private_path);
                                    string read_public = File.ReadAllText(public_path);

                                    string rsa_encrypt = rsa.RSAEncrypt(token, public_path);
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);
                                }
                                File.Delete(server_path);
                                MultiView1.ActiveViewIndex = 1;


                            }
                        }
                    }
                }
                else
                {
                    RegisterStartupScript("", "<script Language=JavaScript>alert('Please Upload File')</Script>");


                }

            }
        }
        else
        {
            RegisterStartupScript("", "<script Language=JavaScript>alert('Invalid File')</Script>");
        }
    }
    DataSet ds2 = new DataSet();
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
                bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + ViewState["r1"].ToString() + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                    if (!Directory.Exists(create_folder))
                    {
                        Directory.CreateDirectory(create_folder);
                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                        File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                        bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                            string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                            if (!Directory.Exists(create_folder))
                            {
                                Directory.CreateDirectory(create_folder);
                                string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                File.WriteAllText(enc_tok_path, rsa_encrypt);

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
                            bool O = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                            bool O = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                            bool O = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

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
                            bool O = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority + "')");
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
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

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
                            bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
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
                                string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                if (!Directory.Exists(create_folder))
                                {
                                    Directory.CreateDirectory(create_folder);
                                    string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                    File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                                bool f = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
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
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                                bool f = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
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
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                                bool f = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
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
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                                        File.WriteAllText(enc_tok_path, rsa_encrypt);

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

                                bool f = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + tot_rol + "','0','" + ViewState["token"].ToString() + "','" + priority_role + "')");
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
                                    string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
                                    if (!Directory.Exists(create_folder))
                                    {
                                        Directory.CreateDirectory(create_folder);
                                        string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
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
            string chk1 = db.extscalr("select filename from tb_role_policy where roles='" + fr_role + "' and filename='" + TextBox1.Text + "'");
            if(chk1=="")
            {
            bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + fr_role + "','0','" + ViewState["token"].ToString() + "','" + '1' + "')");
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
                    string chk = db.extscalr("select filename from tb_role_policy where roles='" + st_role + "' and filename='" + TextBox1.Text + "'");
                    if (st_role == "")
                    {
                        bool d = db.extnon("insert into tb_role_policy values('" + TextBox1.Text + "','" + st_role + "','0','" + ViewState["token"].ToString() + "','" + '1' + "')");


                    }


                }
            }

        }

        ds.Clear();
        ds = db.discont("select * from tb_role_policy where filename='"+TextBox1.Text+"'");
        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        {
            string username = db.extscalr("select username from [tb_employee_role] where role='"+ds.Tables[0].Rows[i]["roles"].ToString()+"'");
            if(username!="")
            {
            string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + username + ".pbl");
            //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
            rsa_algorithm rsa = new rsa_algorithm();
            ///  rsa.emp_generatkey(tok_path, public_path, private_path);
            string read_public = File.ReadAllText(public_path);

            string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
            string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text);
            if (!Directory.Exists(create_folder))
            {
                Directory.CreateDirectory(create_folder);
                string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + username + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt");
                File.WriteAllText(enc_tok_path, rsa_encrypt);

            }
            }
        }
        MultiView1.ActiveViewIndex = 0;
        RegisterStartupScript("", "<script Language=JavaScript>alert('Successfully Assigned Privacy')</Script>");



    }
}