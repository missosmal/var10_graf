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
using MySql.Data.MySqlClient;

namespace var10_graf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Classes.PC> pcs = new List<Classes.PC>();
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                PC();
                frame.Navigate(new Pages.Main(this));
            }
            catch
            {
                MessageBox.Show("Нет подключения к БД!");
                this.Close();
            }
        }

        public MySqlDataReader Connection(string query)
        {
            string connect = "server=127.0.0.1;port=3310;database=PC;uid=root";
            MySqlConnection mysqlconnection = new MySqlConnection(connect);
            mysqlconnection.Open();
            MySqlCommand mysqlcommand = new MySqlCommand(query, mysqlconnection);
            return mysqlcommand.ExecuteReader();
        }

        public void PC()
        {
            pcs.Clear();
            MySqlDataReader itemquery = Connection("SELECT * FROM PC.pc_table");
            while (itemquery.Read())
            {
                pcs.Add(new Classes.PC(
                    itemquery.GetInt32(0),
                    itemquery.GetDateTime(1),
                    itemquery.GetString(2),
                    itemquery.GetString(3),
                    itemquery.GetString(4),
                    itemquery.GetString(5)
                    ));
            }
            itemquery.Close();
        }
    }
}
