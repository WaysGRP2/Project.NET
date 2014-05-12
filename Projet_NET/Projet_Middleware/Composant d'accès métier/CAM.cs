using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Projet_Middleware.Couche_métier.Composant_technique;
using Projet_Middleware.Couche_métier.Contrôleur_de_workflow;
using MessageSerializable;

namespace Projet_Middleware.Composant_d_accès_métier
{
    class CAM
    {
        string namaspaceWF; // Namespace vers le contrôleur de workflow

        /// <summary>CAM est la classe qui va executer la bonne demande en fonction du message.</summary>
        public CAM()
        {
            this.namaspaceWF = "Projet_Middleware.Couche_métier.Contrôleur_de_workflow";
        }

        public Message ExecWF(Message msg)
        {
            if (!string.IsNullOrEmpty(msg.Invoke))
            {
                string classeApp = msg.Invoke;// Invoke contient le nom du workflow a utiliser

                Assembly assembly = Assembly.GetExecutingAssembly();
                Type typeClasse = assembly.GetType(this.namaspaceWF +  "." + classeApp);
                if (typeClasse != null)
                {
                    object classe = Activator.CreateInstance(typeClasse); // On instancie le bon workflow
                    msg = ((IWorkflow)classe).Exec(msg); // Et on l'execute
                }
                else
                    msg.Statut = false;
            }
            return msg;
        }
    }
}