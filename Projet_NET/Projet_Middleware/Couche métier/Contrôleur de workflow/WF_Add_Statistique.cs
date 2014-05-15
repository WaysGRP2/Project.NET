using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageSerializable;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Statistique : IWorkflow
    {
        public Message Exec(Message msg)
        {

            if (msg.Data[0].GetType() != typeof(string) && msg.Data[1].GetType() != typeof(bool) && msg.Data[2].GetType() != typeof(string) && msg.Data[3].GetType() != typeof(string) && msg.Data[4].GetType() != typeof(string) && msg.Data[5].GetType() != typeof(string))
                return msg;

            msg.Data[0] = Mpg_Statistiques.Rq_CreateStat((int)msg.Data[0], (bool)msg.Data[1], (string)msg.Data[2], (string)msg.Data[3], (string)msg.Data[4], (string)msg.Data[5]);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            return msg;
        }
    }
}
