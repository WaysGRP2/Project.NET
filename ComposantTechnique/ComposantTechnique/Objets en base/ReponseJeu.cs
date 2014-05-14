using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class ReponseJeu : ObjetEnBase, ISerializable
    {
        public int id;
        private int id_question;
        private string reponseText;
        private int points;
        private bool isCorrect;

        public ReponseJeu(int id, int id_question, string reponseText, int points, bool isCorrect)
        {
            this.id = id;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.points = points;
            this.isCorrect = isCorrect;
        }

        public ReponseJeu(int id_question, string reponseText, int points, bool isCorrect)
        {
            this.id = -1;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.points = points;
            this.isCorrect = isCorrect;
        }

        public ReponseJeu(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("Désérialisation de " + this.GetType().ToString());
            this.id = (int)info.GetValue("id", typeof(int));
            this.id_question = (int)info.GetValue("id_question", typeof(int));
            this.reponseText = (string)info.GetValue("reponseText", typeof(string));
            this.points = (int)info.GetValue("points", typeof(int));
            this.isCorrect = (bool)info.GetValue("isCorrect", typeof(bool));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("Sérialisation de " + this.GetType().ToString());
            info.AddValue("id", this.id);
            info.AddValue("id_question", this.id_question);
            info.AddValue("reponseText", this.reponseText);
            info.AddValue("points", this.points);
            info.AddValue("isCorrect", this.isCorrect);
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
