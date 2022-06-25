using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class For_message
    {
        static For_message for_msg;

        string email_msg;
        Model.Clients cli;

        int client_id;
        int user_id;
        Model.Games selectedgame;

        private For_message()
        {

        }

        public int User_id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
            }
        }

        public int Client_id
        {
            get
            {
                return client_id;
            }
            set
            {
                client_id = value;
            }
        }

        public Model.Games Selectedgame
        {
            get
            {
                return selectedgame;
            }
            set
            {
                selectedgame = value;
            }
        }

        public string Email_MSG
        {
            get
            {
                return email_msg;
            }
            set
            {
                email_msg = value;
            }
        }

        public Model.Clients Cli
        {
            get
            {
                return cli;
            }
            set
            {
                cli = value;
            }
        }

        public static For_message I()
        {
            if (for_msg == null)
            {
                for_msg = new For_message();
            }
            return for_msg;
        }
    }
}
