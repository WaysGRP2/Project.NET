using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projet_Middleware.Service_étendu;
using Projet_Middleware.Couche_métier.Mappage;
using Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base;
using MessageSerializable;

namespace Projet_Middleware.Couche_métier.Contrôleur_de_workflow
{
    class WF_Get_Classement : IWorkflow
    {
        private CAD cad;

        public WF_Get_Classement()
        {
            this.cad = new CAD();
        }

        public Message Exec(Message msg)
        {
            List<Joueur> classement = new List<Joueur>();
            System.Data.DataSet results = this.cad.m_GetRows(Mpg_Joueurs.Rq_GetAllPlayers(), "Classement");

            foreach (System.Data.DataRow row in results.Tables[0].Rows)
            {
                int id = Convert.ToInt32(row["Id_Joueur"].ToString());
                string nom = row["Pseudo"].ToString();
                int score = Convert.ToInt32(row["Score"].ToString());

                classement.Add(new Joueur(id, nom, score));
            }

            msg.Data[0] = classement;
            msg.Statut = true;
            return msg;
        }
    }
}
