using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Projet_Middleware.Composant_Serveur;


namespace Projet_Middleware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Projet Middleware";
            Console.WriteLine("~~~~~~ MIDDLEWARE ~~~~~~");

            //DEBUGTestFunction();
            
            MessageManager.StartListening();
        }

        public static void DEBUGTestFunction()
        {
            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.AppName = "Client";
            msg.Invoke = "Tâche demandée";
            msg.Data[0] = "William";
            msg.Data[1] = 666;
            Composant_Serveur.EntreePlateforme.Check(msg);
            
            Debug("Ajout du joueur : "+msg.Statut.ToString());
        }

        public static void Debug(string msg)
        {
            if (Properties.Settings.Default.DebugMode)
                Console.WriteLine("DEBUG: "+msg+"\n");
        }

        public static void DebugPrintDataSet(System.Data.DataSet ds)
        {
            foreach (System.Data.DataTable table in ds.Tables)
            {
                Debug(table.TableName);
                foreach (System.Data.DataRow row in table.Rows)
                {
                    foreach (System.Data.DataColumn col in table.Columns)
                    {
                        Debug(row[col.ColumnName].ToString());
                    }
                }
            }
        }
    }
}
