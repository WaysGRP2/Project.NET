using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Questions_Jeu
    {
        public static string CH_ID = "Id_Question_J";
        public static string CH_ORDRE = "Ordre_J";
        public static string CH_INTITULE = "Intitule_Question_Jeu";

        static public TSQLProcedure Rq_GetAllQuestions()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayQuestionJeu", null);
            return proc;
        } 
        /*
        static public TSQLProcedure Rq_GetQuestion()
        {
            TSQLProcedure proc = new TSQLProcedure ("DisplayQuestionJeu", null)
            return proc;
        } */

        static public TSQLProcedure Rq_DeleteQuestion(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id_question_jeu", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("SupprQuestionJeu", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateQuestion(int id, string intitule, int point)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_question_jeu", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@intitule_question", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[2] = new ProcedureParameter("@point", System.Data.OleDb.OleDbType.Integer, point);

            TSQLProcedure proc = new TSQLProcedure("ModifQuestionJeu", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreateQuestion(string intitule, int ordre)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[2];
            parameters[0] = new ProcedureParameter("@intitule_question_jeu", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[1] = new ProcedureParameter("@ordre", System.Data.OleDb.OleDbType.Integer, ordre);

            TSQLProcedure proc = new TSQLProcedure("AddQuestionJeu", parameters); 
            return proc;
        }
    }
}
