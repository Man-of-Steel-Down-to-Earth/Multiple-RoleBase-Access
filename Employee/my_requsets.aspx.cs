using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Employee_my_requsets : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            show_request();
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
    public void show_request()
    {

        ds.Clear();
        ds = db.discont("select * from tb_requested_files where request_to='" + Session["user"].ToString() + "' and request_st='1'");
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ds.Clear();
        bool b = db.extnon("update tb_requested_files set request_st='3', app_or_rej_date='" + DateTime.Now.ToString() + "' where request_to='" + Session["user"].ToString() + "' and request_by='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        show_request();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ds.Clear();
     bool b=db.extnon("update tb_requested_files set request_st='2', app_or_rej_date='" + DateTime.Now.ToString() + "' where request_to='" + Session["user"].ToString() + "' and request_by='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        show_request();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
} 