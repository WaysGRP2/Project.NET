﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MessageSerializable;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Add_Metier : IWorkflow
    {
        public Message Exec(Message msg)
        {
            if (msg.Data[0].GetType() != typeof(string) && msg.Data[1].GetType() != typeof(string))
                return msg;

            msg.Data[0] = Mpg_Metiers.Rq_CreateMetier((string)msg.Data[0], (string)msg.Data[1]);

            msg = CAD.GetInstance().Execute_StockedProcedure(msg);

            return msg;
        }
    }
}
