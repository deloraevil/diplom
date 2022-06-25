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
    class Admin_pannel_View_Model : INotifyPropertyChanged
    {
        private RelayCommand search_open;
        public RelayCommand Search_open
        {
            get
            {
                return search_open ??
                    (search_open = new RelayCommand(obj =>
                    {
                        Navigation_me.I().Navigate(Navigation_me.I().Search);
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
