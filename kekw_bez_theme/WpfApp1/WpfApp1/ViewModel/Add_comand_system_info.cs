using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.ViewModel
{
    class Add_comand_system_info : INotifyPropertyChanged
    {
        Context.All_user_context db = new Context.All_user_context();

        private string email;

        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }


        private RelayCommand add_changes;
        public RelayCommand Add_changes
        {
            get
            {
                return add_changes ??
                    (add_changes = new RelayCommand(obj =>
                    {
                        try
                        {
                            var new_system_info = new Model.System_info
                            {
                                Email = this.Email
                            };
                            db.system_info_dbcontext.Add(new_system_info);
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
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
