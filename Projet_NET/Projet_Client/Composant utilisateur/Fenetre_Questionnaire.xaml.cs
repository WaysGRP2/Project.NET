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


namespace Projet_Client.Composant_utilisateur
{
    /// <summary>
    /// Logique d'interaction pour Questionnaire.xaml
    /// </summary>
    public partial class Fenetre_Questionnaire : Window
    {
        public enum QuestionnaireType
        {
            Jeu,
            Orientation
        }

        private QuestionnaireType questionnaireType;
        private List<Object> questionnaire;

        public Fenetre_Questionnaire(QuestionnaireType type)
        {
            InitializeComponent();

            CT_Get_Questionnaire CT = new CT_Get_Questionnaire();
            MessageSerializable.Message msg = new MessageSerializable.Message();
            msg.Data[0] = type;
            this.questionnaireType = type;
            this.questionnaire = (List<Object>)CT.Exec(msg).Data[0];

            switch (type)
            {
                case QuestionnaireType.Jeu:
                    this.Title = "Questionnaire de jeu";
                    
                    break;

                case QuestionnaireType.Orientation:
                    this.Title = "Questionnaire d'orientation";
                    break;
            }
        }
    }
}
