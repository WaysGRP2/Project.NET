using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Administrateurs
    {
        public static string CH_ID = "Id_Admin";
        public static string CH_LOGIN = "Login";
        public static string CH_MDP = "Mdp";

        static public TSQLProcedure Rq_GetAllAdmins()
        {
            TSQLProcedure proc = new TSQLProcedure("GetAllAdmins", null);
            return proc;
        }

        static public TSQLProcedure Rq_GetAdmin(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("GetAdmin", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_DeleteAdmin(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("Supp_Admin", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateAdmin(int id, string login, string hashedPassword)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@login", System.Data.OleDb.OleDbType.VarChar, login);
            parameters[2] = new ProcedureParameter("@password", System.Data.OleDb.OleDbType.VarChar, hashedPassword);
            TSQLProcedure proc = new TSQLProcedure("ModifierAdmin", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreateAdmin(string login, string hashedPassword)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[2];
            parameters[0] = new ProcedureParameter("@login", System.Data.OleDb.OleDbType.VarChar, login);
            parameters[1] = new ProcedureParameter("@score", System.Data.OleDb.OleDbType.VarChar, hashedPassword);
            TSQLProcedure proc = new TSQLProcedure("AddAdmin", parameters);
            return proc;
        }
    }
}
