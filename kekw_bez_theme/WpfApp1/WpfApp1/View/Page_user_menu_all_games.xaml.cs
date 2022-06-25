using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Page_user_menu_all_games.xaml
    /// </summary>
    public partial class Page_user_menu_all_games : Page
    {
        public Page_user_menu_all_games()
        {
            InitializeComponent();

            //DataContext = new ViewModel.See_games_viewmodel();
            List<Model.Games> gg;
            using (Context.All_user_context db = new Context.All_user_context())
            {
                db.games_dbcontext.Load();
                gg = db.games_dbcontext.ToList();

            }
            list_porosad.ItemsSource = gg;
        }

        private void list_porosad_Selected(object sender, RoutedEventArgs e)
        {
            var a = sender as ListBox;
            if (a.SelectedItem == null)
            {
                return;
            }
            var game = a.SelectedItem as Model.Games;
            Selected_item_to_pay selected_Item_To_Pay = new Selected_item_to_pay(game);
            selected_Item_To_Pay.Show();
        }
    }
}
