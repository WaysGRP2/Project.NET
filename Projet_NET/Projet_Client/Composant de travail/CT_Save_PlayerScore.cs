using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Client.Composant_utilisateur;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_Save_PlayerScore
    {
        public Message Exec(Message oMsg)
        {
            Message msg = new Message();

            msg.AppName = Properties.Settings.Default.AppName;
            msg.Invoke = ServeurTask.AJOUTER_JOUEUR;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "J'ajoute un joueur";
            msg.Data = oMsg.Data;
            msg.Token = "20942948CU4209U";
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
