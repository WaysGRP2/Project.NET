using System;
using System.Collections.Generic;
using System.Linq;
using MessageSerializable;
using ComposantTechnique.Objets_en_base;
using Projet_Middleware.Couche_métier.Mappage;
using Projet_Middleware.Service_étendu;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Get_Questions_Orientation : IWorkflow
    {
        public Message Exec(Message msg)
        {
            List<QuestionOrientation> questionsOrientation = new List<QuestionOrientation>();

            msg.Data[0] = Mpg_Questions_Orientation.Rq_GetAllQuestions();
            Message reponse = CAD.GetInstance().Execute_StockedProcedure(msg);
            System.Data.DataSet results = (System.Data.DataSet)reponse.Data[0];

            msg.Data[0] = Mpg_Reponses_Orientation.Rq_GetAllReponses();
            Message reponseRep = CAD.GetInstance().Execute_StockedProcedure(msg);
            System.Data.DataSet resultsRep = (System.Data.DataSet)reponseRep.Data[0];

            msg.Data[0] = Mpg_Metiers.Rq_GetAllMetiers();
            Message reponseMetier = CAD.GetInstance().Execute_StockedProcedure(msg);
            System.Data.DataSet resultsMetier = (System.Data.DataSet)reponseRep.Data[0];

            foreach (System.Data.DataRow row in results.Tables[0].Rows)
            {
                List<ReponseOrientation> reponsesQuestion = new List<ReponseOrientation>();

                int id = Convert.ToInt32(row[Mpg_Questions_Orientation.CH_ID].ToString());
                string intitule = row[Mpg_Questions_Orientation.CH_INTITULE].ToString();
                int ordre = Convert.ToInt32(row[Mpg_Questions_Orientation.CH_ORDRE].ToString());

                foreach (System.Data.DataRow rowRep in resultsRep.Tables[0].Rows)
                {
                    Metier metier = new Metier("Aucun metier","Aucune description");

                    int idRep = Convert.ToInt32(rowRep[Mpg_Reponses_Orientation.CH_ID].ToString());
                    int idQues = Convert.ToInt32(rowRep[Mpg_Reponses_Orientation.CH_ID_QUESTION].ToString());
                    string intituleRep = rowRep[Mpg_Reponses_Orientation.CH_INTITULE].ToString();
                    int idMetier = Convert.ToInt32(rowRep[Mpg_Reponses_Orientation.CH_ID_METIER].ToString());

                    foreach (System.Data.DataRow rowMet in resultsMetier.Tables[0].Rows)
                    {
                        int idMet = Convert.ToInt32(rowMet[Mpg_Metiers.CH_ID].ToString());
                        string intituleMet = rowMet[Mpg_Metiers.CH_INTITULE].ToString();
                        string descMet = rowMet[Mpg_Metiers.CH_DESCRIPTION].ToString();

                        if (idMet == idMetier)
                            metier = new Metier(idMet, intituleMet, descMet);
                    }

                    ReponseOrientation reponseQues = new ReponseOrientation(idRep, idQues, intituleRep, metier);

                    if (reponseQues.ID_Question == id)
                        reponsesQuestion.Add(reponseQues);
                }

                questionsOrientation.Add(new QuestionOrientation(id, intitule, reponsesQuestion.Cast<ReponseOrientation>().ToArray(), ordre));
            }

            msg.Data[0] = questionsOrientation.Cast<QuestionOrientation>().ToArray();
            return msg;
        }
    }
}
