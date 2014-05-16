using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MessageSerializable;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using ComposantTechnique;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Upd_Mail : IWorkflow
    {
        public Message Exec(Message msg)
        {

        //XMLLoader xml = new XMLLoader(CONFIG_TYPE.SMTP_Config);

        string[] nodes = new string[2];
        nodes[0] = "Address";
        nodes[1] = "Username";

        string[] mails = new string[2];
        mails[0] = (string)msg.Data[0];
        mails[1] = (string)msg.Data[0];

        msg.Data[0] = nodes;
        msg.Data[1] = mails;

        msg = XMLLoader.ModifierNode(msg);

        return msg;
        }
    }
}