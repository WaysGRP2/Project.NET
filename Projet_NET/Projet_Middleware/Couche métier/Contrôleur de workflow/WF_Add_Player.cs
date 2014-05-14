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

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            System.Data.DataSet rs = (System.Data.DataSet)msg.Data[0];

            msg.Statut = true;

            return msg;
        }
    }
}
