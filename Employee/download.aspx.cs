using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using iTextSharp.text;
using iTextSharp.text.pdf;


public partial class Employee_download : System.Web.UI.Page
{
    DataSet ds = new DataSet();
    cryptography crypt = new cryptography();
    dbconect db = new dbconect();
    cloud cs = new cloud();
    rsa_algorithm rsa = new rsa_algorithm();
    string full_path = "";
    mail ma = new mail();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
           TextBox1.Text = Session["fname"].ToString();
            ds = db.discont("select owner_name,date from  tb_upload where fname='" + TextBox1.Text + "'");
            TextBox2.Text = ds.Tables[0].Rows[0]["owner_name"].ToString();
            TextBox3.Text = ds.Tables[0].Rows[0]["date"].ToString();
            ds.Clear();
            ds = db.discont("select token from tb_role_policy where filename='" + TextBox1.Text + "'");
            ViewState["token"] = ds.Tables[0].Rows[0]["token"].ToString();
         //   ma.send_msg("Token", ViewState["token"].ToString());
            ds.Clear();
            ds = db.discont("select skey from tb_manage_employee where username='" + Session["user"].ToString() + "'");
            ViewState["skey"] = ds.Tables[0].Rows[0]["skey"].ToString();

           

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {


        string estatus=db.extscalr("select e_status from  tb_upload where fname='" + TextBox1.Text + "'");

        if (estatus == "1")
        {
            try
            {
                string private_path_emp = Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + Session["user"].ToString() + ".pri");
                string read_private = File.ReadAllText(private_path_emp);
                if ((TextBox4.Text == ViewState["skey"].ToString()) && (TextBox6.Text == read_private))
                {
                    string enc_tok_path = File.ReadAllText(Server.MapPath("~/RSA_KEYS/token_key/" + Session["user"].ToString() + "/" + TextBox1.Text + "/" + TextBox1.Text + ".txt"));

                    string tok_decrypt = rsa.RSAdecryption(enc_tok_path, TextBox1.Text, private_path_emp);

                    string tok = db.extscalr("select token from tb_role_policy where filename='" + TextBox1.Text + "'");
                    if (tok == tok_decrypt)
                    {
                        string fname = TextBox1.Text + ".txt";
                        string rsa_path = Server.MapPath("~/Employee/files/rsa_file/" + fname);
                        string content = "";
                        if (File.Exists(rsa_path))
                        {
                            content = File.ReadAllText(rsa_path);
                        }
                        string ekey = db.extscalr("select ekey from tb_upload where fname='" + TextBox1.Text + "'");

                        ds = db.discont("select extension from tb_upload where fname='" + TextBox1.Text + "'");
                        string ex = ds.Tables[0].Rows[0]["extension"].ToString();

                        string rsa_decrypt = "";


                        ds.Clear();

                        string decrpt_content = "";
                        if (ex == ".jpg" || ex == ".png" || ex == ".PNG" || ex == ".JPG")
                        {
                            string imagePath = Server.MapPath("~/Employee/files/efile/" + TextBox1.Text + ex);
                            full_path = Server.MapPath("~/Employee/download/" + TextBox1.Text + ex);
                            crypt.Decrypt(imagePath, full_path, ekey);
                        }
                        else
                        {

                            string private_path = Server.MapPath("~/RSA_KEYS/" + TextBox1.Text + "/" + TextBox1.Text + ".pri");
                            rsa_decrypt = rsa.RSAdecryption(content, fname, private_path);

                            decrpt_content = cs.Decrypt(rsa_decrypt, ekey);
                        }
                        string all_con = decrpt_content;
                        if (ex == ".txt" || ex == ".doc" || ex == ".pdf")
                        {

                            if(ex==".pdf")
                            {
                                Document doc = new Document();
                                //Create PDF Table  
                                PdfPTable tableLayout = new PdfPTable(4);
                                //Create a PDF file in specific path  
                                PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Employee/download/" + TextBox1.Text+".pdf"), FileMode.Create));
                                //Open the PDF document  
                                doc.Open();
                                //Add Content to PDF  
                                doc.Add(new Paragraph(all_con));
                                // Closing the document  
                                doc.Close();
                               full_path =Server.MapPath("~/Employee/download/" + TextBox1.Text + ".pdf");
                            }

                            else{

                            full_path = Server.MapPath("~/Employee/download/" + TextBox1.Text + ex);
                            }
                        }
                        else if (ex == ".docx")
                        {
                            ex = ".doc";
                            full_path = Server.MapPath("~/Employee/download/" + TextBox1.Text + ex);

                        }


                        if (ex == ".jpg" || ex == ".png" || ex == ".PNG" || ex == ".JPG"||ex==".pdf")
                        {

                        }
                        else
                        {
                            File.WriteAllText(full_path, decrpt_content);
                        }


                        WebClient req = new WebClient();
                        HttpResponse response = HttpContext.Current.Response;
                        response.Clear();
                        response.ClearContent();
                        response.ClearHeaders();
                        response.Buffer = true;
                        response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(full_path.ToString()));
                        Response.WriteFile(full_path.ToString());


                        Response.Flush();


                        response.End();
                    }
                    else
                    {

                        RegisterStartupScript("","<script>alert('can't download')</script>");
                    }




                }
            }
            catch (Exception x)
            {
                RegisterStartupScript("", "<script>alert('can't download')</script>");


            }
        }
        else
        {

            RegisterStartupScript("","<script>alert('Download Failed!!.. Waiting for reencrypt');</script>");
        }
    }
}