using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Service_étendu
{
    class ComSMTP
    {
        private static ComSMTP instance = null;
        private XMLLoader xml;

        private ComSMTP()
        {
            xml = new XMLLoader(XMLLoader.CONFIG_TYPE.SMTP_Config);
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
    }
}
