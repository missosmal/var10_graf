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

namespace var10_graf.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public MainWindow mw;

        public Main(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            LoadPC();
        }

        private void LoadPC()
        {
            parent.Children.Clear();
            foreach(Classes.PC item in mw.pcs)
            {
                parent.Children.Add(new Elements.PcItm(mw, item));
            }
        }

        private void Add_Button(object sender, RoutedEventArgs e)
        {
            mw.frame.Navigate(new Pages.Add(mw));
        }

        private void Exit_Button(object sender, RoutedEventArgs e)
        {
            mw.Close();
        }
    }
}
