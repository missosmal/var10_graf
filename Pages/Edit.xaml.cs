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
using System.Text.RegularExpressions;


namespace var10_graf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Page
    {
        public MainWindow mw;
        public Classes.PC item;
        public Edit(MainWindow mw, Classes.PC item)
        {
            InitializeComponent();
            this.mw = mw;
            this.item = item;

            Date.Text = item.Data.ToString();
            Time.Text = item.Time;
            FIO.Text = item.FIO;
            phone_number.Text = item.phone_number;
            passport.Text = item.passport.ToString();
        }

        private void Edit_Button(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(Time.Text, "[0-24]:[0-59]") || Time.Text == "")
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
            string query = $"UPDATE `pc_table` SET `Data`='{Date.Text}',`Time`='{Time.Text}',`FIO`='{FIO.Text}',`phone_number`='{phone_number.Text}',`passport`='{passport.Text}' WHERE 'pc_table'.'Id' = '{item.Id}'";
            mw.Connection(query);
            mw.PC();
            mw.frame.Navigate(new Pages.Main(mw));
            MessageBox.Show("Изменено!");
        }

        private void Cansel_Button(object sender, RoutedEventArgs e)
        {
            mw.frame.Navigate(new Pages.Main(mw));

        }
    }
}
