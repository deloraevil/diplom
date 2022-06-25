using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Qiwi.BillPayments.Client;
using Qiwi.BillPayments.Model;
using Qiwi.BillPayments.Model.In;

namespace WpfApp1.Model
{
    public class Qiwi_me : INotifyPropertyChanged
    {
        private Qiwi.BillPayments.Model.Out.BillResponse gg;

        public Qiwi.BillPayments.Model.Out.BillResponse Gg
        {
            get { return gg; }
            set
            {
                gg = value;
                OnPropertyChanged("Gg");
            }
        }

        private string gg_for_text;

        public string Gg_for_text
        {
            get { return gg_for_text; }
            set
            {
                gg_for_text = value;
                OnPropertyChanged("Gg_for_text");
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
