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
using WpfApp1.Model;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Selected_item_to_pay.xaml
    /// </summary>
    public partial class Selected_item_to_pay : Window
    {
        private Model.Games games;

        public Selected_item_to_pay()
        {
            InitializeComponent();
        }

        public Selected_item_to_pay(Model.Games a)
        {
            InitializeComponent();
            this.Games = a;
            For_message.I().Selectedgame = a;
            DataContext = games;
        }

        public Games Games { get => games; set => games = value; }

        private void button_pay_Click(object sender, RoutedEventArgs e)
        {
            Qiwi_oplata qiwi_Oplata = new Qiwi_oplata();
            qiwi_Oplata.Show();
        }
    }
}
