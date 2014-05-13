using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Service_étendu
{
    class ProcedureParameter
    {
        private string name;
        private System.Data.OleDb.OleDbType type;

        public ProcedureParameter(string name, System.Data.OleDb.OleDbType type)
        {
            this.name = name;
            this.type = type;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public System.Data.OleDb.OleDbType Type
        {
            get { return type; }
            set { type = value; }
        }
    }
}
