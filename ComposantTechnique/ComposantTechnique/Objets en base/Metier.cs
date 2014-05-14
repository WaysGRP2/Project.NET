using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComposantTechnique.Objets_en_base
{
    public class Metier : ObjetEnBase
    {
        public int id;
        private string intitule;
        private string description;

        public Metier(int id, string intitule, string description)
        {
            this.id = id;
            this.intitule = intitule;
            this.description = description;
        }

        public Metier(string intitule, string description)
        {
            this.id = -1;
            this.intitule = intitule;
            this.description = description;
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

        public string Intitule
        {
            get { return intitule; }
            set { intitule= value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
}
