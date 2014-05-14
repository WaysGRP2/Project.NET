using System;
using System.Collections.Generic;
using System.Linq;
using ComposantTechnique;
using MessageSerializable;
using Projet_Middleware.Groupe_de_processus;

namespace Projet_Middleware.Composant_Serveur
{
    class EntreePlateforme
    {
        public static Message Check(Message msg)
        {
            List<string> authorizedApplications = new List<string>();
            authorizedApplications.Add("Client");
            authorizedApplications.Add("Middleware");

            Message reponseNegative = msg;
            reponseNegative.Statut = false;

            if ((!authorizedApplications.Contains(msg.AppName)) && (string.IsNullOrEmpty(msg.Invoke)))
                return reponseNegative;

            TaskProvider taskProvider = new TaskProvider();
            Message reponse = taskProvider.ExecTask(msg);
            return reponse;
        }
    }
}
