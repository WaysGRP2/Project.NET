using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Projet_Client.Composant_de_travail;
using ComposantTechnique.Objets_en_base;
using System.Reflection;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Questionnaire.xaml
    /// </summary>
    public partial class Fenetre_Questionnaire_Jeu : Window
    {
        public enum QuestionnaireType
        {
            Jeu,
            Orientation
        }

        private List<QuestionJeu> questionnaire;

        public Fenetre_Questionnaire_Jeu()
        {
            InitializeComponent();

            CT_Get_Questionnaire CT = new CT_Get_Questionnaire();
            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.Data[0] = QuestionnaireType.Jeu;
            this.questionnaire = (List<QuestionJeu>)CT.Exec(msg).Data[0];
            if (this.questionnaire == null)
                return;
            foreach (QuestionJeu q in this.questionnaire)
            {
                System.Windows.MessageBox.Show(q.ID+" "+q.QuestionText);
            }
        }
    }
}
