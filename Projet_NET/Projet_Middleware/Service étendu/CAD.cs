using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Projet_Middleware.Couche_métier.Composant_technique;
using Projet_Middleware;

namespace Projet_Middleware.Service_étendu
{
    class CAD
    {
        private static  CAD instance = null;
        private string cnx;
        private OleDbConnection oCNX;
        private OleDbCommand oCMD;
        private OleDbDataAdapter oDA;
        private DataSet oDS;

        private CAD()
        {
            XMLLoader xml = new XMLLoader(XMLLoader.CONFIG_TYPE.SQL_Server_Config);
            this.cnx = (string)xml.LoadConfig();
            this.oCNX = new OleDbConnection(this.cnx);
            this.oCMD = new OleDbCommand();
            this.oDA = new OleDbDataAdapter();
            Program.Debug("Tentative de connexion a la base...");
            try
            {
                Program.Debug("Chaîne de connexion : " + this.cnx);
                this.oCNX.Open();
                Program.Debug("Connexion établie");
            }
            catch (Exception ex)
            {
                Program.Debug(ex.Message);
            }
            finally
            {
                this.oCNX.Close();
                Program.Debug("Fermuture de la connexion.");
            }
        }

        public static CAD GetInstance()
        {
            if (instance == null)
                instance = new CAD();
            return instance;
        }

        public System.Data.DataSet m_GetRows(string rq_sql, string rows_name)
        {
            this.oDS = new DataSet();
            this.oCMD.Connection = this.oCNX;
            this.oCMD.CommandText = rq_sql;
            this.oDA.SelectCommand = this.oCMD;
            this.oDA.Fill(this.oDS, rows_name);
            return this.oDS;
        }

        public void m_ActionsRows(string rq_sql)
        {
            this.oCMD.Connection = this.oCNX;
            this.oCMD.CommandText = rq_sql;
            this.oCNX.Open();
            this.oCMD.ExecuteNonQuery();
            this.oCNX.Close();
        }

        public OleDbDataReader Execute_StockedProcedure(string procedureName, ProcedureParameter[] paramList)
        {
            this.oCNX.Open();

            // Creation de l'objet de commande en précisnat le nom de la procédure
            OleDbCommand cmd = new OleDbCommand(procedureName, this.oCNX);

            // Dire à l'objet de commande qu'il est de type procédure stockée
            cmd.CommandType = CommandType.StoredProcedure;
            
            // Ajouter les paramètres de la procédure
            foreach(ProcedureParameter param in paramList)
            {
                cmd.Parameters.Add(new OleDbParameter(param.Name, param.Type));
            }

            // Executer la commande
            OleDbDataReader rdr = cmd.ExecuteReader();

            this.oCNX.Close();

            return rdr;
        }

        public OleDbDataReader Execute_StockedProcedure(string procedureName, List<ProcedureParameter> paramList)
        {
            ProcedureParameter[] list = new ProcedureParameter[paramList.Count];
            int index = 0;
            foreach (ProcedureParameter param in paramList)
            {
                list[index] = param;
                index++;
            }
            return Execute_StockedProcedure(procedureName, list);
        }
    }
}
