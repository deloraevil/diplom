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
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
            DataContext = new ViewModel.All_user_View_Model();
        }

        private void asd_Click(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate(Navigation_me.I().Identification_vxod);

            /*MainW
            Window main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Main_qwe.NavigationService.Navigate(new View.Identification_vxod());
            }*/
            //this.NavigationService.Navigate(new View.Identification_vxod());
        }

        private void button_registration_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void lsadlas_Click_1(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate(Navigation_me.I().Email_code);
        }
    }
}
