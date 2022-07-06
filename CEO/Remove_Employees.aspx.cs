using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CEO_Remove_Employees : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show_grid();
            ds.Clear();
            ds = db.discont("select role from tb_role");
            DropDownList1.DataSource=ds;
            DropDownList1.DataTextField = "role";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, ".....Select Role........");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        bool b = db.extnon("delete from tb_login where username='"+e.CommandArgument.ToString()+"'");
        bool c = db.extnon("delete from tb_manage_employee where username='" + e.CommandArgument.ToString() + "'");
        bool f = db.extnon("delete from tb_employee_role where username='" + e.CommandArgument.ToString() + "'");

        //List<string> fn = new List<string>();
        //ds.Clear();
        //ds = db.discont("select fname from tb_upload where owner_name='" + e.CommandArgument.ToString() + "'");
        //for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //{
        //    fn.Add(ds.Tables[0].Rows[i]["fname"].ToString());

        //}
        //bool d = db.extnon("delete from tb_upload where owner_name='" + e.CommandArgument.ToString() + "'");
        //for (int i = 0; i < fn.Count; i++)
        //{
        //    bool f = db.extnon("delete from tb_role_policy where filename='" +fn[i].ToString() + "'");


        //}
        show_grid();

    }
    public void show_grid()
    {
        ds.Clear();
        ds = db.discont("select * from tb_manage_employee");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            ((Label)GridView1.Rows[i].Cells[0].FindControl("label1")).Text = (i + 1).ToString();
        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        string role = "%" + DropDownList1.Text + "%";
        ds = db.discont("select * from tb_manage_employee where username in (select distinct username from tb_employee_role where role like '"+role+"')");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            ((Label)GridView1.Rows[i].Cells[0].FindControl("label1")).Text = (i + 1).ToString();
        }

        ds.Clear();
        ds = db.discont("select sub_main_role from tb_Sub_main_role  where role='"+DropDownList1.Text+"'");
        DropDownList2.DataSource = ds;
        DropDownList2.DataTextField = "sub_main_role";
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, ".....Select SubRole........");

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
     //   ds = db.discont("select * from tb_manage_employee where role='" + DropDownList1.Text+","+DropDownList2.Text + "'");
        string role = "%" + DropDownList1.Text +"-"+DropDownList2.Text+ "%";
        ds = db.discont("select * from tb_manage_employee where username in (select distinct username from tb_employee_role where role like '" + role + "')");

        GridView1.DataSource = ds;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            ((Label)GridView1.Rows[i].Cells[0].FindControl("label1")).Text = (i + 1).ToString();
        }

        ds.Clear();
        ds = db.discont("select sub_role from tb_subroles_of_subrole  where role='" + DropDownList1.Text + "' and sub_main_role='"+DropDownList2.Text+"'");
        DropDownList3.DataSource = ds;
        DropDownList3.DataTextField = "sub_role";
        DropDownList3.DataBind();
        DropDownList3.Items.Insert(0, ".....Select Main Role........");

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
      
        //   ds = db.discont("select * from tb_manage_employee where role='" + DropDownList1.Text+","+DropDownList2.Text + "'");
        string role = "%" + DropDownList1.Text + "-" + DropDownList2.Text + "%" + "-" + DropDownList3.Text + "%";
        ds = db.discont("select * from tb_manage_employee where username in (select distinct username from tb_employee_role where role like '" + role + "')");
      //  ds.Clear();
        // string role = DropDownList1.Text + "," + DropDownList2.Text + "," + DropDownList3.Text;
       // ds = db.discont("select * from tb_manage_employee where role='"+role+"'");
        GridView1.DataSource = ds;
        GridView1.DataBind();
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {

            ((Label)GridView1.Rows[i].Cells[0].FindControl("label1")).Text = (i + 1).ToString();
        }
    }
}