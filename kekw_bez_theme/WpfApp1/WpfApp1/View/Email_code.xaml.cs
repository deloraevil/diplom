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
    /// Логика взаимодействия для Email_code.xaml
    /// </summary>
    public partial class Email_code : Page
    {
        public Email_code()
        {
            InitializeComponent();
            DataContext = new ViewModel.Email_code_view_model();
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
