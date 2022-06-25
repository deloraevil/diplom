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
    class Add_comand_games : INotifyPropertyChanged
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

        private int img_game;

        public int Img_game
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
                            var new_games = new Model.Games
                            {
                                Name = this.Name,
                                Age = this.Age,
                                Date = this.Date,
                                Price = this.Price,
                                Id_game_genre = this.Id_game_genre
                            };

                            db.games_dbcontext.Add(new_games);
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
