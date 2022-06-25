using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class All_user_View_Model
    {
        //public ObservableCollection<Model.All_user> all_Users { get; set; }

        public string login_gg { get; set; }

        private RelayCommand vxod;
        public RelayCommand Vxod
        {
            get
            {
                return vxod ??
                    (vxod = new RelayCommand(obj =>
                    {


                        using(Context.All_user_context db = new Context.All_user_context())
                        {
                            

                            PasswordBox passwordField = obj as PasswordBox;

                            if (this.login_gg == null || passwordField.Password == null)
                            {
                                MessageBox.Show("Не все поля заполнены");
                            }
                            else
                            {
                                SqlParameter login = new SqlParameter();
                                login.ParameterName = "@login";
                                login.SqlDbType = System.Data.SqlDbType.NVarChar;
                                login.Value = this.login_gg;
                                login.Size = 50;
                                login.Direction = System.Data.ParameterDirection.Input;

                                //PasswordBox passwordField = obj as PasswordBox;

                                SqlParameter password = new SqlParameter();
                                password.ParameterName = "@password";
                                password.SqlDbType = System.Data.SqlDbType.NVarChar;
                                password.Value = passwordField.Password;
                                password.Size = 50;
                                password.Direction = System.Data.ParameterDirection.Input;

                                SqlParameter result = new SqlParameter();
                                result.ParameterName = "@result";
                                result.SqlDbType = System.Data.SqlDbType.NVarChar;
                                result.Size = 250;
                                result.Direction = System.Data.ParameterDirection.Output;

                                SqlParameter role = new SqlParameter();
                                role.ParameterName = "@role";
                                role.SqlDbType = System.Data.SqlDbType.Int;
                                //result.Size = 250;
                                role.Direction = System.Data.ParameterDirection.Output;

                                SqlParameter id_user = new SqlParameter();
                                id_user.ParameterName = "@id_user";
                                id_user.SqlDbType = System.Data.SqlDbType.Int;
                                //result.Size = 250;
                                id_user.Direction = System.Data.ParameterDirection.Output;
                                //kekw porobless
                                //int id_user = -1;

                                db.Database.ExecuteSqlCommand("exec VerificationUser @login, @password, @result OUTPUT, @role OUTPUT, @id_user OUTPUT",
                                  login, password, result, role, id_user);

                                if (result.Value.ToString() == "User successfully logged in")
                                {
                                    int porosad = Convert.ToInt32(id_user.Value);

                                    For_message.I().User_id = Convert.ToInt32(id_user.Value);
                                    For_message.I().Client_id = (from qwe in db.Clients_dbcontext
                                              where qwe.Id_all_user == porosad
                                              select qwe.Id_client).FirstOrDefault();

                                    switch (role.Value.ToString())
                                    {
                                        case "1":
                                            Navigation_me.I().Navigate(Navigation_me.I().Admin);
                                            break;
                                        case "2":
                                            View.Window_user_menu qwe = new View.Window_user_menu();
                                            
                                            qwe.Show();

                                            
                                            //Navigation_me.I().Navigate(Navigation_me.I().Admin);
                                            break;
                                        default:
                                            break;
                                    }
                                    /*var user_status = (from gg in db.all_Users_dbcontext
                                                   where gg.Login == login.Value.ToString() && gg.Password == password.Value.ToString()
                                                   select gg.Status).FirstOrDefault();

                                    if (user_status == "ok")
                                    {
                                        MessageBox.Show("User successfully logged in");
                                    }
                                    else
                                    {
                                        MessageBox.Show("You are banned");
                                    }*/
                                }
                                else
                                {
                                    MessageBox.Show(result.Value.ToString());
                                }
                            }
                        }
                    }));
            }
        }

        public string name_gg { get; set; }
        public string surname_gg { get; set; }
        public string email_gg { get; set; }
        public string phone_gg { get; set; }


        public string email_cd { get; set; }

        

        public Email_code qwe { get; set; }

        private RelayCommand registration;
        public RelayCommand Registration
        {
            get
            {
                return registration ??
                    (registration = new RelayCommand(obj =>
                    {
                        using (Context.All_user_context db = new Context.All_user_context())
                        {
                            PasswordBox passwordField = obj as PasswordBox;
                            if (this.login_gg == null || passwordField.Password == null || this.name_gg == null || this.surname_gg == null
                                                                            || this.email_gg == null || this.phone_gg == null)
                            {
                                MessageBox.Show("Не все поля заполнены");
                            }
                            else
                            {
                                SqlParameter login = new SqlParameter();
                                login.ParameterName = "@login";
                                login.SqlDbType = System.Data.SqlDbType.NVarChar;
                                login.Value = this.login_gg;
                                login.Size = 50;
                                login.Direction = System.Data.ParameterDirection.Input;



                                SqlParameter password = new SqlParameter();
                                password.ParameterName = "@password";
                                password.SqlDbType = System.Data.SqlDbType.NVarChar;
                                password.Value = passwordField.Password;
                                password.Size = 50;
                                password.Direction = System.Data.ParameterDirection.Input;

                                SqlParameter result = new SqlParameter();
                                result.ParameterName = "@result";
                                result.SqlDbType = System.Data.SqlDbType.NVarChar;
                                result.Size = 250;
                                result.Direction = System.Data.ParameterDirection.Output;


                                db.Database.ExecuteSqlCommand($"exec AddUser_to_all_users @login, @password, @result OUTPUT",
                                  login, password, result);



                                if (result.Value.ToString() == "Success")
                                {


                                    //read
                                    var id_user = (from gg in db.all_Users_dbcontext
                                                   orderby gg.Id_all_user descending
                                                   select gg).FirstOrDefault();

                                    int wpwp = id_user.Id_all_user;
                                    MessageBox.Show(this.phone_gg);

                                    var new_client = new Model.Clients
                                    {
                                        Name = this.name_gg,
                                        Surname = this.surname_gg,
                                        Email = this.email_gg,
                                        Phone = this.phone_gg,
                                        Id_all_user = wpwp
                                    };

                                    //db.Clients_dbcontext.Add(new_client);
                                    //db.SaveChanges();


                                    // отправитель - устанавливаем адрес и отображаемое в письме имя
                                    MailAddress from = new MailAddress("dima.odintsov.2002@mail.ru", "Dima");
                                    // кому отправляем
                                    MailAddress to = new MailAddress(new_client.Email);
                                    // создаем объект сообщения
                                    MailMessage m = new MailMessage(from, to);
                                    // тема письма
                                    m.Subject = "Код подтверждения";
                                    // текст письма

                                    Random random = new Random();
                                    List<char> a = new List<char>();
                                    for (int i = 0; i < 17; i++)
                                    {
                                        a.Add((char)random.Next(0x0410, 0x44F));
                                        email_cd += a[i];
                                    }
                                    //email_cd = "12345";
                                    For_message.I().Email_MSG = this.email_cd;
                                    //For_message.I().Cli = new_client;
                                    m.Body = $"<h4>{email_cd}</h4>";
                                    // письмо представляет код html
                                    m.IsBodyHtml = true;
                                    // адрес smtp-сервера и порт, с которого будем отправлять письмо
                                    SmtpClient smtp = new SmtpClient("smtp.mail.ru", 25);
                                    // логин и пароль
                                    smtp.Credentials = new NetworkCredential("dima.odintsov.2002@mail.ru", "rcA8vsrCbte0WY8cjsyr");
                                    smtp.EnableSsl = true;
                                    smtp.Send(m);

                                    MessageBox.Show("opk");

                                    Navigation_me.I().Navigate(Navigation_me.I().Email_code);
                                }
                                else
                                {
                                    MessageBox.Show(result.Value.ToString());
                                    //Navigation_me.I().Navigate(Navigation_me.I().Email_code_aa);
                                }
                            }
                        }
                    }));
            }
        }

        /*private RelayCommand email_accept;
        public RelayCommand Email_accept
        {
            get
            {
                return email_accept ??
                    (email_accept = new RelayCommand(obj =>
                    {
                        if (email_cd == qwe.Email_code_gg)
                        {
                            MessageBox.Show("Ok");
                        }
                        else
                        {
                            MessageBox.Show("gg wp");
                        }
                    }));
            }
        }*/

        private RelayCommand email_open;
        public RelayCommand Email_open
        {
            get
            {
                return email_open ??
                    (email_open = new RelayCommand(obj =>
                    {
                        Navigation_me.I().Navigate(Navigation_me.I().Email_code);
                    }));
            }
        }
    }
}
