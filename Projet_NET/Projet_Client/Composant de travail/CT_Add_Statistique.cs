using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageSerializable;
using Projet_Client.Composant_utilisateur;
using Projet_Client.Composant_de_communication;
using System.Threading.Tasks;

namespace Projet_Client.Composant_de_travail
{
    class CT_Add_Statistique
    {
        public Message Exec(Message oMsg)
        {
            Message msg = new Message();
            Token token = new Token("37223bb1b16ab31a8b653b7d122da208");
            msg.AppName = Properties.Settings.Default.AppName;
            msg.Invoke = ServeurTask.AJOUTER_STATISTIQUE;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "J'ajoute des données de staistique";
            msg.Data = oMsg.Data;
            msg.Token = token.ToString();
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
