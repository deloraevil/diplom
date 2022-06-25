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
    /// Логика взаимодействия для Field_add_clients.xaml
    /// </summary>
    public partial class Field_add_clients : Window
    {
        public Field_add_clients()
        {
            InitializeComponent();

            DataContext = new ViewModel.Add_comand_clients();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Prev_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
