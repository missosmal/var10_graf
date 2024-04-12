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

namespace var10_graf.Elements
{
    /// <summary>
    /// Логика взаимодействия для PcItm.xaml
    /// </summary>
    public partial class PcItm : UserControl
    {
        public MainWindow mw;
        public Classes.PC item;
        public PcItm(MainWindow mw, Classes.PC item)
        {
            InitializeComponent();
            this.mw = mw;
            this.item = item;

            Data.Content = "Дата: " + item.Data; 
            Time.Content = "Время аренды: " + item.Time; 
            FIO.Content = "ФИО: " + item.FIO; 
            phone_number.Content = "Номер телефона: " + item.phone_number; 
            passport.Content = "Паспортные данные : " + item.passport; 
        }

        private void Edit_button(object sender, RoutedEventArgs e)
        {
            mw.frame.Navigate(new Pages.Edit(mw, item));
        }

        private void Delete_button(object sender, RoutedEventArgs e)
        {
            string query = $"DELETE FROM `pc_table` WHERE 'pc_table'.'Id' = '{item.Id}'";
            mw.Connection(query);
            mw.PC();
            mw.frame.Navigate(new Pages.Main(mw));
            MessageBox.Show("Удалено!");
        }
    }
}
