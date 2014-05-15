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

            if ((!authorizedApplications.Contains(msg.AppName)) || (string.IsNullOrEmpty(msg.Invoke)) || !Token.ValidToken(msg.Token))
            {
                Program.Debug("Une application non autorisé a envoyé un message: \nAppName:" + msg.AppName + "  token:" + msg.Token + "  isValid:" + Token.ValidToken(msg.Token));
                string[] tokenParts = msg.Token.Split('|');
                string _hash = tokenParts[0];
                double time = Convert.ToDouble(tokenParts[1]);
                MD5Crypter md5 = new MD5Crypter();
                Program.Debug("Token invalide : " + _hash + "\n\t" + md5.Encrypt("WAYSprOject1")
                    + " Is Valid:" + (_hash == md5.Encrypt("WAYSprOject1"))
                    + " \nTime:" + time + " StillValid:"+ (time > 0));
                return reponseNegative;
            }

            Program.Debug("Une application autorisé a envoyé un message: \nAppName:" + msg.AppName + "  token:" + msg.Token + "  isValid:" + Token.ValidToken(msg.Token));

            TaskProvider taskProvider = new TaskProvider();
            Message reponse = taskProvider.ExecTask(msg);
            return reponse;
        }
    }
}
