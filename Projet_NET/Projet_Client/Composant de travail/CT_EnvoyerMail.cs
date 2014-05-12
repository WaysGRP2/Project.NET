using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_EnvoyerMail
    {
        Message msg;

        public CT_EnvoyerMail()
        {
            msg = new Message();
        }

        public Message Exec(string mail)
        {
            Message msg = new Message();
            msg.AppName = "Client";
            msg.Invoke = ServeurTask.ENVOYER_MAIL;
            msg.PSecurity = "A faire";
            msg.Statut = false;
            msg.Info = "J'essaie d'envoyer un mail";
            msg.Data[0] = mail;
            msg.Data[1] = "Corps du message";
            msg.Token = "20942948CU4209U";
            Message reponse = MessageManager.StartClient(msg);
            return reponse;
        }
    }
}
