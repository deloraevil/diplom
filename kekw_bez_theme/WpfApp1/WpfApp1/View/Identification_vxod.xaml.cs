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
    /// Логика взаимодействия для Identification_vxod.xaml
    /// </summary>
    public partial class Identification_vxod : Page
    {
        public Identification_vxod()
        {
            InitializeComponent();
            DataContext = new ViewModel.All_user_View_Model();
            
        }

        private void button_reg_GotMouseCapture(object sender, MouseEventArgs e)
        {
            button_reg.Foreground = Brushes.Red;
        }

        private void button_reg_LostMouseCapture(object sender, MouseEventArgs e)
        {
            button_reg.Foreground = Brushes.Blue;
        }

        private void button_reg_Click(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate(Navigation_me.I().Registration);
        }
    }
}
