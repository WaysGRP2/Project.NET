using System;
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
using Projet_Client.Composant_de_travail;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Accueil.xaml
    /// </summary>
    public partial class Fenetre_Accueil : Window
    {
        private Fenetre_Admin fa;
        private Fenetre_Questionnaire_Jeu fqj;
        private Fenetre_Questionnaire_Orientation fqo;

        public Fenetre_Accueil()
        {
            InitializeComponent();
            if (Properties.Settings.Default.DebugMode)
            {
                Projet_Client.Composant_de_communication.MessageManager.ShowConsoleWindow();
                Console.ForegroundColor = ConsoleColor.Red;
                Projet_Client.Composant_de_communication.MessageManager.Debug("##### CONSOLE DEBUG PROJET_CLIENT #####");
                Console.ResetColor();
            }
        }

        private void SendMailButton_Click(object sender, RoutedEventArgs e)
        {
            CT_EnvoyerMail work = new CT_EnvoyerMail();
            Message msg = new Message();
            msg.Data[0] = "crepinvcc@hotmail.com";
            Message reponse = work.Exec(msg);

            this.DebugTextBlock.Text = "Tâche :" + reponse.Invoke + "    Réussi :" + reponse.Statut.ToString() + "\n";
        }

        private void AdminButton_Click(object sender, RoutedEventArgs e)
        {
            fa =  new Fenetre_Admin();
            fa.Show();
        }

        private void LaunchGameButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NameTextBox.Text != "" && this.MailTextBox.Text != "")
            {
                Properties.Settings.Default.PlayerName = this.NameTextBox.Text;
                Properties.Settings.Default.PlayerMail = this.MailTextBox.Text;
                fqj = new Fenetre_Questionnaire_Jeu();
                fqj.Show();
            }
        }

        private void LaunchOrientationButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NameTextBox.Text != "" && this.MailTextBox.Text != "")
            {
                Properties.Settings.Default.PlayerName = this.NameTextBox.Text;
                Properties.Settings.Default.PlayerMail = this.MailTextBox.Text;
                fqo = new Fenetre_Questionnaire_Orientation();
                fqo.Show();
            }
        }
    }
}
