﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Udp_Metier : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(int) && msg.Data[1].GetType() != typeof(string) && msg.Data[2].GetType() != typeof(string))
                return msg;

            msg.Data[0] = Mpg_Metiers.Rq_UpdateMetier((int)msg.Data[0], (string)msg.Data[1], (string)msg.Data[2]);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            return msg;
        }
    }
}
