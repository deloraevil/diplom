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
using System.IO;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Page_user_menu_my_games.xaml
    /// </summary>
    public partial class Page_user_menu_my_games : Page
    {

        string path;
        public Page_user_menu_my_games()
        {
            InitializeComponent();

            List<Model.Games> gg;
            using (Context.All_user_context db = new Context.All_user_context())
            {
                db.games_dbcontext.Load();
                db.client_Game_Library_Proms_context.Load();
                //db.Clients_dbcontext.Load();
                gg = db.games_dbcontext.ToList();

                int a = For_message.I().Client_id;

                var cli_lib = (from ww in db.client_Game_Library_Proms_context
                               where ww.Id_client == a
                               select ww.Id_game);

                List<int> games_list_id = new List<int>();
                List<Model.Games> games_list = new List<Model.Games>();
                games_list_id = cli_lib.ToList();

                foreach (var item in games_list_id)
                {
                    var lib = (from qq in db.games_dbcontext
                               where qq.Id_game == item
                               select qq).FirstOrDefault();
                    games_list.Add(lib);
                }

                gg = games_list;
                //gg = lib.ToList();

            }
            list_porosad.ItemsSource = gg;
        }

        private void list_porosad_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = sender as ListBox;
            if (a.SelectedItem == null)
            {
                return;
            }
            var game = a.SelectedItem as Model.Games;

            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                path = openFileDlg.SelectedPath;
                string select_path;
                string select_name;

                using (Context.All_user_context db = new Context.All_user_context())
                {
                    select_path = (from ww in db.games_dbcontext
                                       where ww.Id_game == game.Id_game
                                       select ww.Game_file_path).FirstOrDefault();

                    select_name = (from ww in db.games_dbcontext
                                   where ww.Id_game == game.Id_game
                                   select ww.Name).FirstOrDefault();
                }

                File.Copy(select_path, path + "\\" + select_name + "_downloaded.rar");
                
                MessageBox.Show("files have been downloaded");
            }

            /*Selected_item_to_pay selected_Item_To_Pay = new Selected_item_to_pay(game);
            selected_Item_To_Pay.Show();*/
        }
    }
}
