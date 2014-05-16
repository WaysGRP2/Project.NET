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
using ComposantTechnique.Objets_en_base;
using MessageSerializable;
using Projet_Client.Composant_de_travail;

namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Fenetre_Admin.xaml
    /// </summary>
    public partial class Fenetre_Admin : Window
    {
        #region Attributs
        private CT_Get_Questionnaire.QuestionnaireType type;
        private QuestionJeu[] questionsJeu;
        private QuestionOrientation[] questionsOrientation;
        private TextBox[] ReponsesTxtBox;
        private TextBox[] ReponsesPointsTxtBox;
        private CheckBox[] ReponseIsCorrectChkBox;
        private ComboBox[] ReponseMMetierComboBox;
        private List<string> MetierList;
        #endregion

        #region Initialisation de la fenetre
        public Fenetre_Admin()
        {
            InitializeComponent();

            this.NewButton.IsEnabled = false;// Implémentation incomplète

            ReponsesTxtBox = new TextBox[4];

            ReponsesTxtBox[0] = this.Reponse1TextBox;
            ReponsesTxtBox[1] = this.Reponse2TextBox;
            ReponsesTxtBox[2] = this.Reponse3TextBox;
            ReponsesTxtBox[3] = this.Reponse4TextBox;

            ReponsesPointsTxtBox = new TextBox[4];

            ReponsesPointsTxtBox[0] = this.PtsQues1Txtbox;
            ReponsesPointsTxtBox[1] = this.PtsQues2Txtbox;
            ReponsesPointsTxtBox[2] = this.PtsQues3Txtbox;
            ReponsesPointsTxtBox[3] = this.PtsQues4Txtbox;

            ReponseIsCorrectChkBox = new CheckBox[4];

            ReponseIsCorrectChkBox[0] = this.IsCorrectQues1ChkBox;
            ReponseIsCorrectChkBox[1] = this.IsCorrectQues2ChkBox;
            ReponseIsCorrectChkBox[2] = this.IsCorrectQues3ChkBox;
            ReponseIsCorrectChkBox[3] = this.IsCorrectQues4ChkBox;

            ReponseMMetierComboBox = new ComboBox[4];

            ReponseMMetierComboBox[0] = this.Metier1Combobox;
            ReponseMMetierComboBox[1] = this.Metier2Combobox;
            ReponseMMetierComboBox[2] = this.Metier3Combobox;
            ReponseMMetierComboBox[3] = this.Metier4Combobox;

            this.MetierList = new List<string>();
        }
        #endregion

        #region Methodes changement de type de question
        private void QuestionTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.refreshQuestionList();
        }

        private void refreshQuestionList()
        {
            CT_Get_Questionnaire CT = new CT_Get_Questionnaire();
            Message msg = new Message();

            if (this.QuestionTypeComboBox.SelectedIndex == 0)
            {
                this.type = CT_Get_Questionnaire.QuestionnaireType.Jeu;
                msg.Data[0] = this.type;
                this.questionsJeu = (QuestionJeu[])CT.Exec(msg).Data[0];

                this.QuestionListBox.ItemsSource = this.questionsJeu;
            }
            else
            {
                this.type = CT_Get_Questionnaire.QuestionnaireType.Orientation;
                msg.Data[0] = this.type;
                this.questionsOrientation = (QuestionOrientation[])CT.Exec(msg).Data[0];

                this.QuestionListBox.ItemsSource = this.questionsOrientation;

                foreach (QuestionOrientation q in this.questionsOrientation)
                {
                    foreach (ReponseOrientation rep in q.Reponses)
                    {
                        if (!this.MetierList.Contains(rep.Metier.Intitule))
                        {
                            this.MetierList.Add(rep.Metier.Intitule);
                            Projet_Client.Composant_de_communication.MessageManager.Debug(rep.Metier.Intitule);
                        }
                    }
                }

                foreach (ComboBox cb in this.ReponseMMetierComboBox)
                {
                    cb.ItemsSource = this.MetierList;
                }
            }
        }
        #endregion

        private List<Metier> RecupListMetierOfQuestionOrientation(QuestionOrientation question)
        {
            List<Metier> listMetier = new List<Metier>();
            foreach (QuestionOrientation q in this.questionsOrientation)
            {
                foreach (ReponseOrientation rep in q.Reponses)
                {
                    if (!listMetier.Contains(rep.Metier))
                    {
                        listMetier.Add(rep.Metier);
                    }
                }
            }
            return listMetier;
        }

        #region Méthode changement de question selectionee
        private void QuestionListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.QuestionListBox.SelectedItem == null)
                return;
            switch (this.type)
            {
                case CT_Get_Questionnaire.QuestionnaireType.Jeu:
                    QuestionJeu questionJ = ((QuestionJeu)this.QuestionListBox.SelectedItem);
                    this.QuestionModLabel.Content = "Question " + questionJ.Order;
                    this.QuestionIntituleLabel.Text = questionJ.QuestionText;

                    for (int i = 0; i < questionJ.Reponses.Length; i++)
                    {
                        ReponseJeu rep = questionJ.Reponses[i];

                        this.ReponsesTxtBox[i].Text = rep.ReponseText;
                        this.ReponsesPointsTxtBox[i].IsEnabled = true;
                        this.ReponsesPointsTxtBox[i].Text = rep.Points.ToString();
                        this.ReponseIsCorrectChkBox[i].IsEnabled = true;
                        this.ReponseIsCorrectChkBox[i].IsChecked = rep.IsCorrect;
                        this.ReponseMMetierComboBox[i].IsEnabled = false;
                    }
                        
                    for (int i = questionJ.Reponses.Length; i < 4; i++)
                    {
                        this.ReponsesTxtBox[i].Text = "";
                        this.ReponsesPointsTxtBox[i].IsEnabled = false;
                        this.ReponseIsCorrectChkBox[i].IsChecked = false;
                        this.ReponseIsCorrectChkBox[i].IsEnabled = false;
                        this.ReponseMMetierComboBox[i].IsEnabled = false;
                    }
                    break;
                case CT_Get_Questionnaire.QuestionnaireType.Orientation:
                    QuestionOrientation questionO = ((QuestionOrientation)this.QuestionListBox.SelectedItem);
                    this.QuestionModLabel.Content = "Question " + questionO.Order;
                    this.QuestionIntituleLabel.Text = questionO.QuestionText;

                    for (int i = 0; i < questionO.Reponses.Length; i++)
                    {
                        this.ReponseMMetierComboBox[i].IsEnabled = true;
                        ReponseOrientation rep = questionO.Reponses[i];

                        this.ReponsesTxtBox[i].Text = rep.ReponseText;
                        this.ReponseMMetierComboBox[i].Text = rep.Metier.Intitule;
                    }

                    for (int i = questionO.Reponses.Length; i < 4; i++)
                    {
                        this.ReponsesTxtBox[i].Text = "";
                        this.ReponseMMetierComboBox[i].IsEnabled = false;
                    }

                    foreach (TextBox tb in this.ReponsesPointsTxtBox)
                    {
                        tb.IsEnabled = false;
                    }

                    foreach (CheckBox ch in this.ReponseIsCorrectChkBox)
                    {
                        ch.IsChecked = false;
                        ch.IsEnabled = false;
                    }
                    break;
            }
        }
        #endregion

        #region Méthode de sauvegarde de la question sélectionée
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.type)
            {
                case CT_Get_Questionnaire.QuestionnaireType.Jeu:
                    QuestionJeu questionJ = ((QuestionJeu)this.QuestionListBox.SelectedItem);

                    questionJ.QuestionText = this.QuestionIntituleLabel.Text;

                    for(int i = 0; i < questionJ.Reponses.Length; i++)
                    {
                        bool correct = (this.ReponseIsCorrectChkBox[i].IsChecked.HasValue) ? this.ReponseIsCorrectChkBox[i].IsChecked.Value : false;
                        questionJ.Reponses[i] = new ReponseJeu(
                            questionJ.Reponses[i].ID, 
                            questionJ.ID, 
                            this.ReponsesTxtBox[i].Text,
                            Convert.ToInt32(this.ReponsesPointsTxtBox[i].Text),
                            correct);
                    }

                    Message msgJ = new Message();

                    msgJ.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Jeu;
                    msgJ.Data[1] = questionJ;

                    new CT_Upd_Question().Exec(msgJ);

                    break;
                case CT_Get_Questionnaire.QuestionnaireType.Orientation:
                    QuestionOrientation questionO = ((QuestionOrientation)this.QuestionListBox.SelectedItem);

                    questionO.QuestionText = this.QuestionIntituleLabel.Text;

                    for (int i = 0; i < questionO.Reponses.Length; i++)
                    {
                        Metier m = new Metier("Aucun Metier", "Aucune descrition");

                        foreach(Metier metier in this.RecupListMetierOfQuestionOrientation(questionO))
                        {
                            if(metier.Intitule == this.ReponseMMetierComboBox[i].Text)
                                m = metier;
                        }

                        questionO.Reponses[i] = new ReponseOrientation(
                            questionO.Reponses[i].ID,
                            questionO.ID,
                            this.ReponsesTxtBox[i].Text,
                            m);
                    }

                    Message msgO = new Message();

                    msgO.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Orientation;
                    msgO.Data[1] = questionO;

                    new CT_Upd_Question().Exec(msgO);

                    break;
            }

            this.refreshQuestionList();
        }
        #endregion

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.type)
            {
                case CT_Get_Questionnaire.QuestionnaireType.Jeu:
                    QuestionJeu questionJ = ((QuestionJeu)this.QuestionListBox.SelectedItem);

                    Message msgJ = new Message();

                    msgJ.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Jeu;
                    msgJ.Data[1] = questionJ;

                    new CT_Del_Question().Exec(msgJ);

                    break;
                case CT_Get_Questionnaire.QuestionnaireType.Orientation:
                    QuestionOrientation questionO = ((QuestionOrientation)this.QuestionListBox.SelectedItem);

                    questionO.QuestionText = this.QuestionIntituleLabel.Text;

                    Message msgO = new Message();

                    msgO.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Orientation;
                    msgO.Data[1] = questionO;

                    new CT_Del_Question().Exec(msgO);

                    break;
            }
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            switch (this.type)
            {
                case CT_Get_Questionnaire.QuestionnaireType.Jeu:

                    int id = this.questionsJeu[this.questionsJeu.Length - 1].ID;

                    ReponseJeu[] reps = new ReponseJeu[4];

                    QuestionJeu questionJ = (new QuestionJeu(id,this.QuestionIntituleLabel.Text, reps, this.questionsJeu.Length+1));

                    Message msgJ = new Message();

                    msgJ.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Jeu;
                    msgJ.Data[1] = questionJ;

                    new CT_Add_Question().Exec(msgJ);

                    break;
                case CT_Get_Questionnaire.QuestionnaireType.Orientation:
                    QuestionOrientation questionO = ((QuestionOrientation)this.QuestionListBox.SelectedItem);

                    questionO.QuestionText = this.QuestionIntituleLabel.Text;

                    Message msgO = new Message();

                    msgO.Data[0] = CT_Get_Questionnaire.QuestionnaireType.Orientation;
                    msgO.Data[1] = questionO;

                    new CT_Del_Question().Exec(msgO);

                    break;
            }
        }
    
        private void Button_Modif_Mail_Click(object sender, RoutedEventArgs e)
        {
            string nouv_Addr = nouv_Mail.Text;

            Message mail = new Message();

            mail.Data[0] = nouv_Addr;

            new CT_Upd_Mail().Exec(mail);
        }
    }
}