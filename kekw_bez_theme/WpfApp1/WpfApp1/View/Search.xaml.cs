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

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Search.xaml
    /// </summary>
    public partial class Search : Page
    {
        public Search()
        {
            InitializeComponent();
        }

        private void radio_1_Checked(object sender, RoutedEventArgs e)
        {
            View.Window_to_search_surname qwe = new Window_to_search_surname();
            qwe.Show();
        }

        private void radio_2_Checked(object sender, RoutedEventArgs e)
        {
            View.Window_to_search_game_name qwe = new Window_to_search_game_name();
            qwe.Show();
        }

        private void radio_3_Checked(object sender, RoutedEventArgs e)
        {
            View.Window_to_search_banned_users qwe = new Window_to_search_banned_users();
            qwe.Show();
        }
    }
}
