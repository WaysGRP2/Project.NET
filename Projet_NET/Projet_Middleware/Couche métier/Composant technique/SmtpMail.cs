using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MessageSerializable;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class SmtpMail
    {
        static private string MAIL = "exiacesiways@outlook.com";
        static private string MAIL_USERNAME = "exiacesiways@outlook.com";
        static private string MAIL_PASSWORD = "Ways2014A2";
        private MailMessage message;
        private SmtpClient smtp;
        private NetworkCredential basicCredential;

        public SmtpMail()
        {
            message = new MailMessage();
            smtp = new SmtpClient();
            basicCredential = new NetworkCredential(MAIL_USERNAME, MAIL_PASSWORD);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = basicCredential;
        }

        public Message send(Message oMsg)
        {
            message.To.Add((string)oMsg.Data[0]);
            message.Subject = "JPO Exia Cesi";
            message.From = new System.Net.Mail.MailAddress(SmtpMail.MAIL, "Exia Cesi");
            if ((string)oMsg.Data[1] == null)
            {
                oMsg.Statut = false;
                return oMsg;
            }
            else
            {
                message.Body = (string)oMsg.Data[1];
            }

            smtp.Host = "smtp.live.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.Send(message);

            oMsg.Statut = true;
            return oMsg;
        }
    }
}
