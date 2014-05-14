using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using ComposantTechnique.Objets_en_base;
using Projet_Middleware.Couche_métier.Mappage;
using Projet_Middleware.Service_étendu;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Get_Questions_Jeu : IWorkflow
    {
        public Message Exec(Message msg)
        {
            List<QuestionJeu> questionsJeu = new List<QuestionJeu>();
            
            msg.Data[0] = Mpg_Questions_Jeu.Rq_GetAllQuestions();
            Message reponse = CAD.GetInstance().Execute_StockedProcedure(msg);
            System.Data.DataSet results = (System.Data.DataSet)reponse.Data[0];

            msg.Data[0] = Mpg_Reponses_Jeu.Rq_GetAllReponses();
            Message reponseRep = CAD.GetInstance().Execute_StockedProcedure(msg);
            System.Data.DataSet resultsRep = (System.Data.DataSet)reponseRep.Data[0];

            foreach (System.Data.DataRow row in results.Tables[0].Rows)
            {
                List<ReponseJeu> reponsesQuestion = new List<ReponseJeu>();

                int id = Convert.ToInt32(row[Mpg_Questions_Jeu.CH_ID].ToString());
                string intitule= row[Mpg_Questions_Jeu.CH_INTITULE].ToString();
                int ordre = Convert.ToInt32(row[Mpg_Questions_Jeu.CH_ORDRE].ToString());

                foreach (System.Data.DataRow rowRep in resultsRep.Tables[0].Rows)
                {
                    int idRep = Convert.ToInt32(rowRep[Mpg_Reponses_Jeu.CH_ID].ToString());
                    int idQues = Convert.ToInt32(rowRep[Mpg_Reponses_Jeu.CH_ID_QUESTION].ToString());
                    string intituleRep = rowRep[Mpg_Reponses_Jeu.CH_INTITULE].ToString();
                    int points = Convert.ToInt32(rowRep[Mpg_Reponses_Jeu.CH_POINTS].ToString());
                    bool isCorrect = bool.Parse(rowRep[Mpg_Reponses_Jeu.CH_ISCORRECT].ToString());

                    ReponseJeu reponseQues = new ReponseJeu(idRep, idQues, intituleRep, points, isCorrect);

                    if(reponseQues.ID_Question == id)
                    reponsesQuestion.Add(reponseQues);
                }

                questionsJeu.Add(new QuestionJeu(id, intitule, reponsesQuestion,ordre));
            }

            msg.Data[0] = questionsJeu;
            return msg;
        }
    }
}