using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Middleware.Service_étendu;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Envoi_Mail : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if(msg.Data[0].GetType() == typeof(string) && msg.Data[1].GetType() == typeof(string))
            {
                msg = ComSMTP.GetInstance().SendMail(msg);
                return msg;
            }

            msg.Statut = false;
            return msg;
        }
    }
}
