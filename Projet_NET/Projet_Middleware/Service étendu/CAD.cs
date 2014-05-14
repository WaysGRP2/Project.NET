using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using Projet_Middleware.Couche_métier.Composant_technique;
using Projet_Middleware.Couche_métier.Mappage;

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
            this.cnx = (string)xml.LoadConfig().Data[0];
            this.oCNX = new OleDbConnection(this.cnx);
            this.oCMD = new OleDbCommand();
            this.oDA = new OleDbDataAdapter();
        }

        public static CAD GetInstance()
        {
            if (instance == null)
                instance = new CAD();
            return instance;
        }

        public MessageSerializable.Message Execute_StockedProcedure(MessageSerializable.Message msg)
        {
            if(msg.Data[0].GetType() != typeof(TSQLProcedure))
                return msg;
            TSQLProcedure procedure = (TSQLProcedure)msg.Data[0];

            this.oCNX.Open();

            // Creation de l'objet de commande en précisnat le nom de la procédure
            OleDbCommand cmd = new OleDbCommand(procedure.Name, this.oCNX);

            // Dire à l'objet de commande qu'il est de type procédure stockée
            cmd.CommandType = CommandType.StoredProcedure;

            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);

            // Ajouter les paramètres de la procédure
            if (procedure.Parameters != null)
            {
                foreach (ProcedureParameter param in procedure.Parameters)
                {
                    cmd.Parameters.Add(new OleDbParameter(param.Name, param.Type)).Value = param.Value;
                }
            }

            // Executer la commande
            DataSet ds = new DataSet();
            adp.Fill(ds);

            this.oCNX.Close();

            MessageSerializable.Message reponse = msg;
            reponse.Data[0] = ds;
            reponse.Statut = true;
            return reponse;
        }
    }
}