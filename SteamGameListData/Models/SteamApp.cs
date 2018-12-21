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

        public static SteamApp CreateSteamApp(int appId, string name)
        {
            SteamApp newApp = new SteamApp()
            {
                AppId = appId,
                Name = name
            };

            AppContext context = new AppContext();
            context.SteamApps.Add(newApp);
            context.SaveChanges();

            return newApp;
        }

        public static void UpdateSteamAppReleaseDate(int steamAppId, DateTime releaseDate)
        {
            AppContext context = new AppContext();

            SteamApp app = context.SteamApps.Where(x => x.SteamAppId == steamAppId).FirstOrDefault();

            if(app != null)
            {
                app.ReleaseDate = releaseDate;
            }

            context.SaveChanges();
        }

        public static List<SteamApp> GetAllSteamApps()
        {
            AppContext context = new AppContext();

            return context.SteamApps.ToList();
        }
    }
}
