using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    interface IWorkflow
    {
        Message Exec(Message oMsg);
    }
}
