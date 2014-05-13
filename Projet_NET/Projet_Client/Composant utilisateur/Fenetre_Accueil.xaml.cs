﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MessageSerializable;
using Projet_Client.Composant_de_communication;
using Projet_Client.Composant_de_travail;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Accueil.xaml
    /// </summary>
    public partial class Fenetre_Accueil : Window
    {
        public Fenetre_Accueil()
        {
            InitializeComponent();
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            CT_EnvoyerMail work = new CT_EnvoyerMail();
            Message reponse = work.Exec("crepinvcc@hotmail.com");

            this.DebugTextBlock.Text = "Tâche :" + reponse.Invoke + "    Réussi :" + reponse.Statut.ToString() + "\n";
        }
    }
}