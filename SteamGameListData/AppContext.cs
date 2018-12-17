using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace SteamGameListData
{
    internal class AppContext : DbContext
    {
        public AppContext()
            : base("SteamGameList")
        {

        }

        public DbSet<Models.SteamApp> SteamApps { get; set; }
    }
}
