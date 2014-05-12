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
using Projet_Client.Composant_de_communication;

namespace Projet_Client
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Message msg = new Message();
            msg.AppName = "Client";
            msg.Invoke = "WF_Envoi_Mail";
            msg.PSecurity = "A faire";
            msg.Statut = false;
            msg.Info = "J'essaie d'envoyer un mail";
            msg.Data[0] = "crepinvcc@hotmail.fr";
            msg.Data[1] = "Corps du message";
            msg.Token = "20942948CU4209U";
            Message reponse = MessageManager.StartClient(msg);
            this.resultTextBox.Text += reponse.Invoke + " : " + reponse.Statut.ToString();
        }
    }
}
