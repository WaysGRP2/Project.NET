using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base;
using MessageSerializable;


namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Player : IWorkflow
    {
        public Message Exec(Message msg)
        {
            msg.Data[0] = Mpg_Joueurs.Rq_CreatePlayer((string)msg.Data[0], (int)msg.Data[1]);

            Message reponse = CAD.GetInstance().Execute_StockedProcedure(msg);

            System.Data.DataSet results = (System.Data.DataSet)reponse.Data[0];

            if(results.Tables[0].Rows.Count > 0)
                msg.Statut = true;
            return msg;
        }
    }
}
