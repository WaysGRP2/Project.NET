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
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Title = "Projet Middleware";
            Console.WriteLine("~~~~~~ MIDDLEWARE ~~~~~~");
            Console.ResetColor();
            //DEBUGTestFunction();
            
            MessageManager.StartListening();
        }

        public static void DEBUGTestFunction()
        {
            if (!Properties.Settings.Default.DebugMode)
                return;
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
            if (!Properties.Settings.Default.DebugMode)
                return;
            Console.WriteLine("Tables in '{0}' DataSet.\n", ds.DataSetName);
            foreach (System.Data.DataTable dt in ds.Tables)
            {
                Console.WriteLine("{0} Table.\n", dt.TableName);
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName.Trim() + "\t");
                }
                for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                {
                    for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                    {
                        Console.Write(dt.Rows[curRow][curCol].ToString().Trim() + "\t");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
