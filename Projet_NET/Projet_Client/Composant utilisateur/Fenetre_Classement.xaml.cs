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
using ComposantTechnique.Objets_en_base;
using System.Windows.Controls;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Classement.xaml
    /// </summary>
    public partial class Fenetre_Classement : Window
    {
        public Fenetre_Classement()
        {
            InitializeComponent();

            CT_Get_Classement CT = new CT_Get_Classement();
            
            Joueur[] classement = (Joueur[])CT.Exec(new Message()).Data[0];

            GridView view = new GridView();

            GridViewColumn col1 = new GridViewColumn();
            col1.Header = "Nom";
            col1.DisplayMemberBinding = new Binding("Nom");
            view.Columns.Add(col1);

            GridViewColumn col2 = new GridViewColumn();
            col2.Header = "Score";
            col2.DisplayMemberBinding = new Binding("Score");
            view.Columns.Add(col2);

            view.AllowsColumnReorder = false;
            this.ClassementListView.View = view;

            foreach (Joueur j in classement)
            {
                this.ClassementListView.Items.Add(new Item(j.Nom, j.Score));
            }
        }
    }

    class Item
    {
        string _nom;
        int _score;

        public Item(string nom, int score)
        {
            _nom = nom;
            _score = score;
        }

        public string Nom
        {
            set { _nom = value; }
            get { return _nom; }
        }

        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
    }
}
