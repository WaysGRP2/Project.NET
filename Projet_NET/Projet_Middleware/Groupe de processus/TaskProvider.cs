using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Composant_d_accès_métier;
using MessageSerializable;

namespace Projet_Middleware.Groupe_de_processus
{
    class TaskProvider
    {
        CAM cam;

        public TaskProvider()
        {
            this.cam = new CAM();
        }

        public Message ExecTask(Message msg)
        {
            if (msg.Invoke == "Envoyer_Mail")
                msg.Invoke = "WF_Envoi_Mail";


            Message reponse = this.cam.ExecWF(msg);

            if (reponse.Invoke == "WF_Envoi_Mail")
                reponse.Invoke = "Envoyer_Mail";

            return reponse;
        }
    }
}
