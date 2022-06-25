using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Clients : INotifyPropertyChanged
    {
        private int id_client;
        private string name;
        private string surname;
        private string email;
        private string phone;
        private int id_all_user;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_client
        {
            get
            {
                return id_client;
            }
            set
            {
                id_client = value;
                OnPropertyChanged("Id_client");
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
