using System;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Text;

namespace MessageSerializable
{
    [Serializable()]
    public class Message : ISerializable
    {
        private string appName;
        private string invoke;
        private string pSecurity;
        private bool statut;
        private string info;
        private object[] data;
        private string token;

        public Message()
        {
            this.appName = "";
            this.invoke = "";
            this.pSecurity = "";
            this.statut = false;
            this.info = "";
            this.data = new object[10];
            this.token = "";
        }

        public Message(string appName, string invoke, string pSecurity, bool statut, object[] data, string token)
        {
            this.appName = appName;
            this.invoke = invoke;
            this.pSecurity = pSecurity;
            this.statut = statut;
            this.data = data;
            this.token = token;
        }

        // Deserialization constructor
        public Message(SerializationInfo info, StreamingContext ctxt)
        {
            //Get the values from info and assign them to the appropriate properties
            this.appName = (string)info.GetValue("appName", typeof(string));
            this.invoke = (string)info.GetValue("invoke", typeof(string));
            this.pSecurity = (string)info.GetValue("pSecurity", typeof(string));
            this.statut = (bool)info.GetValue("statut", typeof(bool));
            this.data = (object[])info.GetValue("data", typeof(object[]));
            this.token = (string)info.GetValue("token", typeof(string));
        }

        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            //You can use any custom name for your name-value pair. But make sure you
            // read the values with the same name. For ex:- If you write EmpId as "EmployeeId"
            // then you should read the same with "EmployeeId"
            info.AddValue("appName", this.appName);
            info.AddValue("invoke", this.invoke);
            info.AddValue("pSecurity", this.pSecurity);
            info.AddValue("statut", this.statut);
            info.AddValue("data", this.data);
            info.AddValue("token", this.token);
        }

        public byte[] ToByteArray()
        {
            if (this == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            ms.Position = 0;
            bf.Serialize(ms, this);
            return ms.ToArray();
        }

        static public Message GetMessageFromByteArray(byte[] obj)
        {
            if (obj == null)
            {
                return null;
            }
            else
            {
                if (obj.Length == 0)
                {
                    return null;
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(obj);
                    ms.Position = 0;
                    return (Message)formatter.Deserialize(ms);
                }
            }
        }

        public string AppName
        {
            get { return appName; }
            set { appName = value; }
        }

        public string Invoke
        {
            get { return invoke; }
            set { invoke = value; }
        }

        public string PSecurity
        {
            get { return pSecurity; }
            set { pSecurity = value; }
        }

        public bool Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public string Info
        {
            get { return info; }
            set { info = value; }
        }

        public object[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Token
        {
            get { return token; }
            set { token = value; }
        }
    }
}
