using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Questions_Orientation
    {
        public static string CH_ID = "Id_Question_O";
        public static string CH_ORDRE = "Ordre_O";
        public static string CH_INTITULE = "Intitule_Question_Orient";

        static public TSQLProcedure Rq_GetAllQuestions()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_GetQuestion()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_DeleteQuestion()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_UpdateQuestion()
        {
            return new TSQLProcedure(null, null);
        }

        static public TSQLProcedure Rq_CreateQuestion()
        {
            return new TSQLProcedure(null, null);
        }
    }
}
