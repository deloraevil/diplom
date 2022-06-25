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
using System.Windows.Shapes;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Window_user_menu.xaml
    /// </summary>
    public partial class Window_user_menu : Window
    {
        public Window_user_menu()
        {
            InitializeComponent();
            Navigation_me.I().Navigate_user(Navigation_me.I().User_menu);
        }

        private void button_all_games_Click(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate_user(Navigation_me.I().All_games);
        }

        private void button_my_games_Click(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate_user(Navigation_me.I().My_games);
        }
    }
}
