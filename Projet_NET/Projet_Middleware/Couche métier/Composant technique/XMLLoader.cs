using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Text;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class XMLLoader
    {
        public enum CONFIG_TYPE { SQL_Server_Config, SMTP_Config };
        public static string SQLSERVER_CONFIG_PATH = "../../ConfigFiles/SQLServerConfig.xml";
        public static string SMTP_CONFIG_PATH = "../../ConfigFiles/SMTPConfig.xml";

        private CONFIG_TYPE type;

        public XMLLoader(CONFIG_TYPE type)
        {
            this.type = type;
        }

        public MessageSerializable.Message LoadConfig()
        {
            if (type == CONFIG_TYPE.SQL_Server_Config)
            {
                string cnx = "";
                //ReversibleEncryption.DecryptFile(SQLSERVER_CONFIG_PATH);
                XmlDocument doc = new XmlDocument();
                doc.Load(SQLSERVER_CONFIG_PATH);

                string provider = doc.DocumentElement.SelectSingleNode("/Config/Provider").InnerText;
                string dataSource = doc.DocumentElement.SelectSingleNode("/Config/DataSource").InnerText;
                string initCatalog = doc.DocumentElement.SelectSingleNode("/Config/InitialCatalog").InnerText;
                string user = doc.DocumentElement.SelectSingleNode("/Config/User").InnerText;
                string password = doc.DocumentElement.SelectSingleNode("/Config/Password").InnerText;
                
                //ReversibleEncryption.EncryptFile(SQLSERVER_CONFIG_PATH);

                cnx = "Provider=" + provider + ";Data Source=" + dataSource + ";User ID=" + user + ";Password=" + password + ";Initial Catalog=" + initCatalog + "";
                MessageSerializable.Message msg = new MessageSerializable.Message();
                msg.Data[0] = cnx;
                return msg;
            }
            else if (type == CONFIG_TYPE.SMTP_Config)
            {
                //ReversibleEncryption.DecryptFile(SMTP_CONFIG_PATH);
                XmlDocument doc = new XmlDocument();
                doc.Load(SMTP_CONFIG_PATH);

                string address = doc.DocumentElement.SelectSingleNode("/Config/Address").InnerText;
                string username = doc.DocumentElement.SelectSingleNode("/Config/Username").InnerText;
                string password = doc.DocumentElement.SelectSingleNode("/Config/Password").InnerText;
                string host = doc.DocumentElement.SelectSingleNode("/Config/Host").InnerText;
                string port = doc.DocumentElement.SelectSingleNode("/Config/Port").InnerText;
                string enableSSL = doc.DocumentElement.SelectSingleNode("/Config/EnableSSL").InnerText;
                
                //ReversibleEncryption.EncryptFile(SMTP_CONFIG_PATH);

                SMTPConfig smtp = new SMTPConfig(address, username, password, host, Convert.ToInt32(port), bool.Parse(enableSSL));
                
                MessageSerializable.Message msg = new MessageSerializable.Message();
                msg.Data[0] = smtp;
                return msg;
            }
            else
                return null;
        }
    }
}
