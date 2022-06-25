using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.ViewModel
{
    class Add_comand_all_users : INotifyPropertyChanged
    {
        Context.All_user_context db = new Context.All_user_context();

        private string login;

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

        private string password;

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

        private int id_role;

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

        private string status;

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
                            PasswordBox passwordField = obj as PasswordBox;


                            SqlParameter login_aa = new SqlParameter();
                            login_aa.ParameterName = "@login";
                            login_aa.SqlDbType = System.Data.SqlDbType.NVarChar;
                            login_aa.Value = this.Login;
                            login_aa.Size = 50;
                            login_aa.Direction = System.Data.ParameterDirection.Input;



                            SqlParameter password_aa = new SqlParameter();
                            password_aa.ParameterName = "@password";
                            password_aa.SqlDbType = System.Data.SqlDbType.NVarChar;
                            password_aa.Value = passwordField.Password;
                            password_aa.Size = 50;
                            password_aa.Direction = System.Data.ParameterDirection.Input;

                            SqlParameter id_role_aa = new SqlParameter();
                            id_role_aa.ParameterName = "@id_role";
                            id_role_aa.SqlDbType = System.Data.SqlDbType.NVarChar;
                            id_role_aa.Value = this.Id_role;
                            id_role_aa.Size = 50;
                            id_role_aa.Direction = System.Data.ParameterDirection.Input;

                            SqlParameter result = new SqlParameter();
                            result.ParameterName = "@result";
                            result.SqlDbType = System.Data.SqlDbType.NVarChar;
                            result.Size = 250;
                            result.Direction = System.Data.ParameterDirection.Output;

                            SqlParameter status_aa = new SqlParameter();
                            status_aa.ParameterName = "@status";
                            status_aa.SqlDbType = System.Data.SqlDbType.NVarChar;
                            status_aa.Value = this.Status;
                            status_aa.Size = 3;
                            status_aa.Direction = System.Data.ParameterDirection.Input;


                            db.Database.ExecuteSqlCommand($"exec adduser_ggwp @login, @password, @id_role, @status, @result OUTPUT",
                              login_aa, password_aa, id_role_aa, status_aa, result);
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
