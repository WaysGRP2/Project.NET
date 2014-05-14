using System;
using System.Collections.Generic;
using System.Linq;
using ComposantTechnique;
using MessageSerializable;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    interface IWorkflow
    {
        Message Exec(Message msg);
    }
}
