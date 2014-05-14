using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Reponses_Orientation
    {
        public static string CH_ID = "Id_Reponse_O";
        public static string CH_ID_QUESTION = "Id_Question_O";
        public static string CH_INTITULE = "Intitule_Reponse_Orient";
        public static string CH_ID_METIER = "Id_Metier";

        static public TSQLProcedure Rq_GetAllReponses()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayReponseOrient", null);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateReponse(int id_reponse_orient, string intitule_reponse_orient, int id_metier)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_reponse_orient", System.Data.OleDb.OleDbType.Integer, id_reponse_orient);
            parameters[1] = new ProcedureParameter("@intitule_reponse_orient", System.Data.OleDb.OleDbType.VarChar, intitule_reponse_orient);
            parameters[2] = new ProcedureParameter("@id_metier", System.Data.OleDb.OleDbType.Integer, id_metier);
            TSQLProcedure proc = new TSQLProcedure("ModifReponseOrient", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreateReponse(int id_question_orient, string intitule_reponse_orient, int id_metier)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_question_orient", System.Data.OleDb.OleDbType.VarChar, id_question_orient);
            parameters[1] = new ProcedureParameter("@intitule_reponse_orient", System.Data.OleDb.OleDbType.VarChar, intitule_reponse_orient);
            parameters[2] = new ProcedureParameter("@id_metier", System.Data.OleDb.OleDbType.Integer, id_metier);
            TSQLProcedure proc = new TSQLProcedure("AddReponseOrient", parameters);
            return proc;
        }
    }
}
