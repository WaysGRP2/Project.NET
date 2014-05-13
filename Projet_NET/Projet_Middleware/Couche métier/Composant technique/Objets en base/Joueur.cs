using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class Joueur : ObjetEnBase
    {
        public int id;
        private string nom;
        private int score;

        public Joueur(int id, string nom, int score)
        {
            this.id = id;
            this.nom = nom;
            this.score = score;
        }

        public Joueur(string nom, int score)
        {
            this.id = -1;
            this.nom = nom;
            this.score = score;
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

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
    }
}
