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
    class Client_game_library_proms : INotifyPropertyChanged
    {
        private int id_client;

        public int Id_client
        {
            get { return id_client; }
            set
            {
                id_client = value;
                OnPropertyChanged("Id_client");
            }
        }

        private int id_game;

        public int Id_game
        {
            get { return id_game; }
            set
            {
                id_game = value;
                OnPropertyChanged("Id_game");
            }
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int id;

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
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
