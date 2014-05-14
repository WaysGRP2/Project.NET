using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Reponses_Jeu
    {
        public static string CH_ID = "Id_Reponse_J";
        public static string CH_ID_QUESTION = "Id_Question_J";
        public static string CH_INTITULE = "Intitule_Reponse_Jeu";
        public static string CH_POINTS = "Point";
        public static string CH_ISCORRECT = "Etat";

        static public TSQLProcedure Rq_GetAllReponses()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayReponseJeu", null);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateReponse(int id, string intitule, int point, bool iscorrect)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[4];
            parameters[0] = new ProcedureParameter("@id_reponse_jeu", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@intitule_reponse", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[2] = new ProcedureParameter("@point", System.Data.OleDb.OleDbType.Integer, point);
            parameters[3] = new ProcedureParameter("@etat", System.Data.OleDb.OleDbType.Boolean, iscorrect);

            TSQLProcedure proc = new TSQLProcedure("ModifReponseJeu", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreateReponse(int id, string intitule, int point, bool iscorrect)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[4];
            parameters[0] = new ProcedureParameter("@id_question_jeu", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@intitule_reponse", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[2] = new ProcedureParameter("@point", System.Data.OleDb.OleDbType.Integer, point);
            parameters[3] = new ProcedureParameter("@etat", System.Data.OleDb.OleDbType.Boolean, iscorrect);

            TSQLProcedure proc = new TSQLProcedure("AddReponseJeu", parameters);
            return proc;
        }
    }
}
