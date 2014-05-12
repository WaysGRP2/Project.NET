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
            MessageManager.StartListening();
        }
    }
}
