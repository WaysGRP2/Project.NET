using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public class Metier : ObjetEnBase, ISerializable
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
        
        // Deserialization constructor
        public Metier(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            this.id = (int)info.GetValue("id", typeof(int));
            this.intitule= (string)info.GetValue("intitule", typeof(string));
            this.description = (string)info.GetValue("description", typeof(string));

        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("id", this.id);
            info.AddValue("intitule", this.intitule);
            info.AddValue("description", this.description);
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
