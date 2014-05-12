using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageSerializable
{
    public class Token
    {
        public enum TokenType
        {
            Admin,
            User
        }

        private int Id;
        private TokenType type;

        public Token(TokenType type)
        {
            this.Id = Convert.ToInt32(Guid.NewGuid());
            this.type = type;
        }

        public override string ToString()
        {
            return this.Id + ":" + this.type.ToString();
        }
    }
}