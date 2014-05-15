using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using ComposantTechnique.Objets_en_base;
using MessageSerializable;
using System.Data;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Question_Orientation : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(QuestionOrientation))
                return msg;

            QuestionOrientation questionO = (QuestionOrientation)msg.Data[0];
            ReponseOrientation[] listeRep = questionO.Reponses;

            msg.Data[0] = Mpg_Questions_Jeu.Rq_CreateQuestion(questionO.QuestionText, questionO.Order);
            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            foreach (ReponseOrientation rep in listeRep)
            {
                msg.Data[0] = Mpg_Reponses_Orientation.Rq_CreateReponse(rep.ID, rep.ReponseText, rep.Metier.ID);
                msg = CAD.GetInstance().Execute_StockedProcedure(msg);
            }

            return msg;

        }
    }
}