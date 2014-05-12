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
        public static string SQLSERVER_CONFIG_PATH = "ConfigFiles/SQLServerConfig.xml";
        public static string SMTP_CONFIG_PATH = "ConfigFiles/SMTPConfig.xml";

        private CONFIG_TYPE type;

        public XMLLoader(CONFIG_TYPE type)
        {
            this.type = type;
        }

        public Object LoadConfig()
        {
            if (type == CONFIG_TYPE.SQL_Server_Config)
            {
                string cnx = "";
                ReversibleEncryption.DecryptFile(SQLSERVER_CONFIG_PATH);
                XmlDocument doc = new XmlDocument();
                doc.Load(SQLSERVER_CONFIG_PATH);

                string driver = doc.DocumentElement.SelectSingleNode("/Config/Driver").InnerText;
                string server = doc.DocumentElement.SelectSingleNode("/Config/Server").InnerText;
                string dataBase = doc.DocumentElement.SelectSingleNode("/Config/DataBase").InnerText;
                string uid = doc.DocumentElement.SelectSingleNode("/Config/Uid").InnerText;
                string pwd = doc.DocumentElement.SelectSingleNode("/Config/Pwd").InnerText;
                
                ReversibleEncryption.EncryptFile(SQLSERVER_CONFIG_PATH);
                
                cnx = "Driver={" + driver + "}; Server=" + server + "; DataBase=" + dataBase + "; Uid=" + uid + "; Pwd=" + pwd + ";";
                
                return cnx;
            }
            else if (type == CONFIG_TYPE.SMTP_Config)
            {
                ReversibleEncryption.DecryptFile(SMTP_CONFIG_PATH);
                XmlDocument doc = new XmlDocument();
                doc.Load(SMTP_CONFIG_PATH);

                string address = doc.DocumentElement.SelectSingleNode("/Config/Address").InnerText;
                string username = doc.DocumentElement.SelectSingleNode("/Config/Username").InnerText;
                string password = doc.DocumentElement.SelectSingleNode("/Config/Password").InnerText;
                string host = doc.DocumentElement.SelectSingleNode("/Config/Host").InnerText;
                string port = doc.DocumentElement.SelectSingleNode("/Config/Port").InnerText;
                string enableSSL = doc.DocumentElement.SelectSingleNode("/Config/EnableSSL").InnerText;
                
                ReversibleEncryption.EncryptFile(SMTP_CONFIG_PATH);

                SMTPConfig smtp = new SMTPConfig(address, username, password, host, Convert.ToInt32(port), bool.Parse(enableSSL));
                
                return smtp;
            }
            else
                return null;
        }
    }
}
