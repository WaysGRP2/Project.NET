using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class ReponseJeu : ObjetEnBase
    {
        public int id;
        private string reponseText;
        private int points;
        private bool isCorrect;

        public ReponseJeu(int id, string reponseText, int points, bool isCorrect)
        {
            this.id = id;
            this.reponseText = reponseText;
            this.points = points;
            this.isCorrect = isCorrect;
        }

        public ReponseJeu(string reponseText, int points, bool isCorrect)
        {
            this.id = -1;
            this.reponseText = reponseText;
            this.points = points;
            this.isCorrect = isCorrect;
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

        public int Points
        {
            get { return points; }
            set { points = value; }
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
            set { isCorrect = value; }
        }
    }
}
