﻿using System;
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

        static public string Rq_GetPlayer()
        {
            return "";
        }

        static public string Rq_DeletePlayer()
        {
            return "";
        }

        static public string Rq_UpdatePlayer()
        {
            return "";
        }

        static public string Rq_CreatePlayer()
        {
            return "";
        }
    }
}
