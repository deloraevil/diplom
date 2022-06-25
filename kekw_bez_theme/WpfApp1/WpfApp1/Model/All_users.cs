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
    public class All_users: INotifyPropertyChanged
    {
        private int id_all_user;
        private string login;
        private string password;
        private int id_role;
        private string status;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
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
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public int Id_role
        {
            get
            {
                return id_role;
            }
            set
            {
                id_role = value;
                OnPropertyChanged("Id_role");
            }
        }
        public string Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
                OnPropertyChanged("Status");
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
