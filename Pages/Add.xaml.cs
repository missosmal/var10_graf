using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace var10_graf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public MainWindow mw;
        public Add(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            if(!Regex.IsMatch(Time.Text, "[0-24]:[0-59]") || Time.Text == "" )
            {
                MessageBox.Show("2");
                return;
            }

            if (!Regex.IsMatch(FIO.Text, "[а-яА-Я]") || FIO.Text == "")
            {
                MessageBox.Show("3");
                return;
            }

            if (!Regex.IsMatch(phone_number.Text, @"^\+7\d{10}$") || phone_number.Text == "")
            {
                MessageBox.Show("4");
                return;
            }
            string query = $"INSERT INTO `pc_table`(`Id`, `Data`, `Time`, `FIO`, `phone_number`, `passport`) VALUES (NULL,'{Date.Text}','{Time.Text}','{FIO.Text}','{phone_number.Text}','{passport.Text}')";
            mw.Connection(query);
            mw.PC();
            mw.frame.Navigate(new Pages.Main(mw));
            MessageBox.Show("Добавлено!");
        }

        private void Cansel_Button(object sender, RoutedEventArgs e)
        {
            mw.frame.Navigate(new Pages.Main(mw));
        }
    }
}
