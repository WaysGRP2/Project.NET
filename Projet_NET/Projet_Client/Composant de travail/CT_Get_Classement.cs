using System;
using System.Collections.Generic;
using System.Linq;
using MessageSerializable;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_Get_Classement
    {
        public Message Exec(Message oMsg)
        {
            Message msg = new Message();

            msg.AppName = Properties.Settings.Default.AppName;
            msg.Invoke = ServeurTask.AFFICHER_CLASSEMENT;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "J'ajoute un joueur";
            msg.Token = "20942948CU4209U";
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
