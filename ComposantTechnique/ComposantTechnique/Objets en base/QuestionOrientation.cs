using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class QuestionOrientation : ObjetEnBase,ISerializable
    {
        public int id;
        private string question;
        private ReponseOrientation[] reponses = new ReponseOrientation[4];
        private int order;

        public QuestionOrientation(int id, string question, ReponseOrientation[] reponses, int order)
        {
            this.id = id;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
        }

        public QuestionOrientation(string question, ReponseOrientation[] reponses, int order)
        {
            this.id = -1;
            this.question = question;
            this.reponses = reponses;
            this.order = order;
        }

        public QuestionOrientation(SerializationInfo info, StreamingContext ctxt)
        {
            this.id = (int)info.GetValue("id", typeof(int));
            this.question = (string)info.GetValue("question", typeof(string));
            this.reponses = (ReponseOrientation[])info.GetValue("reponses", typeof(ReponseOrientation[]));
            this.order = (int)info.GetValue("order", typeof(int));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
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

        public ReponseOrientation[] Reponses
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
