using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Employee_access_files : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
  

    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ds = db.discont("truncate table tb_temp_files");
            List<string> files = new List<string>();
            ds.Clear();
            List<string> eroles = new List<string>();
            string fr_role = db.extscalr("select role from  tb_role where priority='1'");
            if (fr_role != "")
            {
                ds.Clear();
                ds = db.discont("select role from  tb_employee_role where username='" + Session["user"].ToString() + "' ");
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eroles.Add(ds.Tables[0].Rows[i]["role"].ToString());
                }
                if (eroles.Contains(fr_role))
                {
                    ds.Clear();
                    ds = db.discont("truncate table tb_temp_files");
                    ds.Clear();
                    ds = db.discont("select fname from tb_upload");
                    
                    for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        bool b = db.extnon("insert into tb_temp_files values('" + ds.Tables[0].Rows[i]["fname"] + "')");

                    }
                    ds.Clear();
                    ds = db.discont("select * from tb_upload u,tb_temp_files t where t.fnames=u.fname");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    ds.Clear();

                    ds.Clear();
                    ds = db.discont("truncate table tb_temp_files");

                    ds = db.discont("select * from tb_role_policy r,tb_employee_role e,tb_manage_employee m where r.roles=e.role and r.priority=e.priority and e.username='" + Session["user"] + "' and m.username=e.username");
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string chk = db.extscalr("select fnames from tb_temp_files where fnames='" + ds.Tables[0].Rows[i]["filename"] + "'");
                            if (chk == "")
                            {
                                bool b = db.extnon("insert into tb_temp_files values('" + ds.Tables[0].Rows[i]["filename"] + "')");
                            }
                        }
                        ds.Clear();
                        ds = db.discont("select * from tb_upload u,tb_temp_files t where t.fnames=u.fname");
                        GridView1.DataSource = ds;
                        GridView1.DataBind();

                    }
                }
            }
            else
            {
                ds.Clear();
                ds = db.discont("truncate table tb_temp_files");

                ds.Clear();



                ds = db.discont("select * from tb_role_policy r,tb_employee_role e,tb_manage_employee m where r.roles=e.role and r.priority=e.priority and e.username='" + Session["user"] + "' and m.username=e.username");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        string chk = db.extscalr("select fnames from tb_temp_files where fnames='" + ds.Tables[0].Rows[i]["filename"] + "'");
                        if (chk == "")
                        {
                            bool b = db.extnon("insert into tb_temp_files values('" + ds.Tables[0].Rows[i]["filename"] + "')");
                        }
                    }
                    ds.Clear();
                    ds = db.discont("select * from tb_upload u,tb_temp_files t where t.fnames=u.fname");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();

                }
            }
        }
    }


  

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string fname = ((Label)GridView1.Rows[e.RowIndex].Cells[5].FindControl("label1")).Text;
        Session["fname"] = fname;
        Response.Redirect("~/Employee/download.aspx");
    }
}