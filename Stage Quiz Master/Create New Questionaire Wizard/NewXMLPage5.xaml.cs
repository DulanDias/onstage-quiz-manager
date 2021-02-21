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
    /// Interaction logic for NewXMLPage5.xaml
    /// </summary>
    public partial class NewXMLPage5 : Page
    {
        public NewXMLPage5()
        {
            InitializeComponent();
        }

        private void btnFinish_Click(object sender, RoutedEventArgs e)
        {
            var parentWindow = this.Parent as Window;

            if (parentWindow != null)
            {
                parentWindow.Close();           //TODO:: Check here
            }
        }

    }
}
