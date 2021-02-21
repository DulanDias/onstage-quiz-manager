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
    /// Interaction logic for NewXMLPage3.xaml
    /// </summary>
    public partial class NewXMLPage3 : Page
    {

        string filePath = null;
        int Qs;

        String[,] arr;

        private int count;

        public NewXMLPage3(string path, int numQ)
        {
            InitializeComponent();

            count = 1;

            Qs = numQ;
            filePath = path;

            //Create Data Array

            arr = new String[Qs,6];

            //Create List Items

            for (int i = 0; i < Qs; i++)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = "Question " + (i + 1).ToString();

                lbi.Selected += lbi_Selected;

                listBox.Items.Add(lbi);
            }

            listBox.SelectedIndex = 0;

            txtQuestionCount.Text = "Question " + count + " of " + Qs;
        }

        void lbi_Selected(object sender, RoutedEventArgs e)
        {
           ListBoxItem lbi = (ListBoxItem)sender;
           count = Convert.ToInt32(((lbi.Content.ToString()).Replace("Question ", "").Trim()));
           txtQuestionCount.Text = "Question " + count + " of " + Qs;

           navigateData();
        }

        void navigateData()
        {
            //Navigate Data
            tbQues.Text = arr[count - 1, 0];
            tbAns1.Text = arr[count - 1, 1];
            tbAns2.Text = arr[count - 1, 2];
            tbAns3.Text = arr[count - 1, 3];
            tbAns4.Text = arr[count - 1, 4];
            tbTime.Text = arr[count - 1, 5];
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (validateForm())
            {
                //clearForm();

                if (count < Qs)
                {
                    count++;
                    txtQuestionCount.Text = "Question " + count + " of " + Qs;

                    listBox.SelectedIndex= count-1;

                    navigateData();
                }
                else
                {
                    //End of Question Input
                    saveToXML();

                    NavigationService nav = NavigationService.GetNavigationService(this);
                    nav.Navigate(new NewXMLPage5());
                }
            }
            else
            {
                System.Windows.MessageBox.Show("One or more fields are empty.", "Validation Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void saveToXML()
        {
            try
            {
                XmlTextWriter textWriter = new XmlTextWriter(@filePath, null);
                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("Questionaire");
                textWriter.WriteAttributeString("qCount", Qs.ToString());
                textWriter.WriteAttributeString("type", "mcq");             //TYPE: MCQ

                for (int i = 0; i < Qs;i++)
                {
                    textWriter.WriteStartElement("Question "+(i+1).ToString());

                    textWriter.WriteStartElement("Question");
                    textWriter.WriteString(arr[i,0]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Answer 1");
                    textWriter.WriteString(arr[i,1]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Answer 2");
                    textWriter.WriteString(arr[i,2]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Answer 3");
                    textWriter.WriteString(arr[i,3]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Answer 4");
                    textWriter.WriteString(arr[i,4]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Time");
                    textWriter.WriteString(arr[i,5]);
                    textWriter.WriteEndElement(); 

                    textWriter.WriteEndElement(); 
                }

                textWriter.WriteEndElement(); 

                textWriter.WriteEndDocument();
                textWriter.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);                    //Error Message
            }
        }

        private bool validateForm()
        {
            if (tbQues.Text.Trim() == null || tbAns1.Text.Trim() == null || tbAns2.Text.Trim() == null || tbAns3.Text.Trim() == null || tbAns4.Text.Trim() == null || tbTime.Text.Trim() == null)
            {
                return false;
            }

            return true;
        }

        private void clearForm()
        {
            tbQues.Clear();
            tbAns1.Clear();
            tbAns2.Clear();
            tbAns3.Clear();
            tbAns4.Clear();
            tbTime.Clear();
            tbQues.Focus();
        }

        private void tbQues_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 0] = tbQues.Text;
        }

        private void tbAns1_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 1] = tbAns1.Text;
        }

        private void tbAns2_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 2] = tbAns2.Text;
        }

        private void tbAns3_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 3] = tbAns3.Text;
        }

        private void tbAns4_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 4] = tbAns4.Text;
        }

        private void tbTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 5] = tbTime.Text;
        }
    }
}
