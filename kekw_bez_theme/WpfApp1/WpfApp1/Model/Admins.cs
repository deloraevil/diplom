using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp1.Model
{
    class Admins : INotifyPropertyChanged
    {
        private int id_admin;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_admin
        {
            get
            {
                return id_admin;
            }
            set
            {
                id_admin = value;
                OnPropertyChanged("Id_admin");
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
