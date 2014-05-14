using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class ReponseOrientation : ObjetEnBase, ISerializable
    {
        public int id;
        private int id_question;
        private string reponseText;
        private Metier metier;

        public ReponseOrientation(int id, int id_question, string reponseText, Metier metier)
        {
            this.id = id;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.metier = metier;
        }

        public ReponseOrientation(int id_question, string reponseText, Metier metier)
        {
            this.id = -1;
            this.id_question = id_question;
            this.reponseText = reponseText;
            this.metier = metier;
        }

        public ReponseOrientation(SerializationInfo info, StreamingContext ctxt)
        {
            this.id = (int)info.GetValue("id", typeof(int));
            this.id_question = (int)info.GetValue("id_question", typeof(int));
            this.reponseText = (string)info.GetValue("reponseText", typeof(string));
            this.metier = (Metier)info.GetValue("metier", typeof(Metier));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.id);
            info.AddValue("id_question", this.id_question);
            info.AddValue("reponseText", this.reponseText);
            info.AddValue("metier", this.metier);
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

        public Metier Metier
        {
            get { return metier; }
            set { metier = value; }
        }
    }
}
