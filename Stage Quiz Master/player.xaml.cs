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

namespace Stage_Quiz_Master
{
    /// <summary>
    /// Interaction logic for player.xaml
    /// </summary>
    public partial class player : Page
    {
        string fileName;

        public player(string file)
        {
            InitializeComponent();

            this.Visibility = System.Windows.Visibility.Hidden;

            fileName = file;

            this.Cursor = Cursors.Arrow;
            this.Visibility = System.Windows.Visibility.Visible;
        }
    }
}
