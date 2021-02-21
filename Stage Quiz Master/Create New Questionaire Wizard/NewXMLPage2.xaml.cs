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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Stage_Quiz_Master.Create_New_Questionaire_Wizard
{
    /// <summary>
    /// Interaction logic for NewXMLPage2.xaml
    /// </summary>
    public partial class NewXMLPage2 : Page
    {
        string filePath = null;
        int numQ ;

        public NewXMLPage2(string path)
        {
            InitializeComponent();
            comboAnswerType.SelectedIndex = 0;
            filePath = path;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            int i;
            bool success = int.TryParse(tbNumQues.Text, out i);

            if (success && int.Parse(tbNumQues.Text)>0)
            {
                numQ = int.Parse(tbNumQues.Text);

                //Save to XML File
                XmlTextWriter textWriter = new XmlTextWriter(@filePath, null);
                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("Questionaire");
                textWriter.WriteAttributeString("NumberOfQuestions", numQ.ToString());

                if (comboAnswerType.SelectedIndex==0)
                {
                textWriter.WriteAttributeString("AnswerType", "mcq");
                }
                else  if (comboAnswerType.SelectedIndex==1)
                {
                textWriter.WriteAttributeString("AnswerType", "direct");
                }

                textWriter.WriteEndDocument();
                textWriter.Close();

                navigateToNextPage();
            }
            else
            {
                System.Windows.MessageBox.Show("Please enter a valid number for the Number of Questions field.", "Validation Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                tbNumQues.Clear();
                tbNumQues.Focus();
            }
        }

        private void navigateToNextPage()
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);

                if (comboAnswerType.SelectedIndex == 0)
                {
                    nav.Navigate(new NewXMLPage3(filePath, numQ));
                }
                else if (comboAnswerType.SelectedIndex == 1)
                {
                    nav.Navigate(new NewXMLPage4(filePath, numQ));
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);            //Error Message
            }

        }

        private void tbNumQues_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbNumQues.Text.Trim() != null)
            {
                btnNext.IsEnabled = true;
            }
            else
            {
                btnNext.IsEnabled = false;
            }
        }

    }
}
