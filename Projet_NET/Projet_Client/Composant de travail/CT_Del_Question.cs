using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Client.Composant_de_communication;

namespace Projet_Client.Composant_de_travail
{
    class CT_Del_Question
    {
        public Message Exec(Message oMsg)
        {
            CT_Get_Questionnaire.QuestionnaireType type = (CT_Get_Questionnaire.QuestionnaireType)oMsg.Data[0];
            Message msg = new Message();
            Token token = new Token("37223bb1b16ab31a8b653b7d122da208");
            switch (type)
            {
                case CT_Get_Questionnaire.QuestionnaireType.Jeu:
                    msg.Invoke = ServeurTask.SUPPRIMER_QUESTION_JEU;
                    break;

                case CT_Get_Questionnaire.QuestionnaireType.Orientation:
                    msg.Invoke = ServeurTask.SUPPRIMER_QUESTION_ORIENTATION;
                    break;
            }
            msg.AppName = Properties.Settings.Default.AppName;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "Je veux mettre à jour une question";
            msg.Data[0] = oMsg.Data[1];
            msg.Token = token.ToString();
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
