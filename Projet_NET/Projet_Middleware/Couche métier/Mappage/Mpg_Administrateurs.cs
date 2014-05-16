using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Middleware.Couche_métier.Mappage
{
    class Mpg_Administrateurs
    {
        /* Déclaration du nom des champs de la table ADMIN */
        public static string CH_ID = "Id_Admin";
        public static string CH_LOGIN = "Login";
        public static string CH_MDP = "Mdp";

        /* Méthode de création de la procédure de récupération de tous les admins */
        static public TSQLProcedure Rq_GetAllAdmins()
        {
            TSQLProcedure proc = new TSQLProcedure("GetAllAdmins", null);
            return proc;
        }

        /* Méthode de création de la procédure de récupération d'un admin via son ID */
        static public TSQLProcedure Rq_GetAdmin(int id)
        {
            // On créé un tableau qui va contenir les paramètres de la procédure, la taille du tableau, c'est le nombre de paramètre, ici 1
            ProcedureParameter[] parameters = new ProcedureParameter[1];

            // Un paramètre --> Un nom (ex: @id ou encore @login), un type (OleDBtype --> type que la BDD comprend), 
            // une valeur (ex: 1 pour un ID, William pour un admin, ect).
            // On ajoute don ces paramètres dans le tableau
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);

            // On créé donc la procédure, en spécifiant le nom et ses paramètres
            TSQLProcedure proc = new TSQLProcedure("GetAdmin", parameters);

            // On renvoie la procédure
            return proc;
        }

        /* Méthode de création de la procédure de suppression d'un admin via son ID */
        static public TSQLProcedure Rq_DeleteAdmin(int id)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[1];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            TSQLProcedure proc = new TSQLProcedure("Supp_Admin", parameters);
            return proc;
        }

        /* Méthode de création de la procédure de modification d'un admin via son ID */
        static public TSQLProcedure Rq_UpdateAdmin(int id, string login, string hashedPassword)
        {
            ProcedureParameter[] parameters = new ProcedureParameter[3];
            parameters[0] = new ProcedureParameter("@id", System.Data.OleDb.OleDbType.Integer, id);
            parameters[1] = new ProcedureParameter("@login", System.Data.OleDb.OleDbType.VarChar, login);
            parameters[2] = new ProcedureParameter("@password", System.Data.OleDb.OleDbType.VarChar, hashedPassword);
            TSQLProcedure proc = new TSQLProcedure("ModifierAdmin", parameters);
            return proc;
        }

        /* Méthode de création de la procédure de récupération de création d'un admin */
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
