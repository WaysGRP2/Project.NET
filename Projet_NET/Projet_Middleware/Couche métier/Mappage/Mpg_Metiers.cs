using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Metiers
    {
        public static string CH_ID = "Id_Metier";
        public static string CH_DESCRIPTION = "Description_Metier";
        public static string CH_INTITULE = "Intitule_Metier";

        static public TSQLProcedure Rq_GetAllMetiers()
        {
            TSQLProcedure proc = new TSQLProcedure("DisplayMetier", null);
            return proc;
        }

        static public TSQLProcedure Rq_DeleteMetier(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id_metier", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("SuppMetier", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_UpdateMetier(int id, string intitule, string description)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id_metier", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@intitule_metier", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[2] = new ProcedureParameter("@description_metier", System.Data.OleDb.OleDbType.VarChar, description);
            TSQLProcedure proc = new TSQLProcedure("ModifMetier", parameters);
            return proc;
        }

        static public TSQLProcedure Rq_CreateMetier(string intitule, string description)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[2];
            parameters[0] = new ProcedureParameter("@intitule_metier", System.Data.OleDb.OleDbType.VarChar, intitule);
            parameters[1] = new ProcedureParameter("@description_metier", System.Data.OleDb.OleDbType.VarChar, description);
            TSQLProcedure proc = new TSQLProcedure("AddMetier", parameters);
            return proc;
        }
    }
}
