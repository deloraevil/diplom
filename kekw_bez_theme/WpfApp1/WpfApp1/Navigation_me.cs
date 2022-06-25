using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.View;

namespace WpfApp1
{
    class Navigation_me
    {
        static Navigation_me nav;

        Page identification_vxod;
        Page registration;
        Page email_code_aa;
        Page admin;
        Page search;
        Page user_menu;
        Page all_games;
        Page my_games;

        private Navigation_me()
        {
            
        }

        public Page All_games
        {
            get
            {
                if (all_games == null)
                {
                    all_games = new Page_user_menu_all_games();
                }
                return all_games;
            }
        }

        public Page My_games
        {
            get
            {
                if (my_games == null)
                {
                    my_games = new Page_user_menu_my_games();
                }
                return my_games;
            }
        }

        public Page Search
        {
            get
            {
                if (search == null)
                {
                    search = new Search();
                }
                return search;
            }
        }

        public Page User_menu
        {
            get
            {
                if (user_menu == null)
                {
                    user_menu = new Page_user_menu_all_games();
                }
                return user_menu;
            }
        }

        public Page Identification_vxod
        {
            get
            {
                if (identification_vxod == null)
                {
                    identification_vxod = new Identification_vxod();
                }
                return identification_vxod;
            }
        }

        public Page Registration
        {
            get
            {
                if (registration == null)
                {
                    registration = new Registration();
                }
                return registration;
            }
        }

        public Page Email_code
        {
            get
            {
                if (email_code_aa == null)
                {
                    email_code_aa = new Email_code();
                }
                return email_code_aa;
            }
        }

        public Page Admin
        {
            get
            {
                if (admin == null)
                {
                    admin = new Admin();
                }
                return admin;
            }
        }

        public string msg_me { get; set; }

        public void Navigate(Page page)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Main_qwe.Navigate(page);
                //main.Main_qwe.Content = page;
            }
        }

        public void Navigate_user(Page page)
        {
            Window_user_menu main = Application.Current.Windows.OfType<Window_user_menu>().FirstOrDefault();
            if (main != null)
            {
                main.Main_user_qwe.Navigate(page);
                //main.Main_qwe.Content = page;
            }
        }

        public static Navigation_me I()
        {
            if (nav == null)
            {
                nav = new Navigation_me();
            }
            return nav;
        }
    }
}
