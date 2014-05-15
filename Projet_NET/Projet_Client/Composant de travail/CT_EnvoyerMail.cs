﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_EnvoyerMail : IComposantTravail
    {
        Message msg;

        public CT_EnvoyerMail()
        {
            msg = new Message();
        }

        public Message Exec(Message oMsg)
        {
            Message msg = new Message();
            Token token = new Token("37223bb1b16ab31a8b653b7d122da208");
            msg.AppName = Properties.Settings.Default.AppName;
            msg.Invoke = ServeurTask.ENVOYER_MAIL;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "J'essaie d'envoyer un mail";
            msg.Data[0] = oMsg.Data[0];
            msg.Data[1] = "Corps du message";
            msg.Token = token.ToString();
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}