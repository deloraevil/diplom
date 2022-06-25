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
    class Add_comand_clients : INotifyPropertyChanged
    {
        Context.All_user_context db = new Context.All_user_context();

        private string name;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }

        private string surname;

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                surname = value;
                OnPropertyChanged("Surname");
            }
        }

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

        private string phone;

        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private int id_all_user;

        public int Id_all_user
        {
            get
            {
                return id_all_user;
            }
            set
            {
                id_all_user = value;
                OnPropertyChanged("Id_all_user");
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
                            var new_client = new Model.Clients
                            {
                                Name = this.Name,
                                Surname = this.Surname,
                                Email = this.Email,
                                Phone = this.Phone,
                                Id_all_user = this.Id_all_user
                            };

                            db.Clients_dbcontext.Add(new_client);
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
