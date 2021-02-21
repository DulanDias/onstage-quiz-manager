using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps;
using MahApps.Metro;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Diagnostics;
using Microsoft.Win32;
namespace Stage_Quiz_Master
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        DispatcherTimer tmr;

        public MainWindow()
        {
            InitializeComponent();

            tmr = new DispatcherTimer();
            tmr.Interval = TimeSpan.FromMilliseconds(1);
            tmr.Tick += tmr_Tick;
            tmr.Start();

        }

        void tmr_Tick(object sender, EventArgs e)
        {
            tbDateTime.Text = DateTime.Now.ToString();
        }

        private void btnShutDown_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Minimized;
        }

        private void metroMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to exit from this application?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
            {
                e.Cancel=true;
            }
        }

        private void btnCalculator_Click(object sender, RoutedEventArgs e)
        {
            windowCalculator newWin = new windowCalculator();
            newWin.Owner = this;
            newWin.Show();
        }

        private void btnCreateNewQuestionaire_Click(object sender, RoutedEventArgs e)
        {
            windowCreateNewXMLWizard newWin = new windowCreateNewXMLWizard();
            newWin.Owner = this;
            newWin.Show();
        }

        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog fbd = new System.Windows.Forms.OpenFileDialog();
            fbd.Title = "Select Questionaire XML File..";
            fbd.Filter = "XML files |*.xml";

            System.Windows.Forms.DialogResult result = fbd.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                mainFrame.Cursor = Cursors.AppStarting;

                miSettings.Visibility = System.Windows.Visibility.Hidden;
                miTools.Visibility = System.Windows.Visibility.Hidden;

                mainFrame.NavigationService.Navigate(new player(fbd.FileName));
            }
        }
    }
}
