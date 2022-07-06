 using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Proxy_reencrpt : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    dbconect db = new dbconect();
    rsa_algorithm rsa = new rsa_algorithm();
    cloud cloud = new cloud();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            show_grid();

        }
    }
    public void show_grid()
    {

        ds.Clear();
        ds = db.discont("select * from tb_upload u,tb_manage_employee m where (u.owner_name=m.username) and (u.e_status='0' or u.e_status='2')");
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string fname = (GridView1.Rows[e.RowIndex].Cells[2]).Text;
        string ext = db.extscalr("select extension from tb_upload where fname='"+fname+"'");
        string epath = Server.MapPath("~/Employee/files/efile/" + fname + ".txt");
        string epathimage = Server.MapPath("~/Employee/files/efile/" + fname + ext);
        if (File.Exists(epath))
        {
            string content = File.ReadAllText(epath);

            string path = Server.MapPath("~/RSA_KEYS/" + fname);
            string public_path = Server.MapPath("~/RSA_KEYS/" + fname + "/" + fname + ".pbl");
            string private_path = Server.MapPath("~/RSA_KEYS/" + fname + "/" + fname + ".pri");

            rsa.generatkey(fname, path, public_path, private_path);

            if (ext == ".jpg" || ext == ".png" || ext == ".PNG" || ext == ".JPG")
            {
            //    //  string epathimage = Server.MapPath("~/Employee/files/efile/" + fname + ext);


            //    //string rsa_path = Server.MapPath("~/Employee/files/rsa_file/" + fname +ext);

            //    //File.WriteAllText(rsa_path, content);

            }
            else
            {
                string rsa_encrypt = rsa.RSAEncrypt(content, private_path);

                string rsa_path = Server.MapPath("~/Employee/files/rsa_file/" + fname + ".txt");
                File.WriteAllText(rsa_path, rsa_encrypt);
            }
        }

        //File.Delete(epath);

        //cloud.cloud_upload(rsa_path);



        bool b = db.extnon("update tb_upload set e_status='1' where fname='"+fname+"'");
        show_grid();
        RegisterStartupScript("", "<script Language=JavaScript>alert('Successfully Re-encrypted')</Script>");



    }
}