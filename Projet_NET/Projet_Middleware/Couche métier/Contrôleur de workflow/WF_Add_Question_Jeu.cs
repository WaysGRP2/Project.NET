using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using MessageSerializable;
using ComposantTechnique.Objets_en_base;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Question_Jeu : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(QuestionJeu))
                return msg;

            QuestionJeu questionAAjouter = (QuestionJeu)msg.Data[0];

            ReponseJeu[] listeReponses = questionAAjouter.Reponses;

            msg.Data[0] = Mpg_Questions_Jeu.Rq_CreateQuestion(questionAAjouter.QuestionText, questionAAjouter.Order);
            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            foreach (ReponseJeu rep in listeReponses)
            {
                msg.Data[0] = Mpg_Reponses_Jeu.Rq_CreateReponse(rep.ID, rep.ReponseText, rep.Points, rep.IsCorrect);
                msg = CAD.GetInstance().Execute_StockedProcedure(msg);
            }

            return msg;
        }
    }
}
