using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware.Service_étendu
{
    class CAD
    {
        private string cnx;
        private OleDbConnection oCNX;
        private OleDbCommand oCMD;
        private OleDbDataAdapter oDA;
        private DataSet oDS;

        public CAD()
        {
            XMLLoader xml = new XMLLoader(XMLLoader.CONFIG_TYPE.SQL_Server_Config);
            this.cnx = (string)xml.LoadConfig();
            this.oCNX = new OleDbConnection(this.cnx);
            this.oCMD = new OleDbCommand();
            this.oDA = new OleDbDataAdapter();
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
    }
}
