using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace WpfApp1.View
{
    /// <summary>
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {

        private Context.All_user_context db = new Context.All_user_context();
        public Admin()
        {
            InitializeComponent();
            
        }

        private void datagrid_all_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (combo_box_table_name.Text)
            {
                case "System_info":
                    db.system_info_dbcontext.Load();
                    datagrid_all.ItemsSource = db.system_info_dbcontext.ToList();
                    break;
                case "Roles":
                    db.roles_dbcontext.Load();
                    datagrid_all.ItemsSource = db.roles_dbcontext.ToList();
                    
                    break;
                case "Games":
                    db.games_dbcontext.Load();
                    datagrid_all.ItemsSource = db.games_dbcontext.ToList();
                    break;
                case "Clients":
                    db.Clients_dbcontext.Load();
                    datagrid_all.ItemsSource = db.Clients_dbcontext.ToList();
                    break;
                case "All_users":
                    db.all_Users_dbcontext.Load();
                    datagrid_all.ItemsSource = db.all_Users_dbcontext.ToList();
                    break;
                case "Admins":
                    db.admins_dbcontext.Load();
                    datagrid_all.ItemsSource = db.admins_dbcontext.ToList();
                    break;
                default:
                    break;
            }
            //this.NavigationService.Refresh();
        }

        private void button_update_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void button_delete_Click(object sender, RoutedEventArgs e)
        {
            switch (combo_box_table_name.Text)
            {
                case "System_info":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.System_info gm = datagrid_all.SelectedItems[i] as Model.System_info;
                            if (gm != null)
                            {
                                db.system_info_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                case "Roles":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.Roles gm = datagrid_all.SelectedItems[i] as Model.Roles;
                            if (gm != null)
                            {
                                db.roles_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                case "Games":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.Games gm = datagrid_all.SelectedItems[i] as Model.Games;
                            if (gm != null)
                            {
                                db.games_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                case "Clients":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.Clients gm = datagrid_all.SelectedItems[i] as Model.Clients;
                            if (gm != null)
                            {
                                db.Clients_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                case "All_users":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.All_users gm = datagrid_all.SelectedItems[i] as Model.All_users;
                            if (gm != null)
                            {
                                db.all_Users_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                case "Admins":
                    if (datagrid_all.SelectedItems.Count > 0)
                    {
                        for (int i = 0; i < datagrid_all.SelectedItems.Count; i++)
                        {
                            Model.Admins gm = datagrid_all.SelectedItems[i] as Model.Admins;
                            if (gm != null)
                            {
                                db.admins_dbcontext.Remove(gm);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            db.SaveChanges();
        }

        private void button_search_Click(object sender, RoutedEventArgs e)
        {
            Navigation_me.I().Navigate(Navigation_me.I().Search);
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            switch (combo_box_table_name.Text)
            {
                case "System_info":
                    View.Field_add_system_info field_Add_System_Info = new Field_add_system_info();
                    field_Add_System_Info.Show();
                    break;
                case "Roles":
                    View.Field_add_role field_Add_Role = new Field_add_role();
                    field_Add_Role.Show();
                    break;
                case "Games":
                    View.Field_add_games field_Add_Games = new Field_add_games();
                    field_Add_Games.Show();
                    break;
                case "Clients":
                    View.Field_add_clients field_Add_Clients = new Field_add_clients();
                    field_Add_Clients.Show();
                    break;
                case "All_users":
                    View.Field_add_all_users field_Add_All_Users = new Field_add_all_users();
                    field_Add_All_Users.Show();
                    break;
                case "Admins":
                    View.Field_add_admin field_Add_Admin = new Field_add_admin();
                    field_Add_Admin.Show();
                    break;
                default:
                    break;
            }
        }
    }
}
