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
    public class Games : INotifyPropertyChanged
    {
        private int id_game;

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_game
        {
            get
            {
                return id_game;
            }
            set
            {
                id_game = value;
                OnPropertyChanged("Id_game");
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

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
                OnPropertyChanged("Age");
            }
        }

        private DateTime date;

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        private decimal price;

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                OnPropertyChanged("Price");
            }
        }

        private int id_game_genre;

        public int Id_game_genre
        {
            get
            {
                return id_game_genre;
            }
            set
            {
                id_game_genre = value;
                OnPropertyChanged("Id_game_genre");
            }
        }

        private string img_game;

        public string Img_game
        {
            get
            {
                return img_game;
            }
            set
            {
                img_game = value;
                OnPropertyChanged("Img_game");
            }
        }

        private string game_file_path;
        public string Game_file_path
        {
            get
            {
                return game_file_path;
            }
            set
            {
                game_file_path = value;
                OnPropertyChanged("Game_file_path");
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
