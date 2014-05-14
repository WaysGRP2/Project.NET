using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;


namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Upd_Question_O
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(int) && msg.Data[1].GetType() != typeof(string) && msg.Data[2].GetType() != typeof(int))
                return msg;

            msg.Data[0] = Mpg_Questions_Orientation.Rq_UpdateQuestion((int)msg.Data[0], (string)msg.Data[1], (int)msg.Data[2]);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            return msg;
        }
    }
}
