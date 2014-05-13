using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class TSQLProcedure
    {
        private string name;
        private ProcedureParameter[] parameters;

        public TSQLProcedure(string name, ProcedureParameter[] parameters)
        {
            this.name = name;
            this.parameters = parameters;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public ProcedureParameter[] Parameters
        {
            get { return parameters; }
            set { parameters = value; }
        }
    }
}
