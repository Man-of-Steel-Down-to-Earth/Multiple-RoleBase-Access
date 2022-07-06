using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class test_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //try
        //{
        //    MailMessage MailObj = new MailMessage();
        //    MailObj.To.Add("testtrinity123@gmail.com");
        //    MailObj.From = new MailAddress("testtrinity123@gmail.com", "TESTTRINITY333");
        //    MailObj.IsBodyHtml = true;
        //    MailObj.Priority = MailPriority.Normal;
        //    MailObj.Subject = "wow";
        //    MailObj.Body = "bsvcvb";
        //    SmtpClient smtpcli = new SmtpClient("smtp.gmail.com", 587); //use this PORT!
        //    smtpcli.EnableSsl = true;
        //    smtpcli.DeliveryMethod = SmtpDeliveryMethod.Network;
        //    smtpcli.Credentials = new System.Net.NetworkCredential("testtrinity123@gmail.com", "TESTTRINITY333");
        //    try
        //    {
        //        smtpcli.Send(MailObj);
        //    }
        //    catch (Exception ex)
        //    {


        //    }
        //}
        //catch (Exception ex)
        //{
        //    Response.Write(ex);
        //}
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

    
        //FileStream fs = new FileStream("Chapter1_Example1.pdf", FileMode.Create, FileAccess.Write, FileShare.None);
        //Document doc = new Document();
        //PdfWriter writer = PdfWriter.GetInstance(doc, fs);
        //doc.Open();
        //doc.Add(new Paragraph("Hello World"));
        //doc.Close();

        Document doc = new Document();
        //Create PDF Table  
        PdfPTable tableLayout = new PdfPTable(4);
        //Create a PDF file in specific path  
        PdfWriter.GetInstance(doc, new FileStream(Server.MapPath("~/Sample-PDF-File1.pdf"), FileMode.Create));
        //Open the PDF document  
        doc.Open();
        //Add Content to PDF  
        doc.Add(new Paragraph("hello world"));
        // Closing the document  
        doc.Close();
        //btnOpenPDFFile.Enabled = true;
        //btnGeneratePDFFile.Enabled = false;  
        string path = Server.MapPath("~/Sample-PDF-File1.pdf");

        //for download

        WebClient req = new WebClient();
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.Buffer = true;
        response.AddHeader("Content-Disposition", "attachment;filename=" + Path.GetFileName(path.ToString()));
        Response.WriteFile(path.ToString());


        Response.Flush();


        response.End();



    }
}