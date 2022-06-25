using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для Window_to_search_banned_users.xaml
    /// </summary>
    public partial class Window_to_search_banned_users : Window
    {
        private Context.All_user_context db = new Context.All_user_context();

        private ObservableCollection<Model.All_users> collection = new ObservableCollection<Model.All_users>();

        public Window_to_search_banned_users()
        {
            InitializeComponent();
            collection.Clear();

            var user = (from gg in db.all_Users_dbcontext
                        where gg.Status == "ban"
                        select gg);

            foreach (var item in user)
            {
                collection.Add(item);
            }
            datagrid_all.ItemsSource = collection;
        }
    }
}
