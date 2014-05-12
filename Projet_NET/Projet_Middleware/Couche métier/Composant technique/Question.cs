using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Composant_technique
{
    class Question
    {
        private string question;
        private string[] reponses;
        private string theme;

        public Question(string question, string[] reponses, string theme)
        {
            this.question = question;
            this.reponses = reponses;
            this.theme = theme;
        }

        public bool IsGoodReponse(string reponse)
        {
            if (this.reponses[0] == reponse)
                return true;
            return false;
        }

        public string QuestionText
        {
            get { return question; }
            set { question = value; }
        }

        public string[] Reponses
        {
            get { return Reponses; }
            set { Reponses = value; }
        }

        public string Theme
        {
            get { return theme; }
            set { theme = value; }
        }
    }
}
