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
using Projet_Client.Composant_de_travail;
using MessageSerializable;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Aidez_Nous.xaml
    /// </summary>
    public partial class Fenetre_Aidez_Nous : Window
    {
        public Fenetre_Aidez_Nous()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CT_Add_Statistique CT = new CT_Add_Statistique();

            Message msg = new Message();
            msg.Data[0] = this.AgeTextBox.Text;
            if(this.SexeComboBox.SelectedValue == "Homme")
                msg.Data[1] = true;
            else
                msg.Data[1] = false;
            msg.Data[2] = this.CodePostalTextBox.Text;
            msg.Data[3] = this.DiplomeTextBox.Text;
            msg.Data[4] = this.TypeDiplomeTextBox.Text;
            msg.Data[5] = this.ConnaissanceTextBox.Text;

            CT.Exec(msg);
        }
    }
}
