using MahApps.Metro.Controls;
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
    public partial class windowCalculator : MetroWindow
    {
        static int[] numbersArray = new int[10];
        static string[] operatorsArray = new string[9];

        static string storageVariable;
        static int numbersCounter = 0;
        static int operatorsCounter = 0;
        static int total = 0;
        static bool totalled = false;

        public windowCalculator()
        {
            InitializeComponent();
        }

        private void One_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "1";
            storageVariable += "1";
        }
        private void Two_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "2";
            storageVariable += "2";
        }
        private void Three_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "3";
            storageVariable += "3";
        }
        private void Four_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "4";
            storageVariable += "4";
        }
        private void Five_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "5";
            storageVariable += "5";
        }
        private void Six_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "6";
            storageVariable += "6";
        }
        private void Seven_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "7";
            storageVariable += "7";
        }
        private void Eight_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "8";
            storageVariable += "8";
        }
        private void Nine_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "9";
            storageVariable += "9";
        }
        private void Zero_Click(object sender, RoutedEventArgs e)
        {
            if (totalled == true)
            {
                Display.Content = "";
                totalled = false;
            }
            Display.Content += "0";
            storageVariable += "0";
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            setNumber(storageVariable);
            setOperator("+");
            Display.Content += "+";
        }
        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            setNumber(storageVariable);
            setOperator("-");
            Display.Content += "-";
        }
        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            setNumber(storageVariable);
            setOperator("*");
            Display.Content += "x";
        }
        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            setNumber(storageVariable);
            setOperator("/");
            Display.Content += "/";
        }
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            setNumber(storageVariable);
            for (int i = 0; i < operatorsCounter; i++)
            {
                if (operatorsArray[i] == "+" && i == 0)
                {
                    total = numbersArray[i] + numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "+")
                {
                    total = total + numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "-" && i == 0)
                {
                    total = numbersArray[i] - numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "-")
                {
                    total = total - numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "*" && i == 0)
                {
                    total = numbersArray[i] * numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "*")
                {
                    total = total * numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "/" && i == 0)
                {
                    total = numbersArray[i] / numbersArray[i + 1];
                }
                else if (operatorsArray[i] == "/")
                {
                    total = total / numbersArray[i + 1];
                }
            }
            Display.Content = total;
            numbersArray = null;
            operatorsArray = null;
            storageVariable = null;
            numbersCounter = 0;
            operatorsCounter = 0;
            total = 0;
            totalled = true;
        }
        static void setNumber(String Number)
        {
            numbersArray[numbersCounter] = Convert.ToInt16(Number);
            storageVariable = null;
            numbersCounter++;
        }
        static void setOperator(String Op)
        {
            operatorsArray[operatorsCounter] = Op;
            operatorsCounter++;
        }
        private void AC_Click(object sender, RoutedEventArgs e)
        {
            Display.Content = "";
            numbersArray = null;
            operatorsArray = null;
            storageVariable = null;
            numbersCounter = 0;
            operatorsCounter = 0;
            total = 0;
        }
    }
}