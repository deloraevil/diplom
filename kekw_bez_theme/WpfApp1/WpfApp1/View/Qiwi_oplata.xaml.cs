using Qiwi.BillPayments.Client;
using Qiwi.BillPayments.Model;
using Qiwi.BillPayments.Model.In;
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
using System.Windows.Threading;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Qiwi_oplata.xaml
    /// </summary>
    public partial class Qiwi_oplata : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public Qiwi_oplata()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            using (Context.All_user_context db = new Context.All_user_context())
            {
                if (qwe.Address == "https://github.com/QIWI-API/bill-payments-dotnet-sdk")
                {
                    var lib = new Model.Client_game_library_proms
                    {
                        Id_client = For_message.I().Client_id,
                        Id_game = For_message.I().Selectedgame.Id_game
                    };

                    db.client_Game_Library_Proms_context.Add(lib);
                    db.SaveChanges();
                    timer.Stop();   
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (Context.All_user_context db = new Context.All_user_context())
            {
                var secretKey = (from ww in db.qiwi_me_dbcontext
                                 where ww.Id_key == 4
                                 select ww.Secret_key).FirstOrDefault();

                var publicKey = (from aa in db.qiwi_me_dbcontext
                                 where aa.Id_key == 4
                                 select aa.Public_key).FirstOrDefault();

                decimal chena = For_message.I().Selectedgame.Price;

                var price = (from qwe in db.games_dbcontext
                             where qwe.Price == chena
                             select qwe.Price).FirstOrDefault();

                var client = BillPaymentsClientFactory.Create(secretKey);

                var gg = client.CreatePaymentForm(
                    paymentInfo: new PaymentInfo
                    {
                        PublicKey = publicKey,
                        Amount = new MoneyAmount
                        {
                            ValueDecimal = price,
                            CurrencyEnum = CurrencyEnum.Rub
                        },
                        BillId = Guid.NewGuid().ToString(),
                        SuccessUrl = new Uri("https://github.com/QIWI-API/bill-payments-dotnet-sdk")
                    }
                ); ;

                qwe.Address = gg.ToString();

                /*var lib = new Model.Client_game_library_proms
                {
                    Id_client = For_message.I().Client_id,
                    Id_game = For_message.I().Selectedgame.Id_game
                };

                db.client_Game_Library_Proms_context.Add(lib);
                db.SaveChanges();*/
            }
        }
    }
}
