using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Composant_d_accès_métier;
using MessageSerializable;

namespace Projet_Middleware.Groupe_de_processus
{
    class TaskProvider
    {
        CAM cam;
        int switchCase = 1;

        public TaskProvider()
        {
            this.cam = new CAM();
        }

        public Message ExecTask(Message msg)
        {
            msg = TranslateTaskToWF(msg);

            Message reponse = this.cam.ExecWF(msg);

            reponse = TranslateWFToTask(msg);

            return reponse;
        }

        private Message TranslateTaskToWF(Message msg)
        {

            switch (switchCase)
            {

                case 1:if (msg.Invoke == "Envoyer_Mail")
                           msg.Invoke = "WF_Envoi_Mail";
                break;

                case 2: if (msg.Invoke == "Ajouter_Metier")
                           msg.Invoke = "WF_Add_Metier";
                break;

                case 3: if (msg.Invoke == "Ajouter_Joueur")
                            msg.Invoke = "WF_Add_Players";
                break;

                case 4: if (msg.Invoke == "Supprimer_Joueur")
                            msg.Invoke = "WF_Del_Players";
                break;

                case 5: if (msg.Invoke == "Supprimer_Metier")
                            msg.Invoke = "WF_Del_Metier";
                break;

                case 6: if (msg.Invoke == "Supprimer_Question_Jeu")
                            msg.Invoke = "WF_Del_Question_J";
                break;

                case 7: if (msg.Invoke == "Supprimer_Question_Orientation")
                            msg.Invoke = "WF_Del_Question_O";
                break;

                case 8: if (msg.Invoke == "Afficher_Classement")
                            msg.Invoke = "WF_Get_Classement";
                break;

                case 9: if (msg.Invoke == "Afficher_Questions_Jeu")
                            msg.Invoke = "WF_Get_Questions_Jeu";
                break;

                case 10: if (msg.Invoke == "Afficher_Questions_Orientation")
                            msg.Invoke = "WF_Get_Questions_Orientation";
                break;

                case 11: if (msg.Invoke == "Modifier_Metier")
                            msg.Invoke = "WF_Upd_Metier";
                break;

                case 12: if (msg.Invoke == "Modifier_Joueur")
                            msg.Invoke = "WF_Upd_Players";
                break;

                case 13: if (msg.Invoke == "Modifier_Score")
                            msg.Invoke = "WF_Upd_PlayerScore";
                break;

                case 14: if (msg.Invoke == "Modifier_Question_Jeu")
                            msg.Invoke = "WF_Upd_Question_J";
                break;

                case 15: if (msg.Invoke == "Modifier_Question_Orientation")
                            msg.Invoke = "WF_Upd_Question_O";
                break;
            }

            return msg;
        }

        private Message TranslateWFToTask(Message reponse)
        {
            switch (switchCase)
            {
                case 1: if (reponse.Invoke == "WF_Envoi_Mail")
                            reponse.Invoke = "Envoyer_Mail";
                break;

                case 2: if (reponse.Invoke == "WF_Add_Metier")
                            reponse.Invoke = "Ajouter_Metier";
                break;

                case 3: if (reponse.Invoke == "WF_Add_Players")
                            reponse.Invoke = "Ajouter_Joueur";
                break;

                case 4: if (reponse.Invoke == "WF_Del_Joueur")
                            reponse.Invoke = "Supprimer_Metier";
                break;

                case 5: if (reponse.Invoke == "WF_Del_Metier")
                            reponse.Invoke = "Supprimer_Metier";
                break;

                case 6: if (reponse.Invoke == "WF_Del_Question_J")
                            reponse.Invoke = "Supprimer_Question_Jeu";
                break;

                case 7: if (reponse.Invoke == "WF_Del_Question_O")
                            reponse.Invoke = "Supprimer_Question_Orientation";
                break;

                case 8: if (reponse.Invoke == "WF_Get_Classement")
                            reponse.Invoke = "Afficher_Classement";
                break;

                case 9: if (reponse.Invoke == "WF_Get_Questions_Jeu")
                            reponse.Invoke = "Afficher_Questions_Jeu";
                break;

                case 10: if (reponse.Invoke == "WF_Get_Questions_Orientation")
                            reponse.Invoke = "Afficher_Questions_Orientation";
                break;

                case 11: if (reponse.Invoke == "WF_Upd_Metier")
                            reponse.Invoke = "Modifier_Metier";
                break;

                case 12: if (reponse.Invoke == "WF_Upd_Players")
                            reponse.Invoke = "Modifier_Joueur";
                break;

                case 13: if (reponse.Invoke == "WF_Upd_PlayerScore")
                            reponse.Invoke = "Modifier_Score";
                break;

                case 14: if (reponse.Invoke == "WF_Upd_Question_J")
                            reponse.Invoke = "Modifier_Question_Jeu";
                break;

                case 15: if (reponse.Invoke == "WF_Upd_Question_O")
                            reponse.Invoke = "Modifier_Question_Orientation";
                break;
            }

            return reponse;
        }
    }
}
