using System;
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
        public string Encrypt(string msg)
        {
            byte[] encodedPassword = new UTF8Encoding().GetBytes(msg);

            byte[] hash = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(encodedPassword);

            string encoded = BitConverter.ToString(hash)
               .Replace("-", string.Empty)
               .ToLower();
            return encoded;
        }
    }
}
