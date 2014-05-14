﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MessageSerializable;

namespace ComposantTechnique
{
    public class MD5Crypter
    {
        public Message Encrypt(Message msg)
        {
            if (msg.Data[0].GetType() == typeof(string))
            {
                Console.WriteLine("Objet de type string requis, calcule du Hash MD5 impossible.");
                msg.Statut = false;
                return msg;
            }
            byte[] results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();

            results = HashProvider.ComputeHash(UTF8.GetBytes((string)msg.Data[0]));
            msg.Data[0] = results;
            msg.Statut = true;
            return msg;
        }
    }
}
