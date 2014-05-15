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
        private QuestionJeu[] questionnaire;
        private int index = 0;
        private int maxIndex;
        private ReponseJeu[] reponses;
        private System.Windows.Controls.RadioButton[] reponseButtons;
        private bool helped = false;

        public Fenetre_Questionnaire_Jeu()
        {
            InitializeComponent();

            this.Title = "Questionnaire Jeu";
            reponseButtons = new System.Windows.Controls.RadioButton[4];
            reponseButtons[0] = this.Question1Button;
            reponseButtons[1] = this.Question2Button;
            reponseButtons[2] = this.Question3Button;
            reponseButtons[3] = this.Question4Button;

            CT_Get_Questionnaire CT = new CT_Get_Questionnaire();
            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Jeu;
            this.questionnaire = (QuestionJeu[])CT.Exec(msg).Data[0];
            if (this.questionnaire == null)
                return;
            this.maxIndex = this.questionnaire.Length - 1;
            this.reponses = new ReponseJeu[this.questionnaire.Length];
            this.QuestionProgressBar.Minimum = 1;
            this.QuestionProgressBar.Maximum = this.maxIndex + 1;
            this.UpdateQuestion();
        }

        private bool SaveReponses()
        {
            bool canGoNext = false;
            for (int i = 0; i < this.questionnaire[index].Reponses.Length; i++)
            {
                if (this.reponseButtons[i].IsChecked.Value)
                {
                    this.reponses[index] = this.questionnaire[index].Reponses[i];
                    Projet_Client.Composant_de_communication.MessageManager.Debug("Question " + (this.index + 1) + " (" + this.questionnaire[index].QuestionText + ")");
                    Projet_Client.Composant_de_communication.MessageManager.Debug("Reponse " + i + "(" + this.questionnaire[index].Reponses[i].ReponseText + ")");
                    canGoNext = true;
                }
            }
            return canGoNext;
        }

        private void UpdateQuestion()
        {
            this.QuestionTitleLabel.Content = "Question " + (this.index + 1);
            this.QuestionProgressBar.Value = this.index + 1;
            this.QuestionLabel.Content = this.questionnaire[index].QuestionText;

            for (int i = 0; i < 4; i++ )
            {
                if (this.questionnaire[index].Reponses.Length > i)
                {
                    if (this.questionnaire[index].Reponses[i] != null)
                    {
                        this.reponseButtons[i].Content = this.questionnaire[index].Reponses[i].ReponseText;
                        this.reponseButtons[i].Visibility = Visibility.Visible;
                    }
                    else
                        this.reponseButtons[i].Visibility = Visibility.Hidden;
                }
                else
                {
                    this.reponseButtons[i].Content = "";
                    this.reponseButtons[i].Visibility = Visibility.Hidden;
                }
            }
        }

        private int DoCorrection()
        {
            int points = 0;
            if (this.helped)
                points = 2;
            foreach(ReponseJeu rep in this.reponses)
            {
                Projet_Client.Composant_de_communication.MessageManager.Debug("CORRECTION : " + rep.ReponseText + "  correct: " + rep.IsCorrect );
                if (rep.IsCorrect)
                    points += rep.Points;
            }
            MessageBox.Show("Félicitation " + Properties.Settings.Default.PlayerName + " tu as " + points + " points !");
            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.Data[0] = Properties.Settings.Default.PlayerName;
            msg.Data[1] = points;
            CT_Add_PlayerScore CT = new CT_Add_PlayerScore();
            CT.Exec(msg);
            Fenetre_Classement fq = new Fenetre_Classement();
            fq.Show();
            this.Close();
            return points;
        }

        private void SuivButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SaveReponses())
            {
                if (this.index < this.maxIndex)// on passe a la question suivante
                {
                    this.index++;
                    this.UpdateQuestion();

                    if(this.index == maxIndex)
                        this.SuivButton.Content = "Terminer";
                    else
                        this.SuivButton.Content = "Suivant";
                }
                else
                {
                    this.DoCorrection();
                }
            }
        }

        private void PrecButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SaveReponses())
            {
                if (this.index > 0)// on passe a la question suivante
                {
                    this.index--;
                    this.UpdateQuestion();
                }
            }
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            Fenetre_Aidez_Nous fq = new Fenetre_Aidez_Nous();
            fq.Show();

            this.helped = true;
        }
    }
}
