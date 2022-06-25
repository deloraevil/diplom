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
    class System_info_qiwi : INotifyPropertyChanged
    {
        private string secret_key;
        private string public_key;
        private int id_key;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_key
        {
            get
            {
                return id_key;
            }
            set
            {
                id_key = value;
                OnPropertyChanged("Id_key");
            }
        }

        public string Secret_key
        {
            get
            {
                return secret_key;
            }
            set
            {
                secret_key = value;
                OnPropertyChanged("Secret_key");
            }
        }

        public string Public_key
        {
            get
            {
                return public_key;
            }
            set
            {
                public_key = value;
                OnPropertyChanged("Public_key");
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
