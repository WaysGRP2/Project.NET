using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base;
using Projet_Middleware.Couche_métier.Mappage;
using Projet_Middleware.Service_étendu;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Get_Questions_Jeu : IWorkflow
    {
        public Message Exec(Message msg)
        {
            List<QuestionJeu> questionnaireJeu = new List<QuestionJeu>();
            System.Data.DataSet results = CAD.GetInstance().m_GetRows(Mpg_Questions_Jeu.Rq_GetAllQuestions(), "QuestionJeu");

            foreach (System.Data.DataRow row in results.Tables[0].Rows)
            {
                int id = Convert.ToInt32(row[Mpg_Questions_Jeu.CH_ID].ToString());
                string question = row[Mpg_Questions_Jeu.CH_INTITULE].ToString();
                int order = Convert.ToInt32(row[Mpg_Questions_Jeu.CH_ORDRE].ToString());

                List<ReponseJeu> reponses = new List<ReponseJeu>();

                System.Data.DataSet resultsRep = CAD.GetInstance().m_GetRows(Mpg_Reponses_Jeu.Rq_GetReponseByQuestionID(id), "ReponsesJeu");

                foreach (System.Data.DataRow rowRep in resultsRep.Tables[0].Rows)
                {
                    string reponseTxt = row[Mpg_Reponses_Jeu.CH_INTITULE].ToString();
                    int pointRep = Convert.ToInt32(row[Mpg_Reponses_Jeu.CH_POINTS].ToString());
                    bool isCorrect = bool.Parse(row[Mpg_Reponses_Jeu.CH_ISCORRECT].ToString());

                    reponses.Add(new ReponseJeu(reponseTxt, pointRep, isCorrect));
                }

                questionnaireJeu.Add(new QuestionJeu(id, question, reponses, order));
            }

            msg.Data[0] = questionnaireJeu;
            msg.Statut = true;
            return msg;
        }
    }
}
