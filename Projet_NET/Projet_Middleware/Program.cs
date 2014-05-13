using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Projet_Middleware.Composant_Serveur;
using Projet_Middleware.Couche_métier.Composant_technique;

namespace Projet_Middleware
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Projet Middleware";
            Console.WriteLine("~~~~~~ MIDDLEWARE ~~~~~~");
            Projet_Middleware.Service_étendu.CAD.GetInstance();
            MessageManager.StartListening();
        }

        public static void Debug(string msg)
        {
            if (Properties.Settings.Default.DebugMode)
                Console.WriteLine("DEBUG: "+msg+"\n");
        }
    }
}
