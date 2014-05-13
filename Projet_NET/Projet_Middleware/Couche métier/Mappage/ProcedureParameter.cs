using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class ProcedureParameter
    {
        private string name;
        private System.Data.OleDb.OleDbType type;
        private Object _value;

        public ProcedureParameter(string name, System.Data.OleDb.OleDbType type, Object value)
        {
            this.name = name;
            this.type = type;
            this._value = value;
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

        public Object Value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}
