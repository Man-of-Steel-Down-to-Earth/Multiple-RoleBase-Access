using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CEO_manage_roles : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    DataSet ds1 = new DataSet();
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        
        if (!IsPostBack)
        {
           

            drop1();
            drop2();
            drop3();
            drop5();
            drop6();
            drop7();
            drop8();
            drop9();
            drop10();
        }
    }
    public void drop1()
    {


        ds.Clear();
        ds = db.discont("select distinct role from tb_role where role!='HR' or role!='hr'");
        DropDownList1.DataSource = ds;
        DropDownList1.DataTextField = "role";
        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, "Select Role..........");

    }
    public void drop2()
    {

        ds.Clear();
        ds = db.discont("select  role from tb_role where role='Developer' or role='developer' or role='DEVELOPER' ");
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "role";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "Select Sub Main Role..........");


    }
    public void drop3()
    {

        ds.Clear();
        ds = db.discont("select distinct sub_main_role from tb_Sub_main_role where role='"+DropDownList2.Text+"' ");
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "sub_main_role";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, "Select Sub Role............");

    }
    public void drop8()
    {
        ds.Clear();
        ds = db.discont("select role from tb_role ");
        DropDownList8.DataSource = ds;
        DropDownList8.DataTextField = "role";
        DropDownList8.DataBind();
        DropDownList8.Items.Insert(0, "Select Role............");
    }
    public void drop5()
    {
        ds.Clear();
        ds = db.discont("select distinct role from tb_Sub_main_role ");
        DropDownList5.DataSource = ds;
        DropDownList5.DataTextField = "role";
        DropDownList5.DataBind();
        DropDownList5.Items.Insert(0, "Select Role............");
    }
    public void drop9()
    {
        ds.Clear();
        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='"+DropDownList5.Text+"'");
        DropDownList9.DataSource = ds;
        DropDownList9.DataTextField = "sub_main_role";
        DropDownList9.DataBind();
        DropDownList9.Items.Insert(0, "Select sub_main_role............");
    }
    public void drop6()
    {
        ds.Clear();
        ds = db.discont("select distinct role from tb_subroles_of_subrole ");
        DropDownList6.DataSource = ds;
        DropDownList6.DataTextField = "role";
        DropDownList6.DataBind();
        DropDownList6.Items.Insert(0, "Select Role............");
    }
    public void drop7()
    {
        ds.Clear();
        ds = db.discont("select sub_main_role from tb_Sub_main_role where role='" + DropDownList6.Text + "'");
        DropDownList7.DataSource = ds;
        DropDownList7.DataTextField = "sub_main_role";
        DropDownList7.DataBind();
        DropDownList7.Items.Insert(0, "Select sub_main_role............");
    }
    public void drop10()
    {
        ds.Clear();
        ds = db.discont("select sub_role from tb_subroles_of_subrole where role='" + DropDownList6.Text + "' and sub_main_role='"+DropDownList7.Text+"'");
        DropDownList10.DataSource = ds;
        DropDownList10.DataTextField = "sub_role";
        DropDownList10.DataBind();
        DropDownList10.Items.Insert(0, "Select sub_role............");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        //if (!Page.IsValid)
        //{
        //    RequiredFieldValidator2.Visible = RequiredFieldValidator1.Visible = false;
        //    Button2.CausesValidation = false;
        //    Button3.CausesValidation = false;
        //    Button1.CausesValidation = true;
        //}
        //else
        //{
        if ((DropDownList12.SelectedIndex != 0) && (TextBox1.Text!=""))
            {
                string str = "";
                ds.Clear();
                str = db.extscalr("select role from tb_role where role='" + TextBox1.Text + "'");
                if (str == "")
                {
                    ds.Clear();

                    ds = db.discont("insert into tb_role values('" + TextBox1.Text + "','" + DropDownList12.Text + "')");
                    TextBox1.Text = "";
                    drop1();
                    DropDownList12.SelectedIndex = 0;

                    RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Inserted')</Script>");
                }
                else
                {


                    RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry!! This role already Existed')</Script>");
                }
            }
            else
            {
                RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry!! please fill all fields')</Script>");

            }
      // }
            Request.RawUrl.ToString();
         
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        //Page.Validate();
        //if (!Page.IsValid)
        //{
        //   RequiredFieldValidator2.Visible = RequiredFieldValidator4.Visible = false;
        //   Button1.CausesValidation = false;
        //   Button3.CausesValidation = false;
        //   Button2.CausesValidation = true;

        //}
        //else{
        if ((DropDownList11.SelectedIndex != 0) && (DropDownList1.SelectedIndex != 0) && (TextBox2.Text != ""))
        {

            string str = "";
            ds.Clear();
            str = db.extscalr("select sub_main_role from tb_Sub_main_role where sub_main_role='" + TextBox2.Text + "' and role='" + DropDownList1.Text + "'");
            if (str == "")
            {
                ds.Clear();
                ds = db.discont("insert into tb_Sub_main_role values('" + DropDownList1.Text + "','" + TextBox2.Text + "','" + DropDownList11.Text + "')");
                TextBox2.Text = "";
                DropDownList1.ClearSelection();
                drop1();
                drop2();
                DropDownList11.SelectedIndex = 0;
                RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Inserted')</Script>");
            }
            else
            {
                TextBox2.Text = "";
                DropDownList1.ClearSelection();
                DropDownList11.ClearSelection();

                RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry!! This role already Existed')</Script>");
            }
        }
        else
        {
            RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry!! please fill all fields')</Script>");

        }
        Request.RawUrl.ToString();
   // }
    
     
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //Page.Validate();
        //if (!Page.IsValid)
        //{
        //    RequiredFieldValidator1.Visible = RequiredFieldValidator4.Visible = false;
        //    Button1.CausesValidation = false;
        //    Button2.CausesValidation = false;
        //    Button3.CausesValidation = true;

        //}
        //else
        //{
        if ((DropDownList2.SelectedIndex != 0) && (DropDownList3.SelectedIndex != 0) && (DropDownList4.SelectedIndex != 0) && (TextBox3.Text!=""))
            {
                string str = "";
                ds.Clear();
                str = db.extscalr("select sub_role from tb_subroles_of_subrole where sub_main_role='" + DropDownList3.Text + "' and role='" + DropDownList2.Text + "' and sub_role='"+TextBox3.Text+"'");
                if (str == "")
                {
                    ds.Clear();
                    ds = db.discont("insert into tb_subroles_of_subrole values('" + DropDownList2.Text + "','" + DropDownList3.Text + "','" + TextBox3.Text + "','" + DropDownList4.Text + "')");
                    TextBox3.Text = "";
                    DropDownList2.ClearSelection();
                    drop1();
                    drop2();
                    DropDownList3.ClearSelection();
                    DropDownList4.ClearSelection();
                    RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Inserted')</Script>");
                }

                else
                {
                    TextBox3.Text = "";
                    DropDownList2.ClearSelection();
                    drop1();
                    drop2();
                    DropDownList3.ClearSelection();
                    DropDownList4.ClearSelection();
                    RegisterStartupScript("", "<script Language=JavaScript>alert('Already Inserted')</Script>");

                }
            }
        
            else
            {


                RegisterStartupScript("", "<script Language=JavaScript>alert('Sorry!! please enter all field!!')</Script>");
            }
      //  }
       
   }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        drop3();
    }
    protected void DropDownList2_SelectedIndexChanged1(object sender, EventArgs e)
    {
        drop3();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        drop8();
        drop5();
        drop9();
        MultiView1.ActiveViewIndex = 1;
    }
    protected void DropDownList8_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        drop9();
    }
    protected void DropDownList6_SelectedIndexChanged1(object sender, EventArgs e)
    {
        drop7();
    }
    protected void DropDownList7_SelectedIndexChanged(object sender, EventArgs e)
    {
        drop10();
    }
    protected void DropDownList9_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int flag = 0;
        ds.Clear();
        ds = db.discont("select role from tb_employee_role ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {

                string rol = ds.Tables[0].Rows[i]["role"].ToString();
                string[] role = rol.Split('-');
                if (role[0] == DropDownList8.Text)
                {
                    flag = 1;

                   


                }
            }
            if (flag == 1)
            {


                RegisterStartupScript("", "<script Language=JavaScript>alert('canot delete')</Script>");
            }
            else
            {
                ds.Clear();
                ds = db.discont("select  p_id,roles from tb_role_policy");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                        string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                        string[] role = rol.Split('-');
                        if (role[0] == DropDownList8.Text)
                        {
                            ds1.Clear();
                            ds1 = db.discont1("delete from tb_role_policy where p_id='" + pd + "'");
                            drop1();
                            drop2();
                            drop3();
                            drop8();

                        }

                    }

                }

                ds.Clear();
                ds = db.discont("delete from tb_role where role='" + DropDownList8.Text + "'");
                ds.Clear();
                ds = db.discont("delete from tb_Sub_main_role where role='" + DropDownList8.Text + "'");
                ds.Clear();
                ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList8.Text + "'");
                RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");

            }

        }
        else
        {
           
            ds.Clear();
            ds = db.discont("select  p_id,roles from tb_role_policy");
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                    string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                    string[] role = rol.Split('-');
                    if (role[0] == DropDownList8.Text)
                    {
                        ds1.Clear();
                        ds1 = db.discont1("delete from tb_role_policy where p_id='"+pd+"'");
                        drop1();
                        drop2();
                        drop3();
                        drop8();
                        drop9();
                        drop5();

                    }

                }
               
            }
          
            ds.Clear();
            ds = db.discont("delete from tb_role where role='" + DropDownList8.Text + "'");
            ds.Clear();
            ds = db.discont("delete from tb_Sub_main_role where role='" + DropDownList8.Text + "'");
            ds.Clear();
            ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList8.Text + "'");
            Response.Write("manage_roles.aspx");
            //RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");
        }
        Request.RawUrl.ToString();
        Response.Redirect("manage_roles.aspx");
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        int flag = 0;
        ds.Clear();
        ds = db.discont("select role from tb_employee_role ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {

                string rol = ds.Tables[0].Rows[i]["role"].ToString();
                string[] role = rol.Split('-');

                if (role.Count() >1)
                {
                    if (role[0] == DropDownList5.Text && role[1]==DropDownList9.Text)
                    {
                        flag = 1;




                    }
                }
            }
            if (flag == 1)
            {


                RegisterStartupScript("", "<script Language=JavaScript>alert('canot delete')</Script>");
            }
            else
            {
                ds.Clear();
                ds = db.discont("select  p_id,roles from tb_role_policy");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                        string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                        string[] role = rol.Split('-');
                        if (role.Count() > 1)
                        {
                            if (role[0] == DropDownList5.Text && role[1] == DropDownList9.Text)
                            {
                                ds1.Clear();
                                ds1 = db.discont1("delete from tb_role_policy where p_id='" + pd + "'");
                                drop1();
                                drop2();
                               

                            }



                        }
                    }




                }

                
               
                ds = db.discont("delete from tb_Sub_main_role where role='" + DropDownList5.Text + "' and  sub_main_role='"+DropDownList9.Text+"'");
                ds.Clear();
                ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList5.Text + "' and  sub_main_role='" + DropDownList9.Text + "'");
                RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");
                DropDownList5.ClearSelection();
                DropDownList9.ClearSelection();
            }

        }
        else
        {

            ds.Clear();
            ds = db.discont("select  p_id,roles from tb_role_policy");
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                    string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                    string[] role = rol.Split('-');
                    if (role.Count() > 1)
                    {
                        if (role[0] == DropDownList5.Text && role[1] == DropDownList9.Text)
                        {
                            ds1.Clear();
                            ds1 = db.discont1("delete from tb_role_policy where p_id='" + pd + "'");

                        }



                    }
                }




            }



            ds = db.discont("delete from tb_Sub_main_role where role='" + DropDownList5.Text + "' and sub_main_role='" + DropDownList9.Text + "'");
            ds.Clear();
            ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList5.Text + "' and  sub_main_role='" + DropDownList9.Text + "'");
            RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");

        }
        Request.RawUrl.ToString();
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        int flag = 0;
        ds.Clear();
        ds = db.discont("select role from tb_employee_role ");
        if (ds.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                string rol = ds.Tables[0].Rows[i]["role"].ToString();
                string[] role = rol.Split('-');

                if (role.Count() > 2)
                {
                    if (role[0] == DropDownList6.Text && role[1] == DropDownList7.Text && role[2]==DropDownList10.Text)
                    {
                        flag = 1;




                    }
                }
            }
            if (flag == 1)
            {


                RegisterStartupScript("", "<script Language=JavaScript>alert('canot delete')</Script>");
            }
            else
            {
                ds.Clear();
                ds = db.discont("select  p_id,roles from tb_role_policy");
                if (ds.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                        string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                        string[] role = rol.Split('-');
                        if (role.Count() > 2)
                        {
                            if (role[0] == DropDownList6.Text && role[1] == DropDownList7.Text && role[2] == DropDownList10.Text)
                            {
                                ds1.Clear();
                                ds1 = db.discont1("delete from tb_role_policy where p_id='" + pd + "'");

                            }



                        }
                    }




                }



                
                ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList6.Text + "' and  sub_main_role='" + DropDownList7.Text + "' and sub_role='"+DropDownList10.Text+"'");
                RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");
            }

        }
        else
        {

            ds.Clear();
            ds = db.discont("select  p_id,roles from tb_role_policy");
            if (ds.Tables[0].Rows.Count > 0)
            {

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string rol = ds.Tables[0].Rows[i]["roles"].ToString();
                    string pd = ds.Tables[0].Rows[i]["p_id"].ToString();
                    string[] role = rol.Split('-');
                    if (role.Count() > 2)
                    {
                        if (role[0] == DropDownList6.Text && role[1] == DropDownList7.Text)
                        {
                            ds1.Clear();
                            ds1 = db.discont1("delete from tb_role_policy where p_id='" + pd + "'");

                        }



                    }
                }




            }


            ds = db.discont("delete from   tb_subroles_of_subrole where role='" + DropDownList6.Text + "' and  sub_main_role='" + DropDownList7.Text + "' and sub_role='" + DropDownList10.Text + "'");
            RegisterStartupScript("", "<script Language=JavaScript>alert('Succesfully Deleted')</Script>");

        }
        Request.RawUrl.ToString();
    }
}