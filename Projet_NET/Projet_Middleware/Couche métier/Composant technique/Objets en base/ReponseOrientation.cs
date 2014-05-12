using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class ReponseOrientation : IObjetEnBase
    {
        public int id;
        private string reponseText;
        private bool isCorrect;
        private Metier metier;

        public ReponseOrientation(int id, string reponseText, bool isCorrect, Metier metier)
        {
            this.id = id;
            this.reponseText = reponseText;
            this.isCorrect = isCorrect;
            this.metier = metier;
        }

        public ReponseOrientation(string reponseText, bool isCorrect, Metier metier)
        {
            this.id = -1;
            this.reponseText = reponseText;
            this.isCorrect = isCorrect;
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

        public string ReponseText
        {
            get { return reponseText; }
            set { reponseText = value; }
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }

        public Metier Metier
        {
            get { return metier; }
            set { metier = value; }
        }
    }
}
