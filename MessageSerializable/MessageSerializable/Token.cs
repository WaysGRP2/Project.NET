using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComposantTechnique;

namespace MessageSerializable
{
    public class Token
    {
        private static string PASSWORD = "WAYSprOject1";
        private string hash;
        private DateTime expiration;

        public Token(string hash)
        {
            this.hash = hash;
            this.expiration = (DateTime.Now).AddSeconds(10);
        }

        public override string ToString()
        {
            return this.hash + "|" + ((this.expiration - DateTime.Now).TotalSeconds);
        }

        public static bool ValidToken(string token)
        {
            string[] tokenParts = token.Split('|');
            MD5Crypter md5 = new MD5Crypter();

            string _hash = tokenParts[0];
            double time = Convert.ToDouble(tokenParts[1]);

            if ((_hash == md5.Encrypt(PASSWORD)) && (time > 0))
            {
                System.Diagnostics.Debug.WriteLine("VALIDATION TOKENT : \nGoodHash:" + md5.Encrypt(PASSWORD) 
                    +"\nTokenHash:"+_hash
                    + "TimeLeft:"+time);
                return true;
            }
            return false;
        }
    }
}