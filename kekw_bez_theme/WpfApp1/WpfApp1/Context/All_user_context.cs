using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Context
{
    class All_user_context: DbContext
    {
        public All_user_context(): base("conn")
        {

        }

        public DbSet<Model.All_users> all_Users_dbcontext { get; set; }
        public DbSet<Model.Clients> Clients_dbcontext { get; set; }
        public DbSet<Model.System_info> system_info_dbcontext { get; set; }
        public DbSet<Model.Roles> roles_dbcontext { get; set; }
        public DbSet<Model.Games> games_dbcontext { get; set; }
        public DbSet<Model.Admins> admins_dbcontext { get; set; }
        public DbSet<Model.System_info_qiwi> qiwi_me_dbcontext { get; set; }
        public DbSet<Model.Client_game_library_proms> client_Game_Library_Proms_context { get; set; }
    }
}
