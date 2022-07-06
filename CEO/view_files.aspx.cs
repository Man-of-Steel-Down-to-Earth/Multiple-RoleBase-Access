using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CEO_view_files : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    List<string> roles = new List<string>();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            show_files();

        }
    }


    public void show_files()
    {
        ds.Clear();
        ds = db.discont("select distinct filename from tb_role_policy");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DropDownList1.DataSource = ds;
            DropDownList1.DataTextField = "filename";
            DropDownList1.DataBind();

            DropDownList1.Items.Insert(0, "Choose File......");

        }

    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ds.Clear();
        ds = db.discont("select  * from tb_upload where fname='" + DropDownList1.SelectedItem.Text + "'");
        GridView1.DataSource = ds;
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {

                string str = ((Label)GridView1.Rows[i].Cells[4].FindControl("label1")).Text;

                ds.Clear();
                ds = db.discont("select roles from tb_role_policy where filename='" + str + "'");
                List<string> ls = new List<string>();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {

                        if (!ls.Contains(ds.Tables[0].Rows[j]["roles"].ToString()))
                        {
                            ls.Add(ds.Tables[0].Rows[j]["roles"].ToString());
                        }


                    }



                }
                for (int k = 0; k < ls.Count; k++)
                {
                    ((BulletedList)GridView1.Rows[i].Cells[4].FindControl("bulletedlist1")).Items.Add(ls[k].ToString());

                }



            }
            DropDownList1.ClearSelection();



        }
    }
}