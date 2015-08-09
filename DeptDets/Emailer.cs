using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Mail;
using System.IO;

using System.Windows.Forms;


namespace DeptDets
{
    class Emailer
    {
        string strFromEmail, strPassword;

        public Emailer( string strE, string strP)
        {
            strFromEmail = strE;
            strPassword = strP;
        }

        public void SendMessage(string strTo, string strCC, string strSubject, string strMessage, bool bCopyYH)
        {
            // This is: "Mail To"..
            MailAddress to = new MailAddress(strTo);

            // This is: "Mail From"..
            MailAddress from = new MailAddress(strFromEmail);

            MailMessage mail = new MailMessage(from, to);
            mail.Subject = strSubject;
            mail.Body = strMessage;

            // copy year head..

            // Add a carbon copy recipient..

            if (bCopyYH)
            {
                MailAddress copy = new MailAddress(strCC);
                mail.CC.Add(copy);
            }
            // set up client and send email..

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;

            smtp.Credentials = new NetworkCredential(strFromEmail, strPassword);
            smtp.EnableSsl = true;

            if (bCopyYH == false)
            {
                strCC = "";
            }

            ConvertChars c = new ConvertChars();

            DialogResult r = MessageBox.Show("Proceed with: " + c.NL() + "To: " + strTo + c.NL() + "cc: " + strCC + c.DoubleNL() + "Re: " + strSubject + c.DoubleNL() + strMessage, "Send Message", MessageBoxButtons.YesNo);

            if (r == DialogResult.Yes)
            {
                smtp.Send(mail);
                MessageBox.Show("Message Sent");
            }
            else
            {
                MessageBox.Show("Message was not sent");
            }

        }
    }
}
