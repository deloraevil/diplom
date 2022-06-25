using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    class Email_code_view_model: INotifyPropertyChanged
    {

        //All_user_View_Model all_User_View_Model = new All_user_View_Model();
        Email_code em = new Email_code();

        public string Email_code_gg
        {
            get
            {
                return em.email_code_gg;
            }
            set
            {
                em.email_code_gg = value;
                OnPropertyChanged("Email_code_gg");
            }
        }

        private RelayCommand ggwp_code;
        public RelayCommand Ggwp_code
        {
            get
            {
                return ggwp_code ??
                  (ggwp_code = new RelayCommand(obj =>
                  {
                      if (For_message.I().Email_MSG == Email_code_gg)
                      {
                          using (Context.All_user_context db = new Context.All_user_context())
                          {
                              var new_client = new Model.Clients
                              {
                                  Name = For_message.I().Cli.Name,
                                  Surname = For_message.I().Cli.Surname,
                                  Email = For_message.I().Cli.Email,
                                  Phone = For_message.I().Cli.Phone,
                                  Id_all_user = For_message.I().Cli.Id_all_user
                              };
                              
                              db.Clients_dbcontext.Add(new_client);
                              db.SaveChanges();
                          }
                          View.Window_user_menu qwe = new View.Window_user_menu();
                          qwe.Show();
                      }
                      else
                      {
                          MessageBox.Show("Wrong code");
                          Environment.Exit(0);
                      }
                  }));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
