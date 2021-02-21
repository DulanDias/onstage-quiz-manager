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
    /// Interaction logic for NewXMLPage4.xaml
    /// </summary>
    public partial class NewXMLPage4 : Page
    {

        string filePath = null;
        int Qs;

        String[,] arr;

        private int count;

        public NewXMLPage4(string path, int numQ)
        {
            InitializeComponent();

            count = 1;

            Qs = numQ;
            filePath = path;

            //Create Data Array

            arr = new String[Qs, 3];

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

        private void lbi_Selected(object sender, RoutedEventArgs e)
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
            tbAns.Text = arr[count - 1, 1];
            tbTime.Text = arr[count - 1, 2];
        }


        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (count < Qs)
            {
                count++;
                txtQuestionCount.Text = "Question " + count + " of " + Qs;

                listBox.SelectedIndex = count - 1;

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

        private void saveToXML()
        {
            try
            {
                XmlTextWriter textWriter = new XmlTextWriter(@filePath, null);
                textWriter.WriteStartDocument();

                textWriter.WriteStartElement("Questionaire");
                textWriter.WriteAttributeString("qCount", Qs.ToString());
                textWriter.WriteAttributeString("type", "direct");             //TYPE: Direct

                for (int i = 0; i < Qs; i++)
                {
                    textWriter.WriteStartElement("Question " + (i + 1).ToString());

                    textWriter.WriteStartElement("Question");
                    textWriter.WriteString(arr[i, 0]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Answer");
                    textWriter.WriteString(arr[i, 1]);
                    textWriter.WriteEndElement();

                    textWriter.WriteStartElement("Time");
                    textWriter.WriteString(arr[i, 2]);
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

        private void tbQues_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 0] = tbQues.Text;
        }

        private void tbAns_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 1] = tbAns.Text;
        }

        private void tbTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            arr[count - 1, 2] = tbTime.Text;
        }
    }
}
