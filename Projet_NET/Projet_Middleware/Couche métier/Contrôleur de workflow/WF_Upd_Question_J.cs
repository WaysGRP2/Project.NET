using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using ComposantTechnique.Objets_en_base;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;


namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Upd_Question_J : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(QuestionJeu))
                return msg;

            QuestionJeu question = (QuestionJeu)msg.Data[0];

            msg.Data[0] = Mpg_Questions_Jeu.Rq_UpdateQuestion(question.ID, question.QuestionText, question.Order);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            foreach(ReponseJeu rep in question.Reponses)
            {
                msg.Data[0] = Mpg_Reponses_Jeu.Rq_UpdateReponse(rep.ID, rep.ReponseText, rep.Points, rep.IsCorrect);

                msg = CAD.GetInstance().Execute_StockedProcedure(msg);
            }

            return msg;
        }
    }
}
