using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Reponses_Orientation
    {
        public static string CH_ID_QUESTION = "Id_Question_O";
        public static string CH_INTITULE = "Intitule_Reponse_Orient";
        public static string CH_ID_METIER = "Id_Metier";

        static public TSQLProcedure Rq_GetAllReponses()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_GetReponse()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_GetReponseByQuestionID(int id)
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_DeleteReponse()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_UpdateReponse()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_CreateReponse()
        {
            return new TSQLProcedure(null, null);
        }
    }
}
