using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Reponses_Jeu
    {
        public static string CH_ID_QUESTION = "Id_Question_J";
        public static string CH_INTITULE = "Intitule_Reponse_Jeu";
        public static string CH_POINTS = "Point";
        public static string CH_ISCORRECT = "Etat";

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
