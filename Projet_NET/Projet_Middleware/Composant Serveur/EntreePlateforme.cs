using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Composant_d_accès_métier;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Composant_Serveur
{
    class EntreePlateforme
    {
        public static Message Check(Message msg)
        {
            Message reponseNegative = msg;
            reponseNegative.Statut = false;

            if ((msg.AppName != "Client") && (string.IsNullOrEmpty(msg.Invoke)) && (msg.Invoke[0] != "W") && (msg.Invoke[1] != "F"))
                return reponseNegative;

            CAM cam = new CAM();
            Message reponse = cam.ExecWF(msg);
            return reponse;
        }
    }
}
