using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using MessageSerializable;


namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Player : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(string) && msg.Data[1].GetType() != typeof(int))
                return msg;

            msg.Data[0] = Mpg_Joueurs.Rq_CreatePlayer((string)msg.Data[0], (int)msg.Data[1]);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            return msg;
        }
    }
}
