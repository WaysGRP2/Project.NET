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
        public Message Exec(Message oMsg)
        {
            Fenetre_Questionnaire.QuestionnaireType type = (Fenetre_Questionnaire.QuestionnaireType)oMsg.Data[0];
            Message msg = new Message();
            
            switch (type)
            {
                case Fenetre_Questionnaire.QuestionnaireType.Jeu:
                    msg.Invoke = ServeurTask.AFFICHER_QUESTION_JEU;
                    break;

                case Fenetre_Questionnaire.QuestionnaireType.Orientation:
                    msg.Invoke = ServeurTask.AFFICHER_QUESTION_ORIENTATION;
                    break;
            }

            msg.AppName = Properties.Settings.Default.AppName;
            msg.PSecurity = "Projet_Client";
            msg.Statut = false;
            msg.Info = "Je veux répupérer le questionnaire";
            msg.Data[0] = oMsg.Data[0];
            msg.Token = "20942948CU4209U";
            Message reponse = MessageManager.SendMessageToServer(msg);
            return reponse;
        }
    }
}
