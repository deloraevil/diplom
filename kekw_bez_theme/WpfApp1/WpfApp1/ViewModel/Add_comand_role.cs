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
    class Add_comand_role : INotifyPropertyChanged
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
                            var new_role = new Model.Roles
                            {
                                Name = this.Name
                            };

                            db.roles_dbcontext.Add(new_role);
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
