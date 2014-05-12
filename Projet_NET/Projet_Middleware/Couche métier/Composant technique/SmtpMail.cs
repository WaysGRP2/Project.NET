using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class SmtpMail
    {
        static public string MAIL = "victor.rebiardcrepin@viacesi.fr";
        private MailMessage message;
        private SmtpClient smtp;

        public SmtpMail()
        {
            message = new MailMessage();
            smtp = new SmtpClient();
        }

        public Message send(Message oMsg)
        {
            message.To.Add((string)oMsg.Data[0]);
            message.Subject = "JPO Exia Cesi";
            message.From = new System.Net.Mail.MailAddress(SmtpMail.MAIL);
            if ((string)oMsg.Data[1] == null)
            {
                oMsg.Statut = false;
                return oMsg;
            }
            else
            {
                message.Body = (string)oMsg.Data[1];
            }

            smtp.Host = "smtp.orange.fr";
            smtp.Port = 25;
            smtp.Send(message);

            oMsg.Statut = true;
            return oMsg;
        }
    }
}
