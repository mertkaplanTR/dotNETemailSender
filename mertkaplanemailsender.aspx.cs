//This application Coded By Mert KAPLAN
//mertkaplanblog.wordpress.com
//Please use hotmail accounts.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) { }

    void send()
    {
        SmtpClient client = new SmtpClient();
        client.Port = 587;
        client.Host = "smtp.live.com";
        client.EnableSsl = true;
        client.Timeout = 50000;
        //edit area
        client.Credentials = new NetworkCredential("edityour@hotmail.com", "edityourpassword"); 
        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("edit", "edit");
        mail.To.Add(targetMailTextBox.Text);
        mail.Subject = subjectTextBox.Text;
        mail.Body = messageTextBox.Text;
        try {
            client.Send(mail);
            Status.Visible = true;
        }
        catch (Exception except)
        {
            Status.Text = "Failed";
            Status.ForeColor = System.Drawing.Color.Red;
            Status.Visible = true;
            
        }
    }

    protected void sendButton_Click(object sender, EventArgs e)
    {
        for (int i = 0; i < Int32.Parse((loopTextBox.Text)); i++)
        {
            send();
        }
    }
}