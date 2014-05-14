using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Statistiques
    {
        public static string CH_AGE = "Age";
        public static string CH_SEXE = "Sexe";
        public static string CH_CODE_POSTAL = "Code_Postal";
        public static string CH_DIPLOME = "Diplome";
        public static string CH_DIPLOME_TYPE = "Type_Diplome";
        public static string CH_CONNAISSANCES = "Connaissance";

        static public TSQLProcedure Rq_GetAllStats()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayStatistique", null);
            return proc; 
        }


        static public TSQLProcedure Rq_CreateStat(int age, bool sexe, string cp, string diplome, string type_diplome, string connaissance)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[6];
            parameters[0] = new ProcedureParameter("@age", System.Data.OleDb.OleDbType.Integer, age);
            parameters[1] = new ProcedureParameter("@sexe", System.Data.OleDb.OleDbType.Boolean, sexe);
            parameters[2] = new ProcedureParameter("@code_postal", System.Data.OleDb.OleDbType.VarChar, cp);
            parameters[3] = new ProcedureParameter("@diplome", System.Data.OleDb.OleDbType.VarChar, diplome);
            parameters[4] = new ProcedureParameter("@type_diplome", System.Data.OleDb.OleDbType.VarChar, type_diplome);
            parameters[5] = new ProcedureParameter("@connaissance", System.Data.OleDb.OleDbType.VarChar, connaissance);
            TSQLProcedure proc = new TSQLProcedure("ModifStatistique", parameters);
            return proc;
        }
    }
}
