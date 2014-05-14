using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Service_étendu
{
    class ComSMTP
    {
        private static ComSMTP instance = null;
        private MailMessage message;
        private SmtpClient smtp;
        private NetworkCredential basicCredential;
        private XMLLoader xml;
        private SMTPConfig config;

        private ComSMTP()
        {
            xml = new XMLLoader(XMLLoader.CONFIG_TYPE.SMTP_Config);
            config = (SMTPConfig)this.GetSmtpConfig().Data[0];
            message = new MailMessage();
            smtp = new SmtpClient();
            basicCredential = new NetworkCredential(config.Username, config.Password);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = basicCredential;

        }

        public static ComSMTP GetInstance()
        {
            if (instance == null)
                instance = new ComSMTP();
            return instance;
        }

        public MessageSerializable.Message GetSmtpConfig()
        {
            SMTPConfig config = (SMTPConfig)xml.LoadConfig().Data[0];

            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.Data[0] = config;
            return msg;
        }

        public MessageSerializable.Message SendMail(MessageSerializable.Message msg)
        {
            if (msg.Data[0].GetType() == typeof(string))
            {
                try
                {
                    message.To.Add((string)msg.Data[0]);
                    message.Subject = "JPO Exia Cesi";
                    message.From = new System.Net.Mail.MailAddress(config.Address, "Exia Cesi");
                    if ((string)msg.Data[1] == null)
                    {
                        msg.Statut = false;
                        return msg;
                    }
                    else
                    {
                        message.Body = (string)msg.Data[1];
                    }

                    smtp.Host = config.Host;
                    smtp.Port = config.Port;
                    smtp.EnableSsl = config.EnableSSL;
                    smtp.Send(message);

                    msg.Statut = true;
                    return msg;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("ERREUR :" + ex.Message);
                    msg.Statut = false;
                    return msg;
                }
            }
            msg.Statut = false;
            return msg;
        }
    }
}
