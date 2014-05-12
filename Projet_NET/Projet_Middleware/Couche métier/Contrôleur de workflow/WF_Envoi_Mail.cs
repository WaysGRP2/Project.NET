using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Couche_métier.Composant_technique;
using MessageSerializable;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Envoi_Mail : IWorkflow
    {
        SmtpMail mail;

        public WF_Envoi_Mail()
        {
            mail = new SmtpMail();
        }

        public Message Exec(Message msg)
        {
            mail.send(msg);
            return msg;
        }
    }
}
