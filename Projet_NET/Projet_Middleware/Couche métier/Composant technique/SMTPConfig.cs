using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class SMTPConfig
    {
        private string address;
        private string username;
        private string password;
        private string host;
        private int port;
        private bool enableSSL;

        public SMTPConfig(string address, string username, string password, string host, int port, bool enableSSL)
        {
            this.address = address;
            this.username = username;
            this.password = password;
            this.host = host;
            this.port = port;
            this.enableSSL = enableSSL;
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Host
        {
            get { return host; }
            set { host = value; }
        }

        public int Port
        {
            get { return port; }
            set { port = value; }
        }

        public bool EnableSSL
        {
            get { return enableSSL; }
            set { enableSSL = value; }
        }
    }
}
