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
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_GetStat()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_DeleteStat()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_UpdateStat()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_CreateStat()
        {
            return new TSQLProcedure(null, null);
        }
    }
}
