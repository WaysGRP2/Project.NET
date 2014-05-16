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
    class WF_Upd_Question_O : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(QuestionOrientation))
                return msg;

            QuestionOrientation question = (QuestionOrientation)msg.Data[0];

            msg.Data[0] = Mpg_Questions_Orientation.Rq_UpdateQuestion(question.ID, question.QuestionText, question.Order);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            foreach (ReponseOrientation rep in question.Reponses)
            {
                msg.Data[0] = Mpg_Reponses_Orientation.Rq_UpdateReponse(rep.ID, rep.ReponseText, rep.Metier.ID);

                msg = CAD.GetInstance().Execute_StockedProcedure(msg);
            }

            return msg;
        }
    }
}
