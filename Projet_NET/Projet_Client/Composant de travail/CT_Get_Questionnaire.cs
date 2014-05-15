using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Client.Composant_de_communication;
using Projet_Client.Composant_utilisateur;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_Get_Questionnaire : IComposantTravail
    {
        public enum QuestionnaireType
        {
            Jeu,
            Orientation
        }

        public Message Exec(Message oMsg)
        {
            QuestionnaireType type = (QuestionnaireType)oMsg.Data[0];
            Message msg = new Message();
            Token token = new Token("37223bb1b16ab31a8b653b7d122da208");
            switch (type)
            {
                case QuestionnaireType.Jeu:
                    msg.Invoke = ServeurTask.AFFICHER_QUESTION_JEU;
                    break;

                case QuestionnaireType.Orientation:
                    msg.Invoke = ServeurTask.AFFICHER_QUESTION_ORIENTATION;
                    break;
            }
            msg.AppName = Properties.Settings.Default.AppName;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "Je veux répupérer le questionnaire";
            msg.Token = token.ToString();
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
