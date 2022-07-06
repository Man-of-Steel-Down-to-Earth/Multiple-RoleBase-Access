using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Employee_access_denied_files : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    DataSet ds2 = new DataSet();


    DataSet ds1 = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            ds = db.discont("truncate table tb_temp_files");
            List<string> files = new List<string>();
            ds.Clear();
            ds.Clear();
            List<string> eroles = new List<string>();
            string fr_role = db.extscalr("select role from  tb_role where priority='1'");
            if (fr_role != "")
            {
                ds.Clear();
                ds = db.discont("select role from  tb_employee_role where username='" + Session["user"].ToString() + "' ");
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    eroles.Add(ds.Tables[0].Rows[i]["role"].ToString());
                }
                if (eroles.Contains(fr_role))
                {


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
                        ds = db.discont("truncate table tb_temp_files");
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            //ds.Clear();
                            //ds = db.discont2("select * from tb_upload where fname not in(select fnames from tb_temp_files)");
                            GridView1.DataSource = ds;
                            GridView1.DataBind();
                        }
                    }
                }
                else
                {
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
                        ds = db.discont2("select * from tb_upload where fname not in(select fnames from tb_temp_files)");
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                    else
                    {
                        ds = db.discont("truncate table tb_temp_files");

                        ds.Clear();
                        ds = db.discont1("select distinct filename from [tb_role_policy]");
                        ds1.Clear();
                        List<string> fn = new List<string>();
                        List<string> temp_files = new List<string>();

                        ds1 = db.discont1("select role from [tb_employee_role] where username='" + Session["user"].ToString() + "'");
                        for (int i1 = 0; i1 < ds1.Tables[0].Rows.Count; i1++)
                        {
                            fn.Add(ds1.Tables[0].Rows[i1]["role"].ToString());
                        }
                        for (int i1 = 0; i1 < ds.Tables[0].Rows.Count; i1++)
                        {

                            temp_files.Add(ds1.Tables[0].Rows[i1]["filename"].ToString());
                        }
                        for (int i1 = 0; i1 < temp_files.Count; i1++)
                        {
                            string file = temp_files[i1].ToString();
                            ds.Clear();
                            List<string> tmp_role = new List<string>();
                            ds = db.discont1("select roles from [tb_role_policy] where filename='" + file + "'");
                            for (int i2 = 0; 21 < ds.Tables[0].Rows.Count; i2++)
                            {
                                tmp_role.Add(ds1.Tables[0].Rows[i1]["roles"].ToString());

                            }
                            for (int i2 = 0; i2 < fn.Count; i2++)
                            {
                                if (tmp_role.Contains(fn[i2].ToString()))
                                {
                                    string chk = db.extscalr("select fnames from [tb_temp_files] where fnames='" + file + "'");
                                    if (chk == "")
                                    {
                                        bool b = db.extnon("insert into tb_temp_files values('" + file + "')");
                                    }
                                }
                            }
                        }



                        ds.Clear();
                        ds = db.discont2("select * from tb_upload where fname not in(select fnames from tb_temp_files)");
                        GridView1.DataSource = ds;
                        GridView1.DataBind();



                    }

                }
            }
            else
            {
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
                    ds = db.discont2("select * from tb_upload where fname not in(select fnames from tb_temp_files)");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }

            }

            //for (int i = 0; i < GridView1.Rows.Count; i++)
            //{
            //    string fname = ((Label)GridView1.Rows[i].Cells[5].FindControl("label1")).Text;
            //     ds = db.discont("select fname,request_st from tb_requested_files where fname='" + fname + "' and request_by='" + Session["user"].ToString() + "'");
            //        if (ds.Tables[0].Rows.Count > 0)
            //        {
            //            Session["st"] = ds.Tables[0].Rows[0]["request_st"].ToString();
            //            if (Session["st"] == "1")
            //            {

            //                ((LinkButton)GridView1.Rows[i].Cells[5].FindControl("LinkButton1")).Text = "Waiting!....";
            //            }
            //            else
            //            {
            //                ((LinkButton)GridView1.Rows[i].Cells[5].FindControl("LinkButton1")).Text = "Send Request";
            //            }
            //        }
            //}





        }
    }





    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ds.Clear();
        string fname = ((Label)GridView1.Rows[e.RowIndex].Cells[5].FindControl("label1")).Text;
        string uname = ((Label)GridView1.Rows[e.RowIndex].Cells[5].FindControl("label2")).Text;

        ds = db.discont("select fname,request_st from tb_requested_files where fname='" + fname + "' and request_by='" + Session["user"].ToString() + "'");
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["st"] = ds.Tables[0].Rows[0]["request_st"].ToString();
            if (Session["st"] == "1")
            {

                RegisterStartupScript("", "<script Language=JavaScript>alert('You Already Send an Request to this file')</Script>");


            }
            else
            {

                ds1.Clear();
                ds1 = db.discont("delete from tb_requested_files where fname='" + fname + "' and request_by='" + Session["user"].ToString() + "'");
                ds1.Clear();
                string un = db.extscalr("select username from tb_login where username='" + uname + "'");
                if (un == "")
                {
                    ds1 = db.discont("insert into tb_requested_files values('" + fname + "','" + uname + "','" + Session["user"].ToString() + "','" + DateTime.Now.ToString() + "','0','2')");
                    RegisterStartupScript("", "<script Language=JavaScript>alert('Send Request to this file')</Script>");
                }
                else
                {


                    ds1 = db.discont("insert into tb_requested_files values('" + fname + "','" + uname + "','" + Session["user"].ToString() + "','" + DateTime.Now.ToString() + "','0','1')");
                    RegisterStartupScript("", "<script Language=JavaScript>alert('Send Request to this file')</Script>");
                }
            }



        }
        else
        {
            string un = db.extscalr("select username from tb_login where username='" + uname + "'");
            if (un == "")
            {
                ds1 = db.discont("insert into tb_requested_files values('" + fname + "','" + uname + "','" + Session["user"].ToString() + "','" + DateTime.Now.ToString() + "','0','2')");
                RegisterStartupScript("", "<script Language=JavaScript>alert('Send Request to this file')</Script>");
            }
            else
            {
                ds1.Clear();
                ds1 = db.discont("insert into tb_requested_files values('" + fname + "','" + uname + "','" + Session["user"].ToString() + "','" + DateTime.Now.ToString() + "','0','1')");
                RegisterStartupScript("", "<script Language=JavaScript>alert('Send Request to this file')</Script>");

            }
        }
    }
}