using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Joueurs
    {
        public static string CH_ID = "Id_Joueur";
        public static string CH_PSEUDO = "Pseudo";
        public static string CH_SCORE = "Score";

        static public TSQLProcedure Rq_GetAllPlayers()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayClassement", null);
            return proc;
        }

        static public TSQLProcedure Rq_DeletePlayer(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("SuppJoueur", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdatePlayer(int id, string pseudo, int score)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_joueur", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@pseudo", System.Data.OleDb.OleDbType.VarChar, pseudo);
            parameters[2] = new ProcedureParameter("@score", System.Data.OleDb.OleDbType.Integer, score);
            TSQLProcedure proc = new TSQLProcedure("ModifJoueur", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdatePlayerScore(int id, int score)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[2];
            parameters[0] = new ProcedureParameter("@id_joueur", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@score", System.Data.OleDb.OleDbType.Integer, score);
            TSQLProcedure proc = new TSQLProcedure("ModifierJoueur", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreatePlayer(string pseudo, int score)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[2]; 
            parameters[0] = new ProcedureParameter("@pseudo", System.Data.OleDb.OleDbType.VarChar, pseudo);
            parameters[1] = new ProcedureParameter("@score", System.Data.OleDb.OleDbType.Integer, score);
            TSQLProcedure proc = new TSQLProcedure("AddJoueur", parameters);
            return proc;
        }
    }
}
