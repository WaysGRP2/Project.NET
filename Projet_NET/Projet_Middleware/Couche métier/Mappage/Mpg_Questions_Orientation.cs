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
            TSQLProcedure proc = new TSQLProcedure("DisplayQuestionOrient", null);
            return proc;
        }


        static public TSQLProcedure Rq_DeleteQuestion(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("SuppQuestionOrient", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateQuestion(int id_question_orient, string intitule_question_orient, int ordre_orient)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_question_orient", System.Data.OleDb.OleDbType.Integer, id_question_orient);
            parameters[1] = new ProcedureParameter("@intitule_question_orient", System.Data.OleDb.OleDbType.VarChar, intitule_question_orient);
            parameters[2] = new ProcedureParameter("@ordre", System.Data.OleDb.OleDbType.Integer, ordre_orient);
            TSQLProcedure proc = new TSQLProcedure("ModifQuestionOrient", parameters); 
            return proc;
        }

        static public TSQLProcedure Rq_CreateQuestion(string intitule_question_orient, int ordre_orient)
        {
            ProcedureParameter [] parameters = new ProcedureParameter[2];
            parameters[0] = new ProcedureParameter("@intitule_question_orient", System.Data.OleDb.OleDbType.VarChar, intitule_question_orient);
            parameters[1] = new ProcedureParameter("@ordre", System.Data.OleDb.OleDbType.Integer, ordre_orient);
            TSQLProcedure proc = new TSQLProcedure("AddQuestionOrient", parameters);
            return proc;
        }
    }
}
