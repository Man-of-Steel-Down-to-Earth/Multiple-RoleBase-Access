using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;


/// <summary>
/// Summary description for mail
/// </summary>
public class mail
{
    public void send_msg(string subject, string body)
    {


        try
        {

            MailMessage MailObj = new MailMessage();
            MailObj.To.Add("neethus98sk@gmail.com");
            MailObj.From = new MailAddress("testtrinity123@gmail.com");
            MailObj.IsBodyHtml = true;
            MailObj.Priority = MailPriority.Normal;
            MailObj.Subject = subject;
            MailObj.Body = body;
            SmtpClient smtpcli = new SmtpClient("smtp.gmail.com", 587); //use this PORT!
            smtpcli.EnableSsl = true;
            smtpcli.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpcli.Credentials = new System.Net.NetworkCredential("testtrinity123@gmail.com", "TESTTRINITY444");
            try
            {
                smtpcli.Send(MailObj);
            }
            catch (Exception ex)
            {


            }
        }
        catch (Exception ex)
        {

        }


    }
    public void send_msg_attachment(string subject, string body,string attach)
    {


        try
        {

            MailMessage MailObj = new MailMessage();
            MailObj.To.Add("neethus98sk@gmail.com");
            MailObj.From = new MailAddress("testtrinity123@gmail.com");
            MailObj.IsBodyHtml = true;
            MailObj.Priority = MailPriority.Normal;
            MailObj.Subject = subject;
            MailObj.Body = body;
            MailObj.Attachments.Add(new Attachment(attach));
            SmtpClient smtpcli = new SmtpClient("smtp.gmail.com", 587); //use this PORT!
            smtpcli.EnableSsl = true;
            smtpcli.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpcli.Credentials = new System.Net.NetworkCredential("testtrinity123@gmail.com", "TESTTRINITY444");
            try
            {
                smtpcli.Send(MailObj);
            }
            catch (Exception ex)
            {


            }
        }
        catch (Exception ex)
        {

        }


    }
}