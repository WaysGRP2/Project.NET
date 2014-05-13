using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MessageSerializable;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class SmtpMail
    {
        private MailMessage message;
        private SmtpClient smtp;
        private NetworkCredential basicCredential;
        private SMTPConfig config;

        public SmtpMail()
        {
            message = new MailMessage();
            smtp = new SmtpClient();
            config = (SMTPConfig)Projet_Middleware.Service_étendu.ComSMTP.GetInstance().GetSmtpConfig().Data[0];
            basicCredential = new NetworkCredential(config.Username, config.Password);
            Program.Debug(config.ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = basicCredential;
        }

        public Message send(Message oMsg)
        {
            try
            {
                message.To.Add((string)oMsg.Data[0]);
                message.Subject = "JPO Exia Cesi";
                message.From = new System.Net.Mail.MailAddress(config.Address, "Exia Cesi");
                if ((string)oMsg.Data[1] == null)
                {
                    oMsg.Statut = false;
                    return oMsg;
                }
                else
                {
                    message.Body = (string)oMsg.Data[1];
                }

                smtp.Host = config.Host;
                smtp.Port = config.Port;
                smtp.EnableSsl = config.EnableSSL;
                smtp.Send(message);

                oMsg.Statut = true;
                return oMsg;
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERREUR :" + ex.Message);
                oMsg.Statut = false;
                return oMsg;
            }
        }
    }
}
