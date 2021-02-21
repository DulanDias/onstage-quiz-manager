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
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;

namespace Stage_Quiz_Master.Create_New_Questionaire_Wizard
{
    /// <summary>
    /// Interaction logic for NewXMLPage1.xaml
    /// </summary>
    public partial class NewXMLPage1 : Page
    {
        public NewXMLPage1()
        {
            InitializeComponent();

            tbDirectory.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
        }

        string pathFile = null;

        private void btnBrowse_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result == DialogResult.OK)
            {
                tbDirectory.Text = fbd.SelectedPath;
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = System.Windows.Input.Cursors.Wait;

            if (IsValidFilename(tbFileName.Text))                 //Check Whether The File Name Is Valid
            {
                string filePath =  tbDirectory.Text + @"\" + tbFileName.Text + ".xml";
                if (File.Exists(filePath))                       //Check If A File Already Exists With The Same Name in the Same Directory
                {
                    if (System.Windows.Forms.MessageBox.Show("There is already a file by this name. Would you like to overwrite it?", "Overwrite File?", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        createFile(filePath);                                  //Overwrite Existing File
                        navigateToNextPage();

                    }
                    else
                    {
                        tbFileName.Clear();
                        tbFileName.Focus();
                    }
                   
                }
                else
                {                                                  //Create New File
                    createFile(filePath);
                    navigateToNextPage();
                }
            }
            else
            {
                System.Windows.MessageBox.Show("File Name that you entered is not valid. Please enter a valid file name.","Validation Failed",MessageBoxButton.OK,MessageBoxImage.Error);
                tbFileName.Clear();
                tbFileName.Focus();
            }

            this.Cursor = System.Windows.Input.Cursors.Arrow;
        }

        private void navigateToNextPage()
        {
            try
            {
                NavigationService nav = NavigationService.GetNavigationService(this);
                //nav.Navigate(new Uri(@"\Create New Questionaire Wizard\NewXMLPage2.xaml", UriKind.RelativeOrAbsolute));
                nav.Navigate(new NewXMLPage2(pathFile));
            }
            catch (Exception ex)
            { 
                System.Windows.Forms.MessageBox.Show("Error: "+ ex.Message);            //Error Message
            }

        }

        private void createFile(string path)
        {
            XmlWriter writer = XmlWriter.Create(@path);
            pathFile = path;
        }



        bool IsValidFilename(string testName)
        {
            Regex containsABadCharacter = new Regex("[" + Regex.Escape(new string(System.IO.Path.GetInvalidPathChars())) + "]");
            if (containsABadCharacter.IsMatch(testName)) { return false; };

            return true;
        }

        private void tbFileName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbFileName.Text.Trim() != null)
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
