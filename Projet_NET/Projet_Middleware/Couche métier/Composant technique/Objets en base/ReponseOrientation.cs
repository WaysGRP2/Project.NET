using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class ReponseOrientation : ObjetEnBase
    {
        public int id;
        private int id_question;
        private string reponseText;;
        private Metier metier;

        public ReponseOrientation(int id, int id_question, string reponseText, Metier metier)
        {
            this.id = id;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.metier = metier;
        }

        public ReponseOrientation(int id_question, string reponseText, Metier metier)
        {
            this.id = -1;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.metier = metier;
        }

        public void SaveInBase()
        {

        }

        public void DeleteFromBase()
        {
            if (this.id == -1)
                return;
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public int ID_Question
        {
            get { return id_question; }
            set { id_question = value; }
        }

        public string ReponseText
        {
            get { return reponseText; }
            set { reponseText = value; }
        }

        public Metier Metier
        {
            get { return metier; }
            set { metier = value; }
        }
    }
}
