using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace ComposantTechnique.Objets_en_base
{
    [Serializable()]
    public abstract class ObjetEnBase : ISerializable
    {
        private int id;

        public void SaveInBase(){}
        public void DeleteFromBase(){}

        public ObjetEnBase() { }

        protected ObjetEnBase(SerializationInfo info, StreamingContext ctxt)
        {
            this.id = (int)info.GetValue("id", typeof(int));
        }

        public virtual void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            info.AddValue("id", this.id);
        }
    }
}
