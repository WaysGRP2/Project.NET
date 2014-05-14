using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class QuestionJeu : ObjetEnBase,ISerializable
    {
        public int id;
        private string question;
        private ReponseJeu[] reponses = new ReponseJeu[4];
        private int order;

        public QuestionJeu(int id, string question, ReponseJeu[] reponses, int order)
        {
            this.id = id;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
        }

        public QuestionJeu(string question, ReponseJeu[] reponses, int order)
        {
            this.id = -1;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
        }

        public QuestionJeu(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("Désérialisation de " + this.GetType().ToString());
            this.id = (int)info.GetValue("id", typeof(int));
            this.question = (string)info.GetValue("question", typeof(string));
            this.reponses = (ReponseJeu[])info.GetValue("reponses", typeof(ReponseJeu[]));
            this.order = (int)info.GetValue("order", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("Sérialisation de " + this.GetType().ToString());
            info.AddValue("id", this.id);
            info.AddValue("question", this.question);
            info.AddValue("reponses", this.reponses);
            info.AddValue("order", this.order);
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

        public ReponseJeu[] Reponses
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
