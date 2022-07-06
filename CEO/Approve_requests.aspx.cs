using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CEO_Approve_requests : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            show_request();

        }
    }
    public void show_request()
    {

        ds.Clear();
        ds = db.discont("select * from tb_requested_files where  request_st='2'");
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        ds.Clear();
        ds = db.discont("update tb_requested_files set request_st='5', app_or_rej_date='" + DateTime.Now.ToString() + "' where fname='" + GridView1.Rows[e.RowIndex].Cells[1].Text + "' and request_by='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        show_request();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        ds.Clear();
        ds = db.discont("update tb_requested_files set request_st='4', app_or_rej_date='" + DateTime.Now.ToString() + "' where fname='" + GridView1.Rows[e.RowIndex].Cells[1].Text + "' and request_by='" + GridView1.Rows[e.RowIndex].Cells[2].Text + "'");
        show_request();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}