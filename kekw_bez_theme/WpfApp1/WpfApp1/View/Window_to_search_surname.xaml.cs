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
    /// Логика взаимодействия для Window_to_search_surname.xaml
    /// </summary>
    public partial class Window_to_search_surname : Window
    {
        private Context.All_user_context db = new Context.All_user_context();

        private ObservableCollection<Model.Clients> collection = new ObservableCollection<Model.Clients>();

        public Window_to_search_surname()
        {
            InitializeComponent();
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            collection.Clear();
            var user = (from gg in db.Clients_dbcontext
                        where gg.Surname == textbox_search.Text
                        select gg).FirstOrDefault();
            collection.Add(user);
            datagrid_all.ItemsSource = collection;
        }
    }
}
