using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique.Objets_en_base
{
    class QuestionOrientation : ObjetEnBase
    {
        public int id;
        private string question;
        private List<ReponseOrientation> reponses;
        private int order;

        public QuestionOrientation(int id, string question, List<ReponseOrientation> reponses, int order)
        {
            this.id = id;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
        }

        public QuestionOrientation(string question, List<ReponseOrientation> reponses, int order)
        {
            this.id = -1;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
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

        public string QuestionText
        {
            get { return question; }
            set { question = value; }
        }

        public List<ReponseOrientation> Reponses
        {
            get { return reponses; }
            set { reponses = value; }
        }

        public int Order
        {
            get { return order; }
            set { order = value; }
        }
    }
}
