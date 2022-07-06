using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class CEO_set_roles_to_employees : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            show_grid();
            for (int i = 0; i < DataList1.Items.Count; i++)
            {
                string username = ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text;

                ds.Clear();
                ds = db.discont("select role from tb_employee_role where username='" + username + "'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                    {
                        ((BulletedList)DataList1.Items[i].FindControl("BulletedList1")).Items.Add(ds.Tables[0].Rows[j]["role"].ToString());
                    }
                }
                else
                {
                    ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Visible = true;
                    ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text = "NO ROLES";
                    ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Red;
                }





            }
        }
    }
    public void show_grid()
    {

        ds.Clear();
        ds = db.discont("select * from tb_manage_employee");
        if (ds.Tables[0].Rows.Count > 0)
        {
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }
        else
        {
            Panel2.Visible = true;
        }

     

    }
   

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "set_role" || e.CommandName=="upd")
        {
            Response.Redirect("~/CEO/set_role.aspx?ename="+e.CommandArgument.ToString());

        }
       
    
    }
    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = e.Item.ItemIndex;
        show_grid();
    }
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        
    }
    protected void DataList1_UpdateCommand1(object source, DataListCommandEventArgs e)
    {
        string name = ((TextBox)e.Item.FindControl("textbox1")).Text;
        string con = ((TextBox)e.Item.FindControl("textbox2")).Text;
        string add = ((TextBox)e.Item.FindControl("textbox3")).Text;
        string ema = ((Label)e.Item.FindControl("label14")).Text;

        ds.Clear();
        ds = db.discont("update tb_manage_employee set name='" + name + "',contact='" + con + "',address='" + add + "' where email='" + ema + "'");
        DataList1.EditItemIndex = -1;
        show_grid();
        for (int i = 0; i < DataList1.Items.Count; i++)
        {
            string username = ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text;

            ds.Clear();
            ds = db.discont("select role from tb_employee_role where username='" + username + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ((BulletedList)DataList1.Items[i].FindControl("BulletedList1")).Items.Add(ds.Tables[0].Rows[j]["role"].ToString());
                }
            }
            else
            {
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Visible = true;
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text = "NO ROLES";
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Red;
            }

        }

    }
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        DataList1.EditItemIndex = -1;
        show_grid();
        for (int i = 0; i < DataList1.Items.Count; i++)
        {
            string username = ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text;

            ds.Clear();
            ds = db.discont("select role from tb_employee_role where username='" + username + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    ((BulletedList)DataList1.Items[i].FindControl("BulletedList1")).Items.Add(ds.Tables[0].Rows[j]["role"].ToString());
                }
            }
            else
            {
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Visible = true;
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).Text = "NO ROLES";
                ((LinkButton)DataList1.Items[i].FindControl("LinkButton1")).ForeColor = System.Drawing.Color.Red;
            }





        }
    }
}