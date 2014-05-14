using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class Joueur : ObjetEnBase, ISerializable
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

        // Deserialization constructor
        public Joueur(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            this.id = (int)info.GetValue("id", typeof(int));
            this.nom = (string)info.GetValue("nom", typeof(string));
            this.score = (int)info.GetValue("score", typeof(int));

        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("id", this.id);
            info.AddValue("nom", this.nom);
            info.AddValue("score", this.score);
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
