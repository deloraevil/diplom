using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp1.ViewModel
{
    class See_games_viewmodel : INotifyPropertyChanged
    {
        private Model.Games selectedGame;

        //public ObservableCollection<Model.Games> games_list { get; set; }

        public Model.Games SelectedGame
        {
            get { return selectedGame; }
            set
            {
                selectedGame = value;
                OnPropertyChanged("SelectedGame");
            }
        }

        public See_games_viewmodel()
        {
            using (Context.All_user_context db = new Context.All_user_context())
            {
                bool count = true;
                foreach (var item in db.games_dbcontext)
                {
                    if (count == true)
                    {
                        Image image = new Image();
                        image.Height = 150;
                        image.Source = BitmapFrame.Create(new Uri(item.Img_game));
                        image.Stretch = Stretch.Uniform;
                        image.Margin = new Thickness(0, 10, 0, 10);
                        
                        //second_stackpanel_for_cards_view.Children.Add(image);
                        
                    }
                }
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
