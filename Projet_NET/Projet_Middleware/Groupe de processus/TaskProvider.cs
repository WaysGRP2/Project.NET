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

        private Message TranslateTaskToWF(Message oMsg)
        {
            Message msg = oMsg;
            switch (msg.Invoke)
            {
                case "Envoyer_Mail":
                           msg.Invoke = "WF_Envoi_Mail";
                break;

                case "Ajouter_Metier":
                           msg.Invoke = "WF_Add_Metier";
                break;

                case "Ajouter_Joueur":
                            msg.Invoke = "WF_Add_Player";
                break;

                case "Supprimer_Joueur":
                            msg.Invoke = "WF_Del_Player";
                break;

                case "Supprimer_Metier":
                            msg.Invoke = "WF_Del_Metier";
                break;

                case "Supprimer_Question_Jeu":
                            msg.Invoke = "WF_Del_Question_J";
                break;

                case "Supprimer_Question_Orientation":
                            msg.Invoke = "WF_Del_Question_O";
                break;

                case "Afficher_Classement":
                            msg.Invoke = "WF_Get_Classement";
                break;

                case "Afficher_Questions_Jeu":
                            msg.Invoke = "WF_Get_Questions_Jeu";
                break;

                case "Afficher_Questions_Orientation":
                            msg.Invoke = "WF_Get_Questions_Orientation";
                break;

                case "Modifier_Metier":
                            msg.Invoke = "WF_Upd_Metier";
                break;

                case "Modifier_Joueur":
                            msg.Invoke = "WF_Upd_Player";
                break;

                case "Modifier_Score":
                            msg.Invoke = "WF_Upd_PlayerScore";
                break;

                case "Modifier_Question_Jeu":
                            msg.Invoke = "WF_Upd_Question_J";
                break;

                case "Modifier_Question_Orientation":
                            msg.Invoke = "WF_Upd_Question_O";
                break;
                case "Ajouter_Statistique":
                            msg.Invoke = "WF_Add_Statistique";
                break;
                default:
                            msg.Invoke = msg.Invoke;
                break;
            }

            return msg;
        }

        private Message TranslateWFToTask(Message oMsg)
        {
            Message reponse = oMsg;
            switch (reponse.Invoke)
            {
                case "WF_Envoi_Mail":
                            reponse.Invoke = "Envoyer_Mail";
                break;

                case "WF_Add_Metier":
                            reponse.Invoke = "Ajouter_Metier";
                break;

                case "WF_Add_Player":
                            reponse.Invoke = "Ajouter_Joueur";
                break;

                case "WF_Del_Joueur":
                            reponse.Invoke = "Supprimer_Metier";
                break;

                case "WF_Del_Metier":
                            reponse.Invoke = "Supprimer_Metier";
                break;

                case "WF_Del_Question_J":
                            reponse.Invoke = "Supprimer_Question_Jeu";
                break;

                case "WF_Del_Question_O":
                            reponse.Invoke = "Supprimer_Question_Orientation";
                break;

                case "WF_Get_Classement":
                            reponse.Invoke = "Afficher_Classement";
                break;

                case "WF_Get_Questions_Jeu":
                            reponse.Invoke = "Afficher_Questions_Jeu";
                break;

                case "WF_Get_Questions_Orientation":
                            reponse.Invoke = "Afficher_Questions_Orientation";
                break;

                case "WF_Upd_Metier":
                            reponse.Invoke = "Modifier_Metier";
                break;

                case "WF_Upd_Player":
                            reponse.Invoke = "Modifier_Joueur";
                break;

                case "WF_Upd_PlayerScore":
                            reponse.Invoke = "Modifier_Score";
                break;

                case "WF_Upd_Question_J":
                            reponse.Invoke = "Modifier_Question_Jeu";
                break;

                case "WF_Upd_Question_O":
                            reponse.Invoke = "Modifier_Question_Orientation";
                break;
                case "WF_Add_Statistique":
                            reponse.Invoke = "Ajouter_Statistique";
                break;
                default:
                            reponse.Invoke = reponse.Invoke;
                break;
            }

            return reponse;
        }
    }
}
