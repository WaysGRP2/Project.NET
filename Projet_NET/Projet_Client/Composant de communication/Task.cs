using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Client.Composant_de_communication
{
    static class ServeurTask
    {
        private static string envoyerMail = "Envoyer_Mail";

        public static string ENVOYER_MAIL
        {
            get { return ServeurTask.envoyerMail; }
        }

        private static string ajouterMetier = "Ajouter_Metier";

        public static string AJOUTER_METIER
        {
            get { return ServeurTask.ajouterMetier; }
        }

        private static string ajouterJoueur = "Ajouter_Joueur";

        public static string AJOUTER_JOUEUR
        {
            get { return ServeurTask.ajouterJoueur; }
        }

        private static string ajouterQuestionJ = "Ajouter_Question_Jeu";

        public static string AJOUTER_QUESTION_JEU
        {
            get { return ServeurTask.ajouterQuestionJ; }
        }

        private static string ajouterQuestionO = "Ajouter_Question_Orientation";

        public static string AJOUTER_QUESTION_ORIENTATION
        {
            get { return ServeurTask.ajouterQuestionO; }
        }
        
        private static string supprimerMetier = "Supprimer_Metier";

        public static string SUPPRIMER_METIER
        {
            get { return ServeurTask.supprimerMetier; }
        }

        
        private static string supprimerJoueur = "Supprimer_Joueur";

        public static string SUPPRIMER_JOUEUR
        {
            get { return ServeurTask.supprimerJoueur; }
        }

        private static string supprimerQuestionJeu = "Supprimer_Question_Jeu";

        public static string SUPPRIMER_QUESTION_JEU
        {
            get { return ServeurTask.supprimerQuestionJeu; }
        }

        
        private static string supprimerQuestionOrientation = "Supprimer_Question_Orientation";

        public static string SUPPRIMER_QUESTION_ORIENTATION
        {
            get { return ServeurTask.supprimerQuestionOrientation; }
        }

        
        private static string afficherClassement = "Afficher_Classement";

        public static string AFFICHER_CLASSEMENT
        {
            get { return ServeurTask.afficherClassement; }
        }

        
        private static string afficherQuestionJeu = "Afficher_Questions_Jeu";

        public static string AFFICHER_QUESTION_JEU
        {
            get { return ServeurTask.afficherQuestionJeu; }
        }

        
        private static string afficherQuestionOrientation = "Afficher_Questions_Orientation";

        public static string AFFICHER_QUESTION_ORIENTATION
        {
            get { return ServeurTask.afficherQuestionOrientation; }
        }

        
        private static string modifierMetier = "Modifier_Metier";

        public static string MODIFIER_METIER
        {
            get { return ServeurTask.modifierMetier; }
        }

        private static string modifierJoueur = "Modifier_Joueur";

        public static string MODIFIER_JOUEUR
        {
            get { return ServeurTask.modifierJoueur; }
        }

        
        private static string modifierScore = "Modifier_Score";

        public static string MODIFIER_SCORE
        {
            get { return ServeurTask.modifierScore; }
        }

        private static string modifierQuestionJeu = "Modifier_Question_Jeu";

        public static string MODIFIER_QUESTION_JEU
        {
            get { return ServeurTask.modifierQuestionJeu; }
        }

        private static string modifierQuestionOrientation = "Modifier_Question_Orientation";

        public static string MODIFIER_QUESTION_ORIENTATION
        {
            get { return ServeurTask.modifierQuestionOrientation; }
        }

        private static string ajouterStatistique = "Ajouter_Statistique";

        public static string AJOUTER_STATISTIQUE
        {
            get { return ServeurTask.modifierQuestionOrientation; }
        }

        private static string modifierMail = "Modifier_Mail";

        public static string MODIFIER_MAIL
        {
            get { return ServeurTask.modifierMail; }
        }
    }
}
