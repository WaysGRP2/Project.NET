using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class Metier : IObjetEnBase
    {
        public int id;
        private string nom;

        public Metier(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        public Metier(string nom)
        {
            this.id = -1;
            this.nom = nom;
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
    }
}
