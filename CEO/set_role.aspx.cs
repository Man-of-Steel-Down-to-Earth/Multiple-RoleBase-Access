using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class CEO_set_role : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            display_data();

        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["empl"] = Request.QueryString["ename"].ToString();
        for (int i = 0; i < DataList1.Items.Count; i++)
        {
            if (((CheckBox)DataList1.Items[i].FindControl("checkbox1")).Checked == true)
            {
                string role = ((Label)DataList1.Items[i].FindControl("label5")).Text;
                string check = db.extscalr("select role from  tb_employee_role where role='" + role + "' and username='" + Request.QueryString["ename"].ToString() + "' ");
                if (check == "")
                {
                    string priority = ((Label)DataList1.Items[i].FindControl("label9")).Text;

                    bool b = db.extnon("insert into tb_employee_role values('" + Request.QueryString["ename"].ToString() + "','" + role + "','" + priority + "')");

                }
            }
        } for (int i = 0; i < DataList2.Items.Count; i++)
        {
            if (((CheckBox)DataList2.Items[i].FindControl("checkbox1")).Checked == true)
            {
                string role = ((Label)DataList2.Items[i].FindControl("label5")).Text + "-" + ((Label)DataList2.Items[i].FindControl("label6")).Text;
                string check = db.extscalr("select role from  tb_employee_role where role='" + role + "' and username='" + Request.QueryString["ename"].ToString() + "' ");
                if (check == "")
                {
                    //int max_priority=int.Parse(db.extscalr("select max(priority) from tb_Sub_main_role where role='"+((Label)DataList2.Items[i].FindControl("label5")).Text+"'"));
                    string priority = ((Label)DataList2.Items[i].FindControl("label9")).Text;
                    //string count = db.extscalr("select count(priority) from tb_Sub_main_role where role='"+((Label)DataList2.Items[i].FindControl("label5")).Text+"' and priority='"+priority+"'");
                    //if (int.Parse(count) > 1)
                    //{
                    //    role = ((Label)DataList2.Items[i].FindControl("label5")).Text + "-" + ((Label)DataList2.Items[i].FindControl("label6")).Text;
                    bool b = db.extnon("insert into tb_employee_role values('" + Request.QueryString["ename"].ToString() + "','" + role + "','" + priority + "')");

                    // }
                    //else
                    //{
                    //    for (int k = int.Parse(priority); k <= max_priority; k++)
                    //    {
                    //        ds.Clear();
                    //        ds = db.discont("select * from tb_Sub_main_role where priority='" + k + "' and role='" + ((Label)DataList2.Items[i].FindControl("label5")).Text + "'");
                    //        for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
                    //        {
                    //            role = ds.Tables[0].Rows[c]["role"].ToString() + "-" + ds.Tables[0].Rows[c]["sub_main_role"].ToString();
                    //            bool b = db.extnon("insert into tb_employee_role values('" + Request.QueryString["ename"].ToString() + "','" + role + "','" + k + "')");
                    //        }
                    //    }
                    //}
                }
            }
        } for (int i = 0; i < DataList3.Items.Count; i++)
        {
            if (((CheckBox)DataList3.Items[i].FindControl("checkbox1")).Checked == true)
            {

                string role = ((Label)DataList3.Items[i].FindControl("label5")).Text + "-" + ((Label)DataList3.Items[i].FindControl("label6")).Text + "-" + ((Label)DataList3.Items[i].FindControl("label7")).Text;
                string check = db.extscalr("select role from  tb_employee_role where role='" + role + "' and username='" + Request.QueryString["ename"].ToString() + "' ");
                if (check == "")
                {
                    //int max_priority = int.Parse(db.extscalr("select max(priority) from tb_subroles_of_subrole where role='" + ((Label)DataList3.Items[i].FindControl("label5")).Text + "' and sub_main_role='" + ((Label)DataList3.Items[i].FindControl("label6")).Text + "'"));
                    string priority = ((Label)DataList3.Items[i].FindControl("label9")).Text;
                    //for (int k = int.Parse(priority); k <= max_priority; k++)
                    //{
                    //    ds.Clear();
                    //    ds = db.discont("select * from tb_subroles_of_subrole where priority='" + k + "' and role='" + ((Label)DataList3.Items[i].FindControl("label5")).Text + "' and sub_main_role='" + ((Label)DataList3.Items[i].FindControl("label6")).Text + "'");
                    //    for (int c = 0; c < ds.Tables[0].Rows.Count; c++)
                    //    {
                    //        role = ds.Tables[0].Rows[c]["role"].ToString() + "-" + ds.Tables[0].Rows[c]["sub_main_role"].ToString() + "-" + ds.Tables[0].Rows[c]["sub_role"].ToString();

                    bool b = db.extnon("insert into tb_employee_role values('" + Request.QueryString["ename"].ToString() + "','" + role + "','"+priority+"')");
                    //  }
                    //   }
                }
            }
        }
        display_data();
        give_permission(Session["empl"].ToString());
        Response.Redirect("set_roles_to_employees.aspx");
    }
    public void give_permission(string empl)
    {
        empl = Session["empl"].ToString();
        DataSet ds5 = new DataSet();
        ds5.Clear();
        ds5 = db.discont2("select   filename from  tb_role_policy  where roles in (select role  from tb_employee_role where username='" + empl + "')");
        ds.Clear();
        ds = db.discont("truncate table tb_temp_files");
        for (int i = 0; i < ds5.Tables[0].Rows.Count; i++)
        {
            string ch = db.extscalr("select fnames from tb_temp_files where fnames='" + ds5.Tables[0].Rows[i]["filename"].ToString() + "'");
            if (ch == "")
            {
                bool b = db.extnon("insert into tb_temp_files values('" + ds5.Tables[0].Rows[i]["filename"].ToString() + "')");
            }
        }
        ds5.Clear();
        ds5 = db.discont2("select fnames from tb_temp_files");
        for (int cc = 0; cc < ds5.Tables[0].Rows.Count; cc++)
        {
            string public_path = Server.MapPath("~/RSA_KEYS/token_key/" + empl + "/" + empl + ".pbl");
            //       string private_path = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
            rsa_algorithm rsa = new rsa_algorithm();
            ///  rsa.emp_generatkey(tok_path, public_path, private_path);
            string read_public = File.ReadAllText(public_path);
            ViewState["token"] = db.extscalr("select token from tb_role_policy where filename='" + ds5.Tables[0].Rows[cc]["fnames"].ToString() + "'");
            string rsa_encrypt = rsa.RSAEncrypt(ViewState["token"].ToString(), public_path);
            string create_folder = Server.MapPath("~/RSA_KEYS/token_key/" + empl + "/" + ds5.Tables[0].Rows[cc]["fnames"].ToString());
            if (!Directory.Exists(create_folder))
            {
                Directory.CreateDirectory(create_folder);
                string enc_tok_path = Server.MapPath("~/RSA_KEYS/token_key/" + empl + "/" + ds5.Tables[0].Rows[cc]["fnames"].ToString() + "/" + ds5.Tables[0].Rows[cc]["fnames"].ToString() + ".txt");
                File.WriteAllText(enc_tok_path, rsa_encrypt);

            }
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string e_id = e.CommandArgument.ToString();
        string role = db.extscalr("select role from tb_employee_role where e_role_id='" + e_id + "'");
        string username = db.extscalr("select username from tb_employee_role where e_role_id='" + e_id + "'");
        string priority = db.extscalr("select priority from tb_employee_role where e_role_id='" + e_id + "'");

        string[] roles = role.Split('-');
        if (roles.Count() == 1)
        {
            bool b = db.extnon("delete from tb_employee_role where e_role_id='" + e.CommandArgument.ToString() + "'");

        }

        display_data();
    }
    protected void DataList2_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string e_id = e.CommandArgument.ToString();
        string role = db.extscalr("select role from tb_employee_role where e_role_id='" + e_id + "'");
        string username = db.extscalr("select username from tb_employee_role where e_role_id='" + e_id + "'");
        string priority = db.extscalr("select priority from tb_employee_role where e_role_id='" + e_id + "'");

        string[] roles = role.Split('-');

        if (roles.Count() == 2)
        {
            ds.Clear();
            ds = db.discont("select * from tb_Sub_main_role where role='" + roles[0] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int p = int.Parse(ds.Tables[0].Rows[i]["priority"].ToString());
                    int selected_priority = int.Parse(priority);
                    if (p < selected_priority)
                    {
                        string search_role = "%" + roles[0] + "%";
                        string max_no = db.extscalr("select count(*) from tb_sub_main_role where role like '" + search_role + "' and priority='" + p + "'");
                        if (max_no == "1")
                        {
                            string chk_role = roles[0] + "-" + ds.Tables[0].Rows[i]["sub_main_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "'");
                        }
                        else
                        {
                            string chk_role = roles[0] + "-" + ds.Tables[0].Rows[i]["sub_main_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");

                        }
                    }
                    else if (p == selected_priority)
                    {
                        string max_no = db.extscalr("select count(*) from tb_sub_main_role where role like '" + roles[0] + "' and priority='" + p + "'");
                        if (int.Parse(max_no) > 1)
                        {
                            string chk_role = roles[0] + "-" + roles[1];

                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "'  and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");

                        }
                        else
                        {
                            string chk_role = roles[0] + "-" + ds.Tables[0].Rows[i]["sub_main_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");
                        }
                    }
                }
            }
        }

        display_data();
    }
    protected void DataList3_ItemCommand(object source, DataListCommandEventArgs e)
    {
        string e_id = e.CommandArgument.ToString();
        string role = db.extscalr("select role from tb_employee_role where e_role_id='" + e_id + "'");
        string username = db.extscalr("select username from tb_employee_role where e_role_id='" + e_id + "'");
        string priority = db.extscalr("select priority from tb_employee_role where e_role_id='" + e_id + "'");

        string[] roles = role.Split('-');

        if (roles.Count() == 3)
        {
            ds.Clear();
            ds = db.discont("select * from tb_subroles_of_subrole where role='" + roles[0] + "' and sub_main_role='" + roles[1] + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    int p = int.Parse(ds.Tables[0].Rows[i]["priority"].ToString());
                    int selected_priority = int.Parse(priority);
                    if (p < selected_priority)
                    {
                        string search_role = "%" + roles[0] + "%";
                        string sub_main_role = "%" + roles[1] + "%";
                        string max_no = db.extscalr("select count(*) from tb_subroles_of_subrole where role like '" + search_role + "' and sub_main_role like '" + sub_main_role + "' and priority='" + p + "'");
                        if (max_no == "1")
                        {
                            string chk_role = roles[0] + "-" + roles[1] + "-" + ds.Tables[0].Rows[i]["sub_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "'");
                        }
                        else
                        {
                            string chk_role = roles[0] + "-" + roles[1] + "-" + ds.Tables[0].Rows[i]["sub_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");

                        }
                    }
                    else if (p > selected_priority)
                    {
                        string search_role = "%" + roles[0] + "%";
                        string sub_main_role = "%" + roles[1] + "%";
                        string max_no = db.extscalr("select count(*) from tb_subroles_of_subrole where role like '" + search_role + "' and sub_main_role like '" + sub_main_role + "' and priority='" + p + "'");
                        if (max_no == "1")
                        {
                            string chk_role = roles[0] + "-" + roles[1] + "-" + ds.Tables[0].Rows[i]["sub_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "'");
                        }
                        else
                        {
                            string chk_role = roles[0] + "-" + roles[1] + "-" + ds.Tables[0].Rows[i]["sub_role"];
                            bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");

                        }
                    }
                    else if (p == selected_priority)
                    {
                        string chk_role = roles[0] + "-" + roles[1] + "-" + ds.Tables[0].Rows[i]["sub_role"];
                        bool b = db.extnon("delete from tb_employee_role where role='" + chk_role + "' and username='" + Request.QueryString["ename"].ToString() + "' and priority='" + p + "'");

                    }
                }
            }
        }
        display_data();
    }
    public void display_data()
    {
        ds.Clear();
        ds = db.discont("select r_id, role,priority from tb_role where role not in (select role from tb_Sub_main_role) and role not in (select role from tb_subroles_of_subrole)");
        DataList1.DataSource = ds;
        DataList1.DataBind(); ds.Clear();
        ds = db.discont("select  sb_id,role,sub_main_role,priority from tb_Sub_main_role where role  in (select role from tb_Sub_main_role) and role not in (select role from tb_subroles_of_subrole)");
        DataList2.DataSource = ds;
        DataList2.DataBind(); ds.Clear();
        ds = db.discont("select   s_id,role,sub_main_role,sub_role,priority from tb_subroles_of_subrole where role  in (select role from tb_Sub_main_role) and role  in (select role from tb_subroles_of_subrole)");
        DataList3.DataSource = ds;
        DataList3.DataBind();
        ds.Clear();
        ds = db.discont("select * from tb_employee_role where username='" + Request.QueryString["ename"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            List<string> role = new List<string>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                role.Add(ds.Tables[0].Rows[i]["role"].ToString());
            }
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                for (int j = 0; j < role.Count; j++)
                {
                    string[] each_role = role[j].Split('-');
                    if (each_role.Count() == 1)
                    {
                        string role1 = ((Label)DataList1.Items[i].FindControl("label5")).Text;
                        if (role1 == each_role[0].ToString())
                        {
                            ((CheckBox)DataList1.Items[i].FindControl("checkbox1")).Checked = true;
                            string id = db.extscalr("select e_role_id from [tb_employee_role] where role='" + role[j] + "'");
                            if (id != "")
                            {
                                ((ImageButton)DataList1.Items[i].FindControl("ImageButton1")).Visible = true;
                                ((ImageButton)DataList1.Items[i].FindControl("ImageButton1")).CommandArgument = id;
                            }
                        }


                    }
                }
            }
            for (int i = 0; i < DataList2.Items.Count; i++)
            {
                for (int j = 0; j < role.Count; j++)
                {
                    string[] each_role = role[j].Split('-');
                    if (each_role.Count() == 2)
                    {
                        string role1 = ((Label)DataList2.Items[i].FindControl("label5")).Text;
                        string role2 = ((Label)DataList2.Items[i].FindControl("label6")).Text;

                        if (role1 == each_role[0].ToString() && role2 == each_role[1].ToString())
                        {
                            ((CheckBox)DataList2.Items[i].FindControl("checkbox1")).Checked = true;
                            string id = db.extscalr("select e_role_id from [tb_employee_role] where role='" + role[j] + "'");
                            if (id != "")
                            {
                                ((ImageButton)DataList2.Items[i].FindControl("ImageButton1")).Visible = true;
                                ((ImageButton)DataList2.Items[i].FindControl("ImageButton1")).CommandArgument = id;
                            }
                        }


                    }
                }
            }
            for (int i = 0; i < DataList3.Items.Count; i++)
            {
                for (int j = 0; j < role.Count; j++)
                {
                    string[] each_role = role[j].Split('-');
                    if (each_role.Count() == 3)
                    {
                        string role1 = ((Label)DataList3.Items[i].FindControl("label5")).Text;
                        string role2 = ((Label)DataList3.Items[i].FindControl("label6")).Text;
                        string role3 = ((Label)DataList3.Items[i].FindControl("label7")).Text;

                        if (role1 == each_role[0].ToString() && role2 == each_role[1].ToString() && role3 == each_role[2].ToString())
                        {
                            ((CheckBox)DataList3.Items[i].FindControl("checkbox1")).Checked = true;
                            string id = db.extscalr("select e_role_id from [tb_employee_role] where role='" + role[j] + "'");
                            if (id != "")
                            {
                                ((ImageButton)DataList3.Items[i].FindControl("ImageButton1")).Visible = true;
                                ((ImageButton)DataList3.Items[i].FindControl("ImageButton1")).CommandArgument = id;
                            }
                        }


                    }
                }
            }
        }
    }
}