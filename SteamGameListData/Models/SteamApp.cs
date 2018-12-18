using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamGameListData.Models
{
    public class SteamApp
    {
        public int SteamAppId { get; set; }
        public int AppId { get; set; }
        public string Name { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public static int CreateSteamApp(int appId, string name)
        {
            SteamApp newApp = new SteamApp()
            {
                AppId = appId,
                Name = name
            };

            AppContext context = new AppContext();
            context.SteamApps.Add(newApp);
            context.SaveChanges();

            return newApp.SteamAppId;
        }

        public static List<SteamApp> GetAllSteamApps()
        {
            AppContext context = new AppContext();

            return context.SteamApps.ToList();
        }
    }
}
